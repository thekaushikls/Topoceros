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
            args.Pipeline.DrawMeshShaded(this.Value.GetFastRenderMesh(), args.Material);
        }

        public override void DrawViewportWires(GH_PreviewWireArgs args)
        {
            args.Pipeline.DrawMeshWires(this.Value.GetFastRenderMesh(), args.Color);
        }
        #endregion Methods
    }
}
