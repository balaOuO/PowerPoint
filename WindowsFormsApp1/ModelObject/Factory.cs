using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace WindowsFormsApp1
{
    public class Factory
    {
        private Random _random;
        public Factory(Random random)
        {
            _random = random;
        }

        //creat shape
        public static Shape CreateShapes(string shapeType)
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
