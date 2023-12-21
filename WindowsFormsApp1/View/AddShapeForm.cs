using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddShapeForm : Form
    {
        public AddShapeForm()
        {
            InitializeComponent();
            _startXInput.TextChanged += InputCoordinate;
            _startYInput.TextChanged += InputCoordinate;
            _endXInput.TextChanged += InputCoordinate;
            _endYInput.TextChanged += InputCoordinate;
            _okButton.Enabled = false;
        }

        public Point StartPoint
        {
            get; set;
        }
        public Point EndPoint
        {
            get; set;
        }

        //InputCoordinate
        public void InputCoordinate(object sender , EventArgs e)
        {
            try
            {
                StartPoint = new Point(double.Parse(_startXInput.Text), double.Parse(_startYInput.Text));
                EndPoint = new Point(double.Parse(_endXInput.Text), double.Parse(_endYInput.Text));
                _okButton.Enabled = true;
            }
            catch
            {
                _okButton.Enabled = false;
            }
        }

        //ClickOKButton
        private void ClickOkButton(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //ClickCancelButton
        private void ClickCancelButton(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
