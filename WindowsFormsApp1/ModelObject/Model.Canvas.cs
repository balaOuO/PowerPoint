using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.ModelObject.State;

namespace WindowsFormsApp1
{
    public partial class Model
    {
        public delegate void DrawingFinishEventHandler();
        public event DrawingFinishEventHandler _drawingFinish;

        public delegate void ReferOnEventHandler(string referPart);
        public event ReferOnEventHandler _referOn;

        private PointerState _pointerState;
        private DrawingState _drawingState;
        private ICanvasState _canvasState;

        //initialize about canvas part
        private void InitializeCanvas()
        {
            _pointerState = new PointerState(this);
            _drawingState = new DrawingState(this);
            _canvasState = _pointerState;
        }

        //set _refer
        public void SetRefer()
        {
            if (_referOn != null)
                Shapes._referOn += _referOn.Invoke;
        }

        //choose shape
        public void ChooseShape(string button)
        {
            switch (button)
            {
                case (ShapeName.POINTER):
                    _canvasState = _pointerState;
                    break;
                default:
                    _canvasState = _drawingState;
                    _drawingState.DrawingShape = button;
                    break;
            }
        }

        //press canvas
        public void PressCanvas(Point pointer)
        {
            _canvasState.Press(pointer);
        }

        //move on canvas
        public void MoveOnCanvas(Point pointer)
        {
            _canvasState.Move(pointer);
        }

        //release canvas
        public void ReleaseCanvas(Point pointer)
        {
            _canvasState.Release(pointer);
        }

        //notify drawing finish
        public void NotifyDrawingFinish()
        {
            _canvasState = _pointerState;
            if (_drawingFinish != null)
            {
                _drawingFinish();
            }
        }
    }
}
