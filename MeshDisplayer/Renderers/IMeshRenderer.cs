using MeshDisplayer.Model;
using MeshDisplayer.SceneModel;

namespace MeshDisplayer.Renderers
{
    public interface IMeshRenderer
    {
        public void RenderMesh(Mesh mesh, LightSource lightSource);
    }
}
