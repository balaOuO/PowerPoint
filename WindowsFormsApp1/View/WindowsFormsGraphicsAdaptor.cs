using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class WindowsFormsGraphicsAdaptor : WindowsFormsApp1.IGraphics
    {
        Graphics _graphics;
        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            _graphics = graphics;
        }
        //clear screen
        public void ClearAll()
        {
            //nothing
        }

        //draw line
        public void DrawLine(Point startPoint , Point endPoint)
        {
            _graphics.DrawLine(Pens.Black, (float)startPoint.X, (float)startPoint.Y, (float)endPoint.X, (float)endPoint.Y);
        }

        //draw rectangle
        public void DrawRectangle(Point startPoint , Point endPoint)
        {
            _graphics.DrawRectangle(Pens.Black, (float)Math.Min(startPoint.X, endPoint.X), (float)Math.Min(startPoint.Y, endPoint.Y), (float)Math.Abs(endPoint.X - startPoint.X), (float)Math.Abs(endPoint.Y - startPoint.Y));
        }

        //draw ellipse
        public void DrawEllipse(Point startPoint , Point endPoint)
        {
            _graphics.DrawEllipse(Pens.Black, (float)startPoint.X, (float)startPoint.Y, (float)endPoint.X - (float)startPoint.X, (float)endPoint.Y - (float)startPoint.Y);
        }
    }
}
