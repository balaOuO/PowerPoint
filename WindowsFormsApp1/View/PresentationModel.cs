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
        private Cursor _pointerCursorState = Cursors.Default;
        private List<bool> _pageCheckedList = new List<bool>();

        public PresentationModel(Model model)
        {
            _model = model;
            _model._drawingFinish += InitializeChooseShapeButton;
            _model._referOn += SetCursorState;
            _model.SetRefer();
            //_model._pageDataChange += UpdatePageCheckList;
            _pageCheckedList.Add(true);
            _chooseShapeButtonState.Add(ShapeName.RECTANGLE, new ButtonState(false));
            _chooseShapeButtonState.Add(ShapeName.LINE, new ButtonState(false));
            _chooseShapeButtonState.Add(ShapeName.ELLIPSE, new ButtonState(false));
            _chooseShapeButtonState.Add(ShapeName.POINTER, new ButtonState(true));
            _changeShapeButtonReset += _chooseShapeButtonState[ShapeName.POINTER].ResetState;
        }

        //Resize
        public static int Resize(int knowValue , int modelNeedValue , int modelKnowValue)
        {
            return (int)((double)knowValue / (double)modelKnowValue * (double)modelNeedValue);
        }

        //TransformPoint
        public static Point TransformPoint(Point point , Point canvasSize)
        {
            return new Point((point.X / canvasSize.X) * ScreenSize.WIDTH, (point.Y / canvasSize.Y) * ScreenSize.HEIGHT);
        }

        const int TWO = 2;

        //CalculateLocation
        public static int CalculateLocation(int containerSize , int canvasSize)
        {
            return (containerSize - canvasSize) / TWO;
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

        public int LastChoosePage
        {
            get
            {
                return _model.PageIndex;
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

        //ChoosePage
        public void ChoosePage(int index)
        {
            _pageCheckedList[LastChoosePage] = false;
            _pageCheckedList[index] = true;
            _model.SetPageIndex(index);
        }

        //UpdatePageCheckList
        public void UpdatePageCheckList()
        {
            _pageCheckedList.Clear();
            for (int i = 0; i < _model.PageList.Count; i++)
            {
                if (i == _model.PageIndex)
                {
                    _pageCheckedList.Add(true);
                }
                else
                    _pageCheckedList.Add(false);
            }
        }
    }
}
