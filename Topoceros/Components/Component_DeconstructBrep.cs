using Grasshopper.Kernel;
using Rhino.Geometry;
using System;

namespace Topoceros.Components
{
    public class Component_DeconstructBrep : GH_Component
    {
        #region Constructors
        public Component_DeconstructBrep() : base("Deconstruct Brep", "DeBrep", "Deconstruct a brep into its constituent wrapped sub-elements.", "Surface", "Topoceros") { }
        #endregion Constructors

        #region Properties
        private Brep Brep { get; set; } = (Brep)null;
        #endregion Properties
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBrepParameter("Brep", "B", "Base Brep", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Vertices", "V", "Vertices of Brep", GH_ParamAccess.list);
            pManager.AddGenericParameter("Edges", "E", "Edges of Brep", GH_ParamAccess.list);
            pManager.AddGenericParameter("Faces", "F", "Faces of Brep", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Brep brep = (Brep)null;
            if (DA.GetData<Brep>(0, ref brep))
            {
                this.Brep = brep.DuplicateBrep();

                DA.SetDataList(0, this.Brep.GetVertices());
                DA.SetDataList(1, this.Brep.GetEdges());
                DA.SetDataList(2, this.Brep.GetFaces());
            }
        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("C1C78C99-53DC-49A3-B08E-26B53CF2B454"); }
        }
    }
}