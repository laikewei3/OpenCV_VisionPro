namespace OpenCV_Vision_Pro
{
    partial class Form1
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
            this.label13 = new System.Windows.Forms.Label();
            this.m_BlobHigh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_BlobLow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_BlobRange = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.m_BlobMeasureFilter = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.m_BlobProperties = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_BlobMeasurementTable = new System.Windows.Forms.DataGridView();
            this.m_cbBlobProperties = new System.Windows.Forms.ComboBox();
            this.m_btnDeleteProperties = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.m_dgvBlobResults = new System.Windows.Forms.DataGridView();
            this.m_BlobMeasurement = new System.Windows.Forms.TabPage();
            this.m_labelSeg1 = new System.Windows.Forms.Label();
            this.m_NumSegmentation1 = new System.Windows.Forms.NumericUpDown();
            this.m_labelSeg2 = new System.Windows.Forms.Label();
            this.m_NumSegmentation2 = new System.Windows.Forms.NumericUpDown();
            this.m_labelSeg3 = new System.Windows.Forms.Label();
            this.m_NumSegmentation5 = new System.Windows.Forms.NumericUpDown();
            this.m_labelSeg5 = new System.Windows.Forms.Label();
            this.m_NumSegmentation4 = new System.Windows.Forms.NumericUpDown();
            this.m_labelSeg4 = new System.Windows.Forms.Label();
            this.m_CaliperRes = new System.Windows.Forms.DataGridView();
            this.m_BlobOutput = new System.Windows.Forms.TabPage();
            this.m_NumSegmentation3 = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.m_cbSegMode = new System.Windows.Forms.ComboBox();
            this.m_SegMap = new System.Windows.Forms.GroupBox();
            this.m_labelPolarity = new System.Windows.Forms.Label();
            this.m_cbSegPolarity = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.m_CaliperTab = new System.Windows.Forms.TabPage();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.m_CaliperInput = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.m_NumResult = new System.Windows.Forms.NumericUpDown();
            this.m_NumFilter = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.m_NumContrastThreshold = new System.Windows.Forms.NumericUpDown();
            this.m_gbEdgeMode = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.m_radioSingle = new System.Windows.Forms.RadioButton();
            this.m_radioPair = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_Any0 = new System.Windows.Forms.RadioButton();
            this.m_LD0 = new System.Windows.Forms.RadioButton();
            this.m_DL0 = new System.Windows.Forms.RadioButton();
            this.m_gbEdge1Polarity = new System.Windows.Forms.GroupBox();
            this.m_Any1 = new System.Windows.Forms.RadioButton();
            this.m_LD1 = new System.Windows.Forms.RadioButton();
            this.m_DL1 = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.m_NumEdgePairWidth = new System.Windows.Forms.NumericUpDown();
            this.m_CaliperOutput = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_tbSample = new System.Windows.Forms.TextBox();
            this.m_tbVariance = new System.Windows.Forms.TextBox();
            this.m_tbSD = new System.Windows.Forms.TextBox();
            this.m_tbMean = new System.Windows.Forms.TextBox();
            this.m_tbMode = new System.Windows.Forms.TextBox();
            this.m_tbMedian = new System.Windows.Forms.TextBox();
            this.m_tbMax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_HisOutTable = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_tbMin = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_dgvHisData = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.m_HistogramInput = new System.Windows.Forms.TabPage();
            this.m_HistogramOutput = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.m_HistogramTab = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.m_BlobTab = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.m_BlobInput = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label16 = new System.Windows.Forms.Label();
            this.m_cbConnectMode = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.m_cbConnectClean = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.m_NumConnectionMin = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.m_dgvBlobOperation = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.m_cbBlobOperation = new System.Windows.Forms.ComboBox();
            this.m_BtnDeleteOperation = new System.Windows.Forms.Button();
            this.m_RunBtn = new System.Windows.Forms.Button();
            this.m_OpenBtn = new System.Windows.Forms.Button();
            this.m_RunToolBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m_cbImages = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_display = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_BlobMeasurementTable)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvBlobResults)).BeginInit();
            this.m_BlobMeasurement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumSegmentation1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumSegmentation2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumSegmentation5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumSegmentation4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_CaliperRes)).BeginInit();
            this.m_BlobOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumSegmentation3)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.m_CaliperTab.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.m_CaliperInput.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumContrastThreshold)).BeginInit();
            this.m_gbEdgeMode.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.m_gbEdge1Polarity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumEdgePairWidth)).BeginInit();
            this.m_CaliperOutput.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.m_HisOutTable.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvHisData)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.m_HistogramOutput.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.m_HistogramTab.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.m_BlobTab.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.m_BlobInput.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumConnectionMin)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvBlobOperation)).BeginInit();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_display)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Location = new System.Drawing.Point(5, 5);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Mode:";
            // 
            // m_BlobHigh
            // 
            this.m_BlobHigh.HeaderText = "High";
            this.m_BlobHigh.Name = "m_BlobHigh";
            this.m_BlobHigh.ReadOnly = true;
            // 
            // m_BlobLow
            // 
            this.m_BlobLow.HeaderText = "Low";
            this.m_BlobLow.Name = "m_BlobLow";
            this.m_BlobLow.ReadOnly = true;
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
            // m_BlobProperties
            // 
            this.m_BlobProperties.Frozen = true;
            this.m_BlobProperties.HeaderText = "Properties";
            this.m_BlobProperties.Name = "m_BlobProperties";
            this.m_BlobProperties.ReadOnly = true;
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
            this.m_BlobMeasurementTable.Size = new System.Drawing.Size(374, 319);
            this.m_BlobMeasurementTable.TabIndex = 2;
            this.m_BlobMeasurementTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_BlobMeasurementTable_CellEndEdit);
            this.m_BlobMeasurementTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_BlobMeasurementTable_CellValueChanged);
            this.m_BlobMeasurementTable.CurrentCellDirtyStateChanged += new System.EventHandler(this.m_BlobMeasurementTable_CurrentCellDirtyStateChanged);
            // 
            // m_cbBlobProperties
            // 
            this.m_cbBlobProperties.DropDownHeight = 200;
            this.m_cbBlobProperties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbBlobProperties.DropDownWidth = 150;
            this.m_cbBlobProperties.FormattingEnabled = true;
            this.m_cbBlobProperties.IntegralHeight = false;
            this.m_cbBlobProperties.Items.AddRange(new object[] {
            "Area",
            "CenterMassX",
            "CenterMassY",
            "ConnectivityLabel",
            "Angle",
            "BoundaryPixelLength",
            "Perimeter",
            "NumChildren",
            "InertiaX",
            "InertiaY",
            "InertiaMin",
            "InertiaMax",
            "Elongation",
            "Acircularity",
            "AcircularityRms",
            "ImageBoundCenterX",
            "ImageBoundCenterY",
            "ImageBoundMinX",
            "ImageBoundMaxX",
            "ImageBoundMinY",
            "ImageBoundMaxY",
            "ImageBoundWidth",
            "ImageBoundHeight",
            "ImageBoundAspect",
            "MedianX",
            "MedianY",
            "BoundCenterX",
            "BoundCenterY",
            "BoundMinX",
            "BoundMaxX",
            "BoundMinY",
            "BoundMaxY",
            "BoundWidth",
            "BoundHeight",
            "BoundAspect",
            "BoundPrincipalMinX",
            "BoundPrincipalMaxX",
            "BoundPrincipalMinY",
            "BoundPrincipalMaxY",
            "BoundPrincipalWidth",
            "BoundPrincipalHeight",
            "BoundPrincipalAspect",
            "NotClipped",
            "<ADD ALL>"});
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
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.m_cbBlobProperties);
            this.flowLayoutPanel3.Controls.Add(this.m_btnDeleteProperties);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(380, 30);
            this.flowLayoutPanel3.TabIndex = 1;
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
            this.tableLayoutPanel6.Size = new System.Drawing.Size(380, 355);
            this.tableLayoutPanel6.TabIndex = 5;
            // 
            // m_dgvBlobResults
            // 
            this.m_dgvBlobResults.AllowUserToAddRows = false;
            this.m_dgvBlobResults.AllowUserToDeleteRows = false;
            this.m_dgvBlobResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvBlobResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvBlobResults.Location = new System.Drawing.Point(3, 3);
            this.m_dgvBlobResults.Name = "m_dgvBlobResults";
            this.m_dgvBlobResults.RowHeadersVisible = false;
            this.m_dgvBlobResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvBlobResults.Size = new System.Drawing.Size(380, 355);
            this.m_dgvBlobResults.TabIndex = 0;
            this.m_dgvBlobResults.SelectionChanged += new System.EventHandler(this.m_dgvBlobResults_SelectionChanged);
            // 
            // m_BlobMeasurement
            // 
            this.m_BlobMeasurement.Controls.Add(this.tableLayoutPanel6);
            this.m_BlobMeasurement.Location = new System.Drawing.Point(4, 22);
            this.m_BlobMeasurement.Name = "m_BlobMeasurement";
            this.m_BlobMeasurement.Padding = new System.Windows.Forms.Padding(3);
            this.m_BlobMeasurement.Size = new System.Drawing.Size(386, 361);
            this.m_BlobMeasurement.TabIndex = 2;
            this.m_BlobMeasurement.Text = "Measurement";
            this.m_BlobMeasurement.UseVisualStyleBackColor = true;
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
            // 
            // m_NumSegmentation1
            // 
            this.m_NumSegmentation1.Location = new System.Drawing.Point(70, 3);
            this.m_NumSegmentation1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_NumSegmentation1.Name = "m_NumSegmentation1";
            this.m_NumSegmentation1.Size = new System.Drawing.Size(70, 20);
            this.m_NumSegmentation1.TabIndex = 6;
            this.m_NumSegmentation1.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            // 
            // m_labelSeg2
            // 
            this.m_labelSeg2.AutoSize = true;
            this.m_labelSeg2.Location = new System.Drawing.Point(5, 31);
            this.m_labelSeg2.Margin = new System.Windows.Forms.Padding(5);
            this.m_labelSeg2.Name = "m_labelSeg2";
            this.m_labelSeg2.Size = new System.Drawing.Size(57, 13);
            this.m_labelSeg2.TabIndex = 7;
            this.m_labelSeg2.Text = "Threshold:";
            this.m_labelSeg2.Visible = false;
            // 
            // m_NumSegmentation2
            // 
            this.m_NumSegmentation2.Location = new System.Drawing.Point(70, 29);
            this.m_NumSegmentation2.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_NumSegmentation2.Name = "m_NumSegmentation2";
            this.m_NumSegmentation2.Size = new System.Drawing.Size(70, 20);
            this.m_NumSegmentation2.TabIndex = 8;
            this.m_NumSegmentation2.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.m_NumSegmentation2.Visible = false;
            // 
            // m_labelSeg3
            // 
            this.m_labelSeg3.AutoSize = true;
            this.m_labelSeg3.Location = new System.Drawing.Point(5, 57);
            this.m_labelSeg3.Margin = new System.Windows.Forms.Padding(5);
            this.m_labelSeg3.Name = "m_labelSeg3";
            this.m_labelSeg3.Size = new System.Drawing.Size(57, 13);
            this.m_labelSeg3.TabIndex = 9;
            this.m_labelSeg3.Text = "Threshold:";
            this.m_labelSeg3.Visible = false;
            // 
            // m_NumSegmentation5
            // 
            this.m_NumSegmentation5.Location = new System.Drawing.Point(70, 107);
            this.m_NumSegmentation5.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_NumSegmentation5.Name = "m_NumSegmentation5";
            this.m_NumSegmentation5.Size = new System.Drawing.Size(70, 20);
            this.m_NumSegmentation5.TabIndex = 14;
            this.m_NumSegmentation5.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.m_NumSegmentation5.Visible = false;
            // 
            // m_labelSeg5
            // 
            this.m_labelSeg5.AutoSize = true;
            this.m_labelSeg5.Location = new System.Drawing.Point(5, 109);
            this.m_labelSeg5.Margin = new System.Windows.Forms.Padding(5);
            this.m_labelSeg5.Name = "m_labelSeg5";
            this.m_labelSeg5.Size = new System.Drawing.Size(57, 13);
            this.m_labelSeg5.TabIndex = 13;
            this.m_labelSeg5.Text = "Threshold:";
            this.m_labelSeg5.Visible = false;
            // 
            // m_NumSegmentation4
            // 
            this.m_NumSegmentation4.Location = new System.Drawing.Point(70, 81);
            this.m_NumSegmentation4.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_NumSegmentation4.Name = "m_NumSegmentation4";
            this.m_NumSegmentation4.Size = new System.Drawing.Size(70, 20);
            this.m_NumSegmentation4.TabIndex = 12;
            this.m_NumSegmentation4.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.m_NumSegmentation4.Visible = false;
            // 
            // m_labelSeg4
            // 
            this.m_labelSeg4.AutoSize = true;
            this.m_labelSeg4.Location = new System.Drawing.Point(5, 83);
            this.m_labelSeg4.Margin = new System.Windows.Forms.Padding(5);
            this.m_labelSeg4.Name = "m_labelSeg4";
            this.m_labelSeg4.Size = new System.Drawing.Size(57, 13);
            this.m_labelSeg4.TabIndex = 11;
            this.m_labelSeg4.Text = "Threshold:";
            this.m_labelSeg4.Visible = false;
            // 
            // m_CaliperRes
            // 
            this.m_CaliperRes.AllowUserToAddRows = false;
            this.m_CaliperRes.AllowUserToDeleteRows = false;
            this.m_CaliperRes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_CaliperRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_CaliperRes.Location = new System.Drawing.Point(3, 3);
            this.m_CaliperRes.Name = "m_CaliperRes";
            this.m_CaliperRes.ReadOnly = true;
            this.m_CaliperRes.RowHeadersVisible = false;
            this.m_CaliperRes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_CaliperRes.Size = new System.Drawing.Size(380, 355);
            this.m_CaliperRes.TabIndex = 0;
            // 
            // m_BlobOutput
            // 
            this.m_BlobOutput.Controls.Add(this.m_dgvBlobResults);
            this.m_BlobOutput.Location = new System.Drawing.Point(4, 22);
            this.m_BlobOutput.Name = "m_BlobOutput";
            this.m_BlobOutput.Padding = new System.Windows.Forms.Padding(3);
            this.m_BlobOutput.Size = new System.Drawing.Size(386, 361);
            this.m_BlobOutput.TabIndex = 1;
            this.m_BlobOutput.Text = "Output";
            this.m_BlobOutput.UseVisualStyleBackColor = true;
            // 
            // m_NumSegmentation3
            // 
            this.m_NumSegmentation3.Location = new System.Drawing.Point(70, 55);
            this.m_NumSegmentation3.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_NumSegmentation3.Name = "m_NumSegmentation3";
            this.m_NumSegmentation3.Size = new System.Drawing.Size(70, 20);
            this.m_NumSegmentation3.TabIndex = 10;
            this.m_NumSegmentation3.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.m_NumSegmentation3.Visible = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label13);
            this.flowLayoutPanel2.Controls.Add(this.m_cbSegMode);
            this.flowLayoutPanel2.Controls.Add(this.m_SegMap);
            this.flowLayoutPanel2.Controls.Add(this.m_labelPolarity);
            this.flowLayoutPanel2.Controls.Add(this.m_cbSegPolarity);
            this.flowLayoutPanel2.Controls.Add(this.tableLayoutPanel7);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(184, 331);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // m_cbSegMode
            // 
            this.m_cbSegMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_cbSegMode.FormattingEnabled = true;
            this.m_cbSegMode.Items.AddRange(new object[] {
            "None",
            "Map",
            "Hard Threshold (Fixed)",
            "Hard Threshold (Relative)",
            "Hard Threshold (Dynamic)",
            "Soft Threshold (Fixed)",
            "Soft Threshold (Relative)",
            "Subtraction Image"});
            this.m_cbSegMode.Location = new System.Drawing.Point(3, 21);
            this.m_cbSegMode.Name = "m_cbSegMode";
            this.m_cbSegMode.Size = new System.Drawing.Size(172, 21);
            this.m_cbSegMode.TabIndex = 1;
            // 
            // m_SegMap
            // 
            this.m_SegMap.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_SegMap.Location = new System.Drawing.Point(3, 48);
            this.m_SegMap.Name = "m_SegMap";
            this.m_SegMap.Size = new System.Drawing.Size(178, 100);
            this.m_SegMap.TabIndex = 16;
            this.m_SegMap.TabStop = false;
            this.m_SegMap.Text = "Map";
            this.m_SegMap.Visible = false;
            // 
            // m_labelPolarity
            // 
            this.m_labelPolarity.AutoSize = true;
            this.m_labelPolarity.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_labelPolarity.Location = new System.Drawing.Point(5, 156);
            this.m_labelPolarity.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.m_labelPolarity.Name = "m_labelPolarity";
            this.m_labelPolarity.Size = new System.Drawing.Size(44, 13);
            this.m_labelPolarity.TabIndex = 2;
            this.m_labelPolarity.Text = "Polarity:";
            // 
            // m_cbSegPolarity
            // 
            this.m_cbSegPolarity.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_cbSegPolarity.FormattingEnabled = true;
            this.m_cbSegPolarity.Items.AddRange(new object[] {
            "Dark blobs, Light background",
            "Light blobs, Dark background"});
            this.m_cbSegPolarity.Location = new System.Drawing.Point(3, 172);
            this.m_cbSegPolarity.Name = "m_cbSegPolarity";
            this.m_cbSegPolarity.Size = new System.Drawing.Size(172, 21);
            this.m_cbSegPolarity.TabIndex = 3;
            this.m_cbSegPolarity.SelectedIndexChanged += new System.EventHandler(this.m_cbSegPolarity_SelectedIndexChanged);
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
            this.tableLayoutPanel7.Controls.Add(this.m_NumSegmentation5, 1, 4);
            this.tableLayoutPanel7.Controls.Add(this.m_labelSeg5, 0, 4);
            this.tableLayoutPanel7.Controls.Add(this.m_NumSegmentation4, 1, 3);
            this.tableLayoutPanel7.Controls.Add(this.m_labelSeg4, 0, 3);
            this.tableLayoutPanel7.Controls.Add(this.m_NumSegmentation3, 1, 2);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 199);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 5;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.Size = new System.Drawing.Size(143, 130);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // m_CaliperTab
            // 
            this.m_CaliperTab.Controls.Add(this.tabControl4);
            this.m_CaliperTab.Location = new System.Drawing.Point(4, 4);
            this.m_CaliperTab.Name = "m_CaliperTab";
            this.m_CaliperTab.Padding = new System.Windows.Forms.Padding(3);
            this.m_CaliperTab.Size = new System.Drawing.Size(400, 393);
            this.m_CaliperTab.TabIndex = 2;
            this.m_CaliperTab.Text = "Caliper";
            this.m_CaliperTab.UseVisualStyleBackColor = true;
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.m_CaliperInput);
            this.tabControl4.Controls.Add(this.m_CaliperOutput);
            this.tabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl4.Location = new System.Drawing.Point(3, 3);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(394, 387);
            this.tabControl4.TabIndex = 1;
            // 
            // m_CaliperInput
            // 
            this.m_CaliperInput.AutoScroll = true;
            this.m_CaliperInput.Controls.Add(this.panel1);
            this.m_CaliperInput.Location = new System.Drawing.Point(4, 22);
            this.m_CaliperInput.Name = "m_CaliperInput";
            this.m_CaliperInput.Padding = new System.Windows.Forms.Padding(3);
            this.m_CaliperInput.Size = new System.Drawing.Size(386, 361);
            this.m_CaliperInput.TabIndex = 0;
            this.m_CaliperInput.Text = "Input";
            this.m_CaliperInput.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.m_gbEdgeMode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 290);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.m_NumResult, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.m_NumFilter, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.m_NumContrastThreshold, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 187);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(380, 100);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // m_NumResult
            // 
            this.m_NumResult.Location = new System.Drawing.Point(193, 69);
            this.m_NumResult.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.m_NumResult.Name = "m_NumResult";
            this.m_NumResult.Size = new System.Drawing.Size(120, 20);
            this.m_NumResult.TabIndex = 5;
            this.m_NumResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_NumResult.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_NumFilter
            // 
            this.m_NumFilter.Location = new System.Drawing.Point(193, 36);
            this.m_NumFilter.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.m_NumFilter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_NumFilter.Name = "m_NumFilter";
            this.m_NumFilter.Size = new System.Drawing.Size(120, 20);
            this.m_NumFilter.TabIndex = 4;
            this.m_NumFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_NumFilter.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 10);
            this.label9.Margin = new System.Windows.Forms.Padding(10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Contrast Threshold";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 43);
            this.label10.Margin = new System.Windows.Forms.Padding(10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Filter Half Size Pixels";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 76);
            this.label11.Margin = new System.Windows.Forms.Padding(10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Maximum Results";
            // 
            // m_NumContrastThreshold
            // 
            this.m_NumContrastThreshold.DecimalPlaces = 1;
            this.m_NumContrastThreshold.Location = new System.Drawing.Point(193, 3);
            this.m_NumContrastThreshold.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.m_NumContrastThreshold.Name = "m_NumContrastThreshold";
            this.m_NumContrastThreshold.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_NumContrastThreshold.Size = new System.Drawing.Size(120, 20);
            this.m_NumContrastThreshold.TabIndex = 3;
            this.m_NumContrastThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_NumContrastThreshold.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // m_gbEdgeMode
            // 
            this.m_gbEdgeMode.Controls.Add(this.tableLayoutPanel3);
            this.m_gbEdgeMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_gbEdgeMode.Location = new System.Drawing.Point(0, 0);
            this.m_gbEdgeMode.Name = "m_gbEdgeMode";
            this.m_gbEdgeMode.Size = new System.Drawing.Size(380, 187);
            this.m_gbEdgeMode.TabIndex = 0;
            this.m_gbEdgeMode.TabStop = false;
            this.m_gbEdgeMode.Text = "Edge Mode";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.m_radioSingle, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.m_radioPair, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.m_gbEdge1Polarity, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.m_NumEdgePairWidth, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(374, 168);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // m_radioSingle
            // 
            this.m_radioSingle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_radioSingle.AutoSize = true;
            this.m_radioSingle.Checked = true;
            this.m_radioSingle.Location = new System.Drawing.Point(102, 3);
            this.m_radioSingle.Name = "m_radioSingle";
            this.m_radioSingle.Size = new System.Drawing.Size(82, 24);
            this.m_radioSingle.TabIndex = 0;
            this.m_radioSingle.TabStop = true;
            this.m_radioSingle.Text = "Single Edge";
            this.m_radioSingle.UseVisualStyleBackColor = true;
            // 
            // m_radioPair
            // 
            this.m_radioPair.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.m_radioPair.AutoSize = true;
            this.m_radioPair.Location = new System.Drawing.Point(190, 3);
            this.m_radioPair.Name = "m_radioPair";
            this.m_radioPair.Size = new System.Drawing.Size(71, 24);
            this.m_radioPair.TabIndex = 1;
            this.m_radioPair.Text = "Edge Pair";
            this.m_radioPair.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_Any0);
            this.groupBox3.Controls.Add(this.m_LD0);
            this.groupBox3.Controls.Add(this.m_DL0);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 33);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(181, 99);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Edge 0 Polarity";
            // 
            // m_Any0
            // 
            this.m_Any0.AutoSize = true;
            this.m_Any0.Checked = true;
            this.m_Any0.Location = new System.Drawing.Point(10, 68);
            this.m_Any0.Name = "m_Any0";
            this.m_Any0.Size = new System.Drawing.Size(80, 17);
            this.m_Any0.TabIndex = 2;
            this.m_Any0.TabStop = true;
            this.m_Any0.Text = "Any Polarity";
            this.m_Any0.UseVisualStyleBackColor = true;
            // 
            // m_LD0
            // 
            this.m_LD0.AutoSize = true;
            this.m_LD0.Location = new System.Drawing.Point(10, 44);
            this.m_LD0.Name = "m_LD0";
            this.m_LD0.Size = new System.Drawing.Size(86, 17);
            this.m_LD0.TabIndex = 1;
            this.m_LD0.Text = "Light to Dark";
            this.m_LD0.UseVisualStyleBackColor = true;
            // 
            // m_DL0
            // 
            this.m_DL0.AutoSize = true;
            this.m_DL0.Location = new System.Drawing.Point(10, 20);
            this.m_DL0.Name = "m_DL0";
            this.m_DL0.Size = new System.Drawing.Size(86, 17);
            this.m_DL0.TabIndex = 0;
            this.m_DL0.Text = "Dark to Light";
            this.m_DL0.UseVisualStyleBackColor = true;
            // 
            // m_gbEdge1Polarity
            // 
            this.m_gbEdge1Polarity.Controls.Add(this.m_Any1);
            this.m_gbEdge1Polarity.Controls.Add(this.m_LD1);
            this.m_gbEdge1Polarity.Controls.Add(this.m_DL1);
            this.m_gbEdge1Polarity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_gbEdge1Polarity.Enabled = false;
            this.m_gbEdge1Polarity.Location = new System.Drawing.Point(190, 33);
            this.m_gbEdge1Polarity.Name = "m_gbEdge1Polarity";
            this.m_gbEdge1Polarity.Size = new System.Drawing.Size(181, 99);
            this.m_gbEdge1Polarity.TabIndex = 3;
            this.m_gbEdge1Polarity.TabStop = false;
            this.m_gbEdge1Polarity.Text = "Edge 1 Polarity";
            // 
            // m_Any1
            // 
            this.m_Any1.AutoSize = true;
            this.m_Any1.Checked = true;
            this.m_Any1.Location = new System.Drawing.Point(7, 68);
            this.m_Any1.Name = "m_Any1";
            this.m_Any1.Size = new System.Drawing.Size(80, 17);
            this.m_Any1.TabIndex = 2;
            this.m_Any1.TabStop = true;
            this.m_Any1.Text = "Any Polarity";
            this.m_Any1.UseVisualStyleBackColor = true;
            // 
            // m_LD1
            // 
            this.m_LD1.AutoSize = true;
            this.m_LD1.Location = new System.Drawing.Point(7, 44);
            this.m_LD1.Name = "m_LD1";
            this.m_LD1.Size = new System.Drawing.Size(86, 17);
            this.m_LD1.TabIndex = 1;
            this.m_LD1.Text = "Light to Dark";
            this.m_LD1.UseVisualStyleBackColor = true;
            // 
            // m_DL1
            // 
            this.m_DL1.AutoSize = true;
            this.m_DL1.Location = new System.Drawing.Point(7, 20);
            this.m_DL1.Name = "m_DL1";
            this.m_DL1.Size = new System.Drawing.Size(86, 17);
            this.m_DL1.TabIndex = 0;
            this.m_DL1.Text = "Dark to Light";
            this.m_DL1.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 145);
            this.label12.Margin = new System.Windows.Forms.Padding(10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Edge Pair Width";
            // 
            // m_NumEdgePairWidth
            // 
            this.m_NumEdgePairWidth.Enabled = false;
            this.m_NumEdgePairWidth.Location = new System.Drawing.Point(190, 138);
            this.m_NumEdgePairWidth.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.m_NumEdgePairWidth.Name = "m_NumEdgePairWidth";
            this.m_NumEdgePairWidth.Size = new System.Drawing.Size(120, 20);
            this.m_NumEdgePairWidth.TabIndex = 5;
            this.m_NumEdgePairWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_NumEdgePairWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // m_CaliperOutput
            // 
            this.m_CaliperOutput.Controls.Add(this.m_CaliperRes);
            this.m_CaliperOutput.Location = new System.Drawing.Point(4, 22);
            this.m_CaliperOutput.Name = "m_CaliperOutput";
            this.m_CaliperOutput.Padding = new System.Windows.Forms.Padding(3);
            this.m_CaliperOutput.Size = new System.Drawing.Size(386, 361);
            this.m_CaliperOutput.TabIndex = 1;
            this.m_CaliperOutput.Text = "Output";
            this.m_CaliperOutput.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 350);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Segmentation";
            // 
            // m_tbSample
            // 
            this.m_tbSample.Enabled = false;
            this.m_tbSample.Location = new System.Drawing.Point(102, 248);
            this.m_tbSample.Name = "m_tbSample";
            this.m_tbSample.Size = new System.Drawing.Size(100, 20);
            this.m_tbSample.TabIndex = 15;
            // 
            // m_tbVariance
            // 
            this.m_tbVariance.Enabled = false;
            this.m_tbVariance.Location = new System.Drawing.Point(102, 213);
            this.m_tbVariance.Name = "m_tbVariance";
            this.m_tbVariance.Size = new System.Drawing.Size(100, 20);
            this.m_tbVariance.TabIndex = 14;
            // 
            // m_tbSD
            // 
            this.m_tbSD.Enabled = false;
            this.m_tbSD.Location = new System.Drawing.Point(102, 178);
            this.m_tbSD.Name = "m_tbSD";
            this.m_tbSD.Size = new System.Drawing.Size(100, 20);
            this.m_tbSD.TabIndex = 13;
            // 
            // m_tbMean
            // 
            this.m_tbMean.Enabled = false;
            this.m_tbMean.Location = new System.Drawing.Point(102, 143);
            this.m_tbMean.Name = "m_tbMean";
            this.m_tbMean.Size = new System.Drawing.Size(100, 20);
            this.m_tbMean.TabIndex = 12;
            // 
            // m_tbMode
            // 
            this.m_tbMode.Enabled = false;
            this.m_tbMode.Location = new System.Drawing.Point(102, 108);
            this.m_tbMode.Name = "m_tbMode";
            this.m_tbMode.Size = new System.Drawing.Size(100, 20);
            this.m_tbMode.TabIndex = 11;
            // 
            // m_tbMedian
            // 
            this.m_tbMedian.Enabled = false;
            this.m_tbMedian.Location = new System.Drawing.Point(102, 73);
            this.m_tbMedian.Name = "m_tbMedian";
            this.m_tbMedian.Size = new System.Drawing.Size(100, 20);
            this.m_tbMedian.TabIndex = 10;
            // 
            // m_tbMax
            // 
            this.m_tbMax.Enabled = false;
            this.m_tbMax.Location = new System.Drawing.Point(102, 38);
            this.m_tbMax.Name = "m_tbMax";
            this.m_tbMax.Size = new System.Drawing.Size(100, 20);
            this.m_tbMax.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Median";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 108);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mode";
            // 
            // m_HisOutTable
            // 
            this.m_HisOutTable.ColumnCount = 2;
            this.m_HisOutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.80749F));
            this.m_HisOutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.19251F));
            this.m_HisOutTable.Controls.Add(this.m_tbSample, 1, 7);
            this.m_HisOutTable.Controls.Add(this.m_tbVariance, 1, 6);
            this.m_HisOutTable.Controls.Add(this.m_tbSD, 1, 5);
            this.m_HisOutTable.Controls.Add(this.m_tbMean, 1, 4);
            this.m_HisOutTable.Controls.Add(this.m_tbMode, 1, 3);
            this.m_HisOutTable.Controls.Add(this.m_tbMedian, 1, 2);
            this.m_HisOutTable.Controls.Add(this.m_tbMax, 1, 1);
            this.m_HisOutTable.Controls.Add(this.label3, 0, 2);
            this.m_HisOutTable.Controls.Add(this.label4, 0, 3);
            this.m_HisOutTable.Controls.Add(this.label5, 0, 4);
            this.m_HisOutTable.Controls.Add(this.label6, 0, 5);
            this.m_HisOutTable.Controls.Add(this.label1, 0, 0);
            this.m_HisOutTable.Controls.Add(this.label2, 0, 1);
            this.m_HisOutTable.Controls.Add(this.label7, 0, 6);
            this.m_HisOutTable.Controls.Add(this.m_tbMin, 1, 0);
            this.m_HisOutTable.Controls.Add(this.label8, 0, 7);
            this.m_HisOutTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_HisOutTable.Location = new System.Drawing.Point(3, 16);
            this.m_HisOutTable.Name = "m_HisOutTable";
            this.m_HisOutTable.RowCount = 8;
            this.m_HisOutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.m_HisOutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.m_HisOutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.m_HisOutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.m_HisOutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.m_HisOutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.m_HisOutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.m_HisOutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.m_HisOutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.m_HisOutTable.Size = new System.Drawing.Size(357, 286);
            this.m_HisOutTable.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 143);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mean";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 178);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Std. Dev.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Minimum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Maximum";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 213);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Variance";
            // 
            // m_tbMin
            // 
            this.m_tbMin.Enabled = false;
            this.m_tbMin.Location = new System.Drawing.Point(102, 3);
            this.m_tbMin.Name = "m_tbMin";
            this.m_tbMin.Size = new System.Drawing.Size(100, 20);
            this.m_tbMin.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 248);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.MaximumSize = new System.Drawing.Size(100, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Samples";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_HisOutTable);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 305);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Statictics";
            // 
            // m_dgvHisData
            // 
            this.m_dgvHisData.AllowUserToAddRows = false;
            this.m_dgvHisData.AllowUserToDeleteRows = false;
            this.m_dgvHisData.AllowUserToResizeColumns = false;
            this.m_dgvHisData.BackgroundColor = System.Drawing.SystemColors.Control;
            this.m_dgvHisData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvHisData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvHisData.Location = new System.Drawing.Point(3, 16);
            this.m_dgvHisData.MinimumSize = new System.Drawing.Size(0, 500);
            this.m_dgvHisData.Name = "m_dgvHisData";
            this.m_dgvHisData.ReadOnly = true;
            this.m_dgvHisData.RowHeadersVisible = false;
            this.m_dgvHisData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvHisData.Size = new System.Drawing.Size(303, 500);
            this.m_dgvHisData.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.AutoSize = true;
            this.groupBox6.Controls.Add(this.m_dgvHisData);
            this.groupBox6.Location = new System.Drawing.Point(6, 311);
            this.groupBox6.MinimumSize = new System.Drawing.Size(0, 500);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(309, 500);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Data";
            // 
            // m_HistogramInput
            // 
            this.m_HistogramInput.AutoScroll = true;
            this.m_HistogramInput.Location = new System.Drawing.Point(4, 22);
            this.m_HistogramInput.Name = "m_HistogramInput";
            this.m_HistogramInput.Padding = new System.Windows.Forms.Padding(3);
            this.m_HistogramInput.Size = new System.Drawing.Size(386, 361);
            this.m_HistogramInput.TabIndex = 0;
            this.m_HistogramInput.Text = "Input";
            this.m_HistogramInput.UseVisualStyleBackColor = true;
            // 
            // m_HistogramOutput
            // 
            this.m_HistogramOutput.AutoScroll = true;
            this.m_HistogramOutput.Controls.Add(this.groupBox6);
            this.m_HistogramOutput.Controls.Add(this.groupBox2);
            this.m_HistogramOutput.Location = new System.Drawing.Point(4, 22);
            this.m_HistogramOutput.Name = "m_HistogramOutput";
            this.m_HistogramOutput.Padding = new System.Windows.Forms.Padding(3);
            this.m_HistogramOutput.Size = new System.Drawing.Size(386, 361);
            this.m_HistogramOutput.TabIndex = 1;
            this.m_HistogramOutput.Text = "Output";
            this.m_HistogramOutput.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.m_HistogramInput);
            this.tabControl2.Controls.Add(this.m_HistogramOutput);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(394, 387);
            this.tabControl2.TabIndex = 0;
            // 
            // m_HistogramTab
            // 
            this.m_HistogramTab.AutoScroll = true;
            this.m_HistogramTab.Controls.Add(this.tabControl2);
            this.m_HistogramTab.Location = new System.Drawing.Point(4, 4);
            this.m_HistogramTab.Name = "m_HistogramTab";
            this.m_HistogramTab.Padding = new System.Windows.Forms.Padding(3);
            this.m_HistogramTab.Size = new System.Drawing.Size(400, 393);
            this.m_HistogramTab.TabIndex = 0;
            this.m_HistogramTab.Text = "Histogram";
            this.m_HistogramTab.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.m_HistogramTab);
            this.tabControl1.Controls.Add(this.m_BlobTab);
            this.tabControl1.Controls.Add(this.m_CaliperTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(408, 419);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // m_BlobTab
            // 
            this.m_BlobTab.Controls.Add(this.tabControl3);
            this.m_BlobTab.Location = new System.Drawing.Point(4, 4);
            this.m_BlobTab.Name = "m_BlobTab";
            this.m_BlobTab.Padding = new System.Windows.Forms.Padding(3);
            this.m_BlobTab.Size = new System.Drawing.Size(400, 393);
            this.m_BlobTab.TabIndex = 1;
            this.m_BlobTab.Text = "Blob";
            this.m_BlobTab.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.m_BlobInput);
            this.tabControl3.Controls.Add(this.m_BlobMeasurement);
            this.tabControl3.Controls.Add(this.m_BlobOutput);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(3, 3);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(394, 387);
            this.tabControl3.TabIndex = 1;
            // 
            // m_BlobInput
            // 
            this.m_BlobInput.AutoScroll = true;
            this.m_BlobInput.Controls.Add(this.tableLayoutPanel4);
            this.m_BlobInput.Location = new System.Drawing.Point(4, 22);
            this.m_BlobInput.Name = "m_BlobInput";
            this.m_BlobInput.Padding = new System.Windows.Forms.Padding(3);
            this.m_BlobInput.Size = new System.Drawing.Size(386, 361);
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
            this.tableLayoutPanel4.Size = new System.Drawing.Size(380, 350);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.groupBox5, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(193, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(184, 344);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.flowLayoutPanel4);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(184, 150);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Connectivity";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.AutoSize = true;
            this.flowLayoutPanel4.Controls.Add(this.label16);
            this.flowLayoutPanel4.Controls.Add(this.m_cbConnectMode);
            this.flowLayoutPanel4.Controls.Add(this.label17);
            this.flowLayoutPanel4.Controls.Add(this.m_cbConnectClean);
            this.flowLayoutPanel4.Controls.Add(this.label18);
            this.flowLayoutPanel4.Controls.Add(this.m_NumConnectionMin);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(178, 131);
            this.flowLayoutPanel4.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Top;
            this.label16.Location = new System.Drawing.Point(5, 5);
            this.label16.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Mode:";
            // 
            // m_cbConnectMode
            // 
            this.m_cbConnectMode.CausesValidation = false;
            this.m_cbConnectMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_cbConnectMode.FormattingEnabled = true;
            this.m_cbConnectMode.Items.AddRange(new object[] {
            "Grey Scale",
            "Labeled",
            "Whole Image"});
            this.m_cbConnectMode.Location = new System.Drawing.Point(3, 21);
            this.m_cbConnectMode.Name = "m_cbConnectMode";
            this.m_cbConnectMode.Size = new System.Drawing.Size(166, 21);
            this.m_cbConnectMode.TabIndex = 2;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Top;
            this.label17.Location = new System.Drawing.Point(5, 50);
            this.label17.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "Cleanup:";
            // 
            // m_cbConnectClean
            // 
            this.m_cbConnectClean.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_cbConnectClean.FormattingEnabled = true;
            this.m_cbConnectClean.Items.AddRange(new object[] {
            "None",
            "Prune",
            "Fill"});
            this.m_cbConnectClean.Location = new System.Drawing.Point(3, 66);
            this.m_cbConnectClean.Name = "m_cbConnectClean";
            this.m_cbConnectClean.Size = new System.Drawing.Size(166, 21);
            this.m_cbConnectClean.TabIndex = 4;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Left;
            this.label18.Location = new System.Drawing.Point(5, 95);
            this.label18.Margin = new System.Windows.Forms.Padding(5);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 13);
            this.label18.TabIndex = 6;
            this.label18.Text = "Min Area:";
            // 
            // m_NumConnectionMin
            // 
            this.m_NumConnectionMin.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_NumConnectionMin.Location = new System.Drawing.Point(65, 93);
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
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.m_dgvBlobOperation);
            this.groupBox5.Controls.Add(this.flowLayoutPanel5);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 153);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(178, 188);
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
            this.m_dgvBlobOperation.Size = new System.Drawing.Size(172, 139);
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
            this.flowLayoutPanel5.Size = new System.Drawing.Size(172, 30);
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
            // 
            // m_BtnDeleteOperation
            // 
            this.m_BtnDeleteOperation.Location = new System.Drawing.Point(30, 3);
            this.m_BtnDeleteOperation.Name = "m_BtnDeleteOperation";
            this.m_BtnDeleteOperation.Size = new System.Drawing.Size(21, 21);
            this.m_BtnDeleteOperation.TabIndex = 1;
            this.m_BtnDeleteOperation.Text = "X";
            this.m_BtnDeleteOperation.UseVisualStyleBackColor = true;
            // 
            // m_RunBtn
            // 
            this.m_RunBtn.Location = new System.Drawing.Point(3, 3);
            this.m_RunBtn.Name = "m_RunBtn";
            this.m_RunBtn.Size = new System.Drawing.Size(75, 23);
            this.m_RunBtn.TabIndex = 0;
            this.m_RunBtn.Text = "Run";
            this.m_RunBtn.UseVisualStyleBackColor = true;
            this.m_RunBtn.Click += new System.EventHandler(this.m_RunBtn_Click);
            // 
            // m_OpenBtn
            // 
            this.m_OpenBtn.Location = new System.Drawing.Point(84, 3);
            this.m_OpenBtn.Name = "m_OpenBtn";
            this.m_OpenBtn.Size = new System.Drawing.Size(75, 23);
            this.m_OpenBtn.TabIndex = 1;
            this.m_OpenBtn.Text = "Open";
            this.m_OpenBtn.UseVisualStyleBackColor = true;
            this.m_OpenBtn.Click += new System.EventHandler(this.m_OpenBtn_Click);
            // 
            // m_RunToolBtn
            // 
            this.m_RunToolBtn.Location = new System.Drawing.Point(165, 3);
            this.m_RunToolBtn.Name = "m_RunToolBtn";
            this.m_RunToolBtn.Size = new System.Drawing.Size(75, 23);
            this.m_RunToolBtn.TabIndex = 2;
            this.m_RunToolBtn.Text = "Run Tool";
            this.m_RunToolBtn.UseVisualStyleBackColor = true;
            this.m_RunToolBtn.Click += new System.EventHandler(this.m_RunToolBtn_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.m_RunBtn);
            this.flowLayoutPanel1.Controls.Add(this.m_OpenBtn);
            this.flowLayoutPanel1.Controls.Add(this.m_RunToolBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(414, 25);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(414, 450);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // m_cbImages
            // 
            this.m_cbImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_cbImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbImages.FormattingEnabled = true;
            this.m_cbImages.Location = new System.Drawing.Point(3, 3);
            this.m_cbImages.Name = "m_cbImages";
            this.m_cbImages.Size = new System.Drawing.Size(380, 21);
            this.m_cbImages.TabIndex = 5;
            this.m_cbImages.SelectedIndexChanged += new System.EventHandler(this.m_cbImages_SelectedIndexChanged);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.m_cbImages, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(414, 0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(386, 450);
            this.tableLayoutPanel8.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.Navy;
            this.panel2.Controls.Add(this.m_display);
            this.panel2.Location = new System.Drawing.Point(3, 28);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(50);
            this.panel2.Size = new System.Drawing.Size(380, 419);
            this.panel2.TabIndex = 6;
            this.panel2.Resize += new System.EventHandler(this.panel2_Resize);
            // 
            // m_display
            // 
            this.m_display.BackColor = System.Drawing.Color.Transparent;
            this.m_display.Location = new System.Drawing.Point(21, 94);
            this.m_display.Margin = new System.Windows.Forms.Padding(50);
            this.m_display.Name = "m_display";
            this.m_display.Size = new System.Drawing.Size(341, 270);
            this.m_display.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_display.TabIndex = 0;
            this.m_display.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel8);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.m_BlobMeasurementTable)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvBlobResults)).EndInit();
            this.m_BlobMeasurement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_NumSegmentation1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumSegmentation2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumSegmentation5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumSegmentation4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_CaliperRes)).EndInit();
            this.m_BlobOutput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_NumSegmentation3)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.m_CaliperTab.ResumeLayout(false);
            this.tabControl4.ResumeLayout(false);
            this.m_CaliperInput.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumContrastThreshold)).EndInit();
            this.m_gbEdgeMode.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.m_gbEdge1Polarity.ResumeLayout(false);
            this.m_gbEdge1Polarity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumEdgePairWidth)).EndInit();
            this.m_CaliperOutput.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.m_HisOutTable.ResumeLayout(false);
            this.m_HisOutTable.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvHisData)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.m_HistogramOutput.ResumeLayout(false);
            this.m_HistogramOutput.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.m_HistogramTab.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.m_BlobTab.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.m_BlobInput.ResumeLayout(false);
            this.m_BlobInput.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumConnectionMin)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvBlobOperation)).EndInit();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_display)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_BlobHigh;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_BlobLow;
        private System.Windows.Forms.DataGridViewComboBoxColumn m_BlobRange;
        private System.Windows.Forms.DataGridViewComboBoxColumn m_BlobMeasureFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_BlobProperties;
        private System.Windows.Forms.DataGridView m_BlobMeasurementTable;
        private System.Windows.Forms.ComboBox m_cbBlobProperties;
        private System.Windows.Forms.Button m_btnDeleteProperties;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.DataGridView m_dgvBlobResults;
        private System.Windows.Forms.TabPage m_BlobMeasurement;
        private System.Windows.Forms.Label m_labelSeg1;
        private System.Windows.Forms.NumericUpDown m_NumSegmentation1;
        private System.Windows.Forms.Label m_labelSeg2;
        private System.Windows.Forms.NumericUpDown m_NumSegmentation2;
        private System.Windows.Forms.Label m_labelSeg3;
        private System.Windows.Forms.NumericUpDown m_NumSegmentation5;
        private System.Windows.Forms.Label m_labelSeg5;
        private System.Windows.Forms.NumericUpDown m_NumSegmentation4;
        private System.Windows.Forms.Label m_labelSeg4;
        private System.Windows.Forms.DataGridView m_CaliperRes;
        private System.Windows.Forms.TabPage m_BlobOutput;
        private System.Windows.Forms.NumericUpDown m_NumSegmentation3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.ComboBox m_cbSegMode;
        private System.Windows.Forms.GroupBox m_SegMap;
        private System.Windows.Forms.Label m_labelPolarity;
        private System.Windows.Forms.ComboBox m_cbSegPolarity;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TabPage m_CaliperTab;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage m_CaliperInput;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown m_NumResult;
        private System.Windows.Forms.NumericUpDown m_NumFilter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown m_NumContrastThreshold;
        private System.Windows.Forms.GroupBox m_gbEdgeMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.RadioButton m_radioSingle;
        private System.Windows.Forms.RadioButton m_radioPair;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton m_Any0;
        private System.Windows.Forms.RadioButton m_LD0;
        private System.Windows.Forms.RadioButton m_DL0;
        private System.Windows.Forms.GroupBox m_gbEdge1Polarity;
        private System.Windows.Forms.RadioButton m_Any1;
        private System.Windows.Forms.RadioButton m_LD1;
        private System.Windows.Forms.RadioButton m_DL1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown m_NumEdgePairWidth;
        private System.Windows.Forms.TabPage m_CaliperOutput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox m_tbSample;
        private System.Windows.Forms.TextBox m_tbVariance;
        private System.Windows.Forms.TextBox m_tbSD;
        private System.Windows.Forms.TextBox m_tbMean;
        private System.Windows.Forms.TextBox m_tbMode;
        private System.Windows.Forms.TextBox m_tbMedian;
        private System.Windows.Forms.TextBox m_tbMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel m_HisOutTable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox m_tbMin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView m_dgvHisData;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TabPage m_HistogramInput;
        private System.Windows.Forms.TabPage m_HistogramOutput;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage m_HistogramTab;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage m_BlobTab;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage m_BlobInput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
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
        private System.Windows.Forms.Button m_RunBtn;
        private System.Windows.Forms.Button m_OpenBtn;
        private System.Windows.Forms.Button m_RunToolBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox m_cbImages;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.PictureBox m_display;
    }
}

