﻿using Grasshopper.Kernel;
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

        public Brep Brep { get; set; } = null;

        protected override System.Drawing.Bitmap Icon { get => Properties.Resources.Icons_Component_DeconstructBrep_24x24; }

        public override Guid ComponentGuid { get => new Guid("C1C78C99-53DC-49A3-B08E-26B53CF2B454"); }
        #endregion Properties

        #region Methods
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
                DA.SetDataList(0, this.Brep.GetVertices_Goo());
                DA.SetDataList(1, this.Brep.GetEdges_Goo());
                DA.SetDataList(2, this.Brep.GetFaces_Goo());
            }
        }
        #endregion Methods
    }
}
