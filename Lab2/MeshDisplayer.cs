using Lab2.CoordinatesTransformers;
using Lab2.Model;
using Lab2.Renderers;
using Lab2.SceneModel;
using Lab2.Utils;
using Lab2.VertexFileReaders;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;
using System.Timers;

namespace Lab2
{
    public partial class MeshDisplayer : Form
    {
        private int ControlPointsFirstDimensionCount { get; set; } = 4;
        private int ControlPointsSecondDimensionCount { get; set; } = 4;

        private Bitmap Bitmap { get; set; }
        private DirectBitmap DirectBitmap { get; set; }
        private Graphics G { get; set; }
        private System.Timers.Timer Timer { get; } = new(1000 / 30) { AutoReset = true };
        private CenterCoordinateTransformer2D CoordinateTransformer { get; set; }
        private Scene Scene { get; set; }
        private MeshRenderer MeshRenderer { get; set; }

        public MeshDisplayer()
        {
            InitializeComponent();
            BindLabels();

            float kd = scaleTrackBarValueToOne(kdTrackBar);
            float ks = scaleTrackBarValueToOne(ksTrackBar);
            float m = mTrackBar.Value;

            DirectBitmap = new(pictureBox.Width, pictureBox.Height);
            Bitmap = DirectBitmap.Bitmap;
            CoordinateTransformer = new(Bitmap.Width, Bitmap.Height);

            DirectBitmap textureDirectBitmap = LoadDefaultTexture();
            Vector3[,] normalMap = LoadDefaultNormalMap();


            Color meshColor = Color.FromName(Properties.Resources.DefaultMeshColor);
            Color lightColor = Color.FromName(Properties.Resources.DefaultLightColor);
            meshColorPictureBox.BackColor = meshColor;
            lightColorPictureBox.BackColor = lightColor;

            G = Graphics.FromImage(Bitmap);
            SetGraphicsTransformation();

            ReflectionCoefficients reflectionCoefficients = new(ks, kd, m);

            MeshRenderer = new(DirectBitmap, G, CoordinateTransformer, reflectionCoefficients, textureDirectBitmap, normalMap)
            {
                DrawEdges = drawEdgesCheckBox.Checked,
                DrawFilling = drawFillingCheckBox.Checked,
                DrawControlPoitns = drawControlPointsCheckBox.Checked,
                MeshColor = meshColor
            };
            MeshRenderer.GetColor = MeshRenderer.GetMeshRGBColor;
            MeshRenderer.GetNormalVector = MeshRenderer.GetNormalVectorFromVertices;


            Vector3[,] controlPoints = GetControlPointsFromFile(Properties.Resources.DefaultControlPointsPath);
            Vector3 lightPosition = new(0, 0, lightZCoordTrackBar.Value);

            Mesh mesh = new(controlPoints, fidelityTrackBar.Value, fidelityTrackBar.Value, alphaAngleTrackBar.Value, betaAngleTrackBar.Value);
            Scene = new(mesh, new LightSource(lightPosition, lightColor), MeshRenderer);

            Timer.Elapsed += timer_Tick;
        }

        private void SetGraphicsTransformation()
        {
            G.ScaleTransform(1, -1);
            G.TranslateTransform(Bitmap.Width / 2, -Bitmap.Height / 2);
        }

        private Vector3[,] LoadDefaultNormalMap()
        {
            Vector3[,] normalMap;
            using (MemoryStream ms = new(Properties.Resources.DefaultNormalMap))
            {
                Image img = Image.FromStream(ms);
                normalMapPictureBox.Image = img;
                Bitmap normalBmp = (Bitmap)img;
                normalMap = GetNormalMap(normalBmp);
            }

            return normalMap;
        }

        private DirectBitmap LoadDefaultTexture()
        {
            DirectBitmap textureDirectBitmap;
            using (MemoryStream ms = new(Properties.Resources.DefaultTexture))
            {
                Image img = Image.FromStream(ms);
                texturePictureBox.Image = img;
                textureDirectBitmap = new(img.Width, img.Height);
                using Graphics g = Graphics.FromImage(textureDirectBitmap.Bitmap);
                g.DrawImage(img, 0, 0, textureDirectBitmap.Width, textureDirectBitmap.Height);
            }

            return textureDirectBitmap;
        }

