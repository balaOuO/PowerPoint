using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.ShapeObject;

namespace WindowsFormsApp1
{
    class Factory
    {
        const string RECTANGLE = "矩形";
        const string LINE = "線";
        const string ELLIPSE = "圓";

        //creat shape
        public Shape CreateShapes(string shapeType)
        {
            switch (shapeType)
            {
                case RECTANGLE:
                    return new Rectangle();
                case LINE:
                    return new Line();
                case ELLIPSE:
                    return new Ellipse();
            }
            return null;
        }
    }
}
