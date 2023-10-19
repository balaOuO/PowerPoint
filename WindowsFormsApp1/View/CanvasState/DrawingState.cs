using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.View
{
    class DrawingState : CanvasState
    {
        private PresentationModel _presentationModel;
        private Model _model;
        public DrawingState(PresentationModel presentationModel)
        {
            _presentationModel = presentationModel;
            _model = presentationModel._model;
        }

        //press method
        public void Press(Point pointer)
        {
            _presentationModel._pointerPress = true;
            _model.AddShape(_presentationModel._lastChooseShape , pointer , pointer);
        }

        //move method
        public void Move(Point pointer)
        {
            if (_presentationModel._pointerPress == true)
            {
                _model.ModifyShape(pointer);
            }
        }

        //release method
        public void Release()
        {
            if (_presentationModel._pointerPress == true)
            {
                _model.AddShapeToList();
                _presentationModel._pointerPress = false;
                _presentationModel._canvasState = new PointerState(_presentationModel);
                _presentationModel._chooseShapeButtonState[_presentationModel._lastChooseShape] = false;
            }
        }

        //Get Cursor State
        public Cursor GetCursorState()
        {
            return Cursors.Cross;
        }
    }
}
