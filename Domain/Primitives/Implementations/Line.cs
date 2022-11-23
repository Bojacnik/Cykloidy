using Domain.Primitives.Abstractions;

namespace Domain.Primitives.Implementations
{
    public class Line : Geometry
    {
        public Vector2 Start;
        public Vector2 End;

        public Line(Vector2 start, Vector2 end)
        {
            Start = start;
            End = end;
        }

        public override void Push(double value)
        {
            Start.x += value;
            End.x += value;
        }
    }
}
