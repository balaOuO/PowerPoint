
namespace WindowsFormsApp1
{
    partial class PowerPointForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PowerPointForm));
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._directionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._canvas = new System.Windows.Forms.Button();
            this._shapeList = new System.Windows.Forms.DataGridView();
            this._deleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this._shapeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._groupBox1 = new System.Windows.Forms.GroupBox();
            this._selectShape = new System.Windows.Forms.ComboBox();
            this._addShape = new System.Windows.Forms.Button();
            this._page1 = new System.Windows.Forms.Button();
            this._page2 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._rectangleButton = new System.Windows.Forms.ToolStripButton();
            this._ellipseButton = new System.Windows.Forms.ToolStripButton();
            this._lineButton = new System.Windows.Forms.ToolStripButton();
            this._menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._shapeList)).BeginInit();
            this._groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menuStrip
            // 
            this._menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._directionsToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Padding = new System.Windows.Forms.Padding(7, 1, 0, 1);
            this._menuStrip.Size = new System.Drawing.Size(1501, 25);
            this._menuStrip.TabIndex = 0;
            this._menuStrip.Text = "menuStrip1";
            // 
            // _directionsToolStripMenuItem
            // 
            this._directionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
            this._directionsToolStripMenuItem.Name = "_directionsToolStripMenuItem";
            this._directionsToolStripMenuItem.Size = new System.Drawing.Size(53, 23);
            this._directionsToolStripMenuItem.Text = "說明";
            // 
            // _aboutToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this._aboutToolStripMenuItem.Text = "關於";
            // 
            // _canvas
            // 
            this._canvas.Location = new System.Drawing.Point(225, 68);
            this._canvas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(981, 706);
            this._canvas.TabIndex = 1;
            this._canvas.UseVisualStyleBackColor = true;
            // 
            // _shapeList
            // 
            this._shapeList.AllowUserToAddRows = false;
            this._shapeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._shapeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteButton,
            this._shapeName,
            this._information});
            this._shapeList.Cursor = System.Windows.Forms.Cursors.Default;
            this._shapeList.Location = new System.Drawing.Point(0, 81);
            this._shapeList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._shapeList.Name = "_shapeList";
            this._shapeList.RowHeadersVisible = false;
            this._shapeList.RowHeadersWidth = 51;
            this._shapeList.RowTemplate.Height = 27;
            this._shapeList.Size = new System.Drawing.Size(280, 621);
            this._shapeList.TabIndex = 2;
            this._shapeList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShapeListCellContentClick);
            // 
            // _deleteButton
            // 
            this._deleteButton.HeaderText = "刪除";
            this._deleteButton.MinimumWidth = 6;
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.ReadOnly = true;
            this._deleteButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._deleteButton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._deleteButton.Text = "刪除";
            this._deleteButton.UseColumnTextForButtonValue = true;
            this._deleteButton.Width = 40;
            // 
            // _shapeName
            // 
            this._shapeName.HeaderText = "形狀";
            this._shapeName.MinimumWidth = 6;
            this._shapeName.Name = "_shapeName";
            this._shapeName.ReadOnly = true;
            this._shapeName.Width = 60;
            // 
            // _information
            // 
            this._information.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._information.HeaderText = "資訊";
            this._information.MinimumWidth = 6;
            this._information.Name = "_information";
            this._information.ReadOnly = true;
            // 
            // _groupBox1
            // 
            this._groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._groupBox1.Controls.Add(this._selectShape);
            this._groupBox1.Controls.Add(this._addShape);
            this._groupBox1.Controls.Add(this._shapeList);
            this._groupBox1.Location = new System.Drawing.Point(1212, 68);
            this._groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._groupBox1.Size = new System.Drawing.Size(285, 706);
            this._groupBox1.TabIndex = 3;
            this._groupBox1.TabStop = false;
            this._groupBox1.Text = "資料顯示";
            // 
            // _selectShape
            // 
            this._selectShape.FormattingEnabled = true;
            this._selectShape.Items.AddRange(new object[] {
            "矩形",
            "線",
            "圓"});
            this._selectShape.Location = new System.Drawing.Point(103, 39);
            this._selectShape.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._selectShape.Name = "_selectShape";
            this._selectShape.Size = new System.Drawing.Size(121, 23);
            this._selectShape.TabIndex = 4;
            this._selectShape.Text = "矩形";
            // 
            // _addShape
            // 
            this._addShape.Location = new System.Drawing.Point(7, 24);
            this._addShape.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._addShape.Name = "_addShape";
            this._addShape.Size = new System.Drawing.Size(71, 50);
            this._addShape.TabIndex = 3;
            this._addShape.Text = "新增";
            this._addShape.UseVisualStyleBackColor = true;
            this._addShape.Click += new System.EventHandler(this.ClickAddShape);
            // 
            // _page1
            // 
            this._page1.Location = new System.Drawing.Point(13, 68);
            this._page1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._page1.Name = "_page1";
            this._page1.Size = new System.Drawing.Size(205, 116);
            this._page1.TabIndex = 4;
            this._page1.UseVisualStyleBackColor = true;
            // 
            // _page2
            // 
            this._page2.Location = new System.Drawing.Point(13, 192);
            this._page2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._page2.Name = "_page2";
            this._page2.Size = new System.Drawing.Size(205, 116);
            this._page2.TabIndex = 5;
            this._page2.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lineButton,
            this._rectangleButton,
            this._ellipseButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1501, 39);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _rectangleButton
            // 
            this._rectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._rectangleButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15F);
            this._rectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("_rectangleButton.Image")));
            this._rectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._rectangleButton.Name = "_rectangleButton";
            this._rectangleButton.Size = new System.Drawing.Size(37, 36);
            this._rectangleButton.Text = "☐";
            this._rectangleButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // _ellipseButton
            // 
            this._ellipseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._ellipseButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15F);
            this._ellipseButton.Image = ((System.Drawing.Image)(resources.GetObject("_ellipseButton.Image")));
            this._ellipseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ellipseButton.Name = "_ellipseButton";
            this._ellipseButton.Size = new System.Drawing.Size(44, 36);
            this._ellipseButton.Text = "○";
            // 
            // _lineButton
            // 
            this._lineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._lineButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15F);
            this._lineButton.Image = ((System.Drawing.Image)(resources.GetObject("_lineButton.Image")));
            this._lineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._lineButton.Name = "_lineButton";
            this._lineButton.Size = new System.Drawing.Size(34, 36);
            this._lineButton.Text = "╱";
            // 
            // PowerPointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1501, 764);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this._page2);
            this.Controls.Add(this._page1);
            this.Controls.Add(this._groupBox1);
            this.Controls.Add(this._canvas);
            this.Controls.Add(this._menuStrip);
            this.MainMenuStrip = this._menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PowerPointForm";
            this.Text = "PowerPoint";
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._shapeList)).EndInit();
            this._groupBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _directionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
        private System.Windows.Forms.Button _canvas;
        private System.Windows.Forms.GroupBox _groupBox1;
        private System.Windows.Forms.ComboBox _selectShape;
        private System.Windows.Forms.Button _addShape;
        private System.Windows.Forms.DataGridView _shapeList;
        private System.Windows.Forms.Button _page1;
        private System.Windows.Forms.Button _page2;
        private System.Windows.Forms.DataGridViewButtonColumn _deleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shapeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _information;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton _rectangleButton;
        private System.Windows.Forms.ToolStripButton _ellipseButton;
        private System.Windows.Forms.ToolStripButton _lineButton;
    }
}

