using Rhino.Geometry;
using System.Collections.Generic;
using Topoceros.Goo;

namespace Topoceros
{
    public static class BrepExtensions
    {
        public static IEnumerable<Vertex> GetVertices(this Brep brep)
        {
            foreach (BrepVertex vertex in brep.Vertices)
            {
                yield return new Vertex(vertex);
            }
        }

        public static IEnumerable<Edge> GetEdges(this Brep brep)
        {
            foreach (BrepEdge edge in brep.Edges)
            {
                yield return new Edge(edge);
            }
        }

        public static IEnumerable<Face> GetFaces(this Brep brep)
        {
            foreach (BrepFace face in brep.Faces)
            {
                yield return new Face(face);
            }
        }

        internal static IEnumerable<VertexGoo> GetVertices_Goo(this Brep brep)
        {
            foreach (BrepVertex vertex in brep.Vertices)
            {
                yield return new VertexGoo(new Vertex(vertex));
            }
        }

        internal static IEnumerable<EdgeGoo> GetEdges_Goo(this Brep brep)
        {
            foreach (BrepEdge edge in brep.Edges)
            {
                yield return new EdgeGoo(new Edge(edge));
            }
        }

        internal static IEnumerable<FaceGoo> GetFaces_Goo(this Brep brep)
        {
            foreach (BrepFace face in brep.Faces)
            {
                yield return new FaceGoo(new Face(face));
            }
        }
    }
}
