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
            this._model._pageDataChange += UpdatePageList;
            this._model._pageDataChange += UpdateCanvas;
            this._model._pageDataChange += UpdatePageChecked;
            this._model._pageDataChange += ResizePage;

            _presentationModel = presentationModel;

            _canvas.Width = _splitContainer2.Panel1.Width;
            _canvas.Height = (int)((float)_canvas.Width * ((float)ScreenSize.HEIGHT / (float)ScreenSize.WIDTH));
            UpdatePageList();
            UpdatePageChecked();
            ResizePage();

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
            _splitContainer2.Panel1.Resize += HandleSplitContainerResize;
            this._splitContainer2.Panel1.Resize += HandleCanvasContainerResize;
        }

        //Initialize data binding
        public void InitializeDataBinding()
        {
            const string CHECK = "Checked";
            const string ENABLED = "Enabled";
            const string STATE = "State";
            const string IS_UNDO_ENABLED = "IsUndoEnabled";
            const string IS_REDO_ENABLE = "IsRedoEnabled";

            _chooseShapeLineButton.DataBindings.Add(CHECK, _presentationModel.ChooseShapeButtonState[ShapeName.LINE], STATE);
            _chooseShapeRectangleButton.DataBindings.Add(CHECK, _presentationModel.ChooseShapeButtonState[ShapeName.RECTANGLE], STATE);
            _chooseShapeEllipseButton.DataBindings.Add(CHECK, _presentationModel.ChooseShapeButtonState[ShapeName.ELLIPSE], STATE);
            _chooseShapePointerButton.DataBindings.Add(CHECK, _presentationModel.ChooseShapeButtonState[ShapeName.POINTER], STATE);
            _undoButton.DataBindings.Add(ENABLED , _model.CommandManager, IS_UNDO_ENABLED);
            _redoButton.DataBindings.Add(ENABLED, _model.CommandManager, IS_REDO_ENABLE);

            _shapeList.DataSource = _model.ShapeList;
        }

        //update canvas
        private void UpdateCanvas()
        {
            _canvas.Invalidate(true);
            _pageList.Controls[_presentationModel.LastChoosePage].Invalidate(true);
        }

        //clicl add btn
        private void ClickAddShape(object sender, EventArgs e)
        {
            AddShapeForm addShapeForm = new AddShapeForm();
            addShapeForm.ShowDialog();

            if (addShapeForm.DialogResult == DialogResult.OK)
            {
                _model.AddShape(_selectShape.Text, addShapeForm.StartPoint, addShapeForm.EndPoint);
            }
        }
        
        //click delete button in data grid view
        private void ShapeListCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                _model.DeleteShapeByIndex(e.RowIndex);
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
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            _model.Draw(new WindowsFormsPreviewGraphicsAdaptor(e.Graphics , ((Button)sender).Width , ((Button)sender).Height) , _pageList.Controls.GetChildIndex((Control)sender));
        }

        //TransformPoint
        public Point TransformPoint(Point point)
        {
            return new Point((point.X / _canvas.Width) * ScreenSize.WIDTH, (point.Y / _canvas.Height) * ScreenSize.HEIGHT);
        }

        //press canvas event method
        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.PressCanvas(TransformPoint(new Point(e.X, e.Y)));
        }

        //release canvas event method
        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.ReleaseCanvas(TransformPoint(new Point(e.X, e.Y)));
        }

        //move on canvas event method
        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.MoveOnCanvas(TransformPoint(new Point(e.X, e.Y)));
            Cursor = _presentationModel.GetCursors();
        }

        //canvas key down event
        public void HandleKeyDown(object sender , KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Delete)
            {
                _model.Delete();
                Cursor = _presentationModel.GetCursors();
            }
        }

        //canvas resize
        public void HandleSplitContainerResize(object sender, EventArgs e)
        {
            ResizePage();
            _canvas.Invalidate();
        }

        //const float SCREEN_SCALE = (float)ScreenSize.HEIGHT / (float)ScreenSize.WIDTH;

        //canvas container resize
        public void HandleCanvasContainerResize(object sender, EventArgs e)
        {
            if ((float)_splitContainer2.Panel1.Width / (float)_splitContainer2.Panel1.Height < (float)ScreenSize.WIDTH / (float)ScreenSize.HEIGHT)
            {
                _canvas.Width = _splitContainer2.Panel1.Width;
                _canvas.Height = (int)((float)_canvas.Width * ((float)ScreenSize.HEIGHT / (float)ScreenSize.WIDTH));
            }
            else
            {
                _canvas.Height = _splitContainer2.Panel1.Height;
                _canvas.Width = (int)((float)_canvas.Height * ((float)ScreenSize.WIDTH / (float)ScreenSize.HEIGHT));
            }
        }

        //ClickUndoButton
        public void ClickUndoButton(object sender, EventArgs e)
        {
            _model.Undo();
        }

        //ClickRedoButton
        public void ClickRedoButton(object sender, EventArgs e)
        {
            _model.Redo();
        }

        //UpdatePageList
        public void UpdatePageList()
        {
            _presentationModel.UpdatePageCheckList();
            if (_pageList.Controls.OfType<Button>().Count() != _presentationModel.PageCheckList.Count)
            {
                _pageList.Controls.Clear();
                for (int i = 0; i < _presentationModel.PageCheckList.Count; i++)
                {
                    CheckedAbleButton button = new CheckedAbleButton();
                    _pageList.Controls.Add(button);
                    button.Paint += PagePaint;
                    button.Click += ClickPageButton;
                    button.UseVisualStyleBackColor = true;
                }
            }
            UpdatePageChecked();
            ResizePage();
            _shapeList.DataSource = _model.ShapeList;
        }

        //UpdatePageChecked
        public void UpdatePageChecked()
        {
            for (int i = 0; i < _presentationModel.PageCheckList.Count; i++)
            {
                ((CheckedAbleButton)_pageList.Controls[i]).Checked = _presentationModel.PageCheckList[i];
            }
        }

        const int PAGE_PADDING = 25;

        //ResizePage
        public void ResizePage()
        {
            foreach (Control control in _pageList.Controls)
            {
                control.Width = _pageList.Width - PAGE_PADDING;
                control.Height = (int)((float)control.Width * ((float)ScreenSize.HEIGHT / (float)ScreenSize.WIDTH));
            }
        }

        //ClickPageButton
        public void ClickPageButton(object sender , EventArgs e)
        {
            _presentationModel.ChoosePage(_pageList.Controls.GetChildIndex((Control)sender));
            _shapeList.Invalidate(true);
        }

        //ClickAddPageButton
        private void ClickAddPageButton(object sender, EventArgs e)
        {
            _model.AddPage(_presentationModel.LastChoosePage + 1);
        }

        //ClickSaveButton
        private void ClickSaveButton(object sender, EventArgs e)
        {
            if (MessageBox.Show("Save in google drive?", "Confirm Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                _model.Save();
            }
        }

        //ClickLoadButton
        private void ClickLoadButton(object sender, EventArgs e)
        {
            if (MessageBox.Show("Load on google drive?", "Confirm Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                _model.Load();
            }
        }
    }
}
