using Domain.Primitives.Implementations;

namespace Domain.Primitives
{
    public struct Transform
    {
        public Vector2 Position;
        public Vector2 Scale;
        public Degree Rotation;

        public Transform(ref Vector2 position, ref Vector2 scale, ref Degree rotation)
        {
            Position = position;
            Scale = scale;
            Rotation = rotation;
        }
    }
}
