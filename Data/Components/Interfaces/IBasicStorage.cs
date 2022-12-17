using Data.Basic.Abstractions.Classes;

namespace Data.Components.Interfaces
{
    public interface IBasicStorage
    {
        public void AddGeometry(Geometry geometry);
        public void RemoveGeometry(Geometry geometry);
    }
}
