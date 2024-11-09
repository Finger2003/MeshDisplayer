using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.CoordinatesTransformers
{
    public class CenterCoordinateTransformer2D : ICoordinateTransformer2D
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public CenterCoordinateTransformer2D(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public int TransformX(int x) => x + Width / 2;
        public int TransformY(int y) => Height / 2 - y;
    }
}
