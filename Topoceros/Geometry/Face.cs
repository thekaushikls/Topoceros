using System.Collections.Generic;
using Topoceros.Geometry;
using Rhino.Geometry;

namespace Topoceros
{
    public class Face : IGeometry, ITraversable
    {
        #region Constructors
        public Face(BrepFace face)
        {
            BrepFace = face;
        }
        #endregion Constructors

        #region Properties

        public int Index { get => this.BrepFace.FaceIndex; }

        public Brep Brep { get => BrepFace.Brep; }

        public GeometryBase Geometry { get => this.BrepFace.DuplicateSurface(); }
        public BrepFace BrepFace { get; internal set; }
        #endregion Properties

        #region Methods
        public IEnumerable<Vertex> GetAdjacentVertices()
        {
            HashSet<int> vertexIndices = new HashSet<int>();
            foreach (Edge edge in this.GetAdjacentEdges())
            {
                foreach (Vertex vertex in edge.GetAdjacentVertices())
                {
                    if (vertexIndices.Contains(vertex.BrepVertex.VertexIndex) == false)
                    {
                        vertexIndices.Add(vertex.BrepVertex.VertexIndex);
                        yield return vertex;
                    }
                }
            }
        }

        public IEnumerable<Edge> GetAdjacentEdges()
        {
            foreach (int edgeIndex in this.BrepFace.AdjacentEdges())
            {
                yield return new Edge(this.Brep.Edges[edgeIndex]);
            }
        }

        public IEnumerable<Face> GetAdjacentFaces()
        {
            foreach (int faceIndex in this.BrepFace.AdjacentFaces())
            {
                yield return new Face(this.Brep.Faces[faceIndex]);
            }
        }
        #endregion Methods
    }
}
