namespace OpenCV_Vision_Pro.LineSegment
{
    partial class LineSegmentToolControl
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
            this.m_LineSegmentInput = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.m_minSlope = new System.Windows.Forms.NumericUpDown();
            this.m_maxLineGap = new System.Windows.Forms.NumericUpDown();
            this.m_minLineLength = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_NumContrastThreshold = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.m_NumResult = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_maxSlope = new System.Windows.Forms.NumericUpDown();
            this.m_LineSegmentOutput = new System.Windows.Forms.TabPage();
            this.m_LineSegmentRes = new System.Windows.Forms.DataGridView();
            this.tabControl4.SuspendLayout();
            this.m_LineSegmentInput.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_minSlope)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_maxLineGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_minLineLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumContrastThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_maxSlope)).BeginInit();
            this.m_LineSegmentOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_LineSegmentRes)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.m_LineSegmentInput);
            this.tabControl4.Controls.Add(this.m_LineSegmentOutput);
            this.tabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl4.Location = new System.Drawing.Point(0, 0);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(263, 495);
            this.tabControl4.TabIndex = 2;
            // 
            // m_LineSegmentInput
            // 
            this.m_LineSegmentInput.AutoScroll = true;
            this.m_LineSegmentInput.Controls.Add(this.panel1);
            this.m_LineSegmentInput.Location = new System.Drawing.Point(4, 22);
            this.m_LineSegmentInput.Name = "m_LineSegmentInput";
            this.m_LineSegmentInput.Padding = new System.Windows.Forms.Padding(3);
            this.m_LineSegmentInput.Size = new System.Drawing.Size(255, 469);
            this.m_LineSegmentInput.TabIndex = 0;
            this.m_LineSegmentInput.Text = "Input";
            this.m_LineSegmentInput.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 198);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.m_minSlope, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.m_maxLineGap, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.m_minLineLength, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.m_NumContrastThreshold, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.m_NumResult, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.m_maxSlope, 1, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(249, 198);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 175);
            this.label4.Margin = new System.Windows.Forms.Padding(10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Max Slope";
            // 
            // m_minSlope
            // 
            this.m_minSlope.DecimalPlaces = 2;
            this.m_minSlope.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_minSlope.Location = new System.Drawing.Point(127, 135);
            this.m_minSlope.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.m_minSlope.Name = "m_minSlope";
            this.m_minSlope.Size = new System.Drawing.Size(119, 20);
            this.m_minSlope.TabIndex = 9;
            this.m_minSlope.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_minSlope.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.m_minSlope.ValueChanged += new System.EventHandler(this.m_minSlope_ValueChanged);
            // 
            // m_maxLineGap
            // 
            this.m_maxLineGap.Location = new System.Drawing.Point(127, 69);
            this.m_maxLineGap.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.m_maxLineGap.Name = "m_maxLineGap";
            this.m_maxLineGap.Size = new System.Drawing.Size(119, 20);
            this.m_maxLineGap.TabIndex = 7;
            this.m_maxLineGap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_maxLineGap.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_maxLineGap.ValueChanged += new System.EventHandler(this.m_maxLineGap_ValueChanged);
            // 
            // m_minLineLength
            // 
            this.m_minLineLength.Location = new System.Drawing.Point(127, 36);
            this.m_minLineLength.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.m_minLineLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_minLineLength.Name = "m_minLineLength";
            this.m_minLineLength.Size = new System.Drawing.Size(119, 20);
            this.m_minLineLength.TabIndex = 4;
            this.m_minLineLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_minLineLength.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.m_minLineLength.ValueChanged += new System.EventHandler(this.m_minLineLength_ValueChanged);
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
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Min Line Length";
            // 
            // m_NumContrastThreshold
            // 
            this.m_NumContrastThreshold.DecimalPlaces = 1;
            this.m_NumContrastThreshold.Location = new System.Drawing.Point(127, 3);
            this.m_NumContrastThreshold.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.m_NumContrastThreshold.Name = "m_NumContrastThreshold";
            this.m_NumContrastThreshold.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_NumContrastThreshold.Size = new System.Drawing.Size(119, 20);
            this.m_NumContrastThreshold.TabIndex = 3;
            this.m_NumContrastThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_NumContrastThreshold.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_NumContrastThreshold.ValueChanged += new System.EventHandler(this.m_NumContrastThreshold_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 109);
            this.label11.Margin = new System.Windows.Forms.Padding(10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Maximum Results";
            // 
            // m_NumResult
            // 
            this.m_NumResult.Location = new System.Drawing.Point(127, 102);
            this.m_NumResult.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.m_NumResult.Name = "m_NumResult";
            this.m_NumResult.Size = new System.Drawing.Size(119, 20);
            this.m_NumResult.TabIndex = 5;
            this.m_NumResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_NumResult.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_NumResult.ValueChanged += new System.EventHandler(this.m_NumResult_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Max Line Gap";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 142);
            this.label2.Margin = new System.Windows.Forms.Padding(10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Min Slope";
            // 
            // m_maxSlope
            // 
            this.m_maxSlope.DecimalPlaces = 2;
            this.m_maxSlope.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_maxSlope.Location = new System.Drawing.Point(127, 168);
            this.m_maxSlope.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.m_maxSlope.Name = "m_maxSlope";
            this.m_maxSlope.Size = new System.Drawing.Size(119, 20);
            this.m_maxSlope.TabIndex = 12;
            this.m_maxSlope.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_maxSlope.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_maxSlope.ValueChanged += new System.EventHandler(this.m_maxSlope_ValueChanged);
            // 
            // m_LineSegmentOutput
            // 
            this.m_LineSegmentOutput.Controls.Add(this.m_LineSegmentRes);
            this.m_LineSegmentOutput.Location = new System.Drawing.Point(4, 22);
            this.m_LineSegmentOutput.Name = "m_LineSegmentOutput";
            this.m_LineSegmentOutput.Padding = new System.Windows.Forms.Padding(3);
            this.m_LineSegmentOutput.Size = new System.Drawing.Size(255, 469);
            this.m_LineSegmentOutput.TabIndex = 1;
            this.m_LineSegmentOutput.Text = "Output";
            this.m_LineSegmentOutput.UseVisualStyleBackColor = true;
            // 
            // m_LineSegmentRes
            // 
            this.m_LineSegmentRes.AllowUserToAddRows = false;
            this.m_LineSegmentRes.AllowUserToDeleteRows = false;
            this.m_LineSegmentRes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_LineSegmentRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_LineSegmentRes.Location = new System.Drawing.Point(3, 3);
            this.m_LineSegmentRes.Name = "m_LineSegmentRes";
            this.m_LineSegmentRes.ReadOnly = true;
            this.m_LineSegmentRes.RowHeadersVisible = false;
            this.m_LineSegmentRes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_LineSegmentRes.Size = new System.Drawing.Size(249, 463);
            this.m_LineSegmentRes.TabIndex = 0;
            this.m_LineSegmentRes.SelectionChanged += new System.EventHandler(this.m_LineSegmentRes_SelectionChanged);
            // 
            // LineSegmentToolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tabControl4);
            this.MinimumSize = new System.Drawing.Size(263, 0);
            this.Name = "LineSegmentToolControl";
            this.Size = new System.Drawing.Size(263, 495);
            this.Load += new System.EventHandler(this.LineSegmentToolControl_Load);
            this.tabControl4.ResumeLayout(false);
            this.m_LineSegmentInput.ResumeLayout(false);
            this.m_LineSegmentInput.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_minSlope)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_maxLineGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_minLineLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumContrastThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_maxSlope)).EndInit();
            this.m_LineSegmentOutput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_LineSegmentRes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage m_LineSegmentInput;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown m_NumResult;
        private System.Windows.Forms.NumericUpDown m_minLineLength;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown m_NumContrastThreshold;
        private System.Windows.Forms.TabPage m_LineSegmentOutput;
        public System.Windows.Forms.DataGridView m_LineSegmentRes;
        private System.Windows.Forms.NumericUpDown m_maxLineGap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown m_minSlope;
        private System.Windows.Forms.NumericUpDown m_maxSlope;
    }
}
