namespace OpenCV_Vision_Pro.Tools.ImageStacking
{
    partial class ImageStackingToolControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.m_btnStackingOpen = new System.Windows.Forms.Button();
            this.m_cbStackingOperation = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_tableFocus = new System.Windows.Forms.TableLayoutPanel();
            this.m_listImagesSelected = new System.Windows.Forms.ListBox();
            this.m_tableFusion = new System.Windows.Forms.TableLayoutPanel();
            this.m_tableHDR = new System.Windows.Forms.TableLayoutPanel();
            this.m_labelToneMapType = new System.Windows.Forms.Label();
            this.m_btnOpenTimes = new System.Windows.Forms.Button();
            this.m_labelLoadTimes = new System.Windows.Forms.Label();
            this.m_cbToneMappingType = new System.Windows.Forms.ComboBox();
            this.m_tableToneMapParams = new System.Windows.Forms.TableLayoutPanel();
            this.m_nudP5 = new System.Windows.Forms.NumericUpDown();
            this.m_nudP4 = new System.Windows.Forms.NumericUpDown();
            this.m_nudP3 = new System.Windows.Forms.NumericUpDown();
            this.m_nudP2 = new System.Windows.Forms.NumericUpDown();
            this.m_labelP1 = new System.Windows.Forms.Label();
            this.m_labelP2 = new System.Windows.Forms.Label();
            this.m_labelP3 = new System.Windows.Forms.Label();
            this.m_labelP4 = new System.Windows.Forms.Label();
            this.m_labelP5 = new System.Windows.Forms.Label();
            this.m_nudP1 = new System.Windows.Forms.NumericUpDown();
            this.m_openMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imagestiftiffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.m_tableHDR.SuspendLayout();
            this.m_tableToneMapParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudP5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudP4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudP3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudP1)).BeginInit();
            this.m_openMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnStackingOpen
            // 
            this.m_btnStackingOpen.Location = new System.Drawing.Point(3, 3);
            this.m_btnStackingOpen.Name = "m_btnStackingOpen";
            this.m_btnStackingOpen.Size = new System.Drawing.Size(75, 23);
            this.m_btnStackingOpen.TabIndex = 0;
            this.m_btnStackingOpen.Text = "Open Images";
            this.m_btnStackingOpen.UseVisualStyleBackColor = true;
            this.m_btnStackingOpen.Click += new System.EventHandler(this.m_btnStackingOpen_Click);
            // 
            // m_cbStackingOperation
            // 
            this.m_cbStackingOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbStackingOperation.FormattingEnabled = true;
            this.m_cbStackingOperation.Items.AddRange(new object[] {
            "Focus",
            "Exposure - Fusion",
            "Exposure - HDR"});
            this.m_cbStackingOperation.Location = new System.Drawing.Point(69, 3);
            this.m_cbStackingOperation.Name = "m_cbStackingOperation";
            this.m_cbStackingOperation.Size = new System.Drawing.Size(200, 21);
            this.m_cbStackingOperation.TabIndex = 1;
            this.m_cbStackingOperation.SelectedIndexChanged += new System.EventHandler(this.m_cbStackingOperation_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.m_tableFocus, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.m_listImagesSelected, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.m_tableFusion, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.m_btnStackingOpen, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.m_tableHDR, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(521, 464);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.m_cbStackingOperation);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 132);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(515, 27);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Operation:";
            // 
            // m_tableFocus
            // 
            this.m_tableFocus.ColumnCount = 2;
            this.m_tableFocus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_tableFocus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_tableFocus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tableFocus.Location = new System.Drawing.Point(3, 417);
            this.m_tableFocus.Name = "m_tableFocus";
            this.m_tableFocus.RowCount = 2;
            this.m_tableFocus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_tableFocus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_tableFocus.Size = new System.Drawing.Size(515, 44);
            this.m_tableFocus.TabIndex = 6;
            // 
            // m_listImagesSelected
            // 
            this.m_listImagesSelected.BackColor = System.Drawing.SystemColors.ControlLight;
            this.m_listImagesSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_listImagesSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_listImagesSelected.FormattingEnabled = true;
            this.m_listImagesSelected.Location = new System.Drawing.Point(3, 32);
            this.m_listImagesSelected.Name = "m_listImagesSelected";
            this.m_listImagesSelected.Size = new System.Drawing.Size(515, 94);
            this.m_listImagesSelected.TabIndex = 3;
            this.m_listImagesSelected.SelectedIndexChanged += new System.EventHandler(this.m_listImagesSelected_SelectedIndexChanged);
            // 
            // m_tableFusion
            // 
            this.m_tableFusion.ColumnCount = 2;
            this.m_tableFusion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_tableFusion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_tableFusion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tableFusion.Location = new System.Drawing.Point(3, 367);
            this.m_tableFusion.Name = "m_tableFusion";
            this.m_tableFusion.RowCount = 2;
            this.m_tableFusion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_tableFusion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_tableFusion.Size = new System.Drawing.Size(515, 44);
            this.m_tableFusion.TabIndex = 5;
            // 
            // m_tableHDR
            // 
            this.m_tableHDR.AutoSize = true;
            this.m_tableHDR.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_tableHDR.ColumnCount = 2;
            this.m_tableHDR.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_tableHDR.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_tableHDR.Controls.Add(this.m_labelToneMapType, 0, 1);
            this.m_tableHDR.Controls.Add(this.m_btnOpenTimes, 0, 0);
            this.m_tableHDR.Controls.Add(this.m_labelLoadTimes, 1, 0);
            this.m_tableHDR.Controls.Add(this.m_cbToneMappingType, 1, 1);
            this.m_tableHDR.Controls.Add(this.m_tableToneMapParams, 1, 2);
            this.m_tableHDR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tableHDR.Location = new System.Drawing.Point(3, 165);
            this.m_tableHDR.Name = "m_tableHDR";
            this.m_tableHDR.RowCount = 3;
            this.m_tableHDR.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_tableHDR.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_tableHDR.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_tableHDR.Size = new System.Drawing.Size(515, 196);
            this.m_tableHDR.TabIndex = 4;
            // 
            // m_labelToneMapType
            // 
            this.m_labelToneMapType.AutoSize = true;
            this.m_labelToneMapType.Location = new System.Drawing.Point(5, 34);
            this.m_labelToneMapType.Margin = new System.Windows.Forms.Padding(5);
            this.m_labelToneMapType.Name = "m_labelToneMapType";
            this.m_labelToneMapType.Size = new System.Drawing.Size(106, 13);
            this.m_labelToneMapType.TabIndex = 2;
            this.m_labelToneMapType.Text = "Tone Mapping Type:";
            this.m_labelToneMapType.UseWaitCursor = true;
            // 
            // m_btnOpenTimes
            // 
            this.m_btnOpenTimes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_btnOpenTimes.Location = new System.Drawing.Point(3, 3);
            this.m_btnOpenTimes.Name = "m_btnOpenTimes";
            this.m_btnOpenTimes.Size = new System.Drawing.Size(110, 23);
            this.m_btnOpenTimes.TabIndex = 0;
            this.m_btnOpenTimes.Text = "Times Files";
            this.m_btnOpenTimes.UseVisualStyleBackColor = true;
            this.m_btnOpenTimes.Click += new System.EventHandler(this.m_btnOpenTimes_Click);
            // 
            // m_labelLoadTimes
            // 
            this.m_labelLoadTimes.AutoSize = true;
            this.m_labelLoadTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_labelLoadTimes.ForeColor = System.Drawing.Color.Gray;
            this.m_labelLoadTimes.Location = new System.Drawing.Point(121, 5);
            this.m_labelLoadTimes.Margin = new System.Windows.Forms.Padding(5);
            this.m_labelLoadTimes.Name = "m_labelLoadTimes";
            this.m_labelLoadTimes.Size = new System.Drawing.Size(46, 15);
            this.m_labelLoadTimes.TabIndex = 1;
            this.m_labelLoadTimes.Text = "Empty";
            // 
            // m_cbToneMappingType
            // 
            this.m_cbToneMappingType.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_cbToneMappingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbToneMappingType.FormattingEnabled = true;
            this.m_cbToneMappingType.Items.AddRange(new object[] {
            "Drago",
            "Durand",
            "Reinhard",
            "Mantiuk"});
            this.m_cbToneMappingType.Location = new System.Drawing.Point(119, 32);
            this.m_cbToneMappingType.Name = "m_cbToneMappingType";
            this.m_cbToneMappingType.Size = new System.Drawing.Size(178, 21);
            this.m_cbToneMappingType.TabIndex = 3;
            this.m_cbToneMappingType.SelectedIndexChanged += new System.EventHandler(this.m_cbToneMappingType_SelectedIndexChanged);
            // 
            // m_tableToneMapParams
            // 
            this.m_tableToneMapParams.ColumnCount = 2;
            this.m_tableToneMapParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_tableToneMapParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_tableToneMapParams.Controls.Add(this.m_nudP5, 1, 4);
            this.m_tableToneMapParams.Controls.Add(this.m_nudP4, 1, 3);
            this.m_tableToneMapParams.Controls.Add(this.m_nudP3, 1, 2);
            this.m_tableToneMapParams.Controls.Add(this.m_nudP2, 1, 1);
            this.m_tableToneMapParams.Controls.Add(this.m_labelP1, 0, 0);
            this.m_tableToneMapParams.Controls.Add(this.m_labelP2, 0, 1);
            this.m_tableToneMapParams.Controls.Add(this.m_labelP3, 0, 2);
            this.m_tableToneMapParams.Controls.Add(this.m_labelP4, 0, 3);
            this.m_tableToneMapParams.Controls.Add(this.m_labelP5, 0, 4);
            this.m_tableToneMapParams.Controls.Add(this.m_nudP1, 1, 0);
            this.m_tableToneMapParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tableToneMapParams.Location = new System.Drawing.Point(119, 59);
            this.m_tableToneMapParams.Name = "m_tableToneMapParams";
            this.m_tableToneMapParams.RowCount = 5;
            this.m_tableToneMapParams.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_tableToneMapParams.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_tableToneMapParams.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_tableToneMapParams.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_tableToneMapParams.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_tableToneMapParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.m_tableToneMapParams.Size = new System.Drawing.Size(393, 134);
            this.m_tableToneMapParams.TabIndex = 4;
            // 
            // m_nudP5
            // 
            this.m_nudP5.DecimalPlaces = 1;
            this.m_nudP5.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_nudP5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudP5.Location = new System.Drawing.Point(58, 107);
            this.m_nudP5.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_nudP5.Name = "m_nudP5";
            this.m_nudP5.Size = new System.Drawing.Size(120, 20);
            this.m_nudP5.TabIndex = 10;
            this.m_nudP5.ValueChanged += new System.EventHandler(this.m_nudP5_ValueChanged);
            // 
            // m_nudP4
            // 
            this.m_nudP4.DecimalPlaces = 1;
            this.m_nudP4.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_nudP4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudP4.Location = new System.Drawing.Point(58, 81);
            this.m_nudP4.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_nudP4.Name = "m_nudP4";
            this.m_nudP4.Size = new System.Drawing.Size(120, 20);
            this.m_nudP4.TabIndex = 9;
            this.m_nudP4.ValueChanged += new System.EventHandler(this.m_nudP4_ValueChanged);
            // 
            // m_nudP3
            // 
            this.m_nudP3.DecimalPlaces = 1;
            this.m_nudP3.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_nudP3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudP3.Location = new System.Drawing.Point(58, 55);
            this.m_nudP3.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_nudP3.Name = "m_nudP3";
            this.m_nudP3.Size = new System.Drawing.Size(120, 20);
            this.m_nudP3.TabIndex = 8;
            this.m_nudP3.ValueChanged += new System.EventHandler(this.m_nudP3_ValueChanged);
            // 
            // m_nudP2
            // 
            this.m_nudP2.DecimalPlaces = 1;
            this.m_nudP2.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_nudP2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudP2.Location = new System.Drawing.Point(58, 29);
            this.m_nudP2.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_nudP2.Name = "m_nudP2";
            this.m_nudP2.Size = new System.Drawing.Size(120, 20);
            this.m_nudP2.TabIndex = 7;
            this.m_nudP2.ValueChanged += new System.EventHandler(this.m_nudP2_ValueChanged);
            // 
            // m_labelP1
            // 
            this.m_labelP1.AutoSize = true;
            this.m_labelP1.Location = new System.Drawing.Point(3, 3);
            this.m_labelP1.Margin = new System.Windows.Forms.Padding(3);
            this.m_labelP1.Name = "m_labelP1";
            this.m_labelP1.Size = new System.Drawing.Size(49, 13);
            this.m_labelP1.TabIndex = 0;
            this.m_labelP1.Text = "Gamma: ";
            // 
            // m_labelP2
            // 
            this.m_labelP2.AutoSize = true;
            this.m_labelP2.Location = new System.Drawing.Point(3, 29);
            this.m_labelP2.Margin = new System.Windows.Forms.Padding(3);
            this.m_labelP2.Name = "m_labelP2";
            this.m_labelP2.Size = new System.Drawing.Size(35, 13);
            this.m_labelP2.TabIndex = 1;
            this.m_labelP2.Text = "label3";
            // 
            // m_labelP3
            // 
            this.m_labelP3.AutoSize = true;
            this.m_labelP3.Location = new System.Drawing.Point(3, 55);
            this.m_labelP3.Margin = new System.Windows.Forms.Padding(3);
            this.m_labelP3.Name = "m_labelP3";
            this.m_labelP3.Size = new System.Drawing.Size(35, 13);
            this.m_labelP3.TabIndex = 2;
            this.m_labelP3.Text = "label4";
            // 
            // m_labelP4
            // 
            this.m_labelP4.AutoSize = true;
            this.m_labelP4.Location = new System.Drawing.Point(3, 81);
            this.m_labelP4.Margin = new System.Windows.Forms.Padding(3);
            this.m_labelP4.Name = "m_labelP4";
            this.m_labelP4.Size = new System.Drawing.Size(35, 13);
            this.m_labelP4.TabIndex = 3;
            this.m_labelP4.Text = "label5";
            // 
            // m_labelP5
            // 
            this.m_labelP5.AutoSize = true;
            this.m_labelP5.Location = new System.Drawing.Point(3, 107);
            this.m_labelP5.Margin = new System.Windows.Forms.Padding(3);
            this.m_labelP5.Name = "m_labelP5";
            this.m_labelP5.Size = new System.Drawing.Size(35, 13);
            this.m_labelP5.TabIndex = 4;
            this.m_labelP5.Text = "label6";
            // 
            // m_nudP1
            // 
            this.m_nudP1.DecimalPlaces = 1;
            this.m_nudP1.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_nudP1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudP1.Location = new System.Drawing.Point(58, 3);
            this.m_nudP1.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_nudP1.Name = "m_nudP1";
            this.m_nudP1.Size = new System.Drawing.Size(120, 20);
            this.m_nudP1.TabIndex = 5;
            this.m_nudP1.ValueChanged += new System.EventHandler(this.m_nudP1_ValueChanged);
            // 
            // m_openMenuStrip
            // 
            this.m_openMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imagestiftiffToolStripMenuItem,
            this.folderToolStripMenuItem});
            this.m_openMenuStrip.Name = "m_openMenuStrip";
            this.m_openMenuStrip.Size = new System.Drawing.Size(161, 48);
            // 
            // imagestiftiffToolStripMenuItem
            // 
            this.imagestiftiffToolStripMenuItem.Name = "imagestiftiffToolStripMenuItem";
            this.imagestiftiffToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.imagestiftiffToolStripMenuItem.Text = "Images (.tif/.tiff)";
            this.imagestiftiffToolStripMenuItem.Click += new System.EventHandler(this.OpenEvent);
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.folderToolStripMenuItem.Text = "Folder";
            this.folderToolStripMenuItem.Click += new System.EventHandler(this.OpenEvent);
            // 
            // ImageStackingToolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ImageStackingToolControl";
            this.Size = new System.Drawing.Size(521, 682);
            this.Load += new System.EventHandler(this.ImageStackingToolContorl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.m_tableHDR.ResumeLayout(false);
            this.m_tableHDR.PerformLayout();
            this.m_tableToneMapParams.ResumeLayout(false);
            this.m_tableToneMapParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudP5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudP4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudP3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudP1)).EndInit();
            this.m_openMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_btnStackingOpen;
        private System.Windows.Forms.ComboBox m_cbStackingOperation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox m_listImagesSelected;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip m_openMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem imagestiftiffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel m_tableHDR;
        private System.Windows.Forms.TableLayoutPanel m_tableFusion;
        private System.Windows.Forms.TableLayoutPanel m_tableFocus;
        private System.Windows.Forms.Label m_labelToneMapType;
        private System.Windows.Forms.Button m_btnOpenTimes;
        private System.Windows.Forms.Label m_labelLoadTimes;
        private System.Windows.Forms.ComboBox m_cbToneMappingType;
        private System.Windows.Forms.TableLayoutPanel m_tableToneMapParams;
        private System.Windows.Forms.Label m_labelP1;
        private System.Windows.Forms.Label m_labelP2;
        private System.Windows.Forms.Label m_labelP3;
        private System.Windows.Forms.Label m_labelP4;
        private System.Windows.Forms.Label m_labelP5;
        private System.Windows.Forms.NumericUpDown m_nudP1;
        private System.Windows.Forms.NumericUpDown m_nudP5;
        private System.Windows.Forms.NumericUpDown m_nudP4;
        private System.Windows.Forms.NumericUpDown m_nudP3;
        private System.Windows.Forms.NumericUpDown m_nudP2;
    }
}
