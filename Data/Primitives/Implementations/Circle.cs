using Domain.Primitives.Abstractions;
using Domain.Primitives.Interfaces;
using System;

namespace Domain.Primitives.Implementations
{
    public class Circle : Geometry
    {
        public Vector2 Center;
        public double Radius;

        public Circle(Vector2 center, double radius)
        {
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