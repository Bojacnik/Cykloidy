using Data.Basic.Abstractions.Classes;

namespace Data.Basic.Implementations
{
    public class Line : Geometry
    {
        public Vector2 PointStart;
        public Vector2 PointEnd;

        public Line(Vector2 start, Vector2 end)
        {
            PointStart = start;
            PointEnd = end;
        }

        public override void Push(double x, double y)
        {
            //Update X
            PointStart.x += x;
            PointEnd.x += x;
            //Update Y
            PointStart.y += y;
            PointEnd.y += y;
        }
    }
}
