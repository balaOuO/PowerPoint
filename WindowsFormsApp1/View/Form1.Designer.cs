﻿
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
            this._page1 = new System.Windows.Forms.Button();
            this._page2 = new System.Windows.Forms.Button();
            this._chooseShape = new System.Windows.Forms.ToolStrip();
            this._chooseShapeLineButton = new System.Windows.Forms.ToolStripButton();
            this._chooseShapeRectangleButton = new System.Windows.Forms.ToolStripButton();
            this._chooseShapeEllipseButton = new System.Windows.Forms.ToolStripButton();
            this._pageList = new System.Windows.Forms.Panel();
            this._canvas = new WindowsFormsApp1.DoubleBufferedPanel();
            this._menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._shapeList)).BeginInit();
            this._groupBox1.SuspendLayout();
            this._chooseShape.SuspendLayout();
            this._pageList.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menuStrip
            // 
            this._menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._directionsToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Padding = new System.Windows.Forms.Padding(5, 1, 0, 1);
            this._menuStrip.Size = new System.Drawing.Size(1126, 24);
            this._menuStrip.TabIndex = 0;
            this._menuStrip.Text = "menuStrip1";
            // 
            // _directionsToolStripMenuItem
            // 
            this._directionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
            this._directionsToolStripMenuItem.Name = "_directionsToolStripMenuItem";
            this._directionsToolStripMenuItem.Size = new System.Drawing.Size(43, 22);
            this._directionsToolStripMenuItem.Text = "說明";
            // 
            // _aboutToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this._aboutToolStripMenuItem.Text = "關於";
            // 
            // _shapeList
            // 
            this._shapeList.AllowUserToAddRows = false;
            this._shapeList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._shapeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._shapeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteButton,
            this._shapeName,
            this._information});
            this._shapeList.Cursor = System.Windows.Forms.Cursors.Default;
            this._shapeList.Location = new System.Drawing.Point(0, 65);
            this._shapeList.Margin = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this._shapeList.Name = "_shapeList";
            this._shapeList.RowHeadersVisible = false;
            this._shapeList.RowHeadersWidth = 51;
            this._shapeList.RowTemplate.Height = 27;
            this._shapeList.Size = new System.Drawing.Size(217, 497);
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
            this._groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._groupBox1.Controls.Add(this._selectShape);
            this._groupBox1.Controls.Add(this._addShape);
            this._groupBox1.Controls.Add(this._shapeList);
            this._groupBox1.Location = new System.Drawing.Point(909, 58);
            this._groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._groupBox1.Size = new System.Drawing.Size(217, 562);
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
            this._selectShape.Location = new System.Drawing.Point(77, 31);
            this._selectShape.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._selectShape.Name = "_selectShape";
            this._selectShape.Size = new System.Drawing.Size(92, 20);
            this._selectShape.TabIndex = 4;
            this._selectShape.Text = "矩形";
            // 
            // _addShape
            // 
            this._addShape.Location = new System.Drawing.Point(5, 19);
            this._addShape.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._addShape.Name = "_addShape";
            this._addShape.Size = new System.Drawing.Size(53, 40);
            this._addShape.TabIndex = 3;
            this._addShape.Text = "新增";
            this._addShape.UseVisualStyleBackColor = true;
            this._addShape.Click += new System.EventHandler(this.ClickAddShape);
            // 
            // _page1
            // 
            this._page1.Location = new System.Drawing.Point(5, 102);
            this._page1.Name = "_page1";
            this._page1.Size = new System.Drawing.Size(154, 93);
            this._page1.TabIndex = 4;
            this._page1.UseVisualStyleBackColor = true;
            // 
            // _page2
            // 
            this._page2.Location = new System.Drawing.Point(5, 3);
            this._page2.Name = "_page2";
            this._page2.Size = new System.Drawing.Size(154, 93);
            this._page2.TabIndex = 5;
            this._page2.UseVisualStyleBackColor = true;
            // 
            // _chooseShape
            // 
            this._chooseShape.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._chooseShape.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._chooseShapeLineButton,
            this._chooseShapeRectangleButton,
            this._chooseShapeEllipseButton});
            this._chooseShape.Location = new System.Drawing.Point(0, 24);
            this._chooseShape.Name = "_chooseShape";
            this._chooseShape.Size = new System.Drawing.Size(1126, 32);
            this._chooseShape.TabIndex = 6;
            this._chooseShape.Text = "toolStrip1";
            // 
            // _chooseShapeLineButton
            // 
            this._chooseShapeLineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._chooseShapeLineButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15F);
            this._chooseShapeLineButton.Image = ((System.Drawing.Image)(resources.GetObject("_chooseShapeLineButton.Image")));
            this._chooseShapeLineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._chooseShapeLineButton.Name = "_chooseShapeLineButton";
            this._chooseShapeLineButton.Size = new System.Drawing.Size(28, 29);
            this._chooseShapeLineButton.Text = "╱";
            this._chooseShapeLineButton.Click += new System.EventHandler(this.ClickChooseShapeLineButton);
            // 
            // _chooseShapeRectangleButton
            // 
            this._chooseShapeRectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._chooseShapeRectangleButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15F);
            this._chooseShapeRectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("_chooseShapeRectangleButton.Image")));
            this._chooseShapeRectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._chooseShapeRectangleButton.Name = "_chooseShapeRectangleButton";
            this._chooseShapeRectangleButton.Size = new System.Drawing.Size(29, 29);
            this._chooseShapeRectangleButton.Text = "☐";
            this._chooseShapeRectangleButton.Click += new System.EventHandler(this.ClickChooseShapeRectangleButton);
            // 
            // _chooseShapeEllipseButton
            // 
            this._chooseShapeEllipseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._chooseShapeEllipseButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15F);
            this._chooseShapeEllipseButton.Image = ((System.Drawing.Image)(resources.GetObject("_chooseShapeEllipseButton.Image")));
            this._chooseShapeEllipseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._chooseShapeEllipseButton.Name = "_chooseShapeEllipseButton";
            this._chooseShapeEllipseButton.Size = new System.Drawing.Size(36, 29);
            this._chooseShapeEllipseButton.Text = "○";
            this._chooseShapeEllipseButton.Click += new System.EventHandler(this.ClickChooseShapeEllipseButton);
            // 
            // _pageList
            // 
            this._pageList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._pageList.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._pageList.Controls.Add(this._page1);
            this._pageList.Controls.Add(this._page2);
            this._pageList.Location = new System.Drawing.Point(0, 54);
            this._pageList.Margin = new System.Windows.Forms.Padding(2);
            this._pageList.Name = "_pageList";
            this._pageList.Size = new System.Drawing.Size(164, 559);
            this._pageList.TabIndex = 8;
            // 
            // _canvas
            // 
            this._canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._canvas.BackColor = System.Drawing.SystemColors.Control;
            this._canvas.Location = new System.Drawing.Point(164, 54);
            this._canvas.Margin = new System.Windows.Forms.Padding(0);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(742, 562);
            this._canvas.TabIndex = 7;
            this._canvas.Paint += HandleCanvasPaint;
            this._canvas.MouseDown += HandleCanvasPressed;
            this._canvas.MouseUp += HandleCanvasReleased;
            this._canvas.MouseMove += HandleCanvasMoved;
            // 
            // PowerPointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 611);
            this.Controls.Add(this._pageList);
            this.Controls.Add(this._canvas);
            this.Controls.Add(this._chooseShape);
            this.Controls.Add(this._groupBox1);
            this.Controls.Add(this._menuStrip);
            this.MainMenuStrip = this._menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "PowerPointForm";
            this.Text = "PowerPoint";
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._shapeList)).EndInit();
            this._groupBox1.ResumeLayout(false);
            this._chooseShape.ResumeLayout(false);
            this._chooseShape.PerformLayout();
            this._pageList.ResumeLayout(false);
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
        private System.Windows.Forms.Button _page1;
        private System.Windows.Forms.Button _page2;
        private System.Windows.Forms.DataGridViewButtonColumn _deleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shapeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _information;
        private System.Windows.Forms.ToolStrip _chooseShape;
        private System.Windows.Forms.ToolStripButton _chooseShapeRectangleButton;
        private System.Windows.Forms.ToolStripButton _chooseShapeEllipseButton;
        private System.Windows.Forms.ToolStripButton _chooseShapeLineButton;
        private System.Windows.Forms.Panel _pageList;
        private DoubleBufferedPanel _canvas;
    }
}
