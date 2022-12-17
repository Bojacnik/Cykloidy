using Data.Primitives.Implementations;

namespace Data.Advanced.Implementations
{
    public class BasicCycloid
    {
        public readonly Circle circle;
        public readonly Point point;
        private readonly double t;
        private readonly double a;

        public BasicCycloid(Circle circle, Point point, double pointOffset, double angle)
        {
            this.circle = circle;
            this.point = point;
            this.a = circle.Radius + pointOffset;
            this.t = angle;
        }

        public void Recalculate(double pushX, double pushY)
        {
            circle.Push(pushX, pushY);
            this.point.coordinates.x = a * (t - Math.Sin(t));
            this.point.coordinates.y = a * (1 - Math.Cos(t));
        }
    }
}
