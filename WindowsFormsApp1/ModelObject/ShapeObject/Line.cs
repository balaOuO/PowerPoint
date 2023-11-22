using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Line : Shape
    {
        //Rectangle get shape name method
        public override string ShapeName
        {
            get
            {
                return WindowsFormsApp1.ShapeName.LINE;
            }
        }

        //draw self
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(StartPoint , EndPoint);
            base.Draw(graphics);
        }
    }
}
