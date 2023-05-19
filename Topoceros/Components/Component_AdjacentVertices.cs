using Grasshopper.Kernel;
using System;
using Topoceros.Goo;

namespace Topoceros.Components
{
    public class Component_AdjacentVertices : GH_Component
    {
        #region Constructors
        public Component_AdjacentVertices() : base("AdjacentVertices", "AdjVertices", "Gets a list of adjacent vertices to any brep sub element.", "Surface", "Topoceros") { }
        #endregion Constructors

        #region Properties
        protected override System.Drawing.Bitmap Icon { get => Properties.Resources.Icons_Component_AdjacentVertices_24x24; }

        public override Guid ComponentGuid { get => new Guid("0538FC15-FB06-4D88-8564-D886039BE58A"); }
        #endregion Properties

        #region Methods
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("SubElement", "S", "Any valid Brep sub-element", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Vertices", "V", "Vertices adjacent to the sub-element", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            ITC_GeometricGoo element = null;
            if (DA.GetData(0, ref element))
            {
                DA.SetDataList(0, element.GetAdjacentVertices());
            }
        }
        #endregion Methods
    }
}