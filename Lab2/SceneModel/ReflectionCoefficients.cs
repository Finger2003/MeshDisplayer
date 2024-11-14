namespace Lab2.SceneModel
{
    public class ReflectionCoefficients(float ks, float kd, float m)
    {
        public float Ks { get; set; } = ks;
        public float Kd { get; set; } = kd;
        public float M { get; set; } = m;
    }
}
