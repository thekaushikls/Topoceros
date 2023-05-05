using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace Topoceros
{
    public class TopocerosInfo : GH_AssemblyInfo
    {
        public override string Name => "Topoceros";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("966c3f2e-5c9c-468f-8ed2-51438acb6f4b");

        //Return a string identifying you or your company.
        public override string AuthorName => "Kaushik LS";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "";
    }
}