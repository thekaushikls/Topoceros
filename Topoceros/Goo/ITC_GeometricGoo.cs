using System.Collections.Generic;
using Topoceros.Geometry;

namespace Topoceros.Goo
{
    public interface ITC_GeometricGoo
    {
        ITraversable Element { get; }

        IEnumerable<VertexGoo> GetAdjacentVertices();

        IEnumerable<EdgeGoo> GetAdjacentEdges();

        IEnumerable<FaceGoo> GetAdjacentFaces();
    }
}
