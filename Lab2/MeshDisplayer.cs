using Lab2.Model;
using Lab2.VertexFileReaders;
using System.Drawing.Imaging;
using System.Numerics;

namespace Lab2
{
    public partial class MeshDisplayer : Form
    {
        private int ControlPointsFirstDimensionCount { get; set; } = 4;
        private int ControlPointsSecondDimensionCount { get; set; } = 4;
        private string ControlPointsPath { get; set; } = "control_points.txt";

        private Vector3[,] ControlPoints { get; set; }

        private Bitmap Bitmap { get; set; }
        private Mesh? Mesh { get; set; }
        private Graphics G { get; set; }

        Color LightColor { get; set; } = Color.Red;
        float Kd { get; set; }
        float Ks { get; set; }
        float M { get; set; }
        float LightZAxis { get; set; }

        private Color MeshColor { get; set; } = Color.White;

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
            lightZAxisValueLabel.DataBindings.Add("Text", lightZAxisTrackBar, "Value");

            Kd = scaleTrackBarValueToOne(kdTrackBar);
            Ks = scaleTrackBarValueToOne(ksTrackBar);
            M = mTrackBar.Value;
            LightZAxis = lightZAxisTrackBar.Value;


            Bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.Image = Bitmap;

            G = Graphics.FromImage(Bitmap);
            G.ScaleTransform(1, -1);
            G.TranslateTransform(Bitmap.Width / 2, -Bitmap.Height / 2);

            LoadControlPoints();
            Mesh = new(ControlPoints!, fidelityTrackBar.Value, fidelityTrackBar.Value, alphaAngleTrackBar.Value, betaAngleTrackBar.Value);
            PaintPictureBox();
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

        private void LoadControlPoints()
        {
            TxtControlPointsReader reader = new(ControlPointsFirstDimensionCount, ControlPointsSecondDimensionCount);
            ControlPoints = reader.Read(ControlPointsPath);
        }

        private void fidelityTrackBar_Scroll(object sender, EventArgs e)
        {
            fidelityTrackBar.Value = (int)Math.Round((double)fidelityTrackBar.Value / fidelityTrackBar.TickFrequency) * fidelityTrackBar.TickFrequency;
            Mesh?.SetFidelity(fidelityTrackBar.Value, fidelityTrackBar.Value);
            pictureBox.Refresh();
            pictureBox.Refresh();
        }

        private void alphaAngleTrackBar_Scroll(object sender, EventArgs e)
        {
            Mesh?.SetAlphaAngle(alphaAngleTrackBar.Value);
            pictureBox.Refresh();
            pictureBox.Refresh();
        }

        private void betaAngleTrackBar_Scroll(object sender, EventArgs e)
        {
            Mesh?.SetBetaAngle(betaAngleTrackBar.Value);
            pictureBox.Refresh();
            pictureBox.Refresh();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            PaintPictureBox();
        }

