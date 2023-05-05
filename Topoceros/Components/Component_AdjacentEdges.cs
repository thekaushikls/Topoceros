using Grasshopper.Kernel;
using Topoceros.Geometry;
using System;

namespace Topoceros.Components
{
    public class Component_AdjacentEdges : GH_Component
    {
        #region Constructors
        public Component_AdjacentEdges() : base("AdjacentEdges", "AdjEdges", "Gets a list of adjacent edges to any brep sub element.", "Surface", "Topoceros") { }
        #endregion Constructors

        #region Properties
        protected override System.Drawing.Bitmap Icon { get => null; }

        public override Guid ComponentGuid { get => new Guid("0326EDFC-8DBD-4271-9637-61D96A28007D"); }
        #endregion Properties

        #region Methods
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("SubElement", "S", "Any valid Brep sub-element", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Edges", "E", "Edges adjacent to the sub-element", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            ITraversable element = (ITraversable)null;
            if (DA.GetData<ITraversable>(0, ref element))
            {
                DA.SetDataList(0, element.GetAdjacentEdges());
            }
        }
        #endregion Methods
    }
}