﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ModelObject.State
{
    class PointerState : CanvasState
    {
        private Model _model;
        private Point _startPoint;
        private Point _endPoint;
        private bool _isPress = false;
        public PointerState(Model model)
        {
            _model = model;
            _startPoint = new Point(0, 0);
            _endPoint = new Point(0, 0);
        }

        //move method
        public void Move(Point pointer)
        {
            if (_isPress)
            {
                _endPoint = pointer;
                _model.Shapes.MoveShape(new Point(_endPoint.X - _startPoint.X, _endPoint.Y - _startPoint.Y));
                _startPoint = pointer;
            }
        }

        //press method
        public void Press(Point pointer)
        {
            _isPress = true;
            _model.Shapes.SelectShape(pointer);
            _startPoint = pointer;
        }

        //release method
        public void Release()
        {
            if (_isPress)
            {
                _isPress = false;
            }
        }
    }
}
