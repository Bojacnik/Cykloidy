using Domain.Primitives.Abstractions;
using System;

namespace Domain.Primitives.Implementations
{
    public class Line : Geometry
    {
        public Vector2 PointStart;
        public Vector2 PointEnd;

        public Line(Guid Id, Vector2 start, Vector2 end)
        {
            this.Id = Id;
            this.PointStart = start;
            this.PointEnd = end;
        }

        public override void Push(double x, double y)
        {
            //Update X
            this.PointStart.x += x;
            this.PointEnd.x += x;
            //Update Y
            this.PointStart.y += y;
            this.PointEnd.y += y;
        }
    }
}
