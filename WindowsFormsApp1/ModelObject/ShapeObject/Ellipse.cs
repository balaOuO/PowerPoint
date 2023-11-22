using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace WindowsFormsApp1
{
    public class Ellipse : Shape
    {
        //Rectangle get shape name method
        public override string ShapeName
        {
            get
            {
                return WindowsFormsApp1.ShapeName.ELLIPSE;
            }
        }

        //draw self
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawEllipse(StartPoint , EndPoint);
            base.Draw(graphics);
        }
    }
}
