﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ModelObject.State
{
    public class DrawingState : ICanvasState
    {
        private Model _model;
        private bool _isPress = false;
        private string _shape = ShapeName.RECTANGLE;
        private const string STATE = "DrawingState";
        public DrawingState(Model model)
        {
            _model = model;
        }

        public string DrawingShape
        {
            set
            {
                _shape = value;
            }
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
                _model.Shapes.ModifyShape(pointer);
            }
        }

        //press method
        public void Press(Point pointer)
        {
            if (!_isPress)
            {
                _isPress = true;
                _model.Shapes.AddShape(_shape, pointer, pointer);
            }            
        }

        //release method
        public void Release()
        {
            if (_isPress)
            {
                _isPress = false;
                _model.Shapes.AddShapeToList();
                _model.NotifyDrawingFinish();
            }
        }
    }
}