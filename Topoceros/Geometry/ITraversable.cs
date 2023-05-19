using Rhino.Geometry;
using System.Collections.Generic;

namespace Topoceros.Geometry
{
    public interface ITraversable
    {
        int Index { get; }

        Brep Brep { get; }

        GeometryBase Geometry { get; }

        IEnumerable<Vertex> GetAdjacentVertices();

        IEnumerable<Edge> GetAdjacentEdges();

        IEnumerable<Face> GetAdjacentFaces();
    }
}
