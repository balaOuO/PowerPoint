﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class PresentationModel
    {
        private Action _changeShapeButtonReset = null;

        private Model _model;
        private Dictionary<string, ButtonState> _chooseShapeButtonState = new Dictionary<string, ButtonState>();
        private Cursor _pointerCursorState = Cursors.Default;
        private List<bool> _pageCheckedList = new List<bool>();
        private int _lastChoosePage = 0;

        public PresentationModel(Model model)
        {
            _model = model;
            _model._drawingFinish += InitializeChooseShapeButton;
            _model._referOn += SetCursorState;
            _model.SetRefer();
            _pageCheckedList.Add(false);
            _pageCheckedList.Add(true);
            _chooseShapeButtonState.Add(ShapeName.RECTANGLE, new ButtonState(false));
            _chooseShapeButtonState.Add(ShapeName.LINE, new ButtonState(false));
            _chooseShapeButtonState.Add(ShapeName.ELLIPSE, new ButtonState(false));
            _chooseShapeButtonState.Add(ShapeName.POINTER, new ButtonState(true));
            _changeShapeButtonReset += _chooseShapeButtonState[ShapeName.POINTER].ResetState;
        }

        public Dictionary<string, ButtonState> ChooseShapeButtonState
        {
            get
            {
                return _chooseShapeButtonState;
            }
        }

        public List<bool> PageCheckList
        {
            get
            {
                return _pageCheckedList;
            }
        }

        //initialize choose shape button
        private void InitializeChooseShapeButton()
        {
            SetChooseShapeButton(ShapeName.POINTER);
        }

        //choose shape on toolbar
        public void SetChooseShapeButton(string buttonName)
        {
            InitializeButtonState();
            _chooseShapeButtonState[buttonName].State = true;
            _changeShapeButtonReset += _chooseShapeButtonState[buttonName].ResetState;
            _model.ChooseShape(buttonName);
        }

        //set cursor state
        private void SetCursorState(string state)
        {
            switch (state)
            {
                case ShapePart.LOWER_RIGHT_POINT:
                case ShapePart.UPPER_LEFT_POINT:
                    _pointerCursorState = Cursors.SizeNWSE;
                    break;
                case ShapePart.LOWER_LEFT_POINT:
                case ShapePart.UPPER_RIGHT_POINT:
                    _pointerCursorState = Cursors.SizeNESW;
                    break;
                case ShapePart.ELSE:
                    _pointerCursorState = Cursors.Default;
                    break;
            }
        }

        //cursor state
        public Cursor GetCursors()
        {
            if (ChooseShapeButtonState[ShapeName.POINTER].State)
            {
                return _pointerCursorState;
            }
            else
            {
                return Cursors.Cross;
            }
        }

        //reset button state
        private void InitializeButtonState()
        {
            if (_changeShapeButtonReset != null)
            {
                _changeShapeButtonReset();
                _changeShapeButtonReset = null;
            }
        }
    }
}
