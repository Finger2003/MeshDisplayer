namespace Lab2.Utils
{
    public class AETElement(Point p1, Point p2)
    {
        public Point P1 { get; set; } = p1;
        public Point P2 { get; set; } = p2;
        public float X { get; set; } = p2.X;
        public float InverseSlope { get; set; } = (float)(p2.X - p1.X) / (p2.Y - p1.Y);
    }
}
