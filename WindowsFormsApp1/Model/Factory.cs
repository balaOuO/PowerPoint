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
        //creat shape
        public Shape CreateShapes(string shapeType)
        {
            switch (shapeType)
            {
                case ShapeName.RECTANGLE:
                    return new Rectangle();
                case ShapeName.LINE:
                    return new Line();
                case ShapeName.ELLIPSE:
                    return new Ellipse();
            }
            return null;
        }
    }
}
