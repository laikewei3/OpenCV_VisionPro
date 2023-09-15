namespace OpenCV___Vision_Pro
{
    partial class CaliperToolControl
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
            this.m_CaliperRes = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.m_CaliperRes)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.m_CaliperInput);
            this.tabControl4.Controls.Add(this.m_CaliperOutput);
            this.tabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl4.Location = new System.Drawing.Point(0, 0);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(492, 495);
            this.tabControl4.TabIndex = 2;
            // 
            // m_CaliperInput
            // 
            this.m_CaliperInput.AutoScroll = true;
            this.m_CaliperInput.Controls.Add(this.panel1);
            this.m_CaliperInput.Location = new System.Drawing.Point(4, 22);
            this.m_CaliperInput.Name = "m_CaliperInput";
            this.m_CaliperInput.Padding = new System.Windows.Forms.Padding(3);
            this.m_CaliperInput.Size = new System.Drawing.Size(484, 469);
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
            this.panel1.Size = new System.Drawing.Size(478, 290);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(478, 100);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // m_NumResult
            // 
            this.m_NumResult.Location = new System.Drawing.Point(242, 69);
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
            this.m_NumFilter.Location = new System.Drawing.Point(242, 36);
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
            this.m_NumContrastThreshold.Location = new System.Drawing.Point(242, 3);
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
            this.m_gbEdgeMode.Size = new System.Drawing.Size(478, 187);
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(472, 168);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // m_radioSingle
            // 
            this.m_radioSingle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_radioSingle.AutoSize = true;
            this.m_radioSingle.Checked = true;
            this.m_radioSingle.Location = new System.Drawing.Point(151, 3);
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
            this.m_radioPair.Location = new System.Drawing.Point(239, 3);
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
            this.groupBox3.Size = new System.Drawing.Size(230, 99);
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
            this.m_gbEdge1Polarity.Location = new System.Drawing.Point(239, 33);
            this.m_gbEdge1Polarity.Name = "m_gbEdge1Polarity";
            this.m_gbEdge1Polarity.Size = new System.Drawing.Size(230, 99);
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
            this.m_NumEdgePairWidth.Location = new System.Drawing.Point(239, 138);
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
            this.m_CaliperOutput.Size = new System.Drawing.Size(643, 530);
            this.m_CaliperOutput.TabIndex = 1;
            this.m_CaliperOutput.Text = "Output";
            this.m_CaliperOutput.UseVisualStyleBackColor = true;
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
            this.m_CaliperRes.Size = new System.Drawing.Size(637, 524);
            this.m_CaliperRes.TabIndex = 0;
            // 
            // CaliperToolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tabControl4);
            this.Name = "CaliperToolControl";
            this.Size = new System.Drawing.Size(492, 495);
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
            ((System.ComponentModel.ISupportInitialize)(this.m_CaliperRes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.DataGridView m_CaliperRes;
    }
}
