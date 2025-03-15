namespace MeshDisplayer.Utils
{
    public class ZBuffer(int width, int height)
    {
        private float[,] Buffer { get; } = new float[width, height];
        private int Width { get; } = width;

        private int Height { get; } = height;

        public void Clear(float value)
        {
            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++)
                    Buffer[i, j] = value;
        }

        public bool CheckIfBiggerAndSet(int x, int y, float z)
        {
            return CheckAndSet(x, y, z, (a, b) => a > b);
        }

        private bool CheckAndSet(int x, int y, float z, Func<float, float, bool> comparerFunc)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
                return false;

            if (comparerFunc(z, Buffer[x, y]))
            {
                Buffer[x, y] = z;
                return true;
            }

            return false;
        }
    }
}
