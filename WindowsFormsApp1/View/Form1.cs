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
            this._shapeList.AutoGenerateColumns = false;

            this._model = model;
            this._model._shapeDataChanged += UpdateCanvas;

            _presentationModel = presentationModel;

            _page1.Height = (int)((float)_page1.Width / (float)_canvas.Width * _canvas.Height);
            _canvas.Width = splitContainer2.Panel1.Width;
            _canvas.Height = (int)((float)_canvas.Width * SCREENSCALE);

            InitializeEvent();
            InitializeDataBinding();
        }

        //Initialize Canvas event
        public void InitializeEvent()
        {
            this.KeyPreview = true;
            this.KeyDown += HandleKeyDown;
            _canvas.Paint += HandleCanvasPaint;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.MouseEnter += EnterCanvas;
            _canvas.MouseLeave += LeaveCanvas;
            _canvas.Resize += HandleCanvasResize;
            this.splitContainer2.Panel1.Resize += HandleCanvasContainerResize;

            _page1.Paint += PagePaint;
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
            
            _shapeList.DataSource = _model.ShapeList;
        }

        //update canvas
        private void UpdateCanvas()
        {
            _canvas.Invalidate(true);
            _page1.Invalidate(true);
        }

        //clicl add btn
        private void ClickAddShape(object sender, EventArgs e)
        {
            _model.AddShape(_selectShape.Text);
        }
        
        //click delete button in data grid view
        private void ShapeListCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                _model.DeleteShapeButton(e.RowIndex);
            }
        }

        //choose rectangle to draw
        private void ClickChooseShapeRectangleButton(object sender, EventArgs e)
        {
            _presentationModel.SetChooseShapeButton(ShapeName.RECTANGLE);
        }

        //choose line to draw
        private void ClickChooseShapeLineButton(object sender, EventArgs e)
        {
            _presentationModel.SetChooseShapeButton(ShapeName.LINE);
        }

        //choose ellipse to draw
        private void ClickChooseShapeEllipseButton(object sender, EventArgs e)
        {
            _presentationModel.SetChooseShapeButton(ShapeName.ELLIPSE);
        }

        //Click Choose Shape Pointer Button
        private void ClickChooseShapePointerButton(object sender, EventArgs e)
        {
            _presentationModel.SetChooseShapeButton(ShapeName.POINTER);
        }

        //Entry canvas event
        private void EnterCanvas(object sender , EventArgs e)
        {
            //Cursor = _presentationModel.GetCursorState();
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
            _model.Draw(new WindowsFormsGraphicsAdaptor(e.Graphics , _canvas.Width , _canvas.Height));
        }

        //page paing event
        public void PagePaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //Let it smooth
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            _model.Draw(new WindowsFormsPreviewGraphicsAdaptor(e.Graphics , _page1.Width , _page1.Height));
        }

        //
        public Point MappingPoint(Point point)
        {
            const int Height = 900;
            const int Width = 1600;
            return new Point((point.X / _canvas.Width) * Width, (point.Y / _canvas.Height) * Height);
        }

        //press canvas event method
        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.PressCanvas(MappingPoint(new Point(e.X, e.Y)));
        }

        //release canvas event method
        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.ReleaseCanvas(MappingPoint(new Point(e.X, e.Y)));
        }

        //move on canvas event method
        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.MoveOnCanvas(MappingPoint(new Point(e.X, e.Y)));
            Cursor = _presentationModel.GetCursors();
        }

        //canvas key down event
        public void HandleKeyDown(object sender , KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Delete)
            {
                _model.DeleteSelect();
                Cursor = _presentationModel.GetCursors();
            }
        }

        //canvas resize
        public void HandleCanvasResize(object sender, EventArgs e)
        {
            _page1.Height = (int)((float)_page1.Width / (float)_canvas.Width * _canvas.Height) + 1;
            _canvas.Invalidate();
        }

        const float SCREENSCALE = (float)9 / (float)16; 
        //canvas container resize
        public void HandleCanvasContainerResize(object sender, EventArgs e)
        {
            _canvas.Width = splitContainer2.Panel1.Width;
            _canvas.Height = (int)((float)_canvas.Width * SCREENSCALE);
        }
    }
}
