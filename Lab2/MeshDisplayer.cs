using Lab2.Model;
using Lab2.VertexFileReaders;
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

        private Color MeshColor { get; set; } = Color.AliceBlue;

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


            Bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.Image = Bitmap;

            G = Graphics.FromImage(Bitmap);
            G.ScaleTransform(1, -1);
            G.TranslateTransform(Bitmap.Width / 2, -Bitmap.Height / 2);

            LoadControlPoints();
            Mesh = new(ControlPoints!, fidelityTrackBar.Value, fidelityTrackBar.Value, alphaAngleTrackBar.Value, betaAngleTrackBar.Value);
            PaintPictureBox();

            //fillPolygon([new PointF(0, 0), new PointF(0, 1), new PointF(1, 1), new PointF(1, 0)]);
        }

        private void bindFormat(object sender, ConvertEventArgs e)
        {
            //int value = (int)e.Value;
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
            //Mesh?.SetAngles(alphaAngleTrackBar.Value, betaAngleTrackBar.Value);
            Mesh?.SetAlphaAngle(alphaAngleTrackBar.Value);
            pictureBox.Refresh();
            pictureBox.Refresh();
        }

        private void betaAngleTrackBar_Scroll(object sender, EventArgs e)
        {
            //Mesh?.SetAngles(alphaAngleTrackBar.Value, betaAngleTrackBar.Value);
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

                fillPolygon([new Point((int)v1.X, (int)v1.Y), new Point((int)v2.X, (int)v2.Y), new Point((int)v3.X, (int)v3.Y)]);

                G.DrawLine(Pens.Black, v1, v2);
                G.DrawLine(Pens.Black, v2, v3);
                G.DrawLine(Pens.Black, v3, v1);

                //fillPolygon([v1, v2, v3]);
            }

            //List<Point> points = [new Point(0, 100), new Point(-100, -100), new Point(100, -100)];
            //fillPolygon(points);
            //G.DrawLine(Pens.Black, points[0], points[1]);
            //G.DrawLine(Pens.Black, points[1], points[2]);
            //G.DrawLine(Pens.Black, points[2], points[0]);

            //List<Point> points = [new Point(-200, -50), new Point(-80, 90), new Point(150, 40), new Point(130, -80)];
            //G.DrawLine(Pens.Black, points[0], points[1]);
            //G.DrawLine(Pens.Black, points[1], points[2]);
            //G.DrawLine(Pens.Black, points[2], points[3]);
            //G.DrawLine(Pens.Black, points[3], points[0]);
            //fillPolygon(points);
            //pictureBox.Image = Bitmap;
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


        private void fillPolygon(List<Point> polygonPoints)
        {
            int[] indices = Enumerable.Range(0, polygonPoints.Count).ToArray();
            Array.Sort(indices, (i1, i2) => polygonPoints[i1].Y.CompareTo(polygonPoints[i2].Y));
            int polygonYMin = polygonPoints[indices[0]].Y;
            int polygonYMax = polygonPoints[indices[^1]].Y;


            List<AETElement> AET = [];

            for (int scanline = polygonYMin; scanline < polygonYMax; scanline++)
            {
                AET.RemoveAll(edge => edge.P1.Y == edge.P2.Y);
                for (int i = 0; i < polygonPoints.Count; i++)
                {
                    Point point = polygonPoints[i];
                    if (point.Y == scanline - 1)
                    {
                        int previousIndex = i == 0 ? polygonPoints.Count - 1 : i - 1;
                        int nextIndex = i == polygonPoints.Count - 1 ? 0 : i + 1;

                        Point previousPoint = polygonPoints[previousIndex];
                        Point nextPoint = polygonPoints[nextIndex];

                        if (previousPoint.Y >= point.Y)
                            AET.Add(new AETElement(previousPoint, point));
                        else
                            AET.RemoveAll(edge => edge.P1 == point && edge.P2 == previousPoint);

                        if (nextPoint.Y >= point.Y)
                            AET.Add(new AETElement(nextPoint, point));
                        else
                            AET.RemoveAll(edge => edge.P1 == point && edge.P2 == nextPoint);
                    }

                }

                AET.Sort((e1, e2) => e1.X.CompareTo(e2.X));

                int transformedY = -scanline + Bitmap.Height / 2;
                for (int j = 0; j < AET.Count - 1; j++)
                {
                    AETElement e1 = AET[j];
                    AETElement e2 = AET[j + 1];

                    //G.DrawLine(Pens.AliceBlue, e1.X, scanline, e2.X, scanline);
                    int x1 = (int)e1.X;
                    int x2 = (int)e2.X;


                    for (int x = x1; x < x2; x++)
                    {
                        int transformedX = x + Bitmap.Width / 2;
                        if(transformedX >= 0 && transformedX < Bitmap.Width && transformedY >= 0 && transformedY < Bitmap.Height)
                            Bitmap.SetPixel(transformedX, transformedY, MeshColor);
                    }

                    e1.X += e1.InverseSlope;
                    e2.X += e2.InverseSlope;
                }

            }
        }
    }
}
