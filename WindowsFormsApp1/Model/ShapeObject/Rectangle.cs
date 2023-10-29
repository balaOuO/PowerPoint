using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Rectangle : Shape
    {
        private const string SHAPE = "Rectangle";

        //Rectangle getinfo method
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
            graphics.DrawRectangle(StartPoint , EndPoint);
        }
    }
}
