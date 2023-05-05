using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topoceros.Geometry
{
    public interface ITraversable
    {
        IEnumerable<Vertex> GetAdjacentVertices();

        IEnumerable<Edge> GetAdjacentEdges();

        IEnumerable<Face> GetAdjacentFaces();
    }
}
