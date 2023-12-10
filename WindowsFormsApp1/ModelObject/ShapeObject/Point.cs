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
        private const int TWO = 2;
        public Point(double xCoordinate , double yCoordinate)
        {
            X = xCoordinate;
            Y = yCoordinate;
        }

        //Distance
        public static double CalculateDistance(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow(point1.X - point2.X, TWO) + Math.Pow(point1.Y - point2.Y, TWO));
        }

        public double X
        {
            get; set;
        }

        public double Y
        {
            get; set;
        }

        // return point in string
        override public string ToString()
        {
            return string.Format(FORMAT, (int)X, (int)Y);
        }
    }
}
