using Data.Primitives.Interfaces;

namespace Data.Primitives.Abstractions
{
    abstract public class Geometry : IPushable
    {
        public double Thickness;

        public abstract void Push(double x, double y);
    }
}
