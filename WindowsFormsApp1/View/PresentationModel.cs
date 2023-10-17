using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class PresentationModel
    {
        public delegate void ClickChangeShapeButtonEventHandler();
        public event ClickChangeShapeButtonEventHandler _changeShapeButtonUpdate;
        private Model _model;
        private Dictionary<string, bool> _chooseShapeButtonState = new Dictionary<string, bool>();
        private string _lastChooseShape = null;
        private bool _canDraw = false;
        private bool _pointerPress = false;

        public PresentationModel(Model model)
        {
            _model = model;
            _chooseShapeButtonState.Add(ShapeName.RECTANGLE, false);
            _chooseShapeButtonState.Add(ShapeName.LINE, false);
            _chooseShapeButtonState.Add(ShapeName.ELLIPSE, false);
        }

        public Dictionary<string, bool> ChooseShapeButtonState
        {
            get
            {
                return _chooseShapeButtonState;
            }
        }

        //choose shape on toolbar
        public void ClickChooseShapeButton(string buttonName)
        {
            _canDraw = true;
            if (_lastChooseShape != buttonName)
            {
                if (_lastChooseShape != null)
                {
                    _chooseShapeButtonState[_lastChooseShape] = false;
                }
                _chooseShapeButtonState[buttonName] = true;
                _lastChooseShape = buttonName;
                _model.DrawingShapeType = buttonName;
                NotifyChangeShapeButtonStatusChange();
            }
        }

        //return cursor state
        public Cursor GetCursorState()
        {
            if (_canDraw == true)
            {
                return Cursors.Cross;
            }
            else
            {
                return Cursors.Default;
            }
        }

        //Notify Change Shape Buton Status Change
        private void NotifyChangeShapeButtonStatusChange()
        {
            if (_changeShapeButtonUpdate != null)
            {
                _changeShapeButtonUpdate();
            }
        }

        //Pointer Pressed Canvas
        public void PressedOnCanvas(Point pointer)
        {
            if (_canDraw == true)
            {
                _pointerPress = true;
                _model.PressedOnCanvas(pointer);
            }            
        }

        //Pointer Moved in Canvas
        public void MovedOnCanvas(Point pointer)
        {
            if (_canDraw == true && _pointerPress == true)
            {
                _model.MovedOnCanvas(pointer);
            }
        }

        //Pointer Released Canvas
        public void ReleasedCanvas(Point pointer)
        {
            if (_canDraw == true && _pointerPress == true)
            {
                _pointerPress = false;
                _canDraw = false;
                _chooseShapeButtonState[_lastChooseShape] = false;
                _lastChooseShape = null;
                NotifyChangeShapeButtonStatusChange();
                _model.ReleasedCanvas(pointer);
            }
        }
    }
}
