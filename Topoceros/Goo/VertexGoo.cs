using Grasshopper.Kernel;

namespace Topoceros.Goo
{
    public class VertexGoo : TC_GeometricGoo<Vertex>
    {
        #region Constructor
        public VertexGoo(Vertex vertex) : base(vertex) { }
        #endregion Constructor

        #region Properties
        public override string TypeDescription { get => "Brep Vertex element"; }
        #endregion Properties

        #region Methods
        public override void DrawViewportMeshes(GH_PreviewMeshArgs args)
        {
            args.Pipeline.DrawPoint(this.Value.BrepVertex.Location, Grasshopper.CentralSettings.PreviewPointStyle, Grasshopper.CentralSettings.PreviewPointRadius, args.Material.Diffuse);
        }

        public override void DrawViewportWires(GH_PreviewWireArgs args)
        {
            args.Pipeline.DrawPoint(this.Value.BrepVertex.Location, Grasshopper.CentralSettings.PreviewPointStyle, Grasshopper.CentralSettings.PreviewPointRadius, args.Color);
        }
        #endregion Methods
    }
}
