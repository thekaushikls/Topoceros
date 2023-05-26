using Grasshopper.Kernel;

namespace Topoceros.Goo
{
    public class FaceGoo : TC_GeometricGoo<Face>
    {
        #region Constructors
        public FaceGoo(Face face) : base(face) { }
        #endregion Constructors

        #region Properties
        public override string TypeDescription { get => "Brep Face element"; }
        #endregion Properties

        #region Methods
        public override void DrawViewportMeshes(GH_PreviewMeshArgs args)
        {
            args.Pipeline.DrawBrepShaded(this.Value.DisplayGeometry(), args.Material);
        }

        public override void DrawViewportWires(GH_PreviewWireArgs args)
        {
            args.Pipeline.DrawBrepWires(this.Value.DisplayGeometry(), args.Color, 0);
        }
        #endregion Methods
    }
}
