namespace OpenCV_Vision_Pro
{
    partial class LoopStitch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.inputList = new System.Windows.Forms.ListBox();
            this.colNud = new System.Windows.Forms.NumericUpDown();
            this.overlapXNud = new System.Windows.Forms.NumericUpDown();
            this.rowNud = new System.Windows.Forms.NumericUpDown();
            this.overlapYNud = new System.Windows.Forms.NumericUpDown();
            this.AlignYNud = new System.Windows.Forms.NumericUpDown();
            this.AlignXNud = new System.Windows.Forms.NumericUpDown();
            this.InputImageBox = new Emgu.CV.UI.ImageBox();
            this.RunBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.AlignYLabel = new System.Windows.Forms.Label();
            this.colLabel = new System.Windows.Forms.Label();
            this.rowLabel = new System.Windows.Forms.Label();
            this.overlapXLabel = new System.Windows.Forms.Label();
            this.overlapYLabel = new System.Windows.Forms.Label();
            this.AlignXLabel = new System.Windows.Forms.Label();
            this.minOverlapLabel = new System.Windows.Forms.Label();
            this.minOverlapNud = new System.Windows.Forms.NumericUpDown();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.OpenFolderBtn = new System.Windows.Forms.Button();
            this.OpenImagesBtn = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.OutImageBox = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.colNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlapXNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlapYNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlignYNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlignXNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputImageBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minOverlapNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // inputList
            // 
            this.inputList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputList.FormattingEnabled = true;
            this.inputList.HorizontalScrollbar = true;
            this.inputList.Location = new System.Drawing.Point(3, 32);
            this.inputList.Name = "inputList";
            this.inputList.ScrollAlwaysVisible = true;
            this.inputList.Size = new System.Drawing.Size(217, 390);
            this.inputList.TabIndex = 0;
            this.inputList.SelectedIndexChanged += new System.EventHandler(this.inputList_SelectedIndexChanged);
            // 
            // colNud
            // 
            this.colNud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colNud.Location = new System.Drawing.Point(70, 3);
            this.colNud.Name = "colNud";
            this.colNud.Size = new System.Drawing.Size(464, 20);
            this.colNud.TabIndex = 1;
            this.colNud.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // overlapXNud
            // 
            this.overlapXNud.DecimalPlaces = 2;
            this.overlapXNud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overlapXNud.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.overlapXNud.Location = new System.Drawing.Point(70, 55);
            this.overlapXNud.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.overlapXNud.Name = "overlapXNud";
            this.overlapXNud.Size = new System.Drawing.Size(464, 20);
            this.overlapXNud.TabIndex = 2;
            this.overlapXNud.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // rowNud
            // 
            this.rowNud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rowNud.Location = new System.Drawing.Point(70, 29);
            this.rowNud.Name = "rowNud";
            this.rowNud.Size = new System.Drawing.Size(464, 20);
            this.rowNud.TabIndex = 3;
            this.rowNud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // overlapYNud
            // 
            this.overlapYNud.DecimalPlaces = 2;
            this.overlapYNud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overlapYNud.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.overlapYNud.Location = new System.Drawing.Point(70, 81);
            this.overlapYNud.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.overlapYNud.Name = "overlapYNud";
            this.overlapYNud.Size = new System.Drawing.Size(464, 20);
            this.overlapYNud.TabIndex = 4;
            this.overlapYNud.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // AlignYNud
            // 
            this.AlignYNud.DecimalPlaces = 3;
            this.AlignYNud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlignYNud.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.AlignYNud.Location = new System.Drawing.Point(70, 133);
            this.AlignYNud.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AlignYNud.Name = "AlignYNud";
            this.AlignYNud.Size = new System.Drawing.Size(464, 20);
            this.AlignYNud.TabIndex = 5;
            this.AlignYNud.Value = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            // 
            // AlignXNud
            // 
            this.AlignXNud.DecimalPlaces = 3;
            this.AlignXNud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlignXNud.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.AlignXNud.Location = new System.Drawing.Point(70, 107);
            this.AlignXNud.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AlignXNud.Name = "AlignXNud";
            this.AlignXNud.Size = new System.Drawing.Size(464, 20);
            this.AlignXNud.TabIndex = 6;
            this.AlignXNud.Value = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            // 
            // InputImageBox
            // 
            this.InputImageBox.BackColor = System.Drawing.Color.Blue;
            this.InputImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.InputImageBox.Location = new System.Drawing.Point(0, 0);
            this.InputImageBox.Name = "InputImageBox";
            this.InputImageBox.Size = new System.Drawing.Size(223, 212);
            this.InputImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.InputImageBox.TabIndex = 2;
            this.InputImageBox.TabStop = false;
            // 
            // RunBtn
            // 
            this.RunBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RunBtn.Location = new System.Drawing.Point(70, 185);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(464, 22);
            this.RunBtn.TabIndex = 7;
            this.RunBtn.Text = "Run";
            this.RunBtn.UseVisualStyleBackColor = true;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.AlignYLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.colNud, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.overlapXNud, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.rowNud, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.overlapYNud, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.AlignXNud, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.AlignYNud, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.colLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rowLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.overlapXLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.overlapYLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.AlignXLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.RunBtn, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.minOverlapLabel, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.minOverlapNud, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(537, 226);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // AlignYLabel
            // 
            this.AlignYLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AlignYLabel.AutoSize = true;
            this.AlignYLabel.Location = new System.Drawing.Point(3, 136);
            this.AlignYLabel.Name = "AlignYLabel";
            this.AlignYLabel.Size = new System.Drawing.Size(37, 13);
            this.AlignYLabel.TabIndex = 12;
            this.AlignYLabel.Text = "AlignY";
            // 
            // colLabel
            // 
            this.colLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.colLabel.AutoSize = true;
            this.colLabel.Location = new System.Drawing.Point(3, 6);
            this.colLabel.Name = "colLabel";
            this.colLabel.Size = new System.Drawing.Size(42, 13);
            this.colLabel.TabIndex = 7;
            this.colLabel.Text = "Column";
            // 
            // rowLabel
            // 
            this.rowLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rowLabel.AutoSize = true;
            this.rowLabel.Location = new System.Drawing.Point(3, 32);
            this.rowLabel.Name = "rowLabel";
            this.rowLabel.Size = new System.Drawing.Size(29, 13);
            this.rowLabel.TabIndex = 8;
            this.rowLabel.Text = "Row";
            // 
            // overlapXLabel
            // 
            this.overlapXLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.overlapXLabel.AutoSize = true;
            this.overlapXLabel.Location = new System.Drawing.Point(3, 58);
            this.overlapXLabel.Name = "overlapXLabel";
            this.overlapXLabel.Size = new System.Drawing.Size(49, 13);
            this.overlapXLabel.TabIndex = 9;
            this.overlapXLabel.Text = "overlapX";
            // 
            // overlapYLabel
            // 
            this.overlapYLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.overlapYLabel.AutoSize = true;
            this.overlapYLabel.Location = new System.Drawing.Point(3, 84);
            this.overlapYLabel.Name = "overlapYLabel";
            this.overlapYLabel.Size = new System.Drawing.Size(49, 13);
            this.overlapYLabel.TabIndex = 10;
            this.overlapYLabel.Text = "overlapY";
            // 
            // AlignXLabel
            // 
            this.AlignXLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AlignXLabel.AutoSize = true;
            this.AlignXLabel.Location = new System.Drawing.Point(3, 110);
            this.AlignXLabel.Name = "AlignXLabel";
            this.AlignXLabel.Size = new System.Drawing.Size(37, 13);
            this.AlignXLabel.TabIndex = 11;
            this.AlignXLabel.Text = "AlignX";
            // 
            // minOverlapLabel
            // 
            this.minOverlapLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.minOverlapLabel.AutoSize = true;
            this.minOverlapLabel.Location = new System.Drawing.Point(3, 162);
            this.minOverlapLabel.Name = "minOverlapLabel";
            this.minOverlapLabel.Size = new System.Drawing.Size(61, 13);
            this.minOverlapLabel.TabIndex = 13;
            this.minOverlapLabel.Text = "MinOverlap";
            // 
            // minOverlapNud
            // 
            this.minOverlapNud.DecimalPlaces = 3;
            this.minOverlapNud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minOverlapNud.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.minOverlapNud.Location = new System.Drawing.Point(70, 159);
            this.minOverlapNud.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minOverlapNud.Name = "minOverlapNud";
            this.minOverlapNud.Size = new System.Drawing.Size(464, 20);
            this.minOverlapNud.TabIndex = 14;
            this.minOverlapNud.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // SaveBtn
            // 
            this.SaveBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.SaveBtn.Location = new System.Drawing.Point(3, 385);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(531, 23);
            this.SaveBtn.TabIndex = 11;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.UseWaitCursor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(764, 641);
            this.splitContainer1.SplitterDistance = 223;
            this.splitContainer1.TabIndex = 12;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.InputImageBox);
            this.splitContainer2.Size = new System.Drawing.Size(223, 641);
            this.splitContainer2.SplitterDistance = 425;
            this.splitContainer2.TabIndex = 13;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.inputList, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(223, 425);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.OpenFolderBtn);
            this.flowLayoutPanel1.Controls.Add(this.OpenImagesBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(217, 23);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // OpenFolderBtn
            // 
            this.OpenFolderBtn.Location = new System.Drawing.Point(0, 0);
            this.OpenFolderBtn.Margin = new System.Windows.Forms.Padding(0);
            this.OpenFolderBtn.Name = "OpenFolderBtn";
            this.OpenFolderBtn.Size = new System.Drawing.Size(75, 23);
            this.OpenFolderBtn.TabIndex = 12;
            this.OpenFolderBtn.Text = "Folder";
            this.OpenFolderBtn.UseVisualStyleBackColor = true;
            this.OpenFolderBtn.Click += new System.EventHandler(this.OpenFolderBtn_Click);
            // 
            // OpenImagesBtn
            // 
            this.OpenImagesBtn.Location = new System.Drawing.Point(75, 0);
            this.OpenImagesBtn.Margin = new System.Windows.Forms.Padding(0);
            this.OpenImagesBtn.Name = "OpenImagesBtn";
            this.OpenImagesBtn.Size = new System.Drawing.Size(75, 23);
            this.OpenImagesBtn.TabIndex = 13;
            this.OpenImagesBtn.Text = "Images";
            this.OpenImagesBtn.UseVisualStyleBackColor = true;
            this.OpenImagesBtn.Click += new System.EventHandler(this.OpenImagesBtn_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer3.Size = new System.Drawing.Size(537, 641);
            this.splitContainer3.SplitterDistance = 411;
            this.splitContainer3.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.SaveBtn, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.OutImageBox, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(537, 411);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.UseWaitCursor = true;
            // 
            // OutImageBox
            // 
            this.OutImageBox.BackColor = System.Drawing.Color.IndianRed;
            this.OutImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutImageBox.Location = new System.Drawing.Point(3, 3);
            this.OutImageBox.Name = "OutImageBox";
            this.OutImageBox.Size = new System.Drawing.Size(531, 376);
            this.OutImageBox.TabIndex = 2;
            this.OutImageBox.TabStop = false;
            this.OutImageBox.UseWaitCursor = true;
            // 
            // LoopStitch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(764, 641);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(780, 680);
            this.Name = "LoopStitch";
            this.Text = "EmptyForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoopStitch_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.colNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlapXNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlapYNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlignYNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlignXNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputImageBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minOverlapNud)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OutImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox inputList;
        private System.Windows.Forms.NumericUpDown colNud;
        private System.Windows.Forms.NumericUpDown overlapXNud;
        private System.Windows.Forms.NumericUpDown rowNud;
        private System.Windows.Forms.NumericUpDown overlapYNud;
        private System.Windows.Forms.NumericUpDown AlignYNud;
        private System.Windows.Forms.NumericUpDown AlignXNud;
        private Emgu.CV.UI.ImageBox InputImageBox;
        private System.Windows.Forms.Button RunBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label colLabel;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Label AlignYLabel;
        private System.Windows.Forms.Label rowLabel;
        private System.Windows.Forms.Label overlapXLabel;
        private System.Windows.Forms.Label overlapYLabel;
        private System.Windows.Forms.Label AlignXLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button OpenFolderBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button OpenImagesBtn;
        private Emgu.CV.UI.ImageBox OutImageBox;
        private System.Windows.Forms.Label minOverlapLabel;
        private System.Windows.Forms.NumericUpDown minOverlapNud;
    }
}