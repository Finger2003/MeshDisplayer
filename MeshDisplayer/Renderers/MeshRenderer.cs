﻿using MeshDisplayer.CoordinatesTransformers;
using MeshDisplayer.Model;
using MeshDisplayer.SceneModel;
using MeshDisplayer.Utils;
using System.Numerics;

namespace MeshDisplayer.Renderers
{
    public class MeshRenderer : IMeshRenderer
    {
        public bool DrawFilling { get; set; } = true;
        public bool DrawEdges { get; set; } = true;
        public bool DrawControlPoints { get; set; } = false;
        public ICoordinateTransformer2D CoordinateTransformer { get; set; }
        public DirectBitmap DirectBitmap { get; private set; }
        public Graphics G { get; private set; }

        private LightSource LightSource { get; } = new(Vector3.Zero, Color.White);


        public Func<float, float, Color> GetColor { get; set; }
        public Func<Triangle, float[], float, float, Vector3> GetNormalVector { get; set; }

        public ReflectionCoefficients ReflectionCoefficients { get; }
        public DirectBitmap TextureDirectBitmap { get; set; }
        public Vector3[,] NormalMap { get; set; }
        public Color MeshColor { get; set; }

        private ZBuffer ZBuffer { get; set; }
        public MeshRenderer(DirectBitmap directBitmap, Graphics bitmapGraphics, ICoordinateTransformer2D coordinateTransformer, ReflectionCoefficients reflectionCoefficients, DirectBitmap textureDirectBitmap, Vector3[,] normalMap)
        {
            DirectBitmap = directBitmap;
            G = bitmapGraphics;
            ZBuffer = new(directBitmap.Width, directBitmap.Height);
            CoordinateTransformer = coordinateTransformer;
            ReflectionCoefficients = reflectionCoefficients;
            TextureDirectBitmap = textureDirectBitmap;
            NormalMap = normalMap;

            GetColor = GetMeshRGBColor;
            GetNormalVector = GetNormalVectorFromVertices;
        }

        public void SetNewBitmap(DirectBitmap directBitmap, Graphics bitmapGraphics)
        {
            DirectBitmap = directBitmap;
            G = bitmapGraphics;
            ZBuffer = new(directBitmap.Width, directBitmap.Height);
        }

        public void RenderMesh(Mesh mesh, LightSource lightSource)
        {
            G.Clear(Color.White);


            ZBuffer.Clear(float.NegativeInfinity);

            if (DrawFilling)
            {
                lock (lightSource)
                {
                    LightSource.Position = lightSource.Position;
                    LightSource.Color = lightSource.Color;
                }

                Parallel.ForEach(mesh.Triangles, FillTriangle);
            }

            if (DrawEdges)
                foreach (Triangle triangle in mesh.Triangles)
                {
                    PointF v1 = new(triangle.V1.AfterRotationState.P.X, triangle.V1.AfterRotationState.P.Y);
                    PointF v2 = new(triangle.V2.AfterRotationState.P.X, triangle.V2.AfterRotationState.P.Y);
                    PointF v3 = new(triangle.V3.AfterRotationState.P.X, triangle.V3.AfterRotationState.P.Y);

                    G.DrawLine(Pens.Black, v1, v2);
                    G.DrawLine(Pens.Black, v2, v3);
                    G.DrawLine(Pens.Black, v3, v1);
                }

            if (DrawControlPoints)
            {
                int n = mesh.ControlPointsAfterRotation.GetLength(0);
                int m = mesh.ControlPointsAfterRotation.GetLength(1);
                for (int i = 0; i < n - 1; i++)
                    for (int j = 0; j < m; j++)
                    {
                        PointF p1 = new(mesh.ControlPointsAfterRotation[i, j].X, mesh.ControlPointsAfterRotation[i, j].Y);
                        PointF p2 = new(mesh.ControlPointsAfterRotation[i + 1, j].X, mesh.ControlPointsAfterRotation[i + 1, j].Y);
                        G.DrawLine(Pens.Red, p1, p2);
                    }

                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m - 1; j++)
                    {
                        PointF p1 = new(mesh.ControlPointsAfterRotation[i, j].X, mesh.ControlPointsAfterRotation[i, j].Y);
                        PointF p2 = new(mesh.ControlPointsAfterRotation[i, j + 1].X, mesh.ControlPointsAfterRotation[i, j + 1].Y);
                        G.DrawLine(Pens.Red, p1, p2);
                    }

                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                    {
                        PointF p = new(mesh.ControlPointsAfterRotation[i, j].X, mesh.ControlPointsAfterRotation[i, j].Y);
                        G.FillEllipse(Brushes.Red, p.X - 4, p.Y - 4, 8, 8);
                    }
            }
        }

