using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.View;

namespace WindowsFormsApp1
{
    public class PresentationModel
    {
        public delegate void ClickChangeShapeButtonEventHandler();
        public event ClickChangeShapeButtonEventHandler _changeShapeButtonUpdate;

        private Model _model;
        private CanvasState _canvasState;
        private Dictionary<string, bool> _chooseShapeButtonState = new Dictionary<string, bool>();
        private string _lastChooseShape = null;

        public PresentationModel(Model model)
        {
            _canvasState = new PointerState(this);
            _model = model;
            _chooseShapeButtonState.Add(ShapeName.RECTANGLE, false);
            _chooseShapeButtonState.Add(ShapeName.LINE, false);
            _chooseShapeButtonState.Add(ShapeName.ELLIPSE, false);
        }

        public string LastChooseShape
        {
            get
            {
                return _lastChooseShape;
            }
            set
            {
                LastChooseShape = value;
            }
        }

        public CanvasState CanvasState
        {
            set
            {
                _canvasState = value;
            }
        }

        public Dictionary<string, bool> ChooseShapeButtonState
        {
            get
            {
                return _chooseShapeButtonState;
            }
        }

        //delete shape
        public void DeleteShapeButton(DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                _model.DeleteShapeButton(e.RowIndex);
            }
        }

        //choose shape on toolbar
        public void ClickChooseShapeButton(string buttonName)
        {
            if (_lastChooseShape != null)
            {
                _chooseShapeButtonState[_lastChooseShape] = false;
            }
            _canvasState = new DrawingState(this, _model, _chooseShapeButtonState);
            _chooseShapeButtonState[buttonName] = true;
            _lastChooseShape = buttonName;
            _model.DrawingShapeType = buttonName;
            NotifyChangeShapeButtonStatusChange();
        }

        //return cursor state
        public Cursor GetCursorState()
        {
            return _canvasState.GetCursorState();
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
            _canvasState.Press(pointer);           
        }

        //Pointer Moved in Canvas
        public void MovedOnCanvas(Point pointer)
        {
            _canvasState.Move(pointer);
        }

        //Pointer Released Canvas
        public void ReleasedCanvas(Point pointer)
        {
            _canvasState.Release();
            NotifyChangeShapeButtonStatusChange();
        }
    }
}
