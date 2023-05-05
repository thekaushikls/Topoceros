using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;
using System;
using Topoceros.Geometry;

namespace Topoceros.Components
{
    public class Component_GetGeometry : GH_Component
    {
        #region Constructors
        public Component_GetGeometry() : base("Get Geometry", "GetGeometry", "Extract native Rhino geometry from Topoceros element.", "Surface", "Topoceros") { }
        #endregion Constructors

        #region Properties
        protected override System.Drawing.Bitmap Icon { get => null; }

        public override Guid ComponentGuid { get => new Guid("335139CC-14F8-4980-BAB0-58EC74AB9F3B"); }

        #endregion Properties

        #region Methods
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Element", "E", "Any Topoceros element to extract Geometry.", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGeometryParameter("Geometry", "G", "Native Rhino geometry from Topoceros element.", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            IGeometry element = (IGeometry)null;
            if (DA.GetData<IGeometry>(0, ref element))
            {
                DA.SetData(0, element.Geometry);
            }
        }
        #endregion Methods
    }
}