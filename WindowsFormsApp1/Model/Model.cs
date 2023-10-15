using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Model
    {
        public delegate void ModelDataChangeEventHandler();
        public event ModelDataChangeEventHandler _dataChange;

        private Shapes _shapes = new Shapes();

        public List<Shape> ShapeList
        {
            get
            {
                return _shapes.ShapeList;
            }
        }

        public string DrawingShapeType
        {
            set
            {
                _shapes.DrawingShapeType = value;
            }
        }

        //add shape method
        public void AddShape(string shapeType , Point upperLeftPoint , Point lowerRightPoint)
        {
            _shapes.AddShape(shapeType, upperLeftPoint, lowerRightPoint);
            NotifyDataChange();
        }

        //delete shape
        public void DeleteShape(int index)
        {
            _shapes.DeleteShape(index);
            NotifyDataChange();
        }

        //draw method
        public void Draw(Graphics graphics)
        {
            _shapes.Draw(graphics);
        }

        //Pointer Pressed Canvas
        public void PressedOnCanvas(Point pointer)
        {
            _shapes.PressedOnCanvas(pointer);
            NotifyDataChange();
        }

        //Pointer Moved in Canvas
        public void MovedOnCanvas(Point pointer)
        {
            _shapes.MovedOnCanvas(pointer);
            NotifyDataChange();
        }

        //Pointer Released Canvas
        public void ReleasedCanvas(Point pointer)
        {
            _shapes.ReleasedCanvas(pointer);
            NotifyDataChange();
        }

        //notify data change
        private void NotifyDataChange()
        {
            if (_dataChange != null)
            {
                _dataChange();
            }
        }
    }
}
