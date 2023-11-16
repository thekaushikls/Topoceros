using Rhino.Geometry;
using System.Collections.Generic;

namespace Topoceros.Geometry
{
    public interface ITraversable
    {
        int Index { get; }

        Brep Brep { get; }

        GeometryBase Geometry { get; }

        double Weight { get; set; }

        Dictionary<string, List<object>> Value { get; set; }

        IEnumerable<Vertex> GetAdjacentVertices();

        IEnumerable<Edge> GetAdjacentEdges();

        IEnumerable<Face> GetAdjacentFaces();
    }
}
