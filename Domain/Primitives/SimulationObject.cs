using Domain.Primitives.Implementations;

namespace Domain.Primitives
{
    public struct SimulationObject
    {
        //TODO: generate properties
        public Vector2 Position;
        public Vector2 Velocity;
        public Vector2 Force;
        public int Mass;

        public SimulationObject(Vector2 position, Vector2 velocity, Vector2 force, int mass)
        {
            Position = position;
            Velocity = velocity;
            Force = force;
            Mass = mass;
        }
    }
}
