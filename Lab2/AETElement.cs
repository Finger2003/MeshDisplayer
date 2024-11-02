namespace Lab2
{
    public class AETElement
    {
        public Point P1 { get; set; }
        public Point P2 { get; set; }
        public float X { get; set; }
        public float InverseSlope { get; set; } = 0;

        public AETElement(Point p1, Point p2)
        {
            P1 = p1;
            P2 = p2;
            X = p2.X;
            InverseSlope = (float)(p2.X - p1.X) / (p2.Y - p1.Y);
        }
    }
}
