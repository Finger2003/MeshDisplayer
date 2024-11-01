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
        private Mesh Mesh { get; set; }
        Graphics G { get; set; }
        public MeshDisplayer()
        {
            InitializeComponent();

            fideltyValueLabel.DataBindings.Add("Text", fideltyTrackBar, "Value");
            alphaAngleValueLabel.DataBindings.Add("Text", alphaAngleTrackBar, "Value");
            betaAngleValueLabel.DataBindings.Add("Text", betaAngleTrackBar, "Value");

            Bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            G = Graphics.FromImage(Bitmap);
            G.ScaleTransform(1, -1);
            G.TranslateTransform(pictureBox.Width / 2, -pictureBox.Height / 2);

            LoadControlPoints();
        }

        private void LoadControlPoints()
        {
            TxtControlPointsReader reader = new(ControlPointsFirstDimensionCount, ControlPointsSecondDimensionCount);
            ControlPoints = reader.Read(ControlPointsPath);
        }

        private void FideltyTrackBar_Scroll(object sender, EventArgs e)
        {
            //int fidelity = fideltyTrackBar.Value;
            //fideltyValueLabel.Text = fidelity.ToString();
        }

        private void alphaAngleTrackBar_Scroll(object sender, EventArgs e)
        {
            //int alphaAngle = alphaAngleTrackBar.Value;
            //alphaAngleValueLabel.Text = alphaAngle.ToString();
        }

        private void betaAngleTrackBar_Scroll(object sender, EventArgs e)
        {
            //int betaAngle = betaAngleTrackBar.Value;
            //betaAngleValueLabel.Text = betaAngle.ToString();
        }
    }
}
