using Data.Basic.Abstractions.Interfaces;

namespace Data.Basic.Implementations
{
    public struct Vector2 : IPushable, IEquatable<Vector2>
    {
        public double x;
        public double y;

        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static readonly Vector2 Default = new Vector2(0, 0);

        public void Push(double x, double y)
        {
            this.x += x;
            this.y += y;
        }

        public bool Equals(Vector2 other)
        {
            if (x == other.x && y == other.y) return true;
            return false;
        }

        public static Vector2 operator +(Vector2 first, Vector2 second)
        {
            return new Vector2(first.x + second.x, first.y + second.y);
        }
        public static Vector2 operator -(Vector2 first, Vector2 second)
        {
            return new Vector2(first.x - second.x, first.y - second.y);
        }
        public static Vector2 operator *(Vector2 first, Vector2 second)
        {
            return new Vector2(first.x * second.x, first.y * second.y);
        }
        public static Vector2 operator /(Vector2 first, Vector2 second)
        {
            return new Vector2(first.x / second.x, first.y / second.y);
        }


    }
}
