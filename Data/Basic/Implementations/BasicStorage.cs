using Data.Basic.Interfaces;
using Data.Primitives.Abstractions;

namespace Data.Basic.Implementations
{
    public class BasicStorage : IBasicStorage
    {
        public readonly List<Geometry> geometries;

        public BasicStorage()
        {
            geometries = new List<Geometry>();
        }

        public void AddGeometry(Geometry geometry)
        {
            geometries.Add(geometry);
        }
        public void RemoveGeometry(Geometry geometry)
        {
            geometries.Remove(geometry);
        }

    }
}
