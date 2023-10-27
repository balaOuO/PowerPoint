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
        private Dictionary<string, ButtonState> _chooseShapeButtonState;
        private bool _pointerPress = false;
        
        public DrawingState(PresentationModel presentationModel , Model model , Dictionary<string , ButtonState> chooseShapeButtonState)
        {
            _presentationModel = presentationModel;
            _model = model;
            _chooseShapeButtonState = chooseShapeButtonState;
        }

        //press method
        public void Press(Point pointer)
        {
            _pointerPress = true;
            _model.AddShape(_presentationModel.LastChooseShape , pointer , pointer);
        }

        //move method
        public void Move(Point pointer)
        {
            if (_pointerPress == true)
            {
                _model.ModifyShape(pointer);
            }
        }

        //release method
        public void Release()
        {
            if (_pointerPress == true)
            {
                _model.AddShapeToList();
                _pointerPress = false;
                _presentationModel.ClickChooseShapeButton(ShapeName.POINTER);
                _presentationModel.CreateCanvasState();
            }
        }

        //Get Cursor State
        public Cursor GetCursorState()
        {
            return Cursors.Cross;
        }
    }
}
