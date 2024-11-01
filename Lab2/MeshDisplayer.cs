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
        Graphics G { get; set; }
        public MeshDisplayer()
        {
            InitializeComponent();

            fideltyValueLabel.DataBindings.Add("Text", fidelityTrackBar, "Value");
            alphaAngleValueLabel.DataBindings.Add("Text", alphaAngleTrackBar, "Value");
            betaAngleValueLabel.DataBindings.Add("Text", betaAngleTrackBar, "Value");

            Bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            G = Graphics.FromImage(Bitmap);
            G.ScaleTransform(1, -1);
            G.TranslateTransform(Bitmap.Width / 2, -Bitmap.Height / 2);

            LoadControlPoints();
            Mesh = new(ControlPoints!, fidelityTrackBar.Value, fidelityTrackBar.Value, alphaAngleTrackBar.Value, betaAngleTrackBar.Value);
        }

        private void LoadControlPoints()
        {
            TxtControlPointsReader reader = new(ControlPointsFirstDimensionCount, ControlPointsSecondDimensionCount);
            ControlPoints = reader.Read(ControlPointsPath);
        }

        private void fidelityTrackBar_Scroll(object sender, EventArgs e)
        {
            fidelityTrackBar.Value = (int)Math.Round((double) fidelityTrackBar.Value / fidelityTrackBar.TickFrequency) * fidelityTrackBar.TickFrequency;
            Mesh?.SetFidelty(fidelityTrackBar.Value, fidelityTrackBar.Value);
        }

        private void alphaAngleTrackBar_Scroll(object sender, EventArgs e)
        {
            Mesh?.SetAlphaAngle(alphaAngleTrackBar.Value);
        }

        private void betaAngleTrackBar_Scroll(object sender, EventArgs e)
        {
            Mesh?.SetBetaAngle(betaAngleTrackBar.Value);
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Paint();
        }

        private void Paint()
        {
            if (Mesh is null)
                return;

            foreach (Triangle triangle in Mesh.Triangles)
            {
                PointF v1 = new(triangle.V1.AfterRotationState.P.X, triangle.V1.AfterRotationState.P.Y);
                PointF v2 = new(triangle.V2.AfterRotationState.P.X, triangle.V2.AfterRotationState.P.Y);
                PointF v3 = new(triangle.V3.AfterRotationState.P.X, triangle.V3.AfterRotationState.P.Y);

                G.DrawLine(Pens.Black, v1, v2);
                G.DrawLine(Pens.Black, v2, v3);
                G.DrawLine(Pens.Black, v3, v1);
            }
        }
    }
}
