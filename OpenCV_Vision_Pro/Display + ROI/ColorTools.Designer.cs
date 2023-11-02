namespace OpenCV_Vision_Pro
{
    partial class ColorTools
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
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.m_btnSelectColor = new System.Windows.Forms.Button();
            this.m_btnDeleteProperties = new System.Windows.Forms.Button();
            this.m_ColorTable = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_currentSelectedTable = new System.Windows.Forms.TableLayoutPanel();
            this.m_colorSample = new System.Windows.Forms.Panel();
            this.m_nudBlue = new System.Windows.Forms.NumericUpDown();
            this.m_nudGreen = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.labelSpace = new System.Windows.Forms.Label();
            this.labelR = new System.Windows.Forms.Label();
            this.labelG = new System.Windows.Forms.Label();
            this.labelB = new System.Windows.Forms.Label();
            this.m_nudRed = new System.Windows.Forms.NumericUpDown();
            this.m_cbColorSpace = new System.Windows.Forms.ComboBox();
            this.m_strColorName = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.m_btnAddColor = new System.Windows.Forms.Button();
            this.m_btnCancelAdd = new System.Windows.Forms.Button();
            this.m_selectColorMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_ColorTable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.m_currentSelectedTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRed)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.m_selectColorMenuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.flowLayoutPanel3, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.m_ColorTable, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(440, 550);
            this.tableLayoutPanel6.TabIndex = 5;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.m_btnSelectColor);
            this.flowLayoutPanel3.Controls.Add(this.m_btnDeleteProperties);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(440, 30);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // m_btnSelectColor
            // 
            this.m_btnSelectColor.Location = new System.Drawing.Point(3, 3);
            this.m_btnSelectColor.Name = "m_btnSelectColor";
            this.m_btnSelectColor.Size = new System.Drawing.Size(21, 21);
            this.m_btnSelectColor.TabIndex = 2;
            this.m_btnSelectColor.Text = "+";
            this.m_btnSelectColor.UseVisualStyleBackColor = true;
            this.m_btnSelectColor.Click += new System.EventHandler(this.m_btnSelectColor_Click);
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
            // m_ColorTable
            // 
            this.m_ColorTable.AllowUserToAddRows = false;
            this.m_ColorTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ColorTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.m_ColorTable.Location = new System.Drawing.Point(3, 33);
            this.m_ColorTable.MultiSelect = false;
            this.m_ColorTable.Name = "m_ColorTable";
            this.m_ColorTable.RowHeadersVisible = false;
            this.m_ColorTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_ColorTable.Size = new System.Drawing.Size(434, 254);
            this.m_ColorTable.TabIndex = 2;
            this.m_ColorTable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.m_ColorTable_CellFormatting);
            this.m_ColorTable.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.m_ColorTable_ColumnAdded);
            this.m_ColorTable.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_ColorTable_RowsAdded);
            this.m_ColorTable.SelectionChanged += new System.EventHandler(this.m_ColorTable_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 293);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 254);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Selected Color";
            // 
            // m_currentSelectedTable
            // 
            this.m_currentSelectedTable.AutoSize = true;
            this.m_currentSelectedTable.ColumnCount = 2;
            this.m_currentSelectedTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_currentSelectedTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_currentSelectedTable.Controls.Add(this.m_nudBlue, 1, 4);
            this.m_currentSelectedTable.Controls.Add(this.m_nudGreen, 1, 3);
            this.m_currentSelectedTable.Controls.Add(this.label1, 0, 0);
            this.m_currentSelectedTable.Controls.Add(this.labelSpace, 0, 1);
            this.m_currentSelectedTable.Controls.Add(this.labelR, 0, 2);
            this.m_currentSelectedTable.Controls.Add(this.labelG, 0, 3);
            this.m_currentSelectedTable.Controls.Add(this.labelB, 0, 4);
            this.m_currentSelectedTable.Controls.Add(this.m_nudRed, 1, 2);
            this.m_currentSelectedTable.Controls.Add(this.m_cbColorSpace, 1, 1);
            this.m_currentSelectedTable.Controls.Add(this.m_strColorName, 1, 0);
            this.m_currentSelectedTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_currentSelectedTable.Location = new System.Drawing.Point(3, 3);
            this.m_currentSelectedTable.Name = "m_currentSelectedTable";
            this.m_currentSelectedTable.RowCount = 5;
            this.m_currentSelectedTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_currentSelectedTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_currentSelectedTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_currentSelectedTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_currentSelectedTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_currentSelectedTable.Size = new System.Drawing.Size(422, 135);
            this.m_currentSelectedTable.TabIndex = 0;
            // 
            // m_colorSample
            // 
            this.m_colorSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_colorSample.Location = new System.Drawing.Point(3, 3);
            this.m_colorSample.Name = "m_colorSample";
            this.m_colorSample.Size = new System.Drawing.Size(43, 43);
            this.m_colorSample.TabIndex = 1;
            // 
            // m_nudBlue
            // 
            this.m_nudBlue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_nudBlue.Location = new System.Drawing.Point(47, 110);
            this.m_nudBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudBlue.MaximumSize = new System.Drawing.Size(100, 0);
            this.m_nudBlue.Name = "m_nudBlue";
            this.m_nudBlue.Size = new System.Drawing.Size(100, 20);
            this.m_nudBlue.TabIndex = 9;
            this.m_nudBlue.ValueChanged += new System.EventHandler(this.m_nud_ValueChanged);
            // 
            // m_nudGreen
            // 
            this.m_nudGreen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_nudGreen.Location = new System.Drawing.Point(47, 83);
            this.m_nudGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudGreen.MaximumSize = new System.Drawing.Size(100, 0);
            this.m_nudGreen.Name = "m_nudGreen";
            this.m_nudGreen.Size = new System.Drawing.Size(100, 20);
            this.m_nudGreen.TabIndex = 8;
            this.m_nudGreen.ValueChanged += new System.EventHandler(this.m_nud_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // labelSpace
            // 
            this.labelSpace.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSpace.AutoSize = true;
            this.labelSpace.Location = new System.Drawing.Point(3, 34);
            this.labelSpace.Name = "labelSpace";
            this.labelSpace.Size = new System.Drawing.Size(38, 13);
            this.labelSpace.TabIndex = 1;
            this.labelSpace.Text = "Space";
            // 
            // labelR
            // 
            this.labelR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelR.AutoSize = true;
            this.labelR.Location = new System.Drawing.Point(3, 60);
            this.labelR.Name = "labelR";
            this.labelR.Size = new System.Drawing.Size(15, 13);
            this.labelR.TabIndex = 2;
            this.labelR.Text = "R";
            // 
            // labelG
            // 
            this.labelG.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelG.AutoSize = true;
            this.labelG.Location = new System.Drawing.Point(3, 86);
            this.labelG.Name = "labelG";
            this.labelG.Size = new System.Drawing.Size(15, 13);
            this.labelG.TabIndex = 3;
            this.labelG.Text = "G";
            // 
            // labelB
            // 
            this.labelB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelB.AutoSize = true;
            this.labelB.Location = new System.Drawing.Point(3, 114);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(14, 13);
            this.labelB.TabIndex = 4;
            this.labelB.Text = "B";
            // 
            // m_nudRed
            // 
            this.m_nudRed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_nudRed.Location = new System.Drawing.Point(47, 57);
            this.m_nudRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudRed.MaximumSize = new System.Drawing.Size(100, 0);
            this.m_nudRed.Name = "m_nudRed";
            this.m_nudRed.Size = new System.Drawing.Size(100, 20);
            this.m_nudRed.TabIndex = 7;
            this.m_nudRed.ValueChanged += new System.EventHandler(this.m_nud_ValueChanged);
            // 
            // m_cbColorSpace
            // 
            this.m_cbColorSpace.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_cbColorSpace.FormattingEnabled = true;
            this.m_cbColorSpace.Items.AddRange(new object[] {
            "RGB"});
            this.m_cbColorSpace.Location = new System.Drawing.Point(47, 30);
            this.m_cbColorSpace.MaximumSize = new System.Drawing.Size(100, 0);
            this.m_cbColorSpace.Name = "m_cbColorSpace";
            this.m_cbColorSpace.Size = new System.Drawing.Size(100, 21);
            this.m_cbColorSpace.TabIndex = 10;
            this.m_cbColorSpace.Text = "RGB";
            // 
            // m_strColorName
            // 
            this.m_strColorName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_strColorName.Location = new System.Drawing.Point(47, 3);
            this.m_strColorName.MaximumSize = new System.Drawing.Size(100, 0);
            this.m_strColorName.MinimumSize = new System.Drawing.Size(0, 21);
            this.m_strColorName.Name = "m_strColorName";
            this.m_strColorName.Size = new System.Drawing.Size(100, 21);
            this.m_strColorName.TabIndex = 5;
            this.m_strColorName.TextChanged += new System.EventHandler(this.m_strColorName_TextChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.m_colorSample);
            this.flowLayoutPanel1.Controls.Add(this.m_btnAddColor);
            this.flowLayoutPanel1.Controls.Add(this.m_btnCancelAdd);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 144);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(422, 88);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // m_btnAddColor
            // 
            this.m_btnAddColor.Location = new System.Drawing.Point(52, 3);
            this.m_btnAddColor.Name = "m_btnAddColor";
            this.m_btnAddColor.Size = new System.Drawing.Size(75, 23);
            this.m_btnAddColor.TabIndex = 11;
            this.m_btnAddColor.Text = "Confirm Add";
            this.m_btnAddColor.UseVisualStyleBackColor = true;
            this.m_btnAddColor.Click += new System.EventHandler(this.m_btnAddColor_Click);
            // 
            // m_btnCancelAdd
            // 
            this.m_btnCancelAdd.Location = new System.Drawing.Point(133, 3);
            this.m_btnCancelAdd.Name = "m_btnCancelAdd";
            this.m_btnCancelAdd.Size = new System.Drawing.Size(75, 23);
            this.m_btnCancelAdd.TabIndex = 12;
            this.m_btnCancelAdd.Text = "Cancel";
            this.m_btnCancelAdd.UseVisualStyleBackColor = true;
            this.m_btnCancelAdd.Click += new System.EventHandler(this.m_btnCancelAdd_Click);
            // 
            // m_selectColorMenuStrip
            // 
            this.m_selectColorMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPointToolStripMenuItem,
            this.addRegionToolStripMenuItem});
            this.m_selectColorMenuStrip.Name = "contextMenuStrip1";
            this.m_selectColorMenuStrip.Size = new System.Drawing.Size(137, 48);
            // 
            // addPointToolStripMenuItem
            // 
            this.addPointToolStripMenuItem.Name = "addPointToolStripMenuItem";
            this.addPointToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.addPointToolStripMenuItem.Text = "Add Point";
            this.addPointToolStripMenuItem.Click += new System.EventHandler(this.addPointToolStripMenuItem_Click);
            // 
            // addRegionToolStripMenuItem
            // 
            this.addRegionToolStripMenuItem.Name = "addRegionToolStripMenuItem";
            this.addRegionToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.addRegionToolStripMenuItem.Text = "Add Region";
            this.addRegionToolStripMenuItem.Click += new System.EventHandler(this.addRegionToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.m_currentSelectedTable, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(428, 235);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // ColorTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel6);
            this.Name = "ColorTools";
            this.Size = new System.Drawing.Size(440, 550);
            this.Load += new System.EventHandler(this.ColorTools_Load);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_ColorTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.m_currentSelectedTable.ResumeLayout(false);
            this.m_currentSelectedTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRed)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.m_selectColorMenuStrip.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button m_btnDeleteProperties;
        private System.Windows.Forms.DataGridView m_ColorTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel m_currentSelectedTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel m_colorSample;
        private System.Windows.Forms.TextBox m_strColorName;
        private System.Windows.Forms.ContextMenuStrip m_selectColorMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addPointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRegionToolStripMenuItem;
        private System.Windows.Forms.Button m_btnSelectColor;
        private System.Windows.Forms.Button m_btnAddColor;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button m_btnCancelAdd;
        public System.Windows.Forms.NumericUpDown m_nudBlue;
        public System.Windows.Forms.NumericUpDown m_nudGreen;
        public System.Windows.Forms.NumericUpDown m_nudRed;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Label labelB;
        public System.Windows.Forms.Label labelG;
        public System.Windows.Forms.Label labelSpace;
        public System.Windows.Forms.Label labelR;
        public System.Windows.Forms.ComboBox m_cbColorSpace;
    }
}
