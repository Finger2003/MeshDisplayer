using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Model
{
    public class Vertex
    {
        public struct State
        {
            public Vector3 P;
            public Vector3 Pu;
            public Vector3 Pv;
            public Vector3 N;
        }

        public State BeforeRotationState { get; set; }
        public State AfterRotationState { get; set; }
    }
}
