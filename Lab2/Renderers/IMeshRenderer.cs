using Lab2.Model;
using Lab2.SceneModel;

namespace Lab2.Renderers
{
    public interface IMeshRenderer
    {
        public void RenderMesh(Mesh mesh, LightSource lightSource);
    }
}
