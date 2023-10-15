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
            _model = model;
            _presentationModel = presentationModel;
            _presentationModel._changeShapeButtonUpdate += ChooseShapeButtonUpdate;
            _model._dataChange += UpdateView; 
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

        //clicl add btn
        private void ClickAddShape(object sender, EventArgs e)
        {
            VirtualUser user = new VirtualUser();
            user.SelectArea(_canvas.Width, _canvas.Height);
            _model.AddShape(_selectShape.Text, user.UpperLeftPoint, user.LowerRightPoint );
        }
        
        //click delete button in data grid view
        private void ShapeListCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_shapeList.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex != -1)
            {
                _model.DeleteShape(e.RowIndex);
            }
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

        //update the choose shape tool bar
        private void ChooseShapeButtonUpdate()
        {
            Dictionary<string, bool> state = _presentationModel.ChooseShapeButtonState;
            _chooseShapeRectangleButton.Checked = state[ShapeName.RECTANGLE];
            _chooseShapeLineButton.Checked = state[ShapeName.LINE];
            _chooseShapeEllipseButton.Checked = state[ShapeName.ELLIPSE];
            Cursor = _presentationModel.GetCursorState();
        }

        //canvas draw event method
        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _model.Draw(e.Graphics);
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
        }

        //press and move on canvas event method
        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _presentationModel.MovedOnCanvas(new Point(e.X, e.Y));
        }
    }
}
