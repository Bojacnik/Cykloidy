using Domain.Primitives.Abstractions;

namespace Domain.Basic.Interfaces
{
    public interface IBasicStorage
    {
        public void AddGeometry(Geometry geometry);
        public void RemoveGeometry(Geometry geometry);
    }
}
