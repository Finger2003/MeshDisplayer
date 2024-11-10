using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.SceneModel
{
    public class ReflectionCoefficients
    {
        public float Ks { get; set; }
        public float Kd { get; set; }
        public float M { get; set; }
        public ReflectionCoefficients(float ks, float kd, float m)
        {
            Ks = ks;
            Kd = kd;
            M = m;
        }
    }
}
