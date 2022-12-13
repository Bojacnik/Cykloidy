using Domain.Primitives.Interfaces;

namespace Domain.Primitives.Implementations
{
    public struct Vector2 : IPushable
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
