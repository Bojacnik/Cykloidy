using System.Collections.Generic;
using Domain.Basic.Interfaces;
using Domain.Primitives.Abstractions;

namespace Domain.Basic.Implementations
{
    public class BasicStorage : IBasicStorage
    {
        public readonly List<Geometry> geometries = new List<Geometry>();

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
