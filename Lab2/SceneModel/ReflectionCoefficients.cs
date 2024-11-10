using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.SceneModel
{
    public class ReflectionCoefficients(float ks, float kd, float m)
    {
        public float Ks { get; set; } = ks;
        public float Kd { get; set; } = kd;
        public float M { get; set; } = m;
    }
}
