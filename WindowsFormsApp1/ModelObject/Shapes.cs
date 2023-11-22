using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WindowsFormsApp1
{
    public class Shapes
    {
        public delegate void ShapeDataChangedEventHandler();
        public event ShapeDataChangedEventHandler _shapeDataChanged;

        private BindingList<Shape> _shapeList = new BindingList<Shape>();
        protected Factory _factory = new Factory(new Random());
        private Shape _shape;

        private Action _cancelSelect;
        private Action<Point> _moveSelectShape; 

        public BindingList<Shape> ShapeList
        {
            get
            {
                return _shapeList;
            }
        }

        //add shape method
        public virtual void AddShape(string shapeType, Point upperLeftPoint, Point lowerRightPoint)
        {
            _shape = Factory.CreateShapes(shapeType);
            _shape.SetPoint(upperLeftPoint, lowerRightPoint);
            NotifyDataChanged();
        }

        //add shape random
        public virtual void AddShape(string shapeType , int screenWidth, int screenHeight)
        {
            AddShape(shapeType, _factory.CreateRandomPoint(screenWidth, screenHeight), _factory.CreateRandomPoint(screenWidth, screenHeight));
            AddShapeToList();
        }

        //add shape in shape list
        public virtual void AddShapeToList()
        {
            _shapeList.Add(_shape);
            _shape = null;
            NotifyDataChanged();
        }

        //delete shape
        public virtual void DeleteShape(int index)
        {
            if (index < _shapeList.Count && index >= 0)
            {
                _shapeList.RemoveAt(index);
                NotifyDataChanged();
            }            
        }

        //delete shape
        public virtual void DeleteSelectShape()
        {
            for (int i = 0; i < _shapeList.Count; i++)
            {
                if (_shapeList[i].IsSelect == true)
                {
                    DeleteShape(i);
                }
            }
        }

        //draw method
        public virtual void Draw(IGraphics graphics)
        {
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
        public virtual void ModifyShape(Point point)
        {
            _shape.SetEndPoint(point);
            NotifyDataChanged();
        }

        //select shape in point
        public virtual void SelectShape(Point point)
        {
            ClearSelect();
            for (int i = _shapeList.Count - 1; i >= 0; i--)
            {
                _shapeList[i].Select(point, point);
                if (_shapeList[i].IsSelect)
                {
                    _cancelSelect += _shapeList[i].CancelSelect;
                    _moveSelectShape += _shapeList[i].Move;
                    NotifyDataChanged();
                    return;
                }
            }
        }

        //Move shape
        public virtual void MoveShape(Point point)
        {
            if (_moveSelectShape != null)
            {
                _moveSelectShape(point);
                NotifyDataChanged();
            }
        }

        //notify data change
        protected void NotifyDataChanged()
        {
            if (_shapeDataChanged != null)
            {
                _shapeDataChanged();
            }
        }

        //clear select
        public void ClearSelect()
        {
            if (_cancelSelect != null)
            {
                _cancelSelect();
                _cancelSelect = null;
                NotifyDataChanged();
            }
            if (_moveSelectShape != null)
            {
                _moveSelectShape = null;
            }
        }
    }
}
