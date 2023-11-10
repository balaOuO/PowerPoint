using System;
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

        public PresentationModel(Model model)
        {
            _model = model;
            _model._drawingFinish += InitializeChooseShapeButton;
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

        //initialize choose shape button
        private void InitializeChooseShapeButton()
        {
            SetChooseShapeButton(ShapeName.POINTER);
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
        public void SetChooseShapeButton(string buttonName)
        {
            InitializeButtonState();
            _chooseShapeButtonState[buttonName].State = true;
            _changeShapeButtonReset += _chooseShapeButtonState[buttonName].ResetState;
            _model.ChooseShape(buttonName);
        }

        //cursor state
        public Cursor GetCursors()
        {
            if (ChooseShapeButtonState[ShapeName.POINTER].State)
            {
                return Cursors.Default;
            }
            else
            {
                return Cursors.Cross;
            }
        }

        //canvas keydown
        public void CanvasKeyDown(Keys keyCode)
        {
            if (keyCode is Keys.Delete)
            {
                _model.DeleteSelect();
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