        private void FillTriangle(Triangle triangle)
        {

            Point[] trianglePoints =
            [
                new((int)Math.Round(triangle.V1.AfterRotationState.P.X), (int)Math.Round(triangle.V1.AfterRotationState.P.Y)),
                new((int)Math.Round(triangle.V2.AfterRotationState.P.X), (int)Math.Round(triangle.V2.AfterRotationState.P.Y)),
                new((int)Math.Round(triangle.V3.AfterRotationState.P.X), (int)Math.Round(triangle.V3.AfterRotationState.P.Y))
            ];

            int[] sortedIndexes = Enumerable.Range(0, trianglePoints.Length).ToArray();
            Array.Sort(sortedIndexes, (i1, i2) => trianglePoints[i1].Y.CompareTo(trianglePoints[i2].Y));


            int polygonYMin = trianglePoints[sortedIndexes[0]].Y; //trianglePoints.Min(p => p.Y);
            int polygonYMax = trianglePoints[sortedIndexes[^1]].Y; //trianglePoints.Max(p => p.Y);
            int sortedIndex = 0;

            List<AETElement> AET = [];

            for (int scanline = polygonYMin; scanline <= polygonYMax; scanline++)
            {
                AET.RemoveAll(edge => edge.P1.Y == edge.P2.Y);

                int index = sortedIndexes[sortedIndex];
                Point point = trianglePoints[index];


                // Jeśli punkt był na scanline zaktualizuj AET o krawędzie, które go zawierają
                while (point.Y == scanline - 1)
                {
                    int previousIndex = index == 0 ? trianglePoints.Length - 1 : index - 1;
                    int nextIndex = index == trianglePoints.Length - 1 ? 0 : index + 1;

                    Point previousPoint = trianglePoints[previousIndex];
                    Point nextPoint = trianglePoints[nextIndex];

                    checkAndUpdateAET(previousPoint, point);
                    checkAndUpdateAET(nextPoint, point);

                    index = sortedIndexes[++sortedIndex];
                    point = trianglePoints[index];
                }

                void checkAndUpdateAET(Point p1, Point p2)
                {
                    if (p1.Y > p2.Y)
                        AET.Add(new AETElement(p1, p2));
                    else
                        AET.RemoveAll(edge => edge.P1 == p2 && edge.P2 == p1);
                }

                // Posortowanie AET w kierunku rosnących X
                AET.Sort((e1, e2) => e1.X.CompareTo(e2.X));

                // Transformacja układu współrzędnych
                int transformedY = CoordinateTransformer.TransformY(scanline);

                // Aktualnie rozważany punkt
                Point p = new(0, scanline);

                // Dla kolejnych par krawędzi 0-1, 2-3
                for (int i = 0; i < AET.Count - 1; i += 2)
                {
                    AETElement e1 = AET[i];
                    AETElement e2 = AET[i + 1];

                    int x1 = (int)e1.X;
                    int x2 = (int)e2.X;

                    if (transformedY >= 0 && transformedY < DirectBitmap.Height)
                        // Wypełnianie scanlinii między krawędziami
                        for (int x = x1; x < x2; x++)
                        {
                            // Transformacja układu współrzędnych
                            int transformedX = CoordinateTransformer.TransformX(x);
                            if (transformedX < 0 || transformedX >= DirectBitmap.Width)
                                continue;

                            p.X = x;
                            float[] coords = MathHelper.GetBaricentricCoordinates(p, trianglePoints[0], trianglePoints[1], trianglePoints[2]);

                            if (coords.Any(x => float.IsNaN(x) || float.IsPositiveInfinity(x) || float.IsNegativeInfinity(x)))
                                continue;

                            Vector3 P = MathHelper.InterpolateVectorFromBaricentric(triangle.V1.AfterRotationState.P, triangle.V2.AfterRotationState.P, triangle.V3.AfterRotationState.P, coords);


                            if (!ZBuffer.CheckIfBiggerAndSet(transformedX, transformedY, P.Z))
                                continue;

                            float u = MathHelper.InterpolateFloatFromBaricentric(triangle.V1.U, triangle.V2.U, triangle.V3.U, coords);
                            float v = MathHelper.InterpolateFloatFromBaricentric(triangle.V1.V, triangle.V2.V, triangle.V3.V, coords);
                            Color color = getInterpolatedColor(coords, u, v, P);

                            DirectBitmap.SetPixel(transformedX, transformedY, color);
                        }
                }

                // Aktualizacja wartości x dla nowej scanlinii
                for (int i = 0; i < AET.Count; i++)
                    AET[i].X += AET[i].InverseSlope;
            }
            Color getInterpolatedColor(float[] coords, float u, float v, Vector3 P)
            {
                Color color = GetColor(u, v);
                Color lightColor = LightSource.Color;
                Vector3 lightPosition = LightSource.Position;


                Vector3 Il = new(lightColor.R, lightColor.G, lightColor.B);
                Vector3 Io = new(color.R, color.G, color.B);
                Vector3 L = lightPosition - P;
                Vector3 N = GetNormalVector(triangle, coords, u, v);
                Vector3 V = Vector3.UnitZ;


                Il /= 255;
                Io /= 255;

                L = Vector3.Normalize(L);
                N = Vector3.Normalize(N);

                float NLDot = Vector3.Dot(N, L);
                float NLCoeff = Math.Sign(Vector3.Dot(V, N));
                Vector3 R = 2 * NLDot * N - L;
                R = Vector3.Normalize(R);


                float kd = ReflectionCoefficients.Kd;
                float ks = ReflectionCoefficients.Ks;
                float m = ReflectionCoefficients.M;

                Vector3 I = Il * Io * (kd * Math.Max(0, NLCoeff * NLDot) + ks * MathF.Pow(Math.Max(0, Vector3.Dot(V, R)), m));

                I = Vector3.Clamp(I, Vector3.Zero, Vector3.One);
                I *= 255;

                return Color.FromArgb((int)I.X, (int)I.Y, (int)I.Z);
            }
        }

