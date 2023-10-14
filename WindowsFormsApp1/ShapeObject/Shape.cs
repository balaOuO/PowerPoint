using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Shape
    {
        private const string INFO = "No Info";
        private const string SHAPE = "None";

        public Point UpperLeftPoint
        {
            get;
            set;
        }

        public Point LowerRightPoint
        {
            get;
            set;
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
        public void SetPoint(Point upperLeftPoint , Point lowerRightPoint)
        {
            this.UpperLeftPoint = upperLeftPoint;
            this.LowerRightPoint = lowerRightPoint;
        }
    }
}
