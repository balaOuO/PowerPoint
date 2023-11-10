using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public interface IGraphics
    {
        //clear screen
        void ClearAll();

        //draw line
        void DrawLine(Point startPoint, Point endPoint);

        //draw rectangle
        void DrawRectangle(Point startPoint, Point endPoint);

        //draw ellipse
        void DrawEllipse(Point startPoint, Point endPoint);

        //draw select point
        void DrawSelectPoint(Point startPoint, Point endPoint);
    }
}