        public Color GetMeshRGBColor(float u, float v)
        {
            return MeshColor;
        }
        public Color GetTextureColor(float u, float v)
        {
            u = Math.Clamp(u, 0, 1);
            v = Math.Clamp(v, 0, 1);

            int x = (int)Math.Round(u * (TextureDirectBitmap.Width - 1));
            int y = (int)Math.Round(v * (TextureDirectBitmap.Height - 1));

            return TextureDirectBitmap.GetPixel(x, y);
        }

        public Vector3 GetNormalVectorFromNormalMap(Triangle triangle, float[] coords, float u, float v)
        {
            u = Math.Clamp(u, 0, 1);
            v = Math.Clamp(v, 0, 1);

            Vector3 normalMapN = NormalMap[(int)(u * (NormalMap.GetLength(0) - 1)), (int)(v * (NormalMap.GetLength(1) - 1))];

            Vector3 Pu = MathHelper.InterpolateVectorFromBaricentric(triangle.V1.AfterRotationState.Pu, triangle.V2.AfterRotationState.Pu, triangle.V3.AfterRotationState.Pu, coords);
            Vector3 Pv = MathHelper.InterpolateVectorFromBaricentric(triangle.V1.AfterRotationState.Pv, triangle.V2.AfterRotationState.Pv, triangle.V3.AfterRotationState.Pv, coords);
            Vector3 N = MathHelper.InterpolateVectorFromBaricentric(triangle.V1.AfterRotationState.N, triangle.V2.AfterRotationState.N, triangle.V3.AfterRotationState.N, coords);

            Pu = Vector3.Normalize(Pu);
            Pv = Vector3.Normalize(Pv);
            N = Vector3.Normalize(N);

            Matrix4x4 T = new(
                Pu.X, Pv.X, N.X, 0,
                Pu.Y, Pv.Y, N.Y, 0,
                Pu.Z, Pv.Z, N.Z, 0,
                0, 0, 0, 1
            );

            normalMapN = Vector3.Transform(normalMapN, T);
            return Vector3.Normalize(normalMapN);
        }

        public Vector3 GetNormalVectorFromVertices(Triangle triangle, float[] coords, float u, float v)
        {
            Vector3 N = MathHelper.InterpolateVectorFromBaricentric(triangle.V1.AfterRotationState.N, triangle.V2.AfterRotationState.N, triangle.V3.AfterRotationState.N, coords);
            return Vector3.Normalize(N);
        }
    }
}
