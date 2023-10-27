using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class PowerPointForm : Form
    {
        Model _model;
        PresentationModel _presentationModel;
        public PowerPointForm(Model model , PresentationModel presentationModel)
        {
            InitializeComponent();
            this._model = model;
            this._model._shapeListChanged += UpdateView;
            this._model._temporaryShapeChanged += UpdateCanvas;

            _presentationModel = presentationModel;

            InitializeCanvasEvent();
            InitializeDataBinding();
        }

        //Initialize Canvas event
        public void InitializeCanvasEvent()
        {
            _canvas.Paint += HandleCanvasPaint;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.MouseEnter += EnterCanvas;
            _canvas.MouseLeave += LeaveCanvas;
        }

        //Initialize data binding
        public void InitializeDataBinding()
        {
            const string CHECK = "Checked";
            const string STATE = "State";
            _chooseShapeLineButton.DataBindings.Add(CHECK, _presentationModel.ChooseShapeButtonState[ShapeName.LINE], STATE);
            _chooseShapeRectangleButton.DataBindings.Add(CHECK, _presentationModel.ChooseShapeButtonState[ShapeName.RECTANGLE], STATE);
            _chooseShapeEllipseButton.DataBindings.Add(CHECK, _presentationModel.ChooseShapeButtonState[ShapeName.ELLIPSE], STATE);
            _chooseShapePointerButton.DataBindings.Add(CHECK, _presentationModel.ChooseShapeButtonState[ShapeName.POINTER], STATE);
        }

        //update data grid view
        private void UpdateView()
        {
            _shapeList.Rows.Clear();
            List<Shape> shapeList = _model.ShapeList;
            for (int i = 0; i < shapeList.Count; i++)
            {
                _shapeList.Rows.Add(0, shapeList[i].GetShapeName(), shapeList[i].GetInfo());
            }
            _canvas.Invalidate(true);
        }

        //update canvas
        private void UpdateCanvas()
        {
            _canvas.Invalidate(true);
        }

        //clicl add btn
        private void ClickAddShape(object sender, EventArgs e)
        {
            _model.AddShapeRandom(_selectShape.Text , _canvas.Width, _canvas.Height);
        }
        
        //click delete button in data grid view
        private void ShapeListCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _presentationModel.DeleteShapeButton(e);
        }

        //choose rectangle to draw
        private void ClickChooseShapeRectangleButton(object sender, EventArgs e)
        {
            _presentationModel.ClickChooseShapeButton(ShapeName.RECTANGLE);
        }

        //choose line to draw
        private void ClickChooseShapeLineButton(object sender, EventArgs e)
        {
            _presentationModel.ClickChooseShapeButton(ShapeName.LINE);
        }

        //choose ellipse to draw
        private void ClickChooseShapeEllipseButton(object sender, EventArgs e)
        {
            _presentationModel.ClickChooseShapeButton(ShapeName.ELLIPSE);
        }

        //Entry canvas event
        private void EnterCanvas(object sender , EventArgs e)
        {
            Cursor = _presentationModel.GetCursorState();
        }

        //Leave canvas event
        private void LeaveCanvas(object sender , EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        //canvas draw event method
        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //Let it smooth
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            _model.Draw(new WindowsFormsGraphicsAdaptor(e.Graphics));
        }

        //press canvas event method
        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _presentationModel.PressedOnCanvas(new Point(e.X , e.Y));
        }

        //release canvas event method
        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _presentationModel.ReleasedCanvas(new Point(e.X, e.Y));
            Cursor = _presentationModel.GetCursorState();
        }

        //press and move on canvas event method
        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _presentationModel.MovedOnCanvas(new Point(e.X, e.Y));
        }

        private void ClickChooseShapePointerButton(object sender, EventArgs e)
        {
            _presentationModel.ClickChooseShapeButton(ShapeName.POINTER);
        }
    }
}
