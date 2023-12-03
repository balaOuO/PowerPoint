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
        private int _canvasWidth;
        private int _canvasHeight;
        public WindowsFormsGraphicsAdaptor(Graphics graphics, int canvasWidth, int canvasHeight) //, int canvasWidth , int canvasHeight
        {
            _graphics = graphics;
            _canvasWidth = canvasWidth;
            _canvasHeight = canvasHeight;
        }

        //MappingReversePoint
        public Point TransformBackPoint(Point point)
        {
            return new Point((point.X / ScreenSize.WIDTH) * _canvasWidth, (point.Y / ScreenSize.HEIGHT) * _canvasHeight);
        }

        //clear screen
        public void ClearAll()
        {
            //nothing
        }

        //draw line
        public void DrawLine(Point startPoint , Point endPoint)
        {
            Point realStartPoint = TransformBackPoint(startPoint);
            Point realEndPoint = TransformBackPoint(endPoint);
            _graphics.DrawLine(Pens.Black, 
                (float)realStartPoint.X, 
                (float)realStartPoint.Y, 
                (float)realEndPoint.X, 
                (float)realEndPoint.Y);
        }

        //draw rectangle
        public void DrawRectangle(Point upperLeftPoint , Point lowerRightPoint)
        {
            Point realUpperLeftPoint = TransformBackPoint(upperLeftPoint);
            Point realLowerRightPoint = TransformBackPoint(lowerRightPoint);

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
            Point realStartPoint = TransformBackPoint(startPoint);
            Point realEndPoint = TransformBackPoint(endPoint);
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
            Point realUpperLeftPoint = TransformBackPoint(upperLeftPoint);
            Point realLowerRightPoint = TransformBackPoint(lowerRightPoint);
            float realSelectPointSize = selectPointSize / ScreenSize.WIDTH * _canvasWidth;

            _graphics.DrawEllipse(Pens.Blue, (float)realUpperLeftPoint.X - realSelectPointSize / TWO, (float)realUpperLeftPoint.Y - realSelectPointSize / TWO, realSelectPointSize, realSelectPointSize);
            _graphics.DrawEllipse(Pens.Blue, (float)realUpperLeftPoint.X - realSelectPointSize / TWO, (float)realLowerRightPoint.Y - realSelectPointSize / TWO, realSelectPointSize, realSelectPointSize);
            _graphics.DrawEllipse(Pens.Blue, (float)realLowerRightPoint.X - realSelectPointSize / TWO, (float)realUpperLeftPoint.Y - realSelectPointSize / TWO, realSelectPointSize, realSelectPointSize);
            _graphics.DrawEllipse(Pens.Blue, (float)realLowerRightPoint.X - realSelectPointSize / TWO, (float)realLowerRightPoint.Y - realSelectPointSize / TWO, realSelectPointSize, realSelectPointSize);

            _graphics.DrawEllipse(Pens.Blue, (float)(realUpperLeftPoint.X + realLowerRightPoint.X) / TWO - realSelectPointSize / TWO, (float)realUpperLeftPoint.Y - realSelectPointSize / TWO, realSelectPointSize, realSelectPointSize);
            _graphics.DrawEllipse(Pens.Blue, (float)(realUpperLeftPoint.X + realLowerRightPoint.X) / TWO - realSelectPointSize / TWO, (float)realLowerRightPoint.Y - realSelectPointSize / TWO, realSelectPointSize, realSelectPointSize);
            _graphics.DrawEllipse(Pens.Blue, (float)realUpperLeftPoint.X - realSelectPointSize / TWO, (float)(realUpperLeftPoint.Y + realLowerRightPoint.Y) / TWO - realSelectPointSize / TWO, realSelectPointSize, realSelectPointSize);
            _graphics.DrawEllipse(Pens.Blue, (float)realLowerRightPoint.X - realSelectPointSize / TWO, (float)(realUpperLeftPoint.Y + realLowerRightPoint.Y) / TWO - realSelectPointSize / TWO, realSelectPointSize, realSelectPointSize);

            _graphics.DrawRectangle(Pens.BlueViolet, (float)realUpperLeftPoint.X, (float)realUpperLeftPoint.Y, (float)(realLowerRightPoint.X - realUpperLeftPoint.X), (float)(realLowerRightPoint.Y - realUpperLeftPoint.Y));
        }
    }
}
