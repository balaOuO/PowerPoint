using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Rectangle : Shape
    {
        private const string SHAPE = "Rectangle";

        //Rectangle getinfo method
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
            graphics.DrawRectangle(Pens.Black, (float)Math.Min(StartPoint.X , EndPoint.X), (float)Math.Min(StartPoint.Y, EndPoint.Y), (float)Math.Abs(EndPoint.X - StartPoint.X), (float)Math.Abs(EndPoint.Y - StartPoint.Y));
        }
    }
}
