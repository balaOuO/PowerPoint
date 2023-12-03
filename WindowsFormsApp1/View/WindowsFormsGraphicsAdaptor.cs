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
        const int Width = 1600;
        const int Height = 900;
        private int _canvasWidth;
        private int _canvasHeight;
        public WindowsFormsGraphicsAdaptor(Graphics graphics, int canvasWidth, int canvasHeight) //, int canvasWidth , int canvasHeight
        {
            _graphics = graphics;
            _canvasWidth = canvasWidth;
            _canvasHeight = canvasHeight;
        }

        public Point MappingReversePoint(Point point)
        {
            return new Point((point.X / Width) * _canvasWidth, (point.Y / Height) * _canvasHeight);
        }

        //clear screen
        public void ClearAll()
        {
            //nothing
        }

        //draw line
        public void DrawLine(Point startPoint , Point endPoint)
        {
            Point realStartPoint = MappingReversePoint(startPoint);
            Point realEndPoint = MappingReversePoint(endPoint);
            _graphics.DrawLine(Pens.Black, 
                (float)realStartPoint.X, 
                (float)realStartPoint.Y, 
                (float)realEndPoint.X, 
                (float)realEndPoint.Y);
        }

        //draw rectangle
        public void DrawRectangle(Point upperLeftPoint , Point lowerRightPoint)
        {
            Point realUpperLeftPoint = MappingReversePoint(upperLeftPoint);
            Point realLowerRightPoint = MappingReversePoint(lowerRightPoint);

            _graphics.DrawRectangle(
                Pens.Black, 
                (float)realUpperLeftPoint.X, 
                (float)realUpperLeftPoint.Y, 
                (float)(realLowerRightPoint.X - realUpperLeftPoint.X), 
                (float)(realLowerRightPoint.Y - realUpperLeftPoint.Y)
                );
        }

        //draw ellipse
        public void DrawEllipse(Point startPoint , Point endPoint)
        {
            Point realStartPoint = MappingReversePoint(startPoint);
            Point realEndPoint = MappingReversePoint(endPoint);
            _graphics.DrawEllipse(Pens.Black, 
                (float)realStartPoint.X, 
                (float)realStartPoint.Y, 
                (float)(realEndPoint.X - realStartPoint.X), 
                (float)(realEndPoint.Y - realStartPoint.Y)
                );
        }

        //draw select point
        public void DrawSelectPoint(Point upperLeftPoint , Point lowerRightPoint , float selectPointSize)
        {
            Point realUpperLeftPoint = MappingReversePoint(upperLeftPoint);
            Point realLowerRightPoint = MappingReversePoint(lowerRightPoint);

            _graphics.DrawEllipse(Pens.Blue, (float)realUpperLeftPoint.X - selectPointSize / TWO, (float)realUpperLeftPoint.Y - selectPointSize / TWO, selectPointSize, selectPointSize);
            _graphics.DrawEllipse(Pens.Blue, (float)realUpperLeftPoint.X - selectPointSize / TWO, (float)realLowerRightPoint.Y - selectPointSize / TWO, selectPointSize, selectPointSize);
            _graphics.DrawEllipse(Pens.Blue, (float)realLowerRightPoint.X - selectPointSize / TWO, (float)realUpperLeftPoint.Y - selectPointSize / TWO, selectPointSize, selectPointSize);
            _graphics.DrawEllipse(Pens.Blue, (float)realLowerRightPoint.X - selectPointSize / TWO, (float)realLowerRightPoint.Y - selectPointSize / TWO, selectPointSize, selectPointSize);

            _graphics.DrawEllipse(Pens.Blue, (float)(realUpperLeftPoint.X + realLowerRightPoint.X) / TWO - selectPointSize / TWO, (float)realUpperLeftPoint.Y - selectPointSize / TWO, selectPointSize, selectPointSize);
            _graphics.DrawEllipse(Pens.Blue, (float)(realUpperLeftPoint.X + realLowerRightPoint.X) / TWO - selectPointSize / TWO, (float)realLowerRightPoint.Y - selectPointSize / TWO, selectPointSize, selectPointSize);
            _graphics.DrawEllipse(Pens.Blue, (float)realUpperLeftPoint.X - selectPointSize / TWO, (float)(realUpperLeftPoint.Y + realLowerRightPoint.Y) / TWO - selectPointSize / TWO, selectPointSize, selectPointSize);
            _graphics.DrawEllipse(Pens.Blue, (float)realLowerRightPoint.X - selectPointSize / TWO, (float)(realUpperLeftPoint.Y + realLowerRightPoint.Y) / TWO - selectPointSize / TWO, selectPointSize, selectPointSize);

            _graphics.DrawRectangle(Pens.BlueViolet, (float)realUpperLeftPoint.X, (float)realUpperLeftPoint.Y, (float)(realLowerRightPoint.X - realUpperLeftPoint.X), (float)(realLowerRightPoint.Y - realUpperLeftPoint.Y));
        }
    }
}
