using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Point
    {
        private const string FORMAT = "({0},{1})";
        public Point(double xCoordinate , double yCoordinate)
        {
            this.X = xCoordinate;
            this.Y = yCoordinate;
        }

        public double X
        {
            get;
            set;
        }

        public double Y
        {
            get;
            set;
        }

        // return point in string
        override public string ToString()
        {
            return string.Format(FORMAT, X, Y);
        }
    }
}
