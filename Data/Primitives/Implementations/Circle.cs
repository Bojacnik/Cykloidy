using Domain.Primitives.Abstractions;
using Domain.Primitives.Interfaces;
using System;

namespace Domain.Primitives.Implementations
{
    public class Circle : Geometry
    {
        Guid id;
        public Vector2 Center;
        public double Radius;

        public Circle(Guid id, Vector2 center, double radius)
        {
            this.id = id;
            this.Center = center;
            this.Radius = radius;
        }

        public override void Push(double x, double y)
        {
            this.Center.x += x;
            this.Center.y += y;
        }
    }
}