using Lab2.Model;
using Lab2.Renderers;
using System.Numerics;

namespace Lab2.SceneModel
{
    public class Scene(Mesh mesh, LightSource lightSource, IMeshRenderer meshRenderer)
    {
        public Mesh Mesh { get; set; } = mesh;
        public LightSource LightSource { get; set; } = lightSource;
        public IMeshRenderer MeshRenderer { get; set; } = meshRenderer;

        public void RenderScene()
        {
            MeshRenderer.RenderMesh(Mesh, LightSource);
        }


        private float LightRadiusStep { get; set; } = 2;
        private float LightAngleStep { get; set; } = 0.1f;
        private static float MaxLightRadius { get; } = 500;
        private static float MinLightRadius { get; } = 0;
        private float LightRadius { get; set; }
        private float LightAngle { get; set; }

        public void MoveLightSource()
        {
            if (LightRadius > MaxLightRadius || LightRadius < MinLightRadius)
            {
                LightRadiusStep *= -1;
                LightAngleStep *= -1;
            }

            LightRadius += LightRadiusStep;
            LightAngle += LightAngleStep;

            float x = LightRadius * MathF.Cos(LightAngle);
            float y = LightRadius * MathF.Sin(LightAngle);

            lock (LightSource)
            {
                LightSource.Position = new Vector3(x, y, LightSource.Position.Z);
            }



        }
        public void ResetLightSourcePosition()
        {
            LightRadius = 0;
            LightAngle = 0;
            lock (LightSource)
            {
                LightSource.Position = new Vector3(0, 0, LightSource.Position.Z);
            }
        }
    }
}
