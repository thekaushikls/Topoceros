using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using Topoceros.Geometry;

namespace Topoceros.Goo
{
    public class TC_GeometricGoo<T> : GH_GeometricGoo<T>, IGH_PreviewData, ITC_GeometricGoo where T : ITraversable
    {
        #region Constructors
        public TC_GeometricGoo(T element)
        {
            this.Value = element;
        }
        #endregion Constructors

        #region Properties
        public ITraversable Element { get => this.Value; }

        public override bool IsValid { get => this.Value.Geometry.IsValid; }

        public override string TypeName { get => this.Value.GetType().Name; }

        public override string TypeDescription { get; }

        public override BoundingBox Boundingbox { get => this.Value.Geometry.GetBoundingBox(false); }

        public BoundingBox ClippingBox { get => this.Boundingbox; }
        #endregion Properties

        #region Methods

        IEnumerable<VertexGoo> ITC_GeometricGoo.GetAdjacentVertices()
        {
            return this.Value.GetAdjacentVertices().Select(vertex => new VertexGoo(vertex));
        }

        IEnumerable<EdgeGoo> ITC_GeometricGoo.GetAdjacentEdges()
        {
            return this.Value.GetAdjacentEdges().Select(edge => new EdgeGoo(edge));
        }

        IEnumerable<FaceGoo> ITC_GeometricGoo.GetAdjacentFaces()
        {
            return this.Value.GetAdjacentFaces().Select(face => new FaceGoo(face));
        }


        public virtual void DrawViewportMeshes(GH_PreviewMeshArgs args) => throw new NotImplementedException();

        public virtual void DrawViewportWires(GH_PreviewWireArgs args) => throw new NotImplementedException();

        public override IGH_GeometricGoo DuplicateGeometry() => throw new NotImplementedException();

        public override BoundingBox GetBoundingBox(Transform xform) => this.Value.Geometry.GetBoundingBox(xform);

        public override IGH_GeometricGoo Morph(SpaceMorph xmorph) => throw new NotImplementedException();

        public override IGH_GeometricGoo Transform(Transform xform) => throw new NotImplementedException();

        public override string ToString() => this.Value.ToString();


        #endregion Methods
    }
}
