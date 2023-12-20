using System;
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
        private Point _startPoint;
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
                _startPoint = pointer;
            }            
        }

        //release method
        public void Release(Point pointer)
        {
            if (_isPress)
            {
                _isPress = false;
                _model.CommandManager.Execute(new AddShapeCommand(_model, _model.PageIndex , _shape , _startPoint , pointer));
                _model.NotifyDrawingFinish();
            }
        }
    }
}
