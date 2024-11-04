using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Model
{
    public class Mesh
    {
        //public List<Vertex> Vertices { get; set; } = [];
        public List<Triangle> Triangles { get; set; } = [];

        public Vertex[,] Vertices { get; set; } = new Vertex[0, 0];

        public Vector3[,] ControlPoints { get; set; }

        private float AlphaRadians { get; set; }
        private float BetaRadians { get; set; }

        public Mesh(Vector3[,] controlPoints, int fidelityU, int fidelityV, int alphaAngle, int betaAngle)
        {
            ControlPoints = controlPoints;
            //SetAngles(alphaAngle, betaAngle);
            AlphaRadians = alphaAngle * MathF.PI / 180;
            BetaRadians = betaAngle * MathF.PI / 180;
            SetFidelity(fidelityU, fidelityV);
            //RotateVertices();
        }


        public void SetFidelity(int fidelityU, int fidelityV)
        {
            Vertices = new Vertex[fidelityU, fidelityV];


            float stepU = 1.0f / (fidelityU - 1);
            float stepV = 1.0f / (fidelityV - 1);

            int n = ControlPoints.GetLength(0) - 1;
            int m = ControlPoints.GetLength(1) - 1;

            // Potęgi u i v oraz 1-u i 1-v - pierwszy wymiar: kolejne u i v oraz 1-u i 1-v, drugi wymiar: kolejne potęgi
            float[,] uPowers = new float[fidelityU, n + 1];
            float[,] vPowers = new float[fidelityV, m + 1];
            float[,] oneMinusUPowers = new float[fidelityU, n + 1];
            float[,] oneMinusVPowers = new float[fidelityV, m + 1];

            fillWithPowers(uPowers, 0, stepU);
            fillWithPowers(vPowers, 0, stepV);
            fillWithPowers(oneMinusUPowers, 1, -stepU);
            fillWithPowers(oneMinusVPowers, 1, -stepV);


            // B_i_n(u) Pierwszy wymiar: kolejne u, drugi wymiar: kolejne i
            float[,] Bu = new float[fidelityU, n + 1];
            // B_j_m(v) Pierwszy wymiar: kolejne v, drugi wymiar: kolejne i
            float[,] Bv = new float[fidelityV, m + 1];

            // B_i_(n-1)(u) Pierwszy wymiar: kolejne u, drugi wymiar: kolejne i
            float[,] BuTan = new float[fidelityU, n];
            // B_j_(m-1)(v) Pierwszy wymiar: kolejne v, drugi wymiar: kolejne i
            float[,] BvTan = new float[fidelityV, m];


            fillWithBernstein(Bu, uPowers, oneMinusUPowers);
            fillWithBernstein(Bv, vPowers, oneMinusVPowers);
            fillWithBernstein(BuTan, uPowers, oneMinusUPowers);
            fillWithBernstein(BvTan, vPowers, oneMinusVPowers);


            // Wyznaczanie wierzchołków
            for (int ui = 0; ui < fidelityU; ui++)
            {
                for (int vi = 0; vi < fidelityV; vi++)
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

                    Vertices[ui, vi] = new Vertex(p, pu, pv, nuv);
                }
            }

            // Łączenie w trójkąty
            Triangles.Clear();
            for (int ui = 0; ui < fidelityU - 1; ui++)
            {
                for (int vi = 0; vi < fidelityV - 1; vi++)
                {
                    Triangle t1 = new Triangle(Vertices[ui, vi], Vertices[ui + 1, vi], Vertices[ui, vi + 1]);
                    Triangle t2 = new Triangle(Vertices[ui + 1, vi], Vertices[ui + 1, vi + 1], Vertices[ui, vi + 1]);

                    Triangles.Add(t1);
                    Triangles.Add(t2);
                }
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
                    for (int j = 1; j < cols; j++)
                    {
                        tab[i, j] = tab[i, j - 1] * initialValue;
                    }
                    initialValue += step;
                }
            }

            void fillWithBernstein(float[,] tab, float[,] powers, float[,] oneMinusPowers)
            {
                int rows = tab.GetLength(0);
                int cols = tab.GetLength(1);
                int m = cols - 1;
                int basebinCoeff = GetBinCoeff(m, 0);

                for (int i = 0; i < rows; i++)
                {
                    int binCoeff = basebinCoeff;
                    //int binCoeff1 = GetBinCoeff(m - 1, 0);
                    for (int j = 0; j < cols; j++)
                    {
                        //float temp = powers[i, j] * oneMinusPowers[i, m - j];
                        //float diff0 = temp - getBernsteinWithoutCoeff(j, m, powers[i, 1]);

                        tab[i, j] = binCoeff * powers[i, j] * oneMinusPowers[i, m - j];
                        binCoeff = binCoeff * (m - j) / (j + 1);

                        //tab[i, j, 1] = binCoeff1 * powers[i, j] * oneMinusPowers[i, m - j - 1];
                        //binCoeff1 = binCoeff1 * (m - j - 1) / (j + 1);

                        //float diff1 = tab[i, j, 0] - getBernstein(j, m, powers[i, 1]);
                        //float diff2 = tab[i, j, 1] - getBernstein(j, m - 1, powers[i, 1]);
                    }
                }
            }

            float getBernstein(int i, int n, float t)
            {
                return GetBinCoeff(n, i) * getBernsteinWithoutCoeff(i, n, t);
                //return GetBinCoeff(n, i) * MathF.Pow(t, i) * MathF.Pow(1 - t, n - i);
            }
            float getBernsteinWithoutCoeff(int i, int n, float t)
            {
                return MathF.Pow(t, i) * MathF.Pow(1 - t, n - i);
            }
        }
        //public void SetFidelity(int fidelityU, int fidelityV)
        //{
        //    Vertices = new Vertex[fidelityU, fidelityV];


        //    float stepU = 1.0f / (fidelityU - 1);
        //    float stepV = 1.0f / (fidelityV - 1);

        //    int n = ControlPoints.GetLength(0) - 1;
        //    int m = ControlPoints.GetLength(1) - 1;

        //    float u = 0, v = 0;

        //    // Wyznaczanie wierzchołków
        //    for (int ui = 0; ui < fidelityU; ui++)
        //    {
        //        v = 0;
        //        for (int vi = 0; vi < fidelityV; vi++)
        //        {
        //            Vector3 p = new(0, 0, 0);
        //            Vector3 pu = new(0, 0, 0);
        //            Vector3 pv = new(0, 0, 0);
        //            Vector3 nuv;

        //            // Punkt P
        //            float binCoeff1 = GetBinCoeff(n, 0);
        //            float binCoeff2 = GetBinCoeff(m, 0);
        //            for (int i = 0; i <= n; i++)
        //            {
        //                binCoeff2 = GetBinCoeff(m, 0);
        //                for (int j = 0; j <= m; j++)
        //                {

        //                    //p += getBernstein(i, n, u) * getBernstein(j, m, v) * ControlPoints[i, j];
        //                    p += binCoeff1 * binCoeff2 * getBernstein(i, n, u) * getBernstein(j, m, v) * ControlPoints[i, j];
        //                    binCoeff2 = binCoeff2 * (m - j) / (j + 1);
        //                    //p += getBernstein(i, n, u) * getBernstein(j, m, v) * ControlPoints[i, j];
        //                }
        //                    binCoeff1 = binCoeff1 * (n - i) / (i + 1);
        //            }

        //            // Wektor styczny Pu
        //            binCoeff1 = GetBinCoeff(n - 1, 0);
        //            binCoeff2 = GetBinCoeff(m, 0);
        //            for (int i = 0; i <= n - 1; i++)
        //            {
        //                binCoeff2 = GetBinCoeff(m, 0);
        //                for (int j = 0; j <= m; j++)
        //                {
        //                    pu += binCoeff1 * binCoeff2 * getBernstein(i, n - 1, u) * getBernstein(j, m, v) * (ControlPoints[i + 1, j] - ControlPoints[i, j]);
        //                    binCoeff2 = binCoeff2 * (m - j) / (j + 1);
        //                    //pu += getBernstein(i, n-1, u)*getBernstein(j,m,v) * (ControlPoints[i + 1, j] - ControlPoints[i, j]);
        //                }
        //                    binCoeff1 = binCoeff1 * (n - 1 - i) / (i + 1);

        //            }

        //            // Wektor styczny Pv
        //            binCoeff1 = GetBinCoeff(n, 0);
        //            binCoeff2 = GetBinCoeff(m - 1, 0);
        //            for (int i = 0; i <= n; i++)
        //            {
        //                binCoeff2 = GetBinCoeff(m, 0);
        //                for (int j = 0; j <= m - 1; j++)
        //                {
        //                    pv += binCoeff1 * binCoeff2 * getBernstein(i, n, u) * getBernstein(j, m - 1, v) * (ControlPoints[i, j + 1] - ControlPoints[i, j]);
        //                    binCoeff2 = binCoeff2 * (m - 1 - j) / (j + 1);
        //                    //pv += getBernstein(i, n, u)*getBernstein(j,m-1,v) * (ControlPoints[i, j + 1] - ControlPoints[i, j]);
        //                }

        //                    binCoeff1 = binCoeff1 * (n - i) / (i + 1);
        //            }

        //            pu *= n;
        //            pv *= m;

        //            // Wektor normalny
        //            nuv = Vector3.Cross(pu, pv);
        //            nuv = -Vector3.Normalize(nuv);

        //            Vertices[ui, vi] = new Vertex(p, pu, pv, nuv);

        //            v += stepV;
        //        }
        //        u += stepU;
        //    }

        //    // Łączenie w trójkąty
        //    Triangles.Clear();
        //    for (int ui = 0; ui < fidelityU - 1; ui++)
        //    {
        //        for (int vi = 0; vi < fidelityV - 1; vi++)
        //        {
        //            Triangle t1 = new Triangle(Vertices[ui, vi], Vertices[ui + 1, vi], Vertices[ui, vi + 1]);
        //            Triangle t2 = new Triangle(Vertices[ui + 1, vi], Vertices[ui + 1, vi + 1], Vertices[ui, vi + 1]);

        //            Triangles.Add(t1);
        //            Triangles.Add(t2);
        //        }
        //    }

        //    // Obrót wierzchołków
        //    RotateVertices();

        //    float getBernstein(int i, int n, float t)
        //    {
        //        return /*GetBinCoeff(n, i) * */MathF.Pow(t, i) * MathF.Pow(1 - t, n - i);
        //    }
        //}


        public void SetAlphaAngle(int alphaAngle)
        {
            AlphaRadians = alphaAngle * MathF.PI / 180;
            RotateVertices();
        }
        public void SetBetaAngle(int betaAngle)
        {
            BetaRadians = betaAngle * MathF.PI / 180;
            RotateVertices();
        }

        private void RotateVertices()
        {
            Matrix4x4 rotationMatrix = Matrix4x4.CreateRotationZ(AlphaRadians) * Matrix4x4.CreateRotationX(BetaRadians);

            foreach (Vertex vertex in Vertices)
            {
                Vector3 p = Vector3.Transform(vertex.BeforeRotationState.P, rotationMatrix);
                Vector3 pu = Vector3.Transform(vertex.BeforeRotationState.Pu, rotationMatrix);
                Vector3 pv = Vector3.Transform(vertex.BeforeRotationState.Pv, rotationMatrix);
                Vector3 n = Vector3.Transform(vertex.BeforeRotationState.N, rotationMatrix);

                vertex.AfterRotationState = new Vertex.State(p, pu, pv, n);
            }
        }


        private int GetBinCoeff(int n, int k)
        {
            int r = 1;
            int d;
            if(k > n)
                return 0;

            for(d = 1; d<=k;d++)
            {
                r *= n--;
                r /= d;
            }

            return r;
        }
    }
}
