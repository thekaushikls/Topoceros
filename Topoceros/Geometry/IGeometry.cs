using Rhino.Geometry;

namespace Topoceros.Geometry
{
    public interface IGeometry
    {
        int Index { get; }
        
        Brep Brep { get; }
        
        GeometryBase Geometry { get; }
    }
}
