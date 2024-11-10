using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class LightSource
    {
        public Vector3 Position { get; set; }
        public Color Color { get; set; }

        public LightSource(Vector3 position, Color color)
        {
            Position = position;
            Color = color;
        }
    }
}
