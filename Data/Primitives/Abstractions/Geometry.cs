using Domain.Primitives.Interfaces;
using System;

namespace Domain.Primitives.Abstractions
{
    abstract public class Geometry : IPushable
    {
        public Guid Id;
        public double Thickness;

        public abstract void Push(double x, double y);
    }
}
