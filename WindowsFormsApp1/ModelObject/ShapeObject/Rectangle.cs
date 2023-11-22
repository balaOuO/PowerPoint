using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class Rectangle : Shape
    {
        //Rectangle get shape name method
        public override string ShapeName
        {
            get
            {
                return WindowsFormsApp1.ShapeName.RECTANGLE;
            }
        }

        //draw self
        public override void Draw(IGraphics graphics)
        {            
            graphics.DrawRectangle(UpperLeftPoint , LowerRightPoint);
            base.Draw(graphics);
        }
    }
}
