using System;

namespace OpenCV_Vision_Pro
{
    partial class BlobToolControl
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
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.m_BlobInput = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m_NumConnectionMin = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.m_cbConnectClean = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.m_cbConnectMode = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.m_dgvBlobOperation = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.m_cbBlobOperation = new System.Windows.Forms.ComboBox();
            this.m_BtnDeleteOperation = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.m_labelSeg1 = new System.Windows.Forms.Label();
            this.m_NumSegmentation1 = new System.Windows.Forms.NumericUpDown();
            this.m_labelSeg2 = new System.Windows.Forms.Label();
            this.m_NumSegmentation2 = new System.Windows.Forms.NumericUpDown();
            this.m_labelSeg3 = new System.Windows.Forms.Label();
            this.m_NumSegmentation3 = new System.Windows.Forms.NumericUpDown();
            this.m_cbSegPolarity = new System.Windows.Forms.ComboBox();
            this.m_labelPolarity = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.m_cbSegMode = new System.Windows.Forms.ComboBox();
            this.m_BlobMeasurement = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.m_cbBlobProperties = new System.Windows.Forms.ComboBox();
            this.m_btnDeleteProperties = new System.Windows.Forms.Button();
            this.m_BlobMeasurementTable = new System.Windows.Forms.DataGridView();
            this.m_BlobProperties = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_BlobMeasureFilter = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.m_BlobRange = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.m_BlobLow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_BlobHigh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_BlobOutput = new System.Windows.Forms.TabPage();
            this.m_dgvBlobResults = new System.Windows.Forms.DataGridView();
            this.tabControl3.SuspendLayout();
            this.m_BlobInput.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumConnectionMin)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvBlobOperation)).BeginInit();
            this.flowLayoutPanel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumSegmentation1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumSegmentation2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumSegmentation3)).BeginInit();
            this.m_BlobMeasurement.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_BlobMeasurementTable)).BeginInit();
            this.m_BlobOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvBlobResults)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.m_BlobInput);
            this.tabControl3.Controls.Add(this.m_BlobMeasurement);
            this.tabControl3.Controls.Add(this.m_BlobOutput);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(0, 0);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(353, 583);
            this.tabControl3.TabIndex = 2;
            // 
            // m_BlobInput
            // 
            this.m_BlobInput.AutoScroll = true;
            this.m_BlobInput.Controls.Add(this.tableLayoutPanel4);
            this.m_BlobInput.Location = new System.Drawing.Point(4, 22);
            this.m_BlobInput.Name = "m_BlobInput";
            this.m_BlobInput.Padding = new System.Windows.Forms.Padding(3);
            this.m_BlobInput.Size = new System.Drawing.Size(345, 557);
            this.m_BlobInput.TabIndex = 0;
            this.m_BlobInput.Text = "Input";
            this.m_BlobInput.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.MinimumSize = new System.Drawing.Size(0, 350);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(339, 350);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.groupBox5, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(172, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(164, 344);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(164, 150);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Connectivity";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.m_NumConnectionMin, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label18, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.m_cbConnectClean, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label17, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.m_cbConnectMode, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(158, 131);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // m_NumConnectionMin
            // 
            this.m_NumConnectionMin.Location = new System.Drawing.Point(50, 61);
            this.m_NumConnectionMin.Maximum = new decimal(new int[] {
            2147480000,
            0,
            0,
            0});
            this.m_NumConnectionMin.Name = "m_NumConnectionMin";
            this.m_NumConnectionMin.Size = new System.Drawing.Size(82, 20);
            this.m_NumConnectionMin.TabIndex = 7;
            this.m_NumConnectionMin.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_NumConnectionMin.ValueChanged += new System.EventHandler(this.m_NumConnectionMin_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(5, 63);
            this.label18.Margin = new System.Windows.Forms.Padding(5);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 26);
            this.label18.TabIndex = 6;
            this.label18.Text = "Min Area:";
            // 
            // m_cbConnectClean
            // 
            this.m_cbConnectClean.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbConnectClean.FormattingEnabled = true;
            this.m_cbConnectClean.Items.AddRange(new object[] {
            "None",
            "Prune",
            "Fill"});
            this.m_cbConnectClean.Location = new System.Drawing.Point(50, 30);
            this.m_cbConnectClean.Name = "m_cbConnectClean";
            this.m_cbConnectClean.Size = new System.Drawing.Size(94, 21);
            this.m_cbConnectClean.TabIndex = 4;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 32);
            this.label17.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 26);
            this.label17.TabIndex = 3;
            this.label17.Text = "Cleanup:";
            // 
            // m_cbConnectMode
            // 
            this.m_cbConnectMode.CausesValidation = false;
            this.m_cbConnectMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbConnectMode.FormattingEnabled = true;
            this.m_cbConnectMode.Items.AddRange(new object[] {
            "Grey Scale",
            "Labeled",
            "Whole Image"});
            this.m_cbConnectMode.Location = new System.Drawing.Point(50, 3);
            this.m_cbConnectMode.Name = "m_cbConnectMode";
            this.m_cbConnectMode.Size = new System.Drawing.Size(94, 21);
            this.m_cbConnectMode.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(5, 5);
            this.label16.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Mode:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.m_dgvBlobOperation);
            this.groupBox5.Controls.Add(this.flowLayoutPanel5);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 153);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(158, 188);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Morphology Operations";
            // 
            // m_dgvBlobOperation
            // 
            this.m_dgvBlobOperation.AllowUserToAddRows = false;
            this.m_dgvBlobOperation.AllowUserToDeleteRows = false;
            this.m_dgvBlobOperation.AllowUserToResizeColumns = false;
            this.m_dgvBlobOperation.AllowUserToResizeRows = false;
            this.m_dgvBlobOperation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvBlobOperation.ColumnHeadersVisible = false;
            this.m_dgvBlobOperation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3});
            this.m_dgvBlobOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvBlobOperation.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.m_dgvBlobOperation.Location = new System.Drawing.Point(3, 46);
            this.m_dgvBlobOperation.Name = "m_dgvBlobOperation";
            this.m_dgvBlobOperation.RowHeadersVisible = false;
            this.m_dgvBlobOperation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvBlobOperation.Size = new System.Drawing.Size(152, 139);
            this.m_dgvBlobOperation.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Operation";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.m_cbBlobOperation);
            this.flowLayoutPanel5.Controls.Add(this.m_BtnDeleteOperation);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(152, 30);
            this.flowLayoutPanel5.TabIndex = 2;
            // 
            // m_cbBlobOperation
            // 
            this.m_cbBlobOperation.DropDownHeight = 200;
            this.m_cbBlobOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbBlobOperation.DropDownWidth = 150;
            this.m_cbBlobOperation.FormattingEnabled = true;
            this.m_cbBlobOperation.IntegralHeight = false;
            this.m_cbBlobOperation.Items.AddRange(new object[] {
            "ErodeHorizontal",
            "ErodeVertical",
            "ErodeSquare",
            "DilateHorizontal",
            "DilateVertical",
            "DilateSquare",
            "CloseHorizontal",
            "CloseVertical",
            "CloseSquare",
            "OpenHorizontal",
            "OpenVertical",
            "OpenSquare"});
            this.m_cbBlobOperation.Location = new System.Drawing.Point(3, 3);
            this.m_cbBlobOperation.MaxDropDownItems = 50;
            this.m_cbBlobOperation.Name = "m_cbBlobOperation";
            this.m_cbBlobOperation.Size = new System.Drawing.Size(21, 21);
            this.m_cbBlobOperation.TabIndex = 0;
            this.m_cbBlobOperation.SelectedIndexChanged += new System.EventHandler(this.m_cbBlobOperation_SelectedIndexChanged);
            // 
            // m_BtnDeleteOperation
            // 
            this.m_BtnDeleteOperation.Location = new System.Drawing.Point(30, 3);
            this.m_BtnDeleteOperation.Name = "m_BtnDeleteOperation";
            this.m_BtnDeleteOperation.Size = new System.Drawing.Size(21, 21);
            this.m_BtnDeleteOperation.TabIndex = 1;
            this.m_BtnDeleteOperation.Text = "X";
            this.m_BtnDeleteOperation.UseVisualStyleBackColor = true;
            this.m_BtnDeleteOperation.Click += new System.EventHandler(this.m_BtnDeleteOperation_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 350);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Segmentation";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel7, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.m_cbSegPolarity, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.m_labelPolarity, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.m_cbSegMode, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(163, 331);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Controls.Add(this.m_labelSeg1, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.m_NumSegmentation1, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.m_labelSeg2, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.m_NumSegmentation2, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.m_labelSeg3, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.m_NumSegmentation3, 1, 2);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 93);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 5;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.Size = new System.Drawing.Size(149, 78);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // m_labelSeg1
            // 
            this.m_labelSeg1.AutoSize = true;
            this.m_labelSeg1.Location = new System.Drawing.Point(5, 5);
            this.m_labelSeg1.Margin = new System.Windows.Forms.Padding(5);
            this.m_labelSeg1.Name = "m_labelSeg1";
            this.m_labelSeg1.Size = new System.Drawing.Size(57, 13);
            this.m_labelSeg1.TabIndex = 5;
            this.m_labelSeg1.Text = "Threshold:";
            this.m_labelSeg1.Visible = false;
            // 
            // m_NumSegmentation1
            // 
            this.m_NumSegmentation1.Location = new System.Drawing.Point(76, 3);
            this.m_NumSegmentation1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_NumSegmentation1.Name = "m_NumSegmentation1";
            this.m_NumSegmentation1.Size = new System.Drawing.Size(70, 20);
            this.m_NumSegmentation1.TabIndex = 6;
            this.m_NumSegmentation1.Visible = false;
            this.m_NumSegmentation1.ValueChanged += new System.EventHandler(this.m_NumSegmentation1_ValueChanged);
            // 
            // m_labelSeg2
            // 
            this.m_labelSeg2.AutoSize = true;
            this.m_labelSeg2.Location = new System.Drawing.Point(5, 31);
            this.m_labelSeg2.Margin = new System.Windows.Forms.Padding(5);
            this.m_labelSeg2.Name = "m_labelSeg2";
            this.m_labelSeg2.Size = new System.Drawing.Size(63, 13);
            this.m_labelSeg2.TabIndex = 7;
            this.m_labelSeg2.Text = "Block Size: ";
            this.m_labelSeg2.Visible = false;
            // 
            // m_NumSegmentation2
            // 
            this.m_NumSegmentation2.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_NumSegmentation2.Location = new System.Drawing.Point(76, 29);
            this.m_NumSegmentation2.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_NumSegmentation2.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_NumSegmentation2.Name = "m_NumSegmentation2";
            this.m_NumSegmentation2.Size = new System.Drawing.Size(70, 20);
            this.m_NumSegmentation2.TabIndex = 8;
            this.m_NumSegmentation2.Value = new decimal(new int[] {
            17,
            0,
            0,
            0});
            this.m_NumSegmentation2.Visible = false;
            this.m_NumSegmentation2.ValueChanged += new System.EventHandler(this.m_NumSegmentation2_ValueChanged);
            // 
            // m_labelSeg3
            // 
            this.m_labelSeg3.AutoSize = true;
            this.m_labelSeg3.Location = new System.Drawing.Point(5, 57);
            this.m_labelSeg3.Margin = new System.Windows.Forms.Padding(5);
            this.m_labelSeg3.Name = "m_labelSeg3";
            this.m_labelSeg3.Size = new System.Drawing.Size(49, 13);
            this.m_labelSeg3.TabIndex = 9;
            this.m_labelSeg3.Text = "Param1: ";
            this.m_labelSeg3.Visible = false;
            // 
            // m_NumSegmentation3
            // 
            this.m_NumSegmentation3.Location = new System.Drawing.Point(76, 55);
            this.m_NumSegmentation3.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_NumSegmentation3.Name = "m_NumSegmentation3";
            this.m_NumSegmentation3.Size = new System.Drawing.Size(70, 20);
            this.m_NumSegmentation3.TabIndex = 10;
            this.m_NumSegmentation3.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_NumSegmentation3.Visible = false;
            this.m_NumSegmentation3.ValueChanged += new System.EventHandler(this.m_NumSegmentation3_ValueChanged);
            // 
            // m_cbSegPolarity
            // 
            this.m_cbSegPolarity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_cbSegPolarity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbSegPolarity.FormattingEnabled = true;
            this.m_cbSegPolarity.Items.AddRange(new object[] {
            "Dark blobs, Light background",
            "Light blobs, Dark background"});
            this.m_cbSegPolarity.Location = new System.Drawing.Point(3, 66);
            this.m_cbSegPolarity.Name = "m_cbSegPolarity";
            this.m_cbSegPolarity.Size = new System.Drawing.Size(157, 21);
            this.m_cbSegPolarity.TabIndex = 3;
            this.m_cbSegPolarity.SelectedIndexChanged += new System.EventHandler(this.m_cbSegPolarity_SelectedIndexChanged);
            // 
            // m_labelPolarity
            // 
            this.m_labelPolarity.AutoSize = true;
            this.m_labelPolarity.Location = new System.Drawing.Point(5, 50);
            this.m_labelPolarity.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.m_labelPolarity.Name = "m_labelPolarity";
            this.m_labelPolarity.Size = new System.Drawing.Size(44, 13);
            this.m_labelPolarity.TabIndex = 2;
            this.m_labelPolarity.Text = "Polarity:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 5);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Mode:";
            // 
            // m_cbSegMode
            // 
            this.m_cbSegMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_cbSegMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbSegMode.FormattingEnabled = true;
            this.m_cbSegMode.Items.AddRange(new object[] {
            "Global (Manual)",
            "Global (Otsu)",
            "Global (Triangle)",
            "Local (MeanC)",
            "Local (GaussianC)"});
            this.m_cbSegMode.Location = new System.Drawing.Point(3, 21);
            this.m_cbSegMode.Name = "m_cbSegMode";
            this.m_cbSegMode.Size = new System.Drawing.Size(157, 21);
            this.m_cbSegMode.TabIndex = 1;
            this.m_cbSegMode.SelectedIndexChanged += new System.EventHandler(this.m_cbSegMode_SelectedIndexChanged);
            // 
            // m_BlobMeasurement
            // 
            this.m_BlobMeasurement.Controls.Add(this.tableLayoutPanel6);
            this.m_BlobMeasurement.Location = new System.Drawing.Point(4, 22);
            this.m_BlobMeasurement.Name = "m_BlobMeasurement";
            this.m_BlobMeasurement.Padding = new System.Windows.Forms.Padding(3);
            this.m_BlobMeasurement.Size = new System.Drawing.Size(345, 557);
            this.m_BlobMeasurement.TabIndex = 2;
            this.m_BlobMeasurement.Text = "Measurement";
            this.m_BlobMeasurement.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.flowLayoutPanel3, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.m_BlobMeasurementTable, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(339, 551);
            this.tableLayoutPanel6.TabIndex = 5;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.m_cbBlobProperties);
            this.flowLayoutPanel3.Controls.Add(this.m_btnDeleteProperties);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(339, 30);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // m_cbBlobProperties
            // 
            this.m_cbBlobProperties.DropDownHeight = 200;
            this.m_cbBlobProperties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbBlobProperties.DropDownWidth = 150;
            this.m_cbBlobProperties.FormattingEnabled = true;
            this.m_cbBlobProperties.IntegralHeight = false;
            this.m_cbBlobProperties.Location = new System.Drawing.Point(3, 3);
            this.m_cbBlobProperties.MaxDropDownItems = 50;
            this.m_cbBlobProperties.Name = "m_cbBlobProperties";
            this.m_cbBlobProperties.Size = new System.Drawing.Size(21, 21);
            this.m_cbBlobProperties.TabIndex = 0;
            this.m_cbBlobProperties.SelectedIndexChanged += new System.EventHandler(this.m_cbBlobProperties_SelectedIndexChanged);
            // 
            // m_btnDeleteProperties
            // 
            this.m_btnDeleteProperties.Location = new System.Drawing.Point(30, 3);
            this.m_btnDeleteProperties.Name = "m_btnDeleteProperties";
            this.m_btnDeleteProperties.Size = new System.Drawing.Size(21, 21);
            this.m_btnDeleteProperties.TabIndex = 1;
            this.m_btnDeleteProperties.Text = "X";
            this.m_btnDeleteProperties.UseVisualStyleBackColor = true;
            this.m_btnDeleteProperties.Click += new System.EventHandler(this.m_btnDeleteProperties_Click);
            // 
            // m_BlobMeasurementTable
            // 
            this.m_BlobMeasurementTable.AllowUserToAddRows = false;
            this.m_BlobMeasurementTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_BlobMeasurementTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_BlobProperties,
            this.m_BlobMeasureFilter,
            this.m_BlobRange,
            this.m_BlobLow,
            this.m_BlobHigh});
            this.m_BlobMeasurementTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_BlobMeasurementTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.m_BlobMeasurementTable.Location = new System.Drawing.Point(3, 33);
            this.m_BlobMeasurementTable.Name = "m_BlobMeasurementTable";
            this.m_BlobMeasurementTable.RowHeadersVisible = false;
            this.m_BlobMeasurementTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_BlobMeasurementTable.Size = new System.Drawing.Size(333, 515);
            this.m_BlobMeasurementTable.TabIndex = 2;
            this.m_BlobMeasurementTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_BlobMeasurementTable_CellEndEdit);
            this.m_BlobMeasurementTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_BlobMeasurementTable_CellValueChanged);
            this.m_BlobMeasurementTable.CurrentCellDirtyStateChanged += new System.EventHandler(this.m_BlobMeasurementTable_CurrentCellDirtyStateChanged);
            // 
            // m_BlobProperties
            // 
            this.m_BlobProperties.Frozen = true;
            this.m_BlobProperties.HeaderText = "Properties";
            this.m_BlobProperties.Name = "m_BlobProperties";
            this.m_BlobProperties.ReadOnly = true;
            // 
            // m_BlobMeasureFilter
            // 
            this.m_BlobMeasureFilter.DataPropertyName = "dataGridComboBoxColumn";
            this.m_BlobMeasureFilter.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.m_BlobMeasureFilter.Frozen = true;
            this.m_BlobMeasureFilter.HeaderText = "Measure/Filter";
            this.m_BlobMeasureFilter.Items.AddRange(new object[] {
            "Grid",
            "Runtime",
            "Filter"});
            this.m_BlobMeasureFilter.Name = "m_BlobMeasureFilter";
            // 
            // m_BlobRange
            // 
            this.m_BlobRange.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.m_BlobRange.HeaderText = "Range";
            this.m_BlobRange.Items.AddRange(new object[] {
            "Exclude",
            "Include"});
            this.m_BlobRange.Name = "m_BlobRange";
            this.m_BlobRange.ReadOnly = true;
            // 
            // m_BlobLow
            // 
            this.m_BlobLow.HeaderText = "Low";
            this.m_BlobLow.Name = "m_BlobLow";
            this.m_BlobLow.ReadOnly = true;
            // 
            // m_BlobHigh
            // 
            this.m_BlobHigh.HeaderText = "High";
            this.m_BlobHigh.Name = "m_BlobHigh";
            this.m_BlobHigh.ReadOnly = true;
            // 
            // m_BlobOutput
            // 
            this.m_BlobOutput.Controls.Add(this.m_dgvBlobResults);
            this.m_BlobOutput.Location = new System.Drawing.Point(4, 22);
            this.m_BlobOutput.Name = "m_BlobOutput";
            this.m_BlobOutput.Padding = new System.Windows.Forms.Padding(3);
            this.m_BlobOutput.Size = new System.Drawing.Size(345, 557);
            this.m_BlobOutput.TabIndex = 1;
            this.m_BlobOutput.Text = "Output";
            this.m_BlobOutput.UseVisualStyleBackColor = true;
            // 
            // m_dgvBlobResults
            // 
            this.m_dgvBlobResults.AllowUserToAddRows = false;
            this.m_dgvBlobResults.AllowUserToDeleteRows = false;
            this.m_dgvBlobResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvBlobResults.Location = new System.Drawing.Point(3, 3);
            this.m_dgvBlobResults.MultiSelect = false;
            this.m_dgvBlobResults.Name = "m_dgvBlobResults";
            this.m_dgvBlobResults.ReadOnly = true;
            this.m_dgvBlobResults.RowHeadersWidth = 60;
            this.m_dgvBlobResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvBlobResults.Size = new System.Drawing.Size(339, 551);
            this.m_dgvBlobResults.TabIndex = 0;
            this.m_dgvBlobResults.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.m_dgvBlobResults_ColumnAdded);
            this.m_dgvBlobResults.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.m_dgvBlobResults_DataBindingComplete);
            this.m_dgvBlobResults.SelectionChanged += new System.EventHandler(this.m_dgvBlobResults_SelectionChanged);
            // 
            // BlobToolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tabControl3);
            this.MinimumSize = new System.Drawing.Size(353, 0);
            this.Name = "BlobToolControl";
            this.Size = new System.Drawing.Size(353, 583);
            this.Load += new System.EventHandler(this.BlobToolControl_Load);
            this.tabControl3.ResumeLayout(false);
            this.m_BlobInput.ResumeLayout(false);
            this.m_BlobInput.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumConnectionMin)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvBlobOperation)).EndInit();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumSegmentation1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumSegmentation2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumSegmentation3)).EndInit();
            this.m_BlobMeasurement.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_BlobMeasurementTable)).EndInit();
            this.m_BlobOutput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvBlobResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage m_BlobInput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox m_cbConnectMode;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox m_cbConnectClean;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown m_NumConnectionMin;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView m_dgvBlobOperation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.ComboBox m_cbBlobOperation;
        private System.Windows.Forms.Button m_BtnDeleteOperation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox m_cbSegMode;
        private System.Windows.Forms.Label m_labelPolarity;
        private System.Windows.Forms.ComboBox m_cbSegPolarity;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label m_labelSeg1;
        private System.Windows.Forms.NumericUpDown m_NumSegmentation1;
        private System.Windows.Forms.Label m_labelSeg2;
        private System.Windows.Forms.NumericUpDown m_NumSegmentation2;
        private System.Windows.Forms.Label m_labelSeg3;
        private System.Windows.Forms.NumericUpDown m_NumSegmentation3;
        private System.Windows.Forms.TabPage m_BlobMeasurement;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.ComboBox m_cbBlobProperties;
        private System.Windows.Forms.Button m_btnDeleteProperties;
        private System.Windows.Forms.DataGridView m_BlobMeasurementTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_BlobProperties;
        private System.Windows.Forms.DataGridViewComboBoxColumn m_BlobMeasureFilter;
        private System.Windows.Forms.DataGridViewComboBoxColumn m_BlobRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_BlobLow;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_BlobHigh;
        private System.Windows.Forms.TabPage m_BlobOutput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.DataGridView m_dgvBlobResults;
    }
}
