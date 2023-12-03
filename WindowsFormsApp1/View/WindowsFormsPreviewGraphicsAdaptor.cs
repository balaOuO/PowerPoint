using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class WindowsFormsPreviewGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;
        const int Width = 1600;
        const int Height = 900;
        private int _canvasWidth;
        private int _canvasHeight;
        public WindowsFormsPreviewGraphicsAdaptor(Graphics graphics, int canvasWidth, int canvasHeight) //, int canvasWidth , int canvasHeight
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
        public void DrawLine(Point startPoint, Point endPoint)
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
        public void DrawRectangle(Point upperLeftPoint, Point lowerRightPoint)
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
        public void DrawEllipse(Point startPoint, Point endPoint)
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
        public void DrawSelectPoint(Point upperLeftPoint, Point lowerRightPoint, float selectPointSize)
        {
        }
    }
}
