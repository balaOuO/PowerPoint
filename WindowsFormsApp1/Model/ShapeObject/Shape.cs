using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Shape
    {
        private const string INFO = "No Info";
        private const string SHAPE = "None";
        protected Point _startPoint;
        protected Point _endPoint;

        public Point StartPoint
        {
            get
            {
                return _startPoint;
            }
        }

        public Point EndPoint
        {
            get
            {
                return _endPoint;
            }
        }

        // GetInfo method
        public virtual string GetInfo()
        {
            return INFO;
        }

        // GetShapeName method
        public virtual string GetShapeName()
        {
            return SHAPE;
        }

        //set point method
        public virtual void SetPoint(Point point1 , Point point2)
        {
            _startPoint = point1;
            _endPoint = point2;
        }

        //set end point
        public virtual void SetEndPoint(Point endPoint)
        {
            SetPoint(_startPoint, endPoint);
        }

        //draw mathod interface
        public virtual void Draw(IGraphics graphics)
        {
            return;
        }
    }
}
