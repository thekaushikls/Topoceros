using Rhino.Geometry;
using System;
using System.Collections.Generic;

namespace Topoceros
{
    public class Edge
    {
        #region Constructors
        public Edge(BrepEdge edge)
        {
            BrepEdge = edge;
        }
        #endregion Constructor

        #region Properties
        public Brep Brep { get => BrepEdge.Brep; }

        public BrepEdge BrepEdge { get; internal set; }
        #endregion Properties

        #region Methods
        public IEnumerable<Vertex> GetAdjacentVertices() => throw new NotImplementedException();

        public IEnumerable<Edge> GetAdjacentEdges() => throw new NotImplementedException();

        public IEnumerable<Face> GetAdjacentFaces() => throw new NotImplementedException();
        #endregion Methods
    }
}
