using System.Collections.Generic;
using Topoceros.Geometry;
using Rhino.Geometry;

namespace Topoceros
{
    public class Edge : IGeometry, ITraversable
    {
        #region Constructors
        public Edge(BrepEdge edge)
        {
            BrepEdge = edge;
        }
        #endregion Constructor

        #region Properties
        public int Index { get => this.BrepEdge.EdgeIndex; }

        public Brep Brep { get => BrepEdge.Brep; }

        public GeometryBase Geometry { get => this.BrepEdge.Duplicate(); }

        public BrepEdge BrepEdge { get; internal set; }
        #endregion Properties

        #region Methods
        public IEnumerable<Vertex> GetAdjacentVertices()
        {
            yield return new Vertex(this.BrepEdge.StartVertex);
            yield return new Vertex(this.BrepEdge.EndVertex);
        }

        public IEnumerable<Edge> GetAdjacentEdges()
        {
            HashSet<int> edgeIndices = new HashSet<int>();
            foreach (Vertex vertex in this.GetAdjacentVertices())
            {
                foreach (Edge edge in vertex.GetAdjacentEdges())
                {
                    if (edgeIndices.Contains(edge.BrepEdge.EdgeIndex) == false)
                    {
                        edgeIndices.Add(edge.BrepEdge.EdgeIndex);
                        yield return edge;
                    }   
                }
            }
        }

        public IEnumerable<Face> GetAdjacentFaces()
        {
            foreach (int faceIndex in this.BrepEdge.AdjacentFaces())
            {
                yield return new Face(this.Brep.Faces[faceIndex]);
            }
        }
        #endregion Methods
    }
}
