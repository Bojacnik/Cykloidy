using Data.Basic.Abstractions.Classes;
using Data.Basic.Implementations;
using Data.Components.Abstractions.Interfaces;

namespace Data.Components.Implementations
{
    public class BasicPusher : IBasicPusher
    {
        List<Geometry> geometries;
        public double PushValue
        {
            get; init;
        }

        public BasicPusher(List<Geometry> geometries, double pushvalue)
        {
            this.geometries = geometries;
            PushValue = pushvalue;
        }

        public void Step()
        {
            foreach (Geometry g in geometries)
            {
                if (g is Circle c)
                    c.Push(PushValue, 0);
            }
        }
    }
}
