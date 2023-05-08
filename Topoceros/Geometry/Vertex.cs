using System.Collections.Generic;
using Topoceros.Geometry;
using Rhino.Geometry;

namespace Topoceros
{
    public class Vertex : IGeometry, ITraversable
    {
        #region Constructor
        public Vertex(BrepVertex brepvertex)
        {
            BrepVertex = brepvertex;
        }
        #endregion Constructor

        #region Properties

        public int Index { get => this.BrepVertex.VertexIndex; }

        public Brep Brep { get => BrepVertex.Brep; }

        public GeometryBase Geometry { get => this.BrepVertex.Duplicate(); }
        
        public BrepVertex BrepVertex { get; internal set; }
        #endregion Properties

        #region Methods
        public IEnumerable<Vertex> GetAdjacentVertices()
        {
            BrepVertex vertex;
            HashSet<int> vertexIndices = new HashSet<int>();
            foreach (Edge edge in this.GetAdjacentEdges())
            {
                vertex = edge.BrepEdge.StartVertex;
                if (vertexIndices.Contains(vertex.VertexIndex) == false)
                {
                    vertexIndices.Add(vertex.VertexIndex);
                    yield return new Vertex(vertex);
                }

                vertex = edge.BrepEdge.EndVertex;
                if (vertexIndices.Contains(vertex.VertexIndex) == false)
                {
                    vertexIndices.Add(vertex.VertexIndex);
                    yield return new Vertex(vertex);
                }
            }
        }

        public IEnumerable<Edge> GetAdjacentEdges()
        {
            foreach (int edgeIndex in this.BrepVertex.EdgeIndices())
            {
                yield return new Edge(this.Brep.Edges[edgeIndex]);
            }
        }

        public IEnumerable<Face> GetAdjacentFaces()
        {
            HashSet<int> faceIndices = new HashSet<int>();
            foreach (Edge edge in this.GetAdjacentEdges())
            {
                foreach (Face face in edge.GetAdjacentFaces())
                {
                    if (faceIndices.Contains(face.BrepFace.FaceIndex) == false)
                    {
                        faceIndices.Add(face.BrepFace.FaceIndex);
                        yield return face;
                    }
                }
            }
        }
        #endregion Methods
    }
}
