using System;
using System.Collections.Generic;
using System.Drawing;
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
            return StartPoint.ToString() + COMMA + EndPoint.ToString();
        }

        //Rectangle get shape name method
        public override string GetShapeName()
        {
            return SHAPE;
        }

        //draw self
        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(Pens.Black, (float)StartPoint.X, (float)StartPoint.Y, (float)EndPoint.X, (float)EndPoint.Y);
        }
    }
}
