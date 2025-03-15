namespace MeshDisplayer.CoordinatesTransformers
{
    public class CenterCoordinateTransformer2D(int width, int height) : ICoordinateTransformer2D
    {
        public int Width { get; set; } = width;
        public int Height { get; set; } = height;

        public int TransformX(int x) => x + Width / 2;
        public int TransformY(int y) => Height / 2 - y;
    }
}
