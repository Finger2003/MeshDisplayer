using Lab2.Utils;
using System.Numerics;

namespace Lab2.Model
{
    public class Mesh
    {
        public List<Triangle> Triangles { get; } = [];

        public Vertex[,] Vertices { get; private set; } = new Vertex[0, 0];

        public Vector3[,] ControlPoints { get; private set; }
        public Vector3[,] ControlPointsAfterRotation { get; private set; }

        private float AlphaRadians { get; set; }
        private float BetaRadians { get; set; }
        private int FidelityU { get; set; }
        private int FidelityV { get; set; }

        public Mesh(Vector3[,] controlPoints, int fidelityU, int fidelityV, int alphaAngle, int betaAngle)
        {
            ControlPoints = controlPoints;
            ControlPointsAfterRotation = new Vector3[controlPoints.GetLength(0), controlPoints.GetLength(1)];
            AlphaRadians = MathHelper.DegreesToRadians(alphaAngle);
            BetaRadians = MathHelper.DegreesToRadians(betaAngle);
            SetFidelity(fidelityU, fidelityV);
        }

        public void SetControlPoints(Vector3[,] controlPoints)
        {
            ControlPoints = controlPoints;
            ControlPointsAfterRotation = new Vector3[controlPoints.GetLength(0), controlPoints.GetLength(1)];
            InterPolateVertices();
        }

        public void InterPolateVertices()
        {
            Vertices = new Vertex[FidelityU, FidelityV];


            float stepU = 1.0f / (FidelityU - 1);
            float stepV = 1.0f / (FidelityV - 1);

            int n = ControlPoints.GetLength(0) - 1;
            int m = ControlPoints.GetLength(1) - 1;

            // Potęgi u i v oraz 1-u i 1-v - pierwszy wymiar: kolejne u i v oraz 1-u i 1-v, drugi wymiar: kolejne potęgi
            float[,] uPowers = new float[FidelityU, n + 1];
            float[,] vPowers = new float[FidelityV, m + 1];
            float[,] oneMinusUPowers = new float[FidelityU, n + 1];
            float[,] oneMinusVPowers = new float[FidelityV, m + 1];

            fillWithPowers(uPowers, 0, stepU);
            fillWithPowers(vPowers, 0, stepV);
            fillWithPowers(oneMinusUPowers, 1, -stepU);
            fillWithPowers(oneMinusVPowers, 1, -stepV);


            // B_i_n(u) Pierwszy wymiar: kolejne u, drugi wymiar: kolejne i
            float[,] Bu = new float[FidelityU, n + 1];
            // B_j_m(v) Pierwszy wymiar: kolejne v, drugi wymiar: kolejne i
            float[,] Bv = new float[FidelityV, m + 1];

            // B_i_(n-1)(u) Pierwszy wymiar: kolejne u, drugi wymiar: kolejne i
            float[,] BuTan = new float[FidelityU, n];
            // B_j_(m-1)(v) Pierwszy wymiar: kolejne v, drugi wymiar: kolejne i
            float[,] BvTan = new float[FidelityV, m];


            fillWithBernstein(Bu, uPowers, oneMinusUPowers);
            fillWithBernstein(Bv, vPowers, oneMinusVPowers);
            fillWithBernstein(BuTan, uPowers, oneMinusUPowers);
            fillWithBernstein(BvTan, vPowers, oneMinusVPowers);

            float v, u = 0;
            // Wyznaczanie wierzchołków
            for (int ui = 0; ui < FidelityU; ui++)
            {
                v = 0;
                for (int vi = 0; vi < FidelityV; vi++)
                {
                    Vector3 p = new(0, 0, 0);
                    Vector3 pu = new(0, 0, 0);
                    Vector3 pv = new(0, 0, 0);
                    Vector3 nuv;

                    // Punkt P
                    for (int i = 0; i <= n; i++)
                        for (int j = 0; j <= m; j++)
                            p += Bu[ui, i] * Bv[vi, j] * ControlPoints[i, j];

                    // Wektor styczny Pu
                    for (int i = 0; i <= n - 1; i++)
                        for (int j = 0; j <= m; j++)
                            pu += BuTan[ui, i] * Bv[vi, j] * (ControlPoints[i + 1, j] - ControlPoints[i, j]);

                    // Wektor styczny Pv
                    for (int i = 0; i <= n; i++)
                        for (int j = 0; j <= m - 1; j++)
                            pv += Bu[ui, i] * BvTan[vi, j] * (ControlPoints[i, j + 1] - ControlPoints[i, j]);

                    pu *= n;
                    pv *= m;

                    // Wektor normalny
                    nuv = Vector3.Cross(pv, pu);
                    nuv = Vector3.Normalize(nuv);

                    Vertices[ui, vi] = new Vertex(p, pu, pv, nuv, u, v);
                    v += stepV;
                }
                u += stepU;
            }

            // Łączenie w trójkąty
            Triangles.Clear();
            for (int ui = 0; ui < FidelityU - 1; ui++)
                for (int vi = 0; vi < FidelityV - 1; vi++)
                {
                    Triangle t1 = new(Vertices[ui, vi], Vertices[ui + 1, vi], Vertices[ui, vi + 1]);
                    Triangle t2 = new(Vertices[ui + 1, vi], Vertices[ui + 1, vi + 1], Vertices[ui, vi + 1]);

                    Triangles.Add(t1);
                    Triangles.Add(t2);
                }

            // Obrót wierzchołków
            RotateVertices();


            void fillWithPowers(float[,] tab, float initialValue, float step)
            {
                int rows = tab.GetLength(0);
                int cols = tab.GetLength(1);

                for (int i = 0; i < rows; i++)
                {
                    tab[i, 0] = 1;
                    for (int j = 1; j < cols; j++) tab[i, j] = tab[i, j - 1] * initialValue;
                    initialValue += step;
                }
            }

            void fillWithBernstein(float[,] tab, float[,] powers, float[,] oneMinusPowers)
            {
                int rows = tab.GetLength(0);
                int cols = tab.GetLength(1);
                int m = cols - 1;
                int baseBinCoeff = MathHelper.GetBinCoeff(m, 0);

                for (int i = 0; i < rows; i++)
                {
                    int binCoeff = baseBinCoeff;
                    for (int j = 0; j < cols; j++)
                    {
                        tab[i, j] = binCoeff * powers[i, j] * oneMinusPowers[i, m - j];
                        binCoeff = binCoeff * (m - j) / (j + 1);
                    }
                }
            }
        }

