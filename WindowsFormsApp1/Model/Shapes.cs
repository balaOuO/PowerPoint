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
        private string _drawingShapeType = null;

        public List<Shape> ShapeList
        {
            get
            {
                return _shapeList;
            }
        }

        public string DrawingShapeType
        {
            set
            {
                _drawingShapeType = value;
            }
        }

        //add shape method
        public void AddShape(string shapeType, Point upperLeftPoint, Point lowerRightPoint)
        {
            _shape = _factory.CreateShapes(shapeType);
            _shape.SetPoint(upperLeftPoint, lowerRightPoint);
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

        //Pointer Pressed Canvas
        public void PressedOnCanvas(Point pointer)
        {
            _shape = _factory.CreateShapes(_drawingShapeType);
            _shape.SetPoint(pointer, pointer);
        }

        //Pointer Moved in Canvas
        public void MovedOnCanvas(Point pointer)
        {
            _shape.SetEndPoint(pointer);

        }

        //Pointer Released Canvas
        public void ReleasedCanvas(Point pointer)
        {
            _shape.SetEndPoint(pointer);
            _shapeList.Add(_shape);
            _shape = null;
        }
    }
}
