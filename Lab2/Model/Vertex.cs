using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Model
{
    public class Vertex
    {
        public record struct State(Vector3 P, Vector3 Pu, Vector3 Pv, Vector3 N) { }

        public State BeforeRotationState { get; set; }
        public State AfterRotationState { get; set; }
        //public Vertex(float x, float y, float z)
        //{
        //    Vector3 p = new(x, y, z);
        //    Vector3 pu = new(0, 0, 0);
        //    Vector3 pv = new(0, 0, 0);
        //    Vector3 n = new(0, 0, 0);

        //    BeforeRotationState = new State(p, pu, pv, n);

        //    AfterRotationState = BeforeRotationState;
        //}

        public Vertex (Vector3 p, Vector3 pu, Vector3 pv, Vector3 n)
        {
            BeforeRotationState = new State(p, pu, pv, n);
            AfterRotationState = BeforeRotationState;
        }
    }
}
