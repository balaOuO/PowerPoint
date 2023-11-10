using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ModelObject.State
{
    class DrawingState : CanvasState
    {
        private Model _model;
        private bool _isPress = false;
        private string _shape = ShapeName.RECTANGLE;
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
            _isPress = true;
            _model.Shapes.AddShape(_shape , pointer , pointer);
        }

        //release method
        public void Release()
        {
            if (_isPress)
            {
                _isPress = false;
                _model.Shapes.AddShapeToList();
                _model.SwitchPointerState();
                _model.NotifyDrawingFinish();
            }
        }
    }
}
