using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ShapeObject
{
    class Line : Shape
    {
        private const string SHAPE = "Line";

        //get info method
        public override string GetInfo()
        {
            const string COMMA = ",";
            return UpperLeftPoint.ToString() + COMMA + LowerRightPoint.ToString();
        }

        //Rectangle get shape name method
        public override string GetShapeName()
        {
            return SHAPE;
        }
    }
}
