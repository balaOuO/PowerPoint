using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ModelObject.File
{
    public class ShapeFormat
    {
        public ShapeFormat(Shape shape)
        {
            ShapeName = shape.ShapeName;
            StartPointX = shape.StartPoint.X;
            StartPointY = shape.StartPoint.Y;
            EndPointX = shape.EndPoint.X;
            EndPointY = shape.EndPoint.Y;
        }

        public ShapeFormat()
        {

        }
        public string ShapeName
        {
            get; set;
        }

        public double StartPointX
        {
            get; set;
        }

        public double StartPointY
        {
            get; set;
        }

        public double EndPointX
        {
            get; set;
        }

        public double EndPointY
        {
            get; set;
        }

        //Read
        public Shape Read()
        {
            Shape shape = Factory.CreateShapes(ShapeName);
            shape.SetPoint(new Point(StartPointX, StartPointY), new Point(EndPointX, EndPointY));
            return shape;
        }
    }
}
