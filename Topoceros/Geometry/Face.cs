using Rhino.Geometry;
using System;
using System.Collections.Generic;

namespace Topoceros
{
    public class Face
    {
        #region Constructors
        public Face(BrepFace face)
        {
            BrepFace = face;
        }
        #endregion Constructors

        #region Properties
        public Brep Brep { get => BrepFace.Brep; }
        public BrepFace BrepFace { get; internal set; }
        #endregion Properties

        #region Methods
        public IEnumerable<Vertex> GetAdjacentVertices() => throw new NotImplementedException();

        public IEnumerable<Edge> GetAdjacentEdges() => throw new NotImplementedException();

        public IEnumerable<Face> GetAdjacentFaces() => throw new NotImplementedException();
        #endregion Methods
    }
}
