using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Shapes
    {
        private List<Shape> _shapeList = new List<Shape>();
        private Factory _factory = new Factory();
        private Shape _shape;

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
            _shape = _factory.CreateShapes(shapeType);
            _shape.SetPoint(upperLeftPoint, lowerRightPoint);
        }

        //add shape random
        public void AddShapeRandom(string shapeType , int screenWidth, int screenHeight)
        {
            AddShape(shapeType, _factory.CreateRandomPoint(screenWidth, screenHeight), _factory.CreateRandomPoint(screenWidth, screenHeight));
            AddShapeToList();
        }

        //add shape in shape list
        public void AddShapeToList()
        {
            _shapeList.Add(_shape);
            _shape = null;
        }

        //delete shape
        public void DeleteShape(int index)
        {
            _shapeList.RemoveAt(index);
        }

        //draw method
        public void Draw(IGraphics graphics)
        {
            //減少鋸齒
            //graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (Shape aShape in _shapeList)
            {
                aShape.Draw(graphics);
            }

            if (_shape != null)
            {
                _shape.Draw(graphics);
            }
        }

        //modify shape
        public void ModifyShape(Point pointer)
        {
            _shape.SetEndPoint(pointer);
        }
    }
}
