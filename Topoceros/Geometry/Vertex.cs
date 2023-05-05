using Rhino.Geometry;
using System;
using System.Collections.Generic;

namespace Topoceros
{
    public class Vertex
    {
        #region Constructor
        public Vertex(BrepVertex brepvertex)
        {
            BrepVertex = brepvertex;
        }
        #endregion Constructor

        #region Properties
        public Brep Brep { get => BrepVertex.Brep; }

        public BrepVertex BrepVertex { get; internal set; }
        #endregion Properties

        #region Methods
        public IEnumerable<Vertex> GetAdjacentVertices() => throw new NotImplementedException();

        public IEnumerable<Edge> GetAdjacentEdges() => throw new NotImplementedException();

        public IEnumerable<Face> GetAdjacentFaces() => throw new NotImplementedException();
        #endregion Methods
    }
}
