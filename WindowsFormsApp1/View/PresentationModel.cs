using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.View;

namespace WindowsFormsApp1
{
    public class PresentationModel
    {
        private delegate void ClickChangeShapeButtonEventHandler();
        private event ClickChangeShapeButtonEventHandler _changeShapeButtonUpdate;

        private Model _model;
        private CanvasState _canvasState;
        private Dictionary<string, ButtonState> _chooseShapeButtonState = new Dictionary<string, ButtonState>();
        private string _lastChooseShape = ShapeName.POINTER;

        public PresentationModel(Model model)
        {
            _canvasState = new PointerState(this);
            _model = model;
            _chooseShapeButtonState.Add(ShapeName.RECTANGLE, new ButtonState(false));
            _chooseShapeButtonState.Add(ShapeName.LINE, new ButtonState(false));
            _chooseShapeButtonState.Add(ShapeName.ELLIPSE, new ButtonState(false));
            _chooseShapeButtonState.Add(ShapeName.POINTER, new ButtonState(true));
            _changeShapeButtonUpdate += _chooseShapeButtonState[ShapeName.POINTER].ResetState;
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

        public Dictionary<string, ButtonState> ChooseShapeButtonState
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
            NotifyChangeShapeButtonStatusChange();
            _chooseShapeButtonState[buttonName].State = true;
            _changeShapeButtonUpdate += _chooseShapeButtonState[buttonName].ResetState;
            _lastChooseShape = buttonName;
            CreateCanvasState();
            
            //_model.DrawingShapeType = buttonName;
        }

        //Create State
        public void CreateCanvasState()
        {
            switch (_lastChooseShape)
            {
                case ShapeName.POINTER:
                    _canvasState = new PointerState(this);
                    break;
                default:
                    _canvasState = new DrawingState(this, _model, _chooseShapeButtonState);
                    break;
            }
        }

        //return cursor state
        public Cursor GetCursorState()
        {
            return _canvasState.GetCursorState();
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
        }

        //Notify Change Shape Buton Status Change
        private void NotifyChangeShapeButtonStatusChange()
        {
            if (_changeShapeButtonUpdate != null)
            {
                _changeShapeButtonUpdate();
                _changeShapeButtonUpdate = null;
            }
        }
    }
}
