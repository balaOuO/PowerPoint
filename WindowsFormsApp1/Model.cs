using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Model
    {
        private Shapes _shapes = new Shapes();

        //add shape method
        public void AddShape(string shapeType , Point upperLeftPoint , Point lowerRightPoint)
        {
            _shapes.AddShape(shapeType, upperLeftPoint, lowerRightPoint);
        }

        //delete shape
        public void DeleteShape(int index)
        {
            _shapes.DeleteShape(index);
        }

        public List<Shape> ShapeList
        {
            get
            {
                return _shapes.ShapeList;
            }
        }
    }
}
