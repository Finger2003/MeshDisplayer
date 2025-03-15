namespace MeshDisplayer.CoordinatesTransformers
{
    public interface ICoordinateTransformer2D
    {
        public int TransformX(int x);
        public int TransformY(int y);
    }
}
