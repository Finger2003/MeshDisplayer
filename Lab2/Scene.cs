using Lab2.Model;
using Lab2.Renderers;
using System.Numerics;

namespace Lab2
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

        //public Bitmap GetRenderedBitmap()
        //{
        //    RenderScene();
        //    return MeshRenderer.GetRenderedBitmap();
        //}



        private float LightRadiusStep { get; set; } = 2;
        private float LightAngleStep { get; set; } = 0.1f;
        private static float MaxLightRadius { get; set; } = 500;
        private static float MinLightRadius { get; set; } = 0;
        private float LightRadius { get; set; } = 0;
        private float LightAngle { get; set; } = 0;

        public void MoveLightSource()
        {
            //LightPositionMutex.WaitOne();

            LightRadius += LightRadiusStep;
            LightAngle += LightAngleStep;

            float x = LightRadius * MathF.Cos(LightAngle);
            float y = LightRadius * MathF.Sin(LightAngle);

            //Vector3 lightPosition = LightSource.Position;

            //lightPosition.X = x;
            //lightPosition.Y = y;

            lock (LightSource)
                LightSource.Position = new(x, y, LightSource.Position.Z);

            //LightPosition = new Vector3(x, y, LightPosition.Z);

            if (LightRadius >= MaxLightRadius || LightRadius <= MinLightRadius)
            {
                LightRadiusStep *= -1;
                LightAngleStep *= -1;
            }

            //LightPositionMutex.ReleaseMutex();
            //pictureBox.Invalidate();

        }
        public void ResetLightSourcePosition()
        {
            LightRadius = 0;
            LightAngle = 0;
            lock(LightSource)
                LightSource.Position = new Vector3(0, 0, LightSource.Position.Z);
        }
    }
}
