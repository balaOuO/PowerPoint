using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WindowsFormsApp1
{
    public class Model
    {
        public delegate void ShapeDataChangedEventHandler();
        public event ShapeDataChangedEventHandler _shapeDataChanged;

        private Shapes _shapes = new Shapes();

        public BindingList<Shape> ShapeList
        {
            get
            {
                return _shapes.ShapeList;
            }
        }

        //add shape method
        public void AddShape(string shapeType , Point upperLeftPoint , Point lowerRightPoint)
        {
            _shapes.AddShape(shapeType, upperLeftPoint, lowerRightPoint);
            NotifyDataChanged();
        }

        //add shape random
        public void AddShapeRandom(string shapeType , int screenWidth , int screenHeight)
        {
            _shapes.AddShapeRandom(shapeType , screenWidth, screenHeight);
            NotifyDataChanged();
        }

        //modify shape
        public void ModifyShape(Point pointer)
        {
            _shapes.ModifyShape(pointer);
            NotifyDataChanged();
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
            if (_shapeDataChanged != null)
            {
                _shapeDataChanged();
            }
        }
    }
}
