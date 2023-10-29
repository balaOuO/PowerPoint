using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ShapeObject
{
    class Ellipse : Shape
    {
        private const string SHAPE = "Ellipse";

        //get info method
        public override string Info
        {
            get
            {
                const string COMMA = ",";
                return StartPoint.ToString() + COMMA + EndPoint.ToString();
            }
        }

        //Rectangle get shape name method
        public override string ShapeName
        {
            get
            {
                return SHAPE;
            }
        }

        //draw self
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawEllipse(StartPoint , EndPoint);
        }
    }
}
