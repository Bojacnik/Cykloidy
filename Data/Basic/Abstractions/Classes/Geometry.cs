using Data.Basic.Abstractions.Interfaces;

namespace Data.Basic.Abstractions.Classes
{
    abstract public class Geometry : IPushable
    {
        public double Thickness;

        public abstract void Push(double x, double y);
    }
}
