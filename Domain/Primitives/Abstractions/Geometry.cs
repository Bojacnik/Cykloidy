using Domain.Primitives.Interfaces;

namespace Domain.Primitives.Abstractions
{
    abstract public class Geometry : IPushable
    {
        public double Thickness;

        public abstract void Push(double value);
    }
}
