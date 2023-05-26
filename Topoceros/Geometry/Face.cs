using Rhino.Geometry;
using System.Collections.Generic;
using Topoceros.Geometry;

namespace Topoceros
{
    public class Face : ITraversable
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

        public GeometryBase Geometry { get => this.BrepFace.DuplicateFace(true); }
        public BrepFace BrepFace { get; internal set; }
        #endregion Properties

        #region Methods
        internal Brep DisplayGeometry() => this.Geometry as Brep;

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
            // Add Adjacent Edges away from the face. Not the boundary
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

        public override string ToString()
        {
            return $"{this.GetType()} [{this.Index}]";
        }
        #endregion Methods
    }
}
