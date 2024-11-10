using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.SceneModel
{
    public class LightSource(Vector3 position, Color color)
    {
        public Vector3 Position { get; set; } = position;
        public Color Color { get; set; } = color;
    }
}
