using Grasshopper.Kernel;
using Topoceros.Geometry;
using System;

namespace Topoceros.Components
{
    public class Component_AdjacentFaces : GH_Component
    {
        #region Constructors
        public Component_AdjacentFaces() : base("AdjacentFaces", "AdjFaces", "Gets a list of adjacent faces to any brep sub element.", "Surface", "Topoceros") { }
        #endregion Constructors

        #region Properties
        protected override System.Drawing.Bitmap Icon { get => null; }

        public override Guid ComponentGuid { get => new Guid("71BE193D-8605-4BDE-B043-72AE5BCD9DCC"); }
        #endregion Properties

        #region Methods
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("SubElement", "S", "Any valid Brep sub-element", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Faces", "F", "Faces adjacent to the sub-element", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            ITraversable element = (ITraversable)null;
            if (DA.GetData<ITraversable>(0, ref element))
            {
                DA.SetDataList(0, element.GetAdjacentFaces());
            }
        }
        #endregion Methods
    }
}