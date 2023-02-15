using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CykloidyWPF
{
    internal readonly struct PointD : IEquatable<PointD>
    {
        public readonly double X, Y;

        public bool Equals(PointD other)
        {
            if (this.X == other.X && this.Y == other.Y)
                return true;
            return false;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            return obj is PointD point && Equals(point);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public PointD(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
