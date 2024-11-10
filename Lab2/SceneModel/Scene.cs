using Lab2.Model;
using Lab2.Renderers;
using System.Numerics;

namespace Lab2.SceneModel
{
    public class Scene
    {
        public Mesh Mesh { get; set; }
        public LightSource LightSource { get; set; }
        public IMeshRenderer MeshRenderer { get; set; }

        public Scene(Mesh mesh, LightSource lightSource, IMeshRenderer meshRenderer)
        {
            Mesh = mesh;
            LightSource = lightSource;
            MeshRenderer = meshRenderer;
        }

        public void RenderScene()
        {
            MeshRenderer.RenderMesh(Mesh, LightSource);
        }


        private float LightRadiusStep { get; set; } = 2;
        private float LightAngleStep { get; set; } = 0.1f;
        private static float MaxLightRadius { get; set; } = 500;
        private static float MinLightRadius { get; set; } = 0;
        private float LightRadius { get; set; } = 0;
        private float LightAngle { get; set; } = 0;

        public void MoveLightSource()
        {

            LightRadius += LightRadiusStep;
            LightAngle += LightAngleStep;

            float x = LightRadius * MathF.Cos(LightAngle);
            float y = LightRadius * MathF.Sin(LightAngle);

            lock (LightSource)
                LightSource.Position = new(x, y, LightSource.Position.Z);


            if (LightRadius >= MaxLightRadius || LightRadius <= MinLightRadius)
            {
                LightRadiusStep *= -1;
                LightAngleStep *= -1;
            }
        }
        public void ResetLightSourcePosition()
        {
            LightRadius = 0;
            LightAngle = 0;
            lock (LightSource)
                LightSource.Position = new Vector3(0, 0, LightSource.Position.Z);
        }
    }
}
