using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.CoordinatesTransformers
{
    public interface ICoordinateTransformer2D
    {
        public int TransformX(int x);
        public int TransformY(int y);
    }
}
