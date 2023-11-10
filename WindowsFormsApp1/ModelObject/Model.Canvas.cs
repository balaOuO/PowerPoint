using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.ModelObject.State;

namespace WindowsFormsApp1
{
    partial class Model
    {
        public delegate void DrawingFinishEventHandler();
        public event DrawingFinishEventHandler _drawingFinish;

        private PointerState _pointerState;
        private DrawingState _drawingState;
        private CanvasState _canvasState;

        //initialize about canvas part
        private void InitializeCanvas()
        {
            _pointerState = new PointerState(this);
            _drawingState = new DrawingState(this);
            _canvasState = _pointerState;
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

        //switch pointer state
        public void SwitchPointerState()
        {
            _canvasState = _pointerState;
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
            _canvasState.Release();
        }

        //notify drawing finish
        public void NotifyDrawingFinish()
        {
            if (_drawingFinish != null)
            {
                _drawingFinish();
            }
        }
    }
}
