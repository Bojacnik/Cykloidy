using Data.Primitives.Abstractions;

namespace Data.Basic.Interfaces
{
    public interface IBasicStorage
    {
        public void AddGeometry(Geometry geometry);
        public void RemoveGeometry(Geometry geometry);
    }
}
