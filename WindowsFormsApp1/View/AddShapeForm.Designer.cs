using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddShapeForm
    {
        private Label _startX;
        private TextBox _startXInput;
        private Label _endX;
        private TextBox _endXInput;
        private Label _endY;
        private TextBox _endYInput;
        private Label _startY;
        private TextBox _startYInput;
        private Button _okButton;
        private Button _cancelButton;

        /// <summary>
        /// 系統生成
        /// </summary>
        private void InitializeComponent()
        {
            this._startX = new System.Windows.Forms.Label();
            this._startXInput = new System.Windows.Forms.TextBox();
            this._endX = new System.Windows.Forms.Label();
            this._endXInput = new System.Windows.Forms.TextBox();
            this._endY = new System.Windows.Forms.Label();
            this._endYInput = new System.Windows.Forms.TextBox();
            this._startY = new System.Windows.Forms.Label();
            this._startYInput = new System.Windows.Forms.TextBox();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _startX
            // 
            this._startX.AutoSize = true;
            this._startX.Location = new System.Drawing.Point(30, 23);
            this._startX.Name = "_startX";
            this._startX.Size = new System.Drawing.Size(74, 15);
            this._startX.TabIndex = 0;
            this._startX.Text = "StartPointX";
            // 
            // _startXInput
            // 
            this._startXInput.Location = new System.Drawing.Point(33, 42);
            this._startXInput.Name = "_startXInput";
            this._startXInput.Size = new System.Drawing.Size(100, 25);
            this._startXInput.TabIndex = 1;
            // 
            // _endX
            // 
            this._endX.AutoSize = true;
            this._endX.Location = new System.Drawing.Point(30, 83);
            this._endX.Name = "_endX";
            this._endX.Size = new System.Drawing.Size(70, 15);
            this._endX.TabIndex = 0;
            this._endX.Text = "EndPointX";
            // 
            // _endXInput
            // 
            this._endXInput.Location = new System.Drawing.Point(33, 102);
            this._endXInput.Name = "_endXInput";
            this._endXInput.Size = new System.Drawing.Size(100, 25);
            this._endXInput.TabIndex = 1;
            // 
            // _endY
            // 
            this._endY.AutoSize = true;
            this._endY.Location = new System.Drawing.Point(238, 83);
            this._endY.Name = "_endY";
            this._endY.Size = new System.Drawing.Size(70, 15);
            this._endY.TabIndex = 0;
            this._endY.Text = "EndPointY";
            // 
            // _endYInput
            // 
            this._endYInput.Location = new System.Drawing.Point(241, 102);
            this._endYInput.Name = "_endYInput";
            this._endYInput.Size = new System.Drawing.Size(100, 25);
            this._endYInput.TabIndex = 1;
            // 
            // _startY
            // 
            this._startY.AutoSize = true;
            this._startY.Location = new System.Drawing.Point(238, 23);
            this._startY.Name = "_startY";
            this._startY.Size = new System.Drawing.Size(74, 15);
            this._startY.TabIndex = 0;
            this._startY.Text = "StartPointY";
            // 
            // _startYInput
            // 
            this._startYInput.Location = new System.Drawing.Point(241, 42);
            this._startYInput.Name = "_startYInput";
            this._startYInput.Size = new System.Drawing.Size(100, 25);
            this._startYInput.TabIndex = 1;
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(33, 169);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 2;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this.ClickOkButton);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(241, 169);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 2;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.ClickCancelButton);
            // 
            // AddShapeForm
            // 
            this.ClientSize = new System.Drawing.Size(393, 235);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._startYInput);
            this.Controls.Add(this._startY);
            this.Controls.Add(this._endYInput);
            this.Controls.Add(this._endY);
            this.Controls.Add(this._endXInput);
            this.Controls.Add(this._endX);
            this.Controls.Add(this._startXInput);
            this.Controls.Add(this._startX);
            this.Name = "AddShapeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
