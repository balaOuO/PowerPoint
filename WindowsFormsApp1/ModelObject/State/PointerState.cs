using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ModelObject.State
{
    public class PointerState : ICanvasState
    {
        private Model _model;
        private Point _point1;
        private Point _point2;
        private Point _startPoint;
        private bool _isPress = false;
        private const string STATE = "PointerState";
        public PointerState(Model model)
        {
            _model = model;
            _point1 = new Point(0, 0);
            _point2 = new Point(0, 0);
        }

        //GetStateName
        public string GetStateName()
        {
            return STATE;
        }

        //move method
        public void Move(Point pointer)
        {
            if (_isPress)
            {
                _point2 = pointer;
                _model.Shapes.MoveShape(new Point(_point2.X - _point1.X, _point2.Y - _point1.Y));
                _point1 = pointer;
            }
            else
            {
                _model.Shapes.ReferSelectedShape(pointer);
            }
        }

        //press method
        public void Press(Point pointer)
        {
            if (!_isPress)
            {
                _isPress = true;
                _model.Shapes.SelectShape(pointer);
                _point1 = pointer;
                _startPoint = pointer;
            }
        }

        //release method
        public void Release(Point pointer)
        {
            if (_isPress)
            {
                _isPress = false;
                _model.Shapes.UpdateInfo();
                if (_startPoint.ToString() != pointer.ToString() && _model.Shapes.GetSelectedShapeIndex() != -1)
                {
                    _model.CommandManager.Add(new MoveCommand(_model , _model.PageIndex , _model.Shapes.GetSelectedShapeIndex(), _startPoint, pointer));
                }
            }
        }
    }
}
