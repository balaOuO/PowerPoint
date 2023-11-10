using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class WindowsFormsPreviewGraphicsAdopter : IGraphics
    {
        Graphics _graphics;
        float _mapping;
        public WindowsFormsPreviewGraphicsAdopter(Graphics graphics , float mapping)
        {
            _graphics = graphics;
            _mapping = mapping;
        }
        //clear screen
        public void ClearAll()
        {
            //nothing
        }

        //draw line
        public void DrawLine(Point startPoint, Point endPoint)
        {
            _graphics.DrawLine(Pens.Black,
                (float)startPoint.X * _mapping,
                (float)startPoint.Y * _mapping,
                (float)endPoint.X * _mapping,
                (float)endPoint.Y * _mapping);
        }

        //draw rectangle
        public void DrawRectangle(Point upperLeftPoint, Point lowerRightPoint)
        {
            _graphics.DrawRectangle(
                Pens.Black,
                (float)upperLeftPoint.X * _mapping,
                (float)upperLeftPoint.Y * _mapping,
                (float)(lowerRightPoint.X - upperLeftPoint.X) * _mapping,
                (float)(lowerRightPoint.Y - upperLeftPoint.Y) * _mapping
                );
        }

        //draw ellipse
        public void DrawEllipse(Point startPoint, Point endPoint)
        {
            _graphics.DrawEllipse(Pens.Black,
                (float)startPoint.X * _mapping,
                (float)startPoint.Y * _mapping,
                (float)(endPoint.X - startPoint.X) * _mapping,
                (float)(endPoint.Y - startPoint.Y) * _mapping
                );
        }

        //draw select point
        public void DrawSelectPoint(Point upperLeftPoint, Point lowerRightPoint)
        {
            //nothing
        }
    }
}
