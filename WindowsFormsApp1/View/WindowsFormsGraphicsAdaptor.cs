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
        const int SIZE = 8;
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
        public void DrawSelectPoint(Point upperLeftPoint , Point lowerRightPoint)
        {
            _graphics.DrawEllipse(Pens.Blue, (float)upperLeftPoint.X - SIZE / TWO, (float)upperLeftPoint.Y - SIZE / TWO, SIZE , SIZE);
            _graphics.DrawEllipse(Pens.Blue, (float)upperLeftPoint.X - SIZE / TWO, (float)lowerRightPoint.Y - SIZE / TWO, SIZE, SIZE);
            _graphics.DrawEllipse(Pens.Blue, (float)lowerRightPoint.X - SIZE / TWO, (float)upperLeftPoint.Y - SIZE / TWO, SIZE, SIZE);
            _graphics.DrawEllipse(Pens.Blue, (float)lowerRightPoint.X - SIZE / TWO, (float)lowerRightPoint.Y - SIZE / TWO, SIZE, SIZE);

            _graphics.DrawEllipse(Pens.Blue, (float)(upperLeftPoint.X + lowerRightPoint.X) / TWO - SIZE / TWO, (float)upperLeftPoint.Y - SIZE / TWO, SIZE, SIZE);
            _graphics.DrawEllipse(Pens.Blue, (float)(upperLeftPoint.X + lowerRightPoint.X) / TWO - SIZE / TWO, (float)lowerRightPoint.Y - SIZE / TWO, SIZE, SIZE);
            _graphics.DrawEllipse(Pens.Blue, (float)upperLeftPoint.X - SIZE / TWO, (float)(upperLeftPoint.Y + lowerRightPoint.Y) / TWO - SIZE / TWO, SIZE, SIZE);
            _graphics.DrawEllipse(Pens.Blue, (float)lowerRightPoint.X - SIZE / TWO, (float)(upperLeftPoint.Y + lowerRightPoint.Y) / TWO - SIZE / TWO, SIZE, SIZE);

            _graphics.DrawRectangle(Pens.BlueViolet, (float)upperLeftPoint.X, (float)upperLeftPoint.Y, (float)(lowerRightPoint.X - upperLeftPoint.X), (float)(lowerRightPoint.Y - upperLeftPoint.Y) );
        }
    }
}
