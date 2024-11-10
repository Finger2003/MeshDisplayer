using Lab2.CoordinatesTransformers;
using Lab2.Model;
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
        //private string DefaultControlPointsPath { get; } = "control_points3D.txt";
        //private string DefaultTexturePath { get; } = "texture.jpg";
        //private string DefaultNormalMapPath { get; } = "normal_map.png";
        //private Bitmap TextureBitmap { get; set; }
        //private Bitmap NormalMapBitmap { get; set; }
        //private Vector3[,] NormalMap { get; set; }

        //private Vector3[,] ControlPoints { get; set; }

        private Bitmap Bitmap { get; set; }
        private DirectBitmap DirectBitmap { get; set; }
        //private DirectBitmap TextureDirectBitmap { get; set; }
        //private Mesh? Mesh { get; set; }
        private Graphics G { get; set; }

        //private Color LightColor { get; set; } = Color.White;
        //private Vector3 LightPosition { get; set; }
        //private Vector3 LightPositionForDrawing { get; set; }
        //private float LightZAxisRadius { get; set; } = 0;
        //private float LightZAxisAngle { get; set; } = 0;
        private System.Timers.Timer Timer { get; } = new(1000 / 30) { AutoReset = true };
        //private Mutex LightPositionMutex { get; } = new();

        //private float Kd { get; set; }
        //private float Ks { get; set; }
        //private float M { get; set; }
        //private float LightZCoord { get; set; }

        //private bool DrawEdges { get; set; } = true;
        //private bool DrawFilling { get; set; } = true;

        //private delegate Color GetColorDelegate(float u, float v);
        //private Func<float, float, Color> GetColor { get; set; }
        //private Func<Triangle, float[], float, float, Vector3> GetNormalVector { get; set; }

        //private Color MeshColor { get; set; } = Color.White;

        private CenterCoordinateTransformer2D CoordinateTransformer { get; set; }

        private Scene Scene { get; set; }
        private MeshRenderer MeshRenderer { get; set; }

        public MeshDisplayer()
        {
            InitializeComponent();

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

            float kd = scaleTrackBarValueToOne(kdTrackBar);
            float ks = scaleTrackBarValueToOne(ksTrackBar);
            float m = mTrackBar.Value;
            //LightZCoord = lightZCoordTrackBar.Value;

            DirectBitmap = new(pictureBox.Width, pictureBox.Height);
            Bitmap = DirectBitmap.Bitmap;
            CoordinateTransformer = new(Bitmap.Width, Bitmap.Height);

            DirectBitmap textureDirectBitmap;
            using (MemoryStream ms = new(Properties.Resources.DefaultTexture))
            {
                Image img = Image.FromStream(ms);
                texturePictureBox.Image = img;
                textureDirectBitmap = new(img.Width, img.Height);
                using Graphics g = Graphics.FromImage(textureDirectBitmap.Bitmap);
                g.DrawImage(img, 0, 0, textureDirectBitmap.Width, textureDirectBitmap.Height);
            }
            Vector3[,] normalMap;
            using (MemoryStream ms = new(Properties.Resources.DefaultNormalMap))
            {
                Image img = Image.FromStream(ms);
                normalMapPictureBox.Image = img;
                Bitmap normalBmp = (Bitmap)img;
                normalMap = GetNormalMap(normalBmp);
            }

            Color meshColor = Color.FromName(Properties.Resources.DefaultMeshColor);
            Color lightColor = Color.FromName(Properties.Resources.DefaultLightColor);
            meshColorPictureBox.BackColor = meshColor;
            lightColorPictureBox.BackColor = lightColor;

            G = Graphics.FromImage(Bitmap);
            G.ScaleTransform(1, -1);
            G.TranslateTransform(Bitmap.Width / 2, -Bitmap.Height / 2);


            ICoordinateTransformer2D transformer = new CenterCoordinateTransformer2D(Bitmap.Width, Bitmap.Height);
            ReflectionCoefficients reflectionCoefficients = new(ks, kd, m);

            MeshRenderer = new(DirectBitmap, transformer, reflectionCoefficients, textureDirectBitmap, normalMap);//, meshRenderer.GetMeshRGBColor, MeshRenderer.GetNormalVectorFromVertices);
            MeshRenderer.GetColor = MeshRenderer.GetMeshRGBColor;
            MeshRenderer.GetNormalVector = MeshRenderer.GetNormalVectorFromVertices;
            MeshRenderer.DrawEdges = true;
            MeshRenderer.DrawFilling = true;
            MeshRenderer.MeshColor = meshColor;
            MeshRenderer.G = G;

            Vector3[,] controlPoints = GetControlPointsFromFile(Properties.Resources.DefaultControlPointsPath);


            //GetColor = GetMeshRGBColor;
            //GetNormalVector = GetNormalVectorFromVertices;
            Vector3 lightPosition = new(0, 0, lightZCoordTrackBar.Value);

            Mesh mesh = new(controlPoints, fidelityTrackBar.Value, fidelityTrackBar.Value, alphaAngleTrackBar.Value, betaAngleTrackBar.Value);
            Scene = new(mesh, new LightSource(lightPosition, lightColor), MeshRenderer);

            Timer.Elapsed += timer_Tick;
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
            //if (Mesh is null)
            //    return;

            G.Clear(Color.White);

            Stopwatch sw = new();
            sw.Start();

            //Scene.RenderScene();
            //Bitmap bitmap = Scene.GetRenderedBitmap();
            Scene.RenderScene();

            //if (DrawFilling)
            //{
            //    LightPositionMutex.WaitOne();
            //    LightPositionForDrawing = LightPosition;
            //    LightPositionMutex.ReleaseMutex();

            //    Parallel.ForEach(Mesh.Triangles, fillTriangle);
            //}

            //if (DrawEdges)
            //{
            //    foreach (Triangle triangle in Mesh.Triangles)
            //    {
            //        PointF v1 = new(triangle.V1.AfterRotationState.P.X, triangle.V1.AfterRotationState.P.Y);
            //        PointF v2 = new(triangle.V2.AfterRotationState.P.X, triangle.V2.AfterRotationState.P.Y);
            //        PointF v3 = new(triangle.V3.AfterRotationState.P.X, triangle.V3.AfterRotationState.P.Y);

            //        G.DrawLine(Pens.Black, v1, v2);
            //        G.DrawLine(Pens.Black, v2, v3);
            //        G.DrawLine(Pens.Black, v3, v1);
            //    }
            //}

            e.Graphics.DrawImage(Bitmap, 0, 0);

            sw.Stop();
            float fps = float.PositiveInfinity;
            if (sw.ElapsedMilliseconds > 0)
                fps = 1000 / sw.ElapsedMilliseconds;
            fpsLabel.Text = $"FPS: {fps}";
        }

        //private void fillTriangle(Triangle triangle)
        //{

        //    Point[] trianglePoints =
        //    [
        //        new Point((int)Math.Round(triangle.V1.AfterRotationState.P.X), (int)Math.Round(triangle.V1.AfterRotationState.P.Y)),
        //        new Point((int)Math.Round(triangle.V2.AfterRotationState.P.X), (int)Math.Round(triangle.V2.AfterRotationState.P.Y)),
        //        new Point((int)Math.Round(triangle.V3.AfterRotationState.P.X), (int)Math.Round(triangle.V3.AfterRotationState.P.Y))
        //    ];

        //    int[] sortedIndexes = Enumerable.Range(0, trianglePoints.Length).ToArray();
        //    Array.Sort(sortedIndexes, (i1, i2) => trianglePoints[i1].Y.CompareTo(trianglePoints[i2].Y));


        //    int polygonYMin = trianglePoints[sortedIndexes[0]].Y; //trianglePoints.Min(p => p.Y);
        //    int polygonYMax = trianglePoints[sortedIndexes[^1]].Y; //trianglePoints.Max(p => p.Y);
        //    int sortedIndex = 0;

        //    List<AETElement> AET = [];

        //    for (int scanline = polygonYMin; scanline <= polygonYMax; scanline++)
        //    {
        //        AET.RemoveAll(edge => edge.P1.Y == edge.P2.Y);

        //        int index = sortedIndexes[sortedIndex];
        //        Point point = trianglePoints[index];


        //        // Je�li punkt by� na scanline zaktualizuj AET o kraw�dzie, kt�re go zawieraj�
        //        while (point.Y == scanline - 1)
        //        {
        //            int previousIndex = index == 0 ? trianglePoints.Length - 1 : index - 1;
        //            int nextIndex = index == trianglePoints.Length - 1 ? 0 : index + 1;

        //            Point previousPoint = trianglePoints[previousIndex];
        //            Point nextPoint = trianglePoints[nextIndex];

        //            checkAndUpdateAET(previousPoint, point);
        //            checkAndUpdateAET(nextPoint, point);

        //            index = sortedIndexes[++sortedIndex];
        //            point = trianglePoints[index];
        //        }

        //        void checkAndUpdateAET(Point p1, Point p2)
        //        {
        //            if (p1.Y > p2.Y)
        //                AET.Add(new AETElement(p1, p2));
        //            else
        //                AET.RemoveAll(edge => edge.P1 == p2 && edge.P2 == p1);
        //        }

        //        // Posortowanie AET w kierunku rosn�cych X
        //        AET.Sort((e1, e2) => e1.X.CompareTo(e2.X));

        //        unsafe
        //        {
        //            // Transformacja uk�adu wsp�rz�dnych
        //            //int transformedY = -scanline + DirectBitmap.Height / 2;
        //            int transformedY = CoordinateTransformer.TransformY(scanline);

        //            // Aktualnie rozwa�any punkt
        //            Point p = new(0, scanline);

        //            // Dla kolejnych par kraw�dzi 0-1, 2-3
        //            for (int i = 0; i < AET.Count - 1; i += 2)
        //            {
        //                AETElement e1 = AET[i];
        //                AETElement e2 = AET[i + 1];

        //                int x1 = (int)e1.X;
        //                int x2 = (int)e2.X;

        //                if (transformedY >= 0 && transformedY < DirectBitmap.Height)
        //                {
        //                    // Wype�nianie scanlinii mi�dzy kraw�dziami
        //                    for (int x = x1; x < x2; x++)
        //                    {
        //                        p.X = x;
        //                        float[] coords = getBaricentricCoords(p);

        //                        if (coords.Contains(float.NaN))
        //                            continue;

        //                        float u = triangle.V1.U * coords[0] + triangle.V2.U * coords[1] + triangle.V3.U * coords[2];
        //                        float v = triangle.V1.V * coords[0] + triangle.V2.V * coords[1] + triangle.V3.V * coords[2];

        //                        Color color = getColor(coords, u, v);

        //                        // Transformacja uk�adu wsp�rz�dnych
        //                        //int transformedX = x + DirectBitmap.Width / 2;
        //                        int transformedX = CoordinateTransformer.TransformX(x);

        //                        if (transformedX >= 0 && transformedX < DirectBitmap.Width)
        //                            DirectBitmap.SetPixel(transformedX, transformedY, color);
        //                    }
        //                }
        //            }

        //            // Aktualizacja warto�ci x dla nowej scanlinii
        //            for (int i = 0; i < AET.Count; i++)
        //                AET[i].X += AET[i].InverseSlope;
        //        }


        //        Color getColor(float[] coords, float u, float v)
        //        {
        //            Color color = GetColor(u, v);

        //            Vector3 Il = new(LightColor.R, LightColor.G, LightColor.B);
        //            Vector3 Io = new(color.R, color.G, color.B);
        //            Vector3 P = triangle.V1.AfterRotationState.P * coords[0] + triangle.V2.AfterRotationState.P * coords[1] + triangle.V3.AfterRotationState.P * coords[2];
        //            Vector3 L = LightPositionForDrawing - P;
        //            Vector3 N = GetNormalVector(triangle, coords, u, v);
        //            Vector3 V = new(0, 0, 1);

        //            Il = Vector3.Normalize(Il);
        //            Io = Vector3.Normalize(Io);
        //            L = Vector3.Normalize(L);
        //            N = Vector3.Normalize(N);

        //            Vector3 R = 2 * Vector3.Dot(N, L) * N - L;
        //            R = Vector3.Normalize(R);

        //            Vector3 I = Kd * Il * Io * Math.Max(0, Vector3.Dot(L, N)) + Ks * Il * Io * MathF.Pow(Math.Max(0, Vector3.Dot(R, V)), M);

        //            I = Vector3.Clamp(I, new Vector3(0, 0, 0), new Vector3(1, 1, 1));
        //            I *= 255;

        //            return Color.FromArgb((int)I.X, (int)I.Y, (int)I.Z);
        //        }

        //        float[] getBaricentricCoords(Point p)
        //        {
        //            float[] coords = new float[3];
        //            float invertedS = (float)1 / getDoubledSarea(trianglePoints[0], trianglePoints[1], trianglePoints[2]);
        //            //float invertedS = 1 / s;
        //            coords[0] = getDoubledSarea(p, trianglePoints[1], trianglePoints[2]) * invertedS;
        //            coords[1] = getDoubledSarea(trianglePoints[0], p, trianglePoints[2]) * invertedS;
        //            coords[2] = getDoubledSarea(trianglePoints[0], trianglePoints[1], p) * invertedS;

        //            return coords;
        //        }

        //        int getDoubledSarea(Point p1, Point p2, Point p3)
        //        {
        //            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        //        }
        //    }
        //}

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

            G.ScaleTransform(1, -1);
            G.TranslateTransform(Bitmap.Width / 2, -Bitmap.Height / 2);

            MeshRenderer.DirectBitmap = DirectBitmap;
            MeshRenderer.G = G;

            pictureBox.Invalidate();

            oldDirectBitmap.Dispose();
            oldGraphics.Dispose();
            oldBitmap.Dispose();
        }

        private void kdTrackBar_Scroll(object sender, EventArgs e)
        {
            MeshRenderer.ReflectionCoefficients.Kd = scaleTrackBarValueToOne(kdTrackBar);
            //Kd = scaleTrackBarValueToOne(kdTrackBar);

            pictureBox.Invalidate();
        }

        private void ksTrackBar_Scroll(object sender, EventArgs e)
        {
            MeshRenderer.ReflectionCoefficients.Ks = scaleTrackBarValueToOne(ksTrackBar);
            //Ks = scaleTrackBarValueToOne(ksTrackBar);

            pictureBox.Invalidate();
        }

        private void mTrackBar_Scroll(object sender, EventArgs e)
        {
            MeshRenderer.ReflectionCoefficients.M = mTrackBar.Value;
            //M = mTrackBar.Value;

            pictureBox.Invalidate();
        }

        private void lightZAxisTrackBar_Scroll(object sender, EventArgs e)
        {
            //LightZCoord = lightZCoordTrackBar.Value;
            lock (Scene.LightSource)
                Scene.LightSource.Position = new(Scene.LightSource.Position.X, Scene.LightSource.Position.Y, lightZCoordTrackBar.Value);

            //LightPositionMutex.WaitOne();
            //LightPosition = new Vector3(LightPosition.X, LightPosition.Y, lightZCoordTrackBar.Value);
            //LightPositionMutex.ReleaseMutex();
            pictureBox.Invalidate();
        }

        private void lightColorButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Scene.LightSource.Color;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                lock (Scene.LightSource)
                    Scene.LightSource.Color = colorDialog.Color;
                //LightColor = colorDialog.Color;
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
            //DrawEdges = drawEdgesCheckBox.Checked;
            pictureBox.Invalidate();
        }

        private void drawFillingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MeshRenderer.DrawFilling = drawFillingCheckBox.Checked;
            //DrawFilling = drawFillingCheckBox.Checked;
            pictureBox.Invalidate();
        }

        private void fixedColorRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            MeshRenderer.GetColor = MeshRenderer.GetMeshRGBColor;
            //GetColor = GetMeshRGBColor;
            pictureBox.Invalidate();
        }

        private void textureRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            MeshRenderer.GetColor = MeshRenderer.GetTextureColor;
            //GetColor = GetTextureColor;
            pictureBox.Invalidate();
        }

        //private Color GetMeshRGBColor(float u, float v)
        //{
        //    return MeshColor;
        //}
        //private Color GetTextureColor(float u, float v)
        //{
        //    u = Math.Clamp(u, 0, 1);
        //    v = Math.Clamp(v, 0, 1);

        //    int x = (int)Math.Round(u * (TextureDirectBitmap.Width - 1));
        //    int y = (int)Math.Round(v * (TextureDirectBitmap.Height - 1));

        //    if (x >= TextureDirectBitmap.Width || x < 0 || y >= TextureDirectBitmap.Height || y < 0)
        //    {

        //    }

        //    return TextureDirectBitmap.GetPixel(x, y);
        //}

        private void textureButton_Click(object sender, EventArgs e)
        {
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
            //GetNormalVector = GetNormalVectorFromNormalMap;
            else
                MeshRenderer.GetNormalVector = MeshRenderer.GetNormalVectorFromVertices;

            pictureBox.Invalidate();
        }

        //private Vector3 GetNormalVectorFromNormalMap(Triangle triangle, float[] coords, float u, float v)
        //{
        //    Vector3 N = GetNormalVectorFromVertices(triangle, coords, u, v);

        //    u = Math.Clamp(u, 0, 1);
        //    v = Math.Clamp(v, 0, 1);

        //    Vector3 normalMapN = NormalMap[(int)(u * (NormalMap.GetLength(0) - 1)), (int)(v * (NormalMap.GetLength(1) - 1))];
        //    Vector3 Pu = triangle.V1.AfterRotationState.Pu * coords[0] + triangle.V2.AfterRotationState.Pu * coords[1] + triangle.V3.AfterRotationState.Pu * coords[2];
        //    Vector3 Pv = triangle.V1.AfterRotationState.Pv * coords[0] + triangle.V2.AfterRotationState.Pv * coords[1] + triangle.V3.AfterRotationState.Pv * coords[2];

        //    Matrix4x4 T = new Matrix4x4(
        //        Pu.X, Pv.X, N.X, 0,
        //        Pu.Y, Pv.Y, N.Y, 0,
        //        Pu.Z, Pv.Z, N.Z, 0,
        //        0, 0, 0, 1
        //    );

        //    normalMapN = Vector3.Transform(normalMapN, T);
        //    return Vector3.Normalize(normalMapN);
        //}

        //private Vector3 GetNormalVectorFromVertices(Triangle triangle, float[] coords, float u, float v)
        //{
        //    Vector3 N = triangle.V1.AfterRotationState.N * coords[0] + triangle.V2.AfterRotationState.N * coords[1] + triangle.V3.AfterRotationState.N * coords[2];
        //    return Vector3.Normalize(N);
        //}

        private void normalMapButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                Bitmap bitmap = new(fileName);
                GetNormalMap(bitmap);
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

        //private void LoadBitmapFromFile(ref Bitmap bitmap)
        //{
        //    if (openFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        bitmap = new(openFileDialog.FileName);

        //        pictureBox.Invalidate();
        //    }
        //}


        //private int RadiusChange { get; set; } = 2;
        //private float AngleChange { get; set; } = 0.1f;
        //private void MoveLight()
        //{
        //    LightPositionMutex.WaitOne();

        //    LightZAxisRadius += RadiusChange;
        //    LightZAxisAngle += AngleChange;
        //    float x = LightZAxisRadius * MathF.Cos(LightZAxisAngle);
        //    float y = LightZAxisRadius * MathF.Sin(LightZAxisAngle);
        //    LightPosition = new Vector3(x, y, LightPosition.Z);

        //    if (LightZAxisRadius >= 500 || LightZAxisRadius <= 0)
        //    {
        //        RadiusChange *= -1;
        //        AngleChange *= -1;
        //    }

        //    LightPositionMutex.ReleaseMutex();
        //    pictureBox.Invalidate();
        //}

        private void timer_Tick(object? sender, EventArgs e)
        {
            Scene.MoveLightSource();
            pictureBox.Invalidate();
            //MoveLight();
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
            //LightPositionMutex.WaitOne();
            //LightPosition = new(0, 0, LightPosition.Z);
            //LightZAxisRadius = 0;
            //LightZAxisAngle = 0;
            //LightPositionMutex.ReleaseMutex();
            pictureBox.Invalidate();
        }

        private void loadControlPointsButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                TxtControlPointsReader reader = new(ControlPointsFirstDimensionCount, ControlPointsSecondDimensionCount);
                string fileName = openFileDialog.FileName;
                Vector3[,] controlPoints = reader.Read(fileName);
                Scene.Mesh = new Mesh(controlPoints, fidelityTrackBar.Value, fidelityTrackBar.Value, alphaAngleTrackBar.Value, betaAngleTrackBar.Value);

                pictureBox.Invalidate();
            }
        }
    }
}