        private void PaintPictureBox()
        {
            if (Mesh is null)
                return;

            G.Clear(Color.White);


            foreach (Triangle triangle in Mesh.Triangles)
            {
                PointF v1 = new(triangle.V1.AfterRotationState.P.X, triangle.V1.AfterRotationState.P.Y);
                PointF v2 = new(triangle.V2.AfterRotationState.P.X, triangle.V2.AfterRotationState.P.Y);
                PointF v3 = new(triangle.V3.AfterRotationState.P.X, triangle.V3.AfterRotationState.P.Y);

                BitmapData bitmapData = Bitmap.LockBits(new Rectangle(0, 0, Bitmap.Width, Bitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                fillTriangle(triangle, bitmapData);
                Bitmap.UnlockBits(bitmapData);

                G.DrawLine(Pens.Black, v1, v2);
                G.DrawLine(Pens.Black, v2, v3);
                G.DrawLine(Pens.Black, v3, v1);
            }
        }

        private void fillTriangle(Triangle triangle, BitmapData bitmapData)
        {
            const int bytesPerPixel = 4;

            List<Point> trianglePoints =
            [
                new Point((int)Math.Round(triangle.V1.AfterRotationState.P.X), (int)Math.Round(triangle.V1.AfterRotationState.P.Y)),
                new Point((int)Math.Round(triangle.V2.AfterRotationState.P.X), (int)Math.Round(triangle.V2.AfterRotationState.P.Y)),
                new Point((int)Math.Round(triangle.V3.AfterRotationState.P.X), (int)Math.Round(triangle.V3.AfterRotationState.P.Y))
            ];

            int polygonYMin = trianglePoints.Min(p => p.Y);
            int polygonYMax = trianglePoints.Max(p => p.Y);

            List<AETElement> AET = [];

            for (int scanline = polygonYMin; scanline <= polygonYMax; scanline++)
            {
                AET.RemoveAll(edge => edge.P1.Y == edge.P2.Y);
                for (int i = 0; i < trianglePoints.Count; i++)
                {
                    Point point = trianglePoints[i];

                    // Jeœli punkt by³ na scanline zaktualizuj AET o krawêdzie, które go zawieraj¹
                    if (point.Y == scanline - 1)
                    {
                        int previousIndex = i == 0 ? trianglePoints.Count - 1 : i - 1;
                        int nextIndex = i == trianglePoints.Count - 1 ? 0 : i + 1;

                        Point previousPoint = trianglePoints[previousIndex];
                        Point nextPoint = trianglePoints[nextIndex];

                        checkAndUpdateAET(previousPoint, point);
                        checkAndUpdateAET(nextPoint, point);
                    }
                }

                void checkAndUpdateAET(Point p1, Point p2)
                {
                    if (p1.Y > p2.Y)
                        AET.Add(new AETElement(p1, p2));
                    else
                        AET.RemoveAll(edge => edge.P1 == p2 && edge.P2 == p1);
                }

                // Posortowanie AET w kierunku rosn¹cych X
                AET.Sort((e1, e2) => e1.X.CompareTo(e2.X));

                unsafe
                {
                    // Transformacja uk³adu wspó³rzêdnych
                    int transformedY = -scanline + Bitmap.Height / 2;

                    // WskaŸnik na pierwszy piksel w scanline
                    byte* row = (byte*)bitmapData.Scan0 + transformedY * bitmapData.Stride;

                    // Aktualnie rozwa¿any punkt
                    Point p = new(0, scanline);

                    // Dla kolejnych par krawêdzi 0-1, 2-3
                    for (int i = 0; i < AET.Count - 1; i+=2)
                    {
                        AETElement e1 = AET[i];
                        AETElement e2 = AET[i + 1];

                        int x1 = (int)e1.X;
                        int x2 = (int)e2.X;

                        if (transformedY >= 0 && transformedY < bitmapData.Height)
                        {
                            // Wype³nianie scanlinii miêdzy krawêdziami
                            for (int x = x1; x < x2; x++)
                            {
                                p.X = x;
                                float[] coords = getBaricentricCoords(p);
                                byte[] color = getColor([MeshColor.R, MeshColor.G, MeshColor.B], coords);

                                // Transformacja uk³adu wspó³rzêdnych
                                int transformedX = x + bitmapData.Width / 2;

                                if (transformedX < 0 || transformedX >= bitmapData.Width)
                                    continue;

                                int index = transformedX * bytesPerPixel;

                                row[index] = color[2];
                                row[index + 1] = color[1];
                                row[index + 2] = color[0];
                                row[index + 3] = MeshColor.A;
                            }
                        }
                    }

                    // Aktualizacja wartoœci x dla nowej scanlinii
                    for (int i = 0; i < AET.Count; i++)
                        AET[i].X += AET[i].InverseSlope;
                }


                byte[] getColor(float[] color, float[] cords)
                {
                    Vector3 Il = new(LightColor.R, LightColor.G, LightColor.B);
                    Vector3 Io = new(color);
                    Vector3 L = new(0, 1, 1);
                    Vector3 N = triangle.V1.AfterRotationState.N * cords[0] + triangle.V2.AfterRotationState.N * cords[1] + triangle.V3.AfterRotationState.N * cords[2];
                    Vector3 V = new(0, 0, 1);
                    N = Vector3.Abs(N);

                    Il = Vector3.Normalize(Il);
                    Io = Vector3.Normalize(Io);
                    L = Vector3.Normalize(L);
                    N = Vector3.Normalize(N);
                    Vector3 R = 2 * Vector3.Dot(N, L) * N - L;
                    R = Vector3.Normalize(R);

                    Vector3 I = Kd * Il * Math.Max(0, Vector3.Dot(L, N)) + Ks * Il * MathF.Pow(Math.Max(0, Vector3.Dot(R, V)), M);

                    I *= 255;
                    I = Vector3.Clamp(I, new Vector3(0, 0, 0), new Vector3(255, 255, 255));

                    return [(byte)I.X, (byte)I.Y, (byte)I.Z];
                }

                float[] getBaricentricCoords(Point p)
                {
                    float[] coords = new float[3];
                    float s = getDoubledSarea(trianglePoints[0], trianglePoints[1], trianglePoints[2]);
                    coords[0] = getDoubledSarea(p, trianglePoints[1], trianglePoints[2]) / s;
                    coords[1] = getDoubledSarea(trianglePoints[0], p, trianglePoints[2]) / s;
                    coords[2] = getDoubledSarea(trianglePoints[0], trianglePoints[1], p) / s;
                    return coords;
                }

                int getDoubledSarea(Point p1, Point p2, Point p3)
                {
                    return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
                }
            }
        }

        private void pictureBox_SizeChanged(object sender, EventArgs e)
        {
            if (pictureBox.Width <= 0 || pictureBox.Height <= 0 || Bitmap is null)
                return;

            Bitmap oldBitmap = Bitmap;
            Graphics oldGraphics = G;

            Bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            G = Graphics.FromImage(Bitmap);
            G.DrawImage(oldBitmap, 0, 0);

            G.ScaleTransform(1, -1);
            G.TranslateTransform(Bitmap.Width / 2, -Bitmap.Height / 2);

            pictureBox.Image = Bitmap;

            oldGraphics.Dispose();
            oldBitmap.Dispose();
        }

        private void kdTrackBar_Scroll(object sender, EventArgs e)
        {
            Kd = scaleTrackBarValueToOne(kdTrackBar);
            pictureBox.Refresh();
            pictureBox.Refresh();
        }

        private void ksTrackBar_Scroll(object sender, EventArgs e)
        {
            Ks = scaleTrackBarValueToOne(ksTrackBar);
            pictureBox.Refresh();
            pictureBox.Refresh();
        }

        private void mTrackBar_Scroll(object sender, EventArgs e)
        {
            M = mTrackBar.Value;
            pictureBox.Refresh();
            pictureBox.Refresh();
        }

        private void lightZAxisTrackBar_Scroll(object sender, EventArgs e)
        {
            LightZAxis = lightZAxisTrackBar.Value;
            pictureBox.Refresh();
            pictureBox.Refresh();
        }
    }
}
