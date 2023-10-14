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
        public PowerPointForm(Model model)
        {
            InitializeComponent();
            this._model = model;
        }

        //update data grid view
        private void UpdateDataGridView()
        {
            _shapeList.Rows.Clear();
            List<Shape> shapeList = _model.ShapeList;
            for (int i = 0; i < shapeList.Count; i++)
            {
                _shapeList.Rows.Add(0, shapeList[i].GetShapeName(), shapeList[i].GetInfo());
            }
        }

        //clicl add btn
        private void ClickAddShape(object sender, EventArgs e)
        {
            VirtualUser user = new VirtualUser();
            user.SelectArea(_canvas.Width, _canvas.Height);
            _model.AddShape(_selectShape.Text, user.UpperLeftPoint, user.LowerRightPoint );
            UpdateDataGridView();
        }
        
        //click delete button in data grid view
        private void ShapeListCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_shapeList.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex != -1)
            {
                _model.DeleteShape(e.RowIndex);
                UpdateDataGridView();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
