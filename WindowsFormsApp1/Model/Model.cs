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
        public delegate void ShapeListChangedEventHandler();
        public event ShapeListChangedEventHandler _shapeListChanged;

        public delegate void TemporaryShapeChangedEventHandler();
        public event TemporaryShapeChangedEventHandler _temporaryShapeChanged;

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
            NotifyDataChanged();
        }

        //modify shape
        public void ModifyShape(Point pointer)
        {
            _shapes.ModifyShape(pointer);
            NotifyTemporaryShapeChanged();
        }

        //add shape to list
        public void AddShapeToList()
        {
            _shapes.AddShapeToList();
            NotifyDataChanged();
        }

        //delete shape
        public void DeleteShapeButton(int index)
        {
            _shapes.DeleteShape(index);
            NotifyDataChanged();
        }

        //draw method
        public void Draw(IGraphics graphics)
        {
            _shapes.Draw(graphics);
        }

        //notify data change
        private void NotifyDataChanged()
        {
            if (_shapeListChanged != null)
            {
                _shapeListChanged();
            }
        }

        //notify Temporary Shape Changed
        private void NotifyTemporaryShapeChanged()
        {
            if (_temporaryShapeChanged != null)
            {
                _temporaryShapeChanged();
            }
        }
    }
}
