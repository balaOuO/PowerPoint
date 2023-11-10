using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Point
    {
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
            const string LEFT = "(";
            const string RIGHT = ")";
            const string COMMA = ",";
            return LEFT + X + COMMA + Y + RIGHT;
        }

        ////point + method
        //public static Point operator +(Point point1 , Point point2)
        //{
        //    return new Point(point1.X + point2.X, point1.Y + point2.Y);
        //}

        ////point - method
        //public static Point operator -(Point point1 , Point point2)
        //{
        //    return new Point(point1.X - point2.X, point1.Y - point2.Y);
        //}
    }
}
