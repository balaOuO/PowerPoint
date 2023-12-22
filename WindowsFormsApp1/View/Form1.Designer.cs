
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
            this._shapeList = new System.Windows.Forms.DataGridView();
            this._deleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this._shapeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._groupBox1 = new System.Windows.Forms.GroupBox();
            this._selectShape = new System.Windows.Forms.ComboBox();
            this._addShape = new System.Windows.Forms.Button();
            this._chooseShape = new System.Windows.Forms.ToolStrip();
            this._addPageButton = new System.Windows.Forms.ToolStripButton();
            this._saveButton = new System.Windows.Forms.ToolStripButton();
            this._loadButton = new System.Windows.Forms.ToolStripButton();
            this._splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._pageList = new System.Windows.Forms.FlowLayoutPanel();
            this._splitContainer2 = new System.Windows.Forms.SplitContainer();
            this._canvas = new WindowsFormsApp1.DoubleBufferedPanel();
            this._chooseShapeLineButton = new WindowsFormsApp1.ToolStripBindAbleButton();
            this._chooseShapeRectangleButton = new WindowsFormsApp1.ToolStripBindAbleButton();
            this._chooseShapeEllipseButton = new WindowsFormsApp1.ToolStripBindAbleButton();
            this._chooseShapePointerButton = new WindowsFormsApp1.ToolStripBindAbleButton();
            this._undoButton = new WindowsFormsApp1.ToolStripBindAbleButton();
            this._redoButton = new WindowsFormsApp1.ToolStripBindAbleButton();
            this._menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._shapeList)).BeginInit();
            this._groupBox1.SuspendLayout();
            this._chooseShape.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).BeginInit();
            this._splitContainer1.Panel1.SuspendLayout();
            this._splitContainer1.Panel2.SuspendLayout();
            this._splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).BeginInit();
            this._splitContainer2.Panel1.SuspendLayout();
            this._splitContainer2.Panel2.SuspendLayout();
            this._splitContainer2.SuspendLayout();
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
            this._menuStrip.Size = new System.Drawing.Size(1441, 30);
            this._menuStrip.TabIndex = 0;
            this._menuStrip.Text = "menuStrip1";
            // 
            // _directionsToolStripMenuItem
            // 
            this._directionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
            this._directionsToolStripMenuItem.Name = "_directionsToolStripMenuItem";
            this._directionsToolStripMenuItem.Size = new System.Drawing.Size(53, 28);
            this._directionsToolStripMenuItem.Text = "說明";
            // 
            // _aboutToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this._aboutToolStripMenuItem.Text = "關於";
            // 
            // _shapeList
            // 
            this._shapeList.AllowUserToAddRows = false;
            this._shapeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._shapeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._shapeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteButton,
            this._shapeName,
            this._information});
            this._shapeList.Cursor = System.Windows.Forms.Cursors.Default;
            this._shapeList.Location = new System.Drawing.Point(7, 81);
            this._shapeList.Margin = new System.Windows.Forms.Padding(3, 4, 0, 4);
            this._shapeList.Name = "_shapeList";
            this._shapeList.RowHeadersVisible = false;
            this._shapeList.RowHeadersWidth = 51;
            this._shapeList.RowTemplate.Height = 27;
            this._shapeList.Size = new System.Drawing.Size(354, 540);
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
            this._shapeName.DataPropertyName = "ShapeName";
            this._shapeName.HeaderText = "形狀";
            this._shapeName.MinimumWidth = 6;
            this._shapeName.Name = "_shapeName";
            this._shapeName.ReadOnly = true;
            this._shapeName.Width = 60;
            // 
            // _information
            // 
            this._information.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._information.DataPropertyName = "Info";
            this._information.HeaderText = "資訊";
            this._information.MinimumWidth = 6;
            this._information.Name = "_information";
            this._information.ReadOnly = true;
            // 
            // _groupBox1
            // 
            this._groupBox1.AutoSize = true;
            this._groupBox1.Controls.Add(this._selectShape);
            this._groupBox1.Controls.Add(this._addShape);
            this._groupBox1.Controls.Add(this._shapeList);
            this._groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._groupBox1.Location = new System.Drawing.Point(0, 0);
            this._groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._groupBox1.Size = new System.Drawing.Size(371, 634);
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
            // _chooseShape
            // 
            this._chooseShape.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._chooseShape.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._chooseShapeLineButton,
            this._chooseShapeRectangleButton,
            this._chooseShapeEllipseButton,
            this._chooseShapePointerButton,
            this._addPageButton,
            this._undoButton,
            this._redoButton,
            this._saveButton,
            this._loadButton});
            this._chooseShape.Location = new System.Drawing.Point(0, 30);
            this._chooseShape.Name = "_chooseShape";
            this._chooseShape.Size = new System.Drawing.Size(1441, 44);
            this._chooseShape.TabIndex = 6;
            this._chooseShape.Text = "toolStrip1";
            // 
            // _addPageButton
            // 
            this._addPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._addPageButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15F);
            this._addPageButton.Image = ((System.Drawing.Image)(resources.GetObject("_addPageButton.Image")));
            this._addPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._addPageButton.Name = "_addPageButton";
            this._addPageButton.Size = new System.Drawing.Size(52, 41);
            this._addPageButton.Text = "📄";
            this._addPageButton.Click += new System.EventHandler(this.ClickAddPageButton);
            // 
            // _saveButton
            // 
            this._saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._saveButton.Image = ((System.Drawing.Image)(resources.GetObject("_saveButton.Image")));
            this._saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(44, 41);
            this._saveButton.Text = "save";
            this._saveButton.Click += new System.EventHandler(this.ClickSaveButton);
            // 
            // _loadButton
            // 
            this._loadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._loadButton.Image = ((System.Drawing.Image)(resources.GetObject("_loadButton.Image")));
            this._loadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._loadButton.Name = "_loadButton";
            this._loadButton.Size = new System.Drawing.Size(44, 41);
            this._loadButton.Text = "load";
            this._loadButton.Click += new System.EventHandler(this.ClickLoadButton);
            // 
            // _splitContainer1
            // 
            this._splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._splitContainer1.Location = new System.Drawing.Point(0, 74);
            this._splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._splitContainer1.Name = "_splitContainer1";
            // 
            // _splitContainer1.Panel1
            // 
            this._splitContainer1.Panel1.Controls.Add(this._pageList);
            // 
            // _splitContainer1.Panel2
            // 
            this._splitContainer1.Panel2.Controls.Add(this._splitContainer2);
            this._splitContainer1.Size = new System.Drawing.Size(1441, 634);
            this._splitContainer1.SplitterDistance = 188;
            this._splitContainer1.TabIndex = 9;
            // 
            // _pageList
            // 
            this._pageList.AutoScroll = true;
            this._pageList.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._pageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pageList.Location = new System.Drawing.Point(0, 0);
            this._pageList.Margin = new System.Windows.Forms.Padding(4);
            this._pageList.Name = "_pageList";
            this._pageList.Size = new System.Drawing.Size(188, 634);
            this._pageList.TabIndex = 0;
            // 
            // _splitContainer2
            // 
            this._splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._splitContainer2.Location = new System.Drawing.Point(0, 0);
            this._splitContainer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._splitContainer2.Name = "_splitContainer2";
            // 
            // _splitContainer2.Panel1
            // 
            this._splitContainer2.Panel1.AutoScroll = true;
            this._splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._splitContainer2.Panel1.Controls.Add(this._canvas);
            // 
            // _splitContainer2.Panel2
            // 
            this._splitContainer2.Panel2.Controls.Add(this._groupBox1);
            this._splitContainer2.Size = new System.Drawing.Size(1249, 634);
            this._splitContainer2.SplitterDistance = 874;
            this._splitContainer2.TabIndex = 4;
            // 
            // _canvas
            // 
            this._canvas.BackColor = System.Drawing.SystemColors.Control;
            this._canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._canvas.Location = new System.Drawing.Point(0, 0);
            this._canvas.Margin = new System.Windows.Forms.Padding(0);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(541, 330);
            this._canvas.TabIndex = 7;
            // 
            // _chooseShapeLineButton
            // 
            this._chooseShapeLineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._chooseShapeLineButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15F);
            this._chooseShapeLineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._chooseShapeLineButton.Name = "_chooseShapeLineButton";
            this._chooseShapeLineButton.Size = new System.Drawing.Size(34, 41);
            this._chooseShapeLineButton.Text = "╱";
            this._chooseShapeLineButton.Click += new System.EventHandler(this.ClickChooseShapeLineButton);
            // 
            // _chooseShapeRectangleButton
            // 
            this._chooseShapeRectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._chooseShapeRectangleButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15F);
            this._chooseShapeRectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._chooseShapeRectangleButton.Name = "_chooseShapeRectangleButton";
            this._chooseShapeRectangleButton.Size = new System.Drawing.Size(37, 41);
            this._chooseShapeRectangleButton.Text = "☐";
            this._chooseShapeRectangleButton.Click += new System.EventHandler(this.ClickChooseShapeRectangleButton);
            // 
            // _chooseShapeEllipseButton
            // 
            this._chooseShapeEllipseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._chooseShapeEllipseButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15F);
            this._chooseShapeEllipseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._chooseShapeEllipseButton.Name = "_chooseShapeEllipseButton";
            this._chooseShapeEllipseButton.Size = new System.Drawing.Size(44, 41);
            this._chooseShapeEllipseButton.Text = "○";
            this._chooseShapeEllipseButton.Click += new System.EventHandler(this.ClickChooseShapeEllipseButton);
            // 
            // _chooseShapePointerButton
            // 
            this._chooseShapePointerButton.Checked = true;
            this._chooseShapePointerButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chooseShapePointerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._chooseShapePointerButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 17F);
            this._chooseShapePointerButton.Image = ((System.Drawing.Image)(resources.GetObject("_chooseShapePointerButton.Image")));
            this._chooseShapePointerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._chooseShapePointerButton.Name = "_chooseShapePointerButton";
            this._chooseShapePointerButton.Size = new System.Drawing.Size(50, 41);
            this._chooseShapePointerButton.Text = " ➛";
            this._chooseShapePointerButton.Click += new System.EventHandler(this.ClickChooseShapePointerButton);
            // 
            // _undoButton
            // 
            this._undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._undoButton.Enabled = false;
            this._undoButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15F);
            this._undoButton.Image = ((System.Drawing.Image)(resources.GetObject("_undoButton.Image")));
            this._undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._undoButton.Name = "_undoButton";
            this._undoButton.Size = new System.Drawing.Size(37, 41);
            this._undoButton.Text = "↩︎";
            this._undoButton.Click += new System.EventHandler(this.ClickUndoButton);
            // 
            // _redoButton
            // 
            this._redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._redoButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15F);
            this._redoButton.Image = ((System.Drawing.Image)(resources.GetObject("_redoButton.Image")));
            this._redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._redoButton.Name = "_redoButton";
            this._redoButton.Size = new System.Drawing.Size(37, 41);
            this._redoButton.Text = "↪︎";
            this._redoButton.Click += new System.EventHandler(this.ClickRedoButton);
            // 
            // PowerPointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1441, 708);
            this.Controls.Add(this._splitContainer1);
            this.Controls.Add(this._chooseShape);
            this.Controls.Add(this._menuStrip);
            this.MainMenuStrip = this._menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PowerPointForm";
            this.Text = "PowerPoint";
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._shapeList)).EndInit();
            this._groupBox1.ResumeLayout(false);
            this._chooseShape.ResumeLayout(false);
            this._chooseShape.PerformLayout();
            this._splitContainer1.Panel1.ResumeLayout(false);
            this._splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).EndInit();
            this._splitContainer1.ResumeLayout(false);
            this._splitContainer2.Panel1.ResumeLayout(false);
            this._splitContainer2.Panel2.ResumeLayout(false);
            this._splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).EndInit();
            this._splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _directionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox _groupBox1;
        private System.Windows.Forms.ComboBox _selectShape;
        private System.Windows.Forms.Button _addShape;
        private System.Windows.Forms.DataGridView _shapeList;
        private System.Windows.Forms.DataGridViewButtonColumn _deleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shapeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _information;
        private System.Windows.Forms.ToolStrip _chooseShape;
        private ToolStripBindAbleButton _chooseShapeRectangleButton;
        private ToolStripBindAbleButton _chooseShapeEllipseButton;
        private ToolStripBindAbleButton _chooseShapeLineButton;
        private DoubleBufferedPanel _canvas;
        private ToolStripBindAbleButton _chooseShapePointerButton;
        private System.Windows.Forms.SplitContainer _splitContainer1;
        private System.Windows.Forms.SplitContainer _splitContainer2;
        private ToolStripBindAbleButton _undoButton;
        private ToolStripBindAbleButton _redoButton;
        private System.Windows.Forms.ToolStripButton _addPageButton;
        private System.Windows.Forms.ToolStripButton _saveButton;
        private System.Windows.Forms.ToolStripButton _loadButton;
        private System.Windows.Forms.FlowLayoutPanel _pageList;
    }
}
