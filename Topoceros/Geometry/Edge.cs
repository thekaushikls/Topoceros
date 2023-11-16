using Rhino.Geometry;
using System.Collections.Generic;
using Topoceros.Geometry;

namespace Topoceros
{
    public class Edge : ITraversable
    {
        #region Constructors
        public Edge(BrepEdge edge)
        {
            this.BrepEdge = edge;
            this.Weight = 1;
            this.Value = new Dictionary<string, List<object>>();
        }

        public Edge(BrepEdge edge, double weight)
        {
            this.BrepEdge = edge;
            this.Weight = weight;
            this.Value = new Dictionary<string, List<object>>();
        }
        #endregion Constructor

        #region Properties
        public int Index { get => this.BrepEdge.EdgeIndex; }

        public Brep Brep { get => this.BrepEdge.Brep; }

        public GeometryBase Geometry { get => this.BrepEdge.Duplicate(); }

        public double Weight { get; set; }

        public Dictionary<string, List<object>> Value { get; set; }

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

        public override string ToString()
        {
            return $"{this.GetType()} [{this.Index}]";
        }
        #endregion Methods
    }
}
