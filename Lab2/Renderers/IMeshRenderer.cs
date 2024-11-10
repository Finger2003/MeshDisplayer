using Lab2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Renderers
{
    public interface IMeshRenderer
    {
        public void RenderMesh(Mesh mesh, LightSource lightSource);
        //public Bitmap GetRenderedBitmap();
    }
}
