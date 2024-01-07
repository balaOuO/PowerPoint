using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class CheckedAbleButton : Button
    {
        bool _checked = false;

        //CheckedAbleButton
        public CheckedAbleButton()
        {
            this.Paint += CheckedHandler;
        }

        public bool Checked
        {
            get
            {
                return _checked;
            }
            set
            {
                _checked = value;
                this.Invalidate(true);
            }
        }

        //CheckedHandler
        private void CheckedHandler(object sender , PaintEventArgs e)
        {
            if (Checked)
            {
                e.Graphics.DrawRectangle(Pens.Red , 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }
}
