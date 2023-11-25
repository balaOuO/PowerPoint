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
        const int TWO = 2;
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
            _graphics.DrawLine(Pens.Black, 
                (float)startPoint.X, 
                (float)startPoint.Y, 
                (float)endPoint.X, 
                (float)endPoint.Y);
        }

        //draw rectangle
        public void DrawRectangle(Point upperLeftPoint , Point lowerRightPoint)
        {
            _graphics.DrawRectangle(
                Pens.Black, 
                (float)upperLeftPoint.X, 
                (float)upperLeftPoint.Y, 
                (float)(lowerRightPoint.X - upperLeftPoint.X), 
                (float)(lowerRightPoint.Y - upperLeftPoint.Y)
                );
        }

        //draw ellipse
        public void DrawEllipse(Point startPoint , Point endPoint)
        {
            _graphics.DrawEllipse(Pens.Black, 
                (float)startPoint.X, 
                (float)startPoint.Y, 
                (float)(endPoint.X - startPoint.X), 
                (float)(endPoint.Y - startPoint.Y)
                );
        }

        //draw select point
        public void DrawSelectPoint(Point upperLeftPoint , Point lowerRightPoint , float selectPointSize)
        {
            _graphics.DrawEllipse(Pens.Blue, (float)upperLeftPoint.X - selectPointSize / TWO, (float)upperLeftPoint.Y - selectPointSize / TWO, selectPointSize, selectPointSize);
            _graphics.DrawEllipse(Pens.Blue, (float)upperLeftPoint.X - selectPointSize / TWO, (float)lowerRightPoint.Y - selectPointSize / TWO, selectPointSize, selectPointSize);
            _graphics.DrawEllipse(Pens.Blue, (float)lowerRightPoint.X - selectPointSize / TWO, (float)upperLeftPoint.Y - selectPointSize / TWO, selectPointSize, selectPointSize);
            _graphics.DrawEllipse(Pens.Blue, (float)lowerRightPoint.X - selectPointSize / TWO, (float)lowerRightPoint.Y - selectPointSize / TWO, selectPointSize, selectPointSize);

            _graphics.DrawEllipse(Pens.Blue, (float)(upperLeftPoint.X + lowerRightPoint.X) / TWO - selectPointSize / TWO, (float)upperLeftPoint.Y - selectPointSize / TWO, selectPointSize, selectPointSize);
            _graphics.DrawEllipse(Pens.Blue, (float)(upperLeftPoint.X + lowerRightPoint.X) / TWO - selectPointSize / TWO, (float)lowerRightPoint.Y - selectPointSize / TWO, selectPointSize, selectPointSize);
            _graphics.DrawEllipse(Pens.Blue, (float)upperLeftPoint.X - selectPointSize / TWO, (float)(upperLeftPoint.Y + lowerRightPoint.Y) / TWO - selectPointSize / TWO, selectPointSize, selectPointSize);
            _graphics.DrawEllipse(Pens.Blue, (float)lowerRightPoint.X - selectPointSize / TWO, (float)(upperLeftPoint.Y + lowerRightPoint.Y) / TWO - selectPointSize / TWO, selectPointSize, selectPointSize);

            _graphics.DrawRectangle(Pens.BlueViolet, (float)upperLeftPoint.X, (float)upperLeftPoint.Y, (float)(lowerRightPoint.X - upperLeftPoint.X), (float)(lowerRightPoint.Y - upperLeftPoint.Y));
        }
    }
}
