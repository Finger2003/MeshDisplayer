using System.Numerics;

namespace Lab2.SceneModel
{
    public class LightSource(Vector3 position, Color color)
    {
        public Vector3 Position { get; set; } = position;
        public Color Color { get; set; } = color;
    }
}
