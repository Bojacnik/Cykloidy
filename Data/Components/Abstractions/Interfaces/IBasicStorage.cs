using Data.Basic.Abstractions.Classes;

namespace Data.Components.Abstractions.Interfaces
{
    public interface IBasicStorage
    {
        public void AddGeometry(Geometry geometry);
        public void RemoveGeometry(Geometry geometry);
    }
}