        private void BindLabels()
        {
            fideltyValueLabel.DataBindings.Add("Text", fidelityTrackBar, "Value");
            alphaAngleValueLabel.DataBindings.Add("Text", alphaAngleTrackBar, "Value");
            betaAngleValueLabel.DataBindings.Add("Text", betaAngleTrackBar, "Value");

            Binding bind = new("Text", kdTrackBar, "Value");
            bind.Format += bindFormat!;
            kdValueLabel.DataBindings.Add(bind);

            bind = new("Text", ksTrackBar, "Value");
            bind.Format += bindFormat!;
            ksValueLabel.DataBindings.Add(bind);

            mValueLabel.DataBindings.Add("Text", mTrackBar, "Value");
            lightZCoordValueLabel.DataBindings.Add("Text", lightZCoordTrackBar, "Value");
        }

        private void bindFormat(object sender, ConvertEventArgs e)
        {
            Binding binding = (Binding)sender;
            TrackBar trackbar = (TrackBar)binding.DataSource;
            e.Value = scaleTrackBarValueToOne(trackbar).ToString();
        }
        private float scaleTrackBarValueToOne(TrackBar trackbar)
        {
            return (float)trackbar.Value / trackbar.Maximum;
        }

        private Vector3[,] GetControlPointsFromFile(string path)
        {
            TxtControlPointsReader reader = new(ControlPointsFirstDimensionCount, ControlPointsSecondDimensionCount);
            return reader.Read(path);
        }

        private void fidelityTrackBar_Scroll(object sender, EventArgs e)
        {
            fidelityTrackBar.Value = (int)Math.Round((double)fidelityTrackBar.Value / fidelityTrackBar.TickFrequency) * fidelityTrackBar.TickFrequency;
            Scene.Mesh.SetFidelity(fidelityTrackBar.Value, fidelityTrackBar.Value);

            pictureBox.Invalidate();
        }

        private void alphaAngleTrackBar_Scroll(object sender, EventArgs e)
        {
            Scene.Mesh.SetAlphaAngle(alphaAngleTrackBar.Value);

            pictureBox.Invalidate();
        }

        private void betaAngleTrackBar_Scroll(object sender, EventArgs e)
        {
            Scene.Mesh.SetBetaAngle(betaAngleTrackBar.Value);

            pictureBox.Invalidate();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            G.Clear(Color.White);

            Stopwatch sw = new();
            sw.Start();

            Scene.RenderScene();

            e.Graphics.DrawImage(Bitmap, 0, 0);

            sw.Stop();
            float fps = float.PositiveInfinity;
            if (sw.ElapsedMilliseconds > 0)
                fps = 1000 / sw.ElapsedMilliseconds;
            fpsLabel.Text = $"FPS: {fps}";
        }

        private void pictureBox_SizeChanged(object sender, EventArgs e)
        {
            if (pictureBox.Width <= 0 || pictureBox.Height <= 0 || Bitmap is null || (Bitmap.Width == pictureBox.Width && Bitmap.Height == pictureBox.Height))
                return;

            Bitmap oldBitmap = Bitmap;
            Graphics oldGraphics = G;
            DirectBitmap oldDirectBitmap = DirectBitmap;

            DirectBitmap = new(pictureBox.Width, pictureBox.Height);
            Bitmap = DirectBitmap.Bitmap;
            CoordinateTransformer.Width = Bitmap.Width;
            CoordinateTransformer.Height = Bitmap.Height;

            G = Graphics.FromImage(Bitmap);
            G.DrawImage(oldBitmap, 0, 0);

            SetGraphicsTransformation();

            //MeshRenderer.DirectBitmap = DirectBitmap;
            //MeshRenderer.G = G;
            //MeshRenderer.PaintedPixelsZ = new float[DirectBitmap.Width, DirectBitmap.Height];
            MeshRenderer.SetNewBitmap(DirectBitmap, G);

            pictureBox.Invalidate();

            oldDirectBitmap.Dispose();
            oldGraphics.Dispose();
            oldBitmap.Dispose();
        }

        private void kdTrackBar_Scroll(object sender, EventArgs e)
        {
            MeshRenderer.ReflectionCoefficients.Kd = scaleTrackBarValueToOne(kdTrackBar);

            pictureBox.Invalidate();
        }

        private void ksTrackBar_Scroll(object sender, EventArgs e)
        {
            MeshRenderer.ReflectionCoefficients.Ks = scaleTrackBarValueToOne(ksTrackBar);

            pictureBox.Invalidate();
        }

