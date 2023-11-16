using Rhino.Geometry;
using System.Collections.Generic;
using Topoceros.Geometry;

namespace Topoceros
{
    public class Vertex : ITraversable
    {
        #region Constructor
        public Vertex(BrepVertex brepvertex)
        {
            this.BrepVertex = brepvertex;
            this.Weight = 1;
            this.Value = new Dictionary<string, List<object>>();
        }

        public Vertex(BrepVertex brepvertex, double weight)
        {
            this.BrepVertex = brepvertex;
            this.Weight = weight;
            this.Value = new Dictionary<string, List<object>>();
        }
        #endregion Constructor

        #region Properties

        public int Index { get => this.BrepVertex.VertexIndex; }

        public Brep Brep { get => BrepVertex.Brep; }

        public GeometryBase Geometry { get => this.BrepVertex.Duplicate(); }

        public double Weight { get; set; }

        public Dictionary<string, List<object>> Value { get; set; } 

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

        public IEnumerable<Vertex> GetAdjacentVertices(int level)
        {
            HashSet<Point3d> visited = new HashSet<Point3d>();
            Queue<Vertex> queue = new Queue<Vertex>();
            int currentLevel = 0;
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    Vertex vertex = queue.Dequeue();

                    if (currentLevel <= level)
                    {
                        IEnumerable<Vertex> adjacentVertices = vertex.GetAdjacentVertices();
                        foreach (Vertex adjacentVertex in adjacentVertices)
                        {
                            if (visited.Contains(adjacentVertex.BrepVertex.Location) == false)
                            {
                                visited.Add(adjacentVertex.BrepVertex.Location);
                                queue.Enqueue(adjacentVertex);
                                yield return adjacentVertex;
                            }
                        }
                    }
                }
                currentLevel++;

                if (currentLevel > level)
                {
                    break;
                }
            }

            yield break;
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

        public override string ToString()
        {
            return $"{this.GetType()} [{this.Index}]";
        }
        #endregion Methods
    }
}
