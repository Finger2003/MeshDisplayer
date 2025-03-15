using System.Numerics;

namespace MeshDisplayer.SceneModel
{
    public class LightSource(Vector3 position, Color color)
    {
        public Vector3 Position { get; set; } = position;
        public Color Color { get; set; } = color;
    }
}
