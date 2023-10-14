using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Shapes
    {
        private List<Shape> _shapeList = new List<Shape>();
        private Factory _factory = new Factory();

        public List<Shape> ShapeList
        {
            get
            {
                return _shapeList;
            }
        }

        //add shape method
        public void AddShape(string shapeType, Point upperLeftPoint, Point lowerRightPoint)
        {
            Shape shape = _factory.CreateShapes(shapeType);
            shape.SetPoint(upperLeftPoint, lowerRightPoint);
            _shapeList.Add(shape);
        }

        //delete shape
        public void DeleteShape(int index)
        {
            _shapeList.RemoveAt(index);
        }
    }
}
