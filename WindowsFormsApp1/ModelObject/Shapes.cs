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

        public delegate void ReferOnEventHandler(string referPart);
        public event ReferOnEventHandler _referOn;

        private BindingList<Shape> _shapeList = new BindingList<Shape>();
        protected Factory _factory = new Factory(new Random());
        private Shape _shape;

        private Action _cancelSelect;
        private Action<Point> _moveSelectShape;
        private Action<string> _updateInfo;
        private Action<Point> _referSelectShape;

        public BindingList<Shape> ShapeList
        {
            get
            {
                return _shapeList;
            }
        }

        //GetSelectedShapeIndex
        /// <returns>If no select return -1</returns>
        public int GetSelectedShapeIndex()
        {
            for (int i = 0; i < _shapeList.Count; i++)
            {
                if (_shapeList[i].IsSelect)
                {
                    return i;
                }
            }
            return -1;
        }

        //add shape method
        public virtual void AddShape(string shapeType, Point upperLeftPoint, Point lowerRightPoint)
        {
            _shape = Factory.CreateShapes(shapeType);
            _shape.SetPoint(upperLeftPoint, lowerRightPoint);
            NotifyDataChanged();
        }

        //add shape in shape list
        public virtual void AddShapeToList()
        {
            if (_referOn != null)
                _shape._referToThePart += _referOn.Invoke;
            _shapeList.Add(_shape);
            _shape = null;
            NotifyDataChanged();
        }

        //InsertShapeToList
        public virtual void InsertShapeToList(string shapeType , Point startPoint , Point endPoint , int index)
        {
            _shape = Factory.CreateShapes(shapeType);
            _shape.SetPoint(startPoint, endPoint);
            if (_referOn != null)
                _shape._referToThePart += _referOn.Invoke;
            _shapeList.Insert(index, _shape);
            _shape = null;
            NotifyDataChanged();
        }

        //delete shape
        public virtual void DeleteShapeByIndex(int index)
        {
            if (index == -1)
            {
                _shapeList.RemoveAt(_shapeList.Count - 1);
            }
            else if (index < _shapeList.Count && index >= 0)
            {
                _shapeList.RemoveAt(index);
                if (_referOn != null)
                    _referOn(ShapePart.ELSE);
            }
            NotifyDataChanged();
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
                    _updateInfo += _shapeList[i].Update;
                    _referSelectShape += _shapeList[i].ReferPart;
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
                _moveSelectShape = null;
                _updateInfo = null;
                _referSelectShape = null;
                NotifyDataChanged();
            }
        }

        const string INFO = "Info";

        //updateInfo
        public virtual void UpdateInfo()
        {
            if (_updateInfo != null)
            {
                _updateInfo(INFO);
            }
        }

        //ReferSelectedShape
        public virtual void ReferSelectedShape(Point point)
        {
            if (_referSelectShape != null)
            {
                _referSelectShape(point);
            }
        }
    }
}
