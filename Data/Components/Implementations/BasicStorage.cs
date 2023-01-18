using Data.Basic.Abstractions.Classes;
using Data.Components.Abstractions.Interfaces;

namespace Data.Components.Implementations
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
