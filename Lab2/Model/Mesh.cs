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

        public Mesh(Vector3[,] controlPoints, int fidelityU, int fidelityV, int alphaAngle, int betaAngle)
        {
            ControlPoints = controlPoints;
            SetFidelty(fidelityU, fidelityV);
            SetAlphaAngle(alphaAngle);
            SetBetaAngle(betaAngle);
        }

        public void SetFidelty(int fidelityU, int fidelityV)
        {
            Vertices = new Vertex[fidelityU, fidelityV];


            float stepU = 1.0f / fidelityU;
            float stepV = 1.0f / fidelityV;

            int n = ControlPoints.GetLength(0) - 1;
            int m = ControlPoints.GetLength(1) - 1;


            // Potęgi u i v oraz 1-u i 1-v - pierwszy wymiar: kolejne u i v, drugi wymiar: kolejne potęgi
            float[,] uPowers = new float[fidelityU, n + 1];
            float[,] vPowers = new float[fidelityV, m + 1];
            float[,] OneMinusUPowers = new float[fidelityU, n + 1];
            float[,] OneMinusVPowers = new float[fidelityV, m + 1];


            for (int i = 0; i < fidelityU; i++)
                uPowers[i, 0] = 1;

            for (int i = 0; i < fidelityV; i++)
                vPowers[i, 0] = 1;



            float u, v;
            u = 0;
            for (int i = 0; i < fidelityU; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    uPowers[i, j] = uPowers[i, j - 1] * u;
                }
                u += stepU;
            }

            v = 0;
            for (int i = 0; i < fidelityV; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    vPowers[i, j] = vPowers[i, j - 1] * v;
                }
                v += stepV;
            }



            for (int i = 0; i < fidelityU; i++)
                OneMinusUPowers[i, n] = 1;

            for (int i = 0; i < fidelityV; i++)
                OneMinusVPowers[i, m] = 1;

            float oneMinusU, oneMinusV;
            oneMinusU = 1;
            for (int i = 0; i < fidelityU; i++)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    OneMinusUPowers[i, j] = OneMinusUPowers[i, j + 1] * oneMinusU;
                }
                oneMinusU -= stepU;
            }

            oneMinusV = 1;
            for (int i = 0; i < fidelityV; i++)
            {
                for (int j = m - 1; j >= 0; j--)
                {
                    OneMinusVPowers[i, j] = OneMinusVPowers[i, j + 1] * oneMinusV;
                }
                oneMinusV -= stepV;
            }




            // Pierwszy wymiar: kolejne u, drugi wymiar: kolejne i, trzeci wymiar: n i n - 1
            float[,,] Bu = new float[fidelityU, n + 1, 2];
            // Pierwszy wymiar: kolejne v, drugi wymiar: kolejne i, trzeci wymiar: m i m - 1
            float[,,] Bv = new float[fidelityV, m + 1, 2];


            // Funkcje bazowe Bernsteina dla u
            u = 0;
            for (int i = 0; i < fidelityU; i++)
            {
                int binCoeff0 = GetBinCoeff(n, 0);
                int binCoeff1 = GetBinCoeff(n - 1, 0);
                for (int j = 0; j <= n; j++)
                {
                    Bu[i, j, 0] = binCoeff0 * uPowers[i, j] * OneMinusUPowers[i, n - j];
                    binCoeff0 = binCoeff0 * (n - j) / (j + 1);

                    Bu[i, j, 1] = binCoeff1 * uPowers[i, j] * OneMinusUPowers[i, n - j];
                    binCoeff1 = binCoeff1 * (n - j - 1) / (j + 1);
                }
                u += stepU;
            }


            // Funkcje bazowe Bernsteina dla v
            v = 0;
            for (int i = 0; i < fidelityV; i++)
            {
                int binCoeff0 = GetBinCoeff(m, 0);
                int binCoeff1 = GetBinCoeff(m - 1, 0);
                for (int j = 0; j <= m; j++)
                {
                    Bv[i, j, 0] = binCoeff0 * vPowers[i, j] * OneMinusVPowers[i, m - j];
                    binCoeff0 = binCoeff0 * (m - j) / (j + 1);

                    Bv[i, j, 1] = binCoeff0 * vPowers[i, j] * OneMinusVPowers[i, m - j];
                    binCoeff1 = binCoeff1 * (m - j - 1) / (j + 1);
                }
                v += stepV;
            }


            // Wyznaczanie wierzchołków
            for (int ui = 0; ui < fidelityU; ui++)
            {
                for (int vi = 0; vi < fidelityV; vi++)
                {
                    Vector3 p = new(0, 0, 0);
                    Vector3 pu = new(0, 0, 0);
                    Vector3 pv = new(0, 0, 0);
                    Vector3 nuv;


                    for (int i = 0; i <= n - 1; i++)
                        for (int j = 0; j <= m - 1; j++)
                        {
                            p += Bu[ui, i, 0] * Bv[vi, j, 0] * ControlPoints[i, j];
                            pu += Bu[ui, i, 1] * Bv[vi, j, 0] * (ControlPoints[i + 1, j] - ControlPoints[i, j]);
                            pv += Bu[ui, i, 0] * Bv[vi, j, 1] * (ControlPoints[i, j + 1] - ControlPoints[i, j]);
                        }

                    p += Bu[ui, n, 0] * Bv[vi, m, 0] * ControlPoints[n, m];

                    for (int i = 0; i <= n - 1; i++)
                        pu += Bu[ui, i, 1] * Bv[vi, m, 0] * (ControlPoints[i + 1, m] - ControlPoints[i, m]);

                    for (int j = 0; j <= m - 1; j++)
                        pv += Bu[ui, n, 0] * Bv[vi, j, 1] * (ControlPoints[n, j + 1] - ControlPoints[n, j]);

                    pu *= n;
                    pv *= m;
                    nuv = Vector3.Cross(pu, pv);

                    Vertices[ui, vi] = new Vertex(p, pu, pv, nuv);
                }
            }


            for (int ui = 0; ui < n; ui++)
            {
                for (int vi = 0; vi < m; vi++)
                {
                    Triangle t1 = new Triangle(Vertices[ui, vi], Vertices[ui + 1, vi], Vertices[ui, vi + 1]);
                    Triangle t2 = new Triangle(Vertices[ui + 1, vi], Vertices[ui + 1, vi + 1], Vertices[ui, vi + 1]);

                    Triangles.Add(t1);
                    Triangles.Add(t2);
                }
            }
        }
        public void SetAlphaAngle(int alphaAngle)
        {
            //Vertices = new List<Vertex>();
            //Triangles = new List<Triangle>();
        }

        public void SetBetaAngle(int betaAngle)
        {
            //Vertices = new List<Vertex>();
            //Triangles = new List<Triangle>();
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
