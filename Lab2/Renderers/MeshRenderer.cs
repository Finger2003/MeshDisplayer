using Lab2.CoordinatesTransformers;
using Lab2.Model;
using System.Numerics;

namespace Lab2.Renderers
{
    public class MeshRenderer : IMeshRenderer
    {
        public bool DrawFilling { get; set; }
        public bool DrawEdges { get; set; }
        public ICoordinateTransformer2D CoordinateTransformer { get; set; }
        public DirectBitmap DirectBitmap { get; set; }
        public Graphics G { get; set; }

        private LightSource LightSource { get; set; } = new(Vector3.Zero, Color.White);


        public Func<float, float, Color> GetColor { get; set; }
        public Func<Triangle, float[], float, float, Vector3> GetNormalVector { get; set; }

        public ReflectionCoefficients ReflectionCoefficients { get; }
        public DirectBitmap TextureDirectBitmap { get; set; }
        public Vector3[,] NormalMap { get; set; }
        public Color MeshColor { get; set; }

        public MeshRenderer(DirectBitmap directBitmap, ICoordinateTransformer2D coordinateTransformer, ReflectionCoefficients reflectionCoefficients, DirectBitmap textureDirectBitmap, Vector3[,] normalMap)
        {
            DirectBitmap = directBitmap;
            CoordinateTransformer = coordinateTransformer;
            ReflectionCoefficients = reflectionCoefficients;
            TextureDirectBitmap = textureDirectBitmap;
            NormalMap = normalMap;

            GetColor = GetMeshRGBColor;
            GetNormalVector = GetNormalVectorFromVertices;
        }

        public void RenderMesh(Mesh mesh, LightSource lightSource)
        {
            //if (mesh is null)
            //    return;

            //using Graphics G = Graphics.FromImage(DirectBitmap.Bitmap);
            //G.ScaleTransform(1, -1);
            //G.TranslateTransform(DirectBitmap.Bitmap.Width / 2, -DirectBitmap.Bitmap.Height / 2);

            G.Clear(Color.White);


            if (DrawFilling)
            {
                lock (lightSource)
                {
                    LightSource.Position = lightSource.Position;
                    LightSource.Color = lightSource.Color;
                }

                Parallel.ForEach(mesh.Triangles, fillTriangle);
            }

            if (DrawEdges)
            {
                foreach (Triangle triangle in mesh.Triangles)
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

        private void fillTriangle(Triangle triangle)
        {

            Point[] trianglePoints =
            [
                new Point((int)Math.Round(triangle.V1.AfterRotationState.P.X), (int)Math.Round(triangle.V1.AfterRotationState.P.Y)),
                new Point((int)Math.Round(triangle.V2.AfterRotationState.P.X), (int)Math.Round(triangle.V2.AfterRotationState.P.Y)),
                new Point((int)Math.Round(triangle.V3.AfterRotationState.P.X), (int)Math.Round(triangle.V3.AfterRotationState.P.Y))
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
                    {
                        // Wypełnianie scanlinii między krawędziami
                        for (int x = x1; x < x2; x++)
                        {
                            p.X = x;
                            float[] coords = getBaricentricCoords(p);

                            if (coords.Contains(float.NaN))
                                continue;

                            float u = triangle.V1.U * coords[0] + triangle.V2.U * coords[1] + triangle.V3.U * coords[2];
                            float v = triangle.V1.V * coords[0] + triangle.V2.V * coords[1] + triangle.V3.V * coords[2];

                            Color color = getColor(coords, u, v);

                            // Transformacja układu współrzędnych
                            int transformedX = CoordinateTransformer.TransformX(x);

                            if (transformedX >= 0 && transformedX < DirectBitmap.Width)
                                DirectBitmap.SetPixel(transformedX, transformedY, color);
                        }
                    }
                }

                // Aktualizacja wartości x dla nowej scanlinii
                for (int i = 0; i < AET.Count; i++)
                    AET[i].X += AET[i].InverseSlope;


                Color getColor(float[] coords, float u, float v)
                {
                    Color color = GetColor(u, v);
                    Color lightColor = LightSource.Color;
                    Vector3 lightPosition = LightSource.Position;


                    Vector3 Il = new(lightColor.R, lightColor.G, lightColor.B);
                    Vector3 Io = new(color.R, color.G, color.B);
                    Vector3 P = triangle.V1.AfterRotationState.P * coords[0] + triangle.V2.AfterRotationState.P * coords[1] + triangle.V3.AfterRotationState.P * coords[2];
                    Vector3 L = lightPosition - P;
                    Vector3 N = GetNormalVector(triangle, coords, u, v);
                    Vector3 V = new(0, 0, 1);

                    Il = Vector3.Normalize(Il);
                    Io = Vector3.Normalize(Io);
                    L = Vector3.Normalize(L);
                    N = Vector3.Normalize(N);

                    Vector3 R = 2 * Vector3.Dot(N, L) * N - L;
                    R = Vector3.Normalize(R);


                    float kd = ReflectionCoefficients.Kd;
                    float ks = ReflectionCoefficients.Ks;
                    float m = ReflectionCoefficients.M;

                    Vector3 I = kd * Il * Io * Math.Max(0, Vector3.Dot(L, N)) + ks * Il * Io * MathF.Pow(Math.Max(0, Vector3.Dot(R, V)), m);

                    I = Vector3.Clamp(I, new Vector3(0, 0, 0), new Vector3(1, 1, 1));
                    I *= 255;

                    return Color.FromArgb((int)I.X, (int)I.Y, (int)I.Z);
                }

                float[] getBaricentricCoords(Point p)
                {
                    float[] coords = new float[3];
                    float invertedS = (float)1 / getDoubledSarea(trianglePoints[0], trianglePoints[1], trianglePoints[2]);
                    //float invertedS = 1 / s;
                    coords[0] = getDoubledSarea(p, trianglePoints[1], trianglePoints[2]) * invertedS;
                    coords[1] = getDoubledSarea(trianglePoints[0], p, trianglePoints[2]) * invertedS;
                    coords[2] = getDoubledSarea(trianglePoints[0], trianglePoints[1], p) * invertedS;

                    return coords;
                }

                int getDoubledSarea(Point p1, Point p2, Point p3)
                {
                    return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
                }
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

            if (x >= TextureDirectBitmap.Width || x < 0 || y >= TextureDirectBitmap.Height || y < 0)
            {

            }

            return TextureDirectBitmap.GetPixel(x, y);
        }

        public Vector3 GetNormalVectorFromNormalMap(Triangle triangle, float[] coords, float u, float v)
        {
            Vector3 N = GetNormalVectorFromVertices(triangle, coords, u, v);

            u = Math.Clamp(u, 0, 1);
            v = Math.Clamp(v, 0, 1);

            Vector3 normalMapN = NormalMap[(int)(u * (NormalMap.GetLength(0) - 1)), (int)(v * (NormalMap.GetLength(1) - 1))];
            Vector3 Pu = triangle.V1.AfterRotationState.Pu * coords[0] + triangle.V2.AfterRotationState.Pu * coords[1] + triangle.V3.AfterRotationState.Pu * coords[2];
            Vector3 Pv = triangle.V1.AfterRotationState.Pv * coords[0] + triangle.V2.AfterRotationState.Pv * coords[1] + triangle.V3.AfterRotationState.Pv * coords[2];

            Matrix4x4 T = new Matrix4x4(
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
            Vector3 N = triangle.V1.AfterRotationState.N * coords[0] + triangle.V2.AfterRotationState.N * coords[1] + triangle.V3.AfterRotationState.N * coords[2];
            return Vector3.Normalize(N);
        }
    }
}
