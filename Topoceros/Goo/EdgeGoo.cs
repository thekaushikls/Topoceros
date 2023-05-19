using Grasshopper.Kernel;

namespace Topoceros.Goo
{
    public class EdgeGoo : TC_GeometricGoo<Edge>
    {
        #region Constructors
        public EdgeGoo(Edge edge) : base(edge) { }
        #endregion Constructors

        #region Properties
        public override string TypeDescription { get => "Brep Edge element"; }
        #endregion Properties

        #region Methods
        public override void DrawViewportMeshes(GH_PreviewMeshArgs args)
        {
            args.Pipeline.DrawCurve(this.Value.BrepEdge, args.Material.Diffuse, Grasshopper.CentralSettings.PreviewSelectionThickening);
        }

        public override void DrawViewportWires(GH_PreviewWireArgs args)
        {
            args.Pipeline.DrawCurve(this.Value.BrepEdge, args.Color, Grasshopper.CentralSettings.PreviewSelectionThickening);
        }
        #endregion Methods
    }
}