        public void SetFidelity(int fidelityU, int fidelityV)
        {
            FidelityU = fidelityU;
            FidelityV = fidelityV;
            InterPolateVertices();
        }


        public void SetAlphaAngle(int alphaAngle)
        {
            AlphaRadians = MathHelper.DegreesToRadians(alphaAngle);
            RotateVertices();
        }
        public void SetBetaAngle(int betaAngle)
        {
            BetaRadians = MathHelper.DegreesToRadians(betaAngle);
            RotateVertices();
        }


        private void RotateVertices()
        {
            Matrix4x4 rotationMatrix = Matrix4x4.CreateRotationZ(-AlphaRadians) * Matrix4x4.CreateRotationX(-BetaRadians);

            foreach (Vertex vertex in Vertices)
            {
                Vector3 p = Vector3.Transform(vertex.BeforeRotationState.P, rotationMatrix);
                Vector3 pu = Vector3.Transform(vertex.BeforeRotationState.Pu, rotationMatrix);
                Vector3 pv = Vector3.Transform(vertex.BeforeRotationState.Pv, rotationMatrix);
                Vector3 n = Vector3.Transform(vertex.BeforeRotationState.N, rotationMatrix);

                vertex.AfterRotationState = new Vertex.State(p, pu, pv, n);
            }
            for (int i = 0; i < ControlPoints.GetLength(0); i++)
                for (int j = 0; j < ControlPoints.GetLength(1); j++)
                    ControlPointsAfterRotation[i, j] = Vector3.Transform(ControlPoints[i, j], rotationMatrix);
        }
    }
}