        private void mTrackBar_Scroll(object sender, EventArgs e)
        {
            MeshRenderer.ReflectionCoefficients.M = mTrackBar.Value;

            pictureBox.Invalidate();
        }

        private void lightZAxisTrackBar_Scroll(object sender, EventArgs e)
        {
            lock (Scene.LightSource)
                Scene.LightSource.Position = new(Scene.LightSource.Position.X, Scene.LightSource.Position.Y, lightZCoordTrackBar.Value);

            pictureBox.Invalidate();
        }

        private void lightColorButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Scene.LightSource.Color;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                lock (Scene.LightSource)
                    Scene.LightSource.Color = colorDialog.Color;

                lightColorPictureBox.BackColor = colorDialog.Color;

                pictureBox.Invalidate();
            }
        }

        private void meshColorButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = MeshRenderer.MeshColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                MeshRenderer.MeshColor = colorDialog.Color;
                meshColorPictureBox.BackColor = colorDialog.Color;

                pictureBox.Invalidate();
            }
        }

        private void drawEdgesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MeshRenderer.DrawEdges = drawEdgesCheckBox.Checked;

            pictureBox.Invalidate();
        }

        private void drawFillingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MeshRenderer.DrawFilling = drawFillingCheckBox.Checked;

            pictureBox.Invalidate();
        }

        private void drawControlPointsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MeshRenderer.DrawControlPoitns = drawControlPointsCheckBox.Checked;

            pictureBox.Invalidate();
        }

        private void fixedColorRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            MeshRenderer.GetColor = MeshRenderer.GetMeshRGBColor;

            pictureBox.Invalidate();
        }

        private void textureRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            MeshRenderer.GetColor = MeshRenderer.GetTextureColor;

            pictureBox.Invalidate();
        }

        private void textureButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Path.GetFullPath(Properties.Resources.TextureFolder);
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                Bitmap textureBitmap = new(fileName);
                MeshRenderer.TextureDirectBitmap = new(textureBitmap.Width, textureBitmap.Height);

                using Graphics g = Graphics.FromImage(MeshRenderer.TextureDirectBitmap.Bitmap);
                {
                    g.DrawImage(textureBitmap, 0, 0, MeshRenderer.TextureDirectBitmap.Width, MeshRenderer.TextureDirectBitmap.Height);
                }

                texturePictureBox.Image = Image.FromFile(fileName);

                pictureBox.Invalidate();
            }
        }

        private void normalMapCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (normalMapCheckBox.Checked)
                MeshRenderer.GetNormalVector = MeshRenderer.GetNormalVectorFromNormalMap;
            else
                MeshRenderer.GetNormalVector = MeshRenderer.GetNormalVectorFromVertices;

            pictureBox.Invalidate();
        }

        private void normalMapButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Path.GetFullPath(Properties.Resources.NormalMapFolder);
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                Bitmap bitmap = new(fileName);
                MeshRenderer.NormalMap = GetNormalMap(bitmap);
                normalMapPictureBox.Image = Image.FromFile(fileName);

                pictureBox.Invalidate();
            }
        }

        private Vector3[,] GetNormalMap(Bitmap bitmap)
        {
            Vector3[,] normalMap = new Vector3[bitmap.Width, bitmap.Height];
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                    normalMap[i, j] = new Vector3(color.R, color.G, color.B) / 255 * 2 - new Vector3(1, 1, 1);
                }
            }

            return normalMap;
        }

        private void timer_Tick(object? sender, EventArgs e)
        {
            Scene.MoveLightSource();

            pictureBox.Invalidate();
        }

        private void moveLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (moveLightCheckBox.Checked)
                Timer.Start();
            else
                Timer.Stop();
        }

        private void resetLightPositionButton_Click(object sender, EventArgs e)
        {
            Scene.ResetLightSourcePosition();

            pictureBox.Invalidate();
        }

        private void loadControlPointsButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Path.GetFullPath(Properties.Resources.ControlPointsFolder);
            openFileDialog.Filter = "Text|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Vector3[,] controlPoints = GetControlPointsFromFile(openFileDialog.FileName);
                    Scene.Mesh.SetControlPoints(controlPoints);
                    //Scene.Mesh.ControlPoints = controlPoints;
                    //Scene.Mesh.InterPolateVertices();

                    pictureBox.Invalidate();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Niew³aœciwy format wierzcho³ków", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
