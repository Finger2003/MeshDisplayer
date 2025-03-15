using System.Numerics;

namespace MeshDisplayer.Utils
{
    public static class MathHelper
    {
        public static float DegreesToRadians(float angle) => angle * MathF.PI / 180;
        public static Vector3 InterpolateVectorFromBaricentric(Vector3 a, Vector3 b, Vector3 c, float[] coordinates) => a * coordinates[0] + b * coordinates[1] + c * coordinates[2];
        public static float InterpolateFloatFromBaricentric(float a, float b, float c, float[] coordinates) => a * coordinates[0] + b * coordinates[1] + c * coordinates[2];

        public static int GetBinCoeff(int n, int k)
        {
            int r = 1;
            int d;
            if (k > n)
                return 0;

            for (d = 1; d <= k; d++)
            {
                r *= n--;
                r /= d;
            }

            return r;
        }

        public static float[] GetBaricentricCoordinates(Point p, Point a, Point b, Point c)
        {
            float[] coords = new float[3];
            float invertedS = (float)1 / GetDoubledSarea(a, b, c);

            coords[0] = GetDoubledSarea(p, b, c) * invertedS;
            coords[1] = GetDoubledSarea(a, p, c) * invertedS;
            coords[2] = GetDoubledSarea(a, b, p) * invertedS;

            return coords;
        }
        public static int GetDoubledSarea(Point p1, Point p2, Point p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }

    }
}
