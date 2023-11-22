using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace WindowsFormsApp1Tests1
{
    class MockGraphicAdaptor : IGraphics
    {
        public bool IsDrawSelectPoint 
        {
            get; set;
        }
        public bool IsDrawLine
        {
            get; set;
        }
        public bool IsDrawEllipse
        {
            get; set;
        }
        public bool IsDrawRectangle
        {
            get; set;
        }
        public int TotalDrawShape
        {
            get; set;
        }

        //ClearAll
        public void ClearAll()
        {
        }

        //DrawEllipse
        public void DrawEllipse(Point startPoint, Point endPoint)
        {
            IsDrawEllipse = true;
            TotalDrawShape++;
        }

        //DrawLine
        public void DrawLine(Point startPoint, Point endPoint)
        {
            IsDrawLine = true;
            TotalDrawShape++;
        }

        //DrawRectangle
        public void DrawRectangle(Point startPoint, Point endPoint)
        {
            IsDrawRectangle = true;
            TotalDrawShape++;
        }

        //DrawSelectPoint
        public void DrawSelectPoint(Point startPoint, Point endPoint)
        {
            IsDrawSelectPoint = true;
        }
    }
}
