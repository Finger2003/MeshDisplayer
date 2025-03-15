using System.Numerics;

namespace MeshDisplayer.Model
{
    public class Vertex
    {
        public record struct State(Vector3 P, Vector3 Pu, Vector3 Pv, Vector3 N) { }

        public State BeforeRotationState { get; set; }
        public State AfterRotationState { get; set; }

        public float U { get; }
        public float V { get; }

        public Vertex(Vector3 p, Vector3 pu, Vector3 pv, Vector3 n, float u, float v)
        {
            BeforeRotationState = new State(p, pu, pv, n);
            AfterRotationState = BeforeRotationState;
            U = u;
            V = v;
        }
    }
}
