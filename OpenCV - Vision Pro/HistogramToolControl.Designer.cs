namespace OpenCV___Vision_Pro
{
    partial class HistogramToolControl
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
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.m_HistogramInput = new System.Windows.Forms.TabPage();
            this.m_HistogramOutput = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.m_dgvHisData = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_HisOutTable = new System.Windows.Forms.TableLayoutPanel();
            this.m_tbSample = new System.Windows.Forms.TextBox();
            this.m_tbVariance = new System.Windows.Forms.TextBox();
            this.m_tbSD = new System.Windows.Forms.TextBox();
            this.m_tbMean = new System.Windows.Forms.TextBox();
            this.m_tbMode = new System.Windows.Forms.TextBox();
            this.m_tbMedian = new System.Windows.Forms.TextBox();
            this.m_tbMax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_tbMin = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl2.SuspendLayout();
            this.m_HistogramOutput.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvHisData)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.m_HisOutTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.m_HistogramInput);
            this.tabControl2.Controls.Add(this.m_HistogramOutput);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(494, 545);
            this.tabControl2.TabIndex = 1;
            // 
            // m_HistogramInput
            // 
            this.m_HistogramInput.AutoScroll = true;
            this.m_HistogramInput.Location = new System.Drawing.Point(4, 22);
            this.m_HistogramInput.Name = "m_HistogramInput";
            this.m_HistogramInput.Padding = new System.Windows.Forms.Padding(3);
            this.m_HistogramInput.Size = new System.Drawing.Size(486, 519);
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
            this.m_HistogramOutput.Size = new System.Drawing.Size(486, 519);
            this.m_HistogramOutput.TabIndex = 1;
            this.m_HistogramOutput.Text = "Output";
            this.m_HistogramOutput.UseVisualStyleBackColor = true;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_HisOutTable);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(463, 305);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Statictics";
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
            this.m_HisOutTable.Size = new System.Drawing.Size(457, 286);
            this.m_HisOutTable.TabIndex = 0;
            // 
            // m_tbSample
            // 
            this.m_tbSample.Enabled = false;
            this.m_tbSample.Location = new System.Drawing.Point(130, 248);
            this.m_tbSample.Name = "m_tbSample";
            this.m_tbSample.Size = new System.Drawing.Size(100, 20);
            this.m_tbSample.TabIndex = 15;
            // 
            // m_tbVariance
            // 
            this.m_tbVariance.Enabled = false;
            this.m_tbVariance.Location = new System.Drawing.Point(130, 213);
            this.m_tbVariance.Name = "m_tbVariance";
            this.m_tbVariance.Size = new System.Drawing.Size(100, 20);
            this.m_tbVariance.TabIndex = 14;
            // 
            // m_tbSD
            // 
            this.m_tbSD.Enabled = false;
            this.m_tbSD.Location = new System.Drawing.Point(130, 178);
            this.m_tbSD.Name = "m_tbSD";
            this.m_tbSD.Size = new System.Drawing.Size(100, 20);
            this.m_tbSD.TabIndex = 13;
            // 
            // m_tbMean
            // 
            this.m_tbMean.Enabled = false;
            this.m_tbMean.Location = new System.Drawing.Point(130, 143);
            this.m_tbMean.Name = "m_tbMean";
            this.m_tbMean.Size = new System.Drawing.Size(100, 20);
            this.m_tbMean.TabIndex = 12;
            // 
            // m_tbMode
            // 
            this.m_tbMode.Enabled = false;
            this.m_tbMode.Location = new System.Drawing.Point(130, 108);
            this.m_tbMode.Name = "m_tbMode";
            this.m_tbMode.Size = new System.Drawing.Size(100, 20);
            this.m_tbMode.TabIndex = 11;
            // 
            // m_tbMedian
            // 
            this.m_tbMedian.Enabled = false;
            this.m_tbMedian.Location = new System.Drawing.Point(130, 73);
            this.m_tbMedian.Name = "m_tbMedian";
            this.m_tbMedian.Size = new System.Drawing.Size(100, 20);
            this.m_tbMedian.TabIndex = 10;
            // 
            // m_tbMax
            // 
            this.m_tbMax.Enabled = false;
            this.m_tbMax.Location = new System.Drawing.Point(130, 38);
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
            this.m_tbMin.Location = new System.Drawing.Point(130, 3);
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
            // HistogramToolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl2);
            this.Name = "HistogramToolControl";
            this.Size = new System.Drawing.Size(494, 545);
            this.tabControl2.ResumeLayout(false);
            this.m_HistogramOutput.ResumeLayout(false);
            this.m_HistogramOutput.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvHisData)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.m_HisOutTable.ResumeLayout(false);
            this.m_HisOutTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage m_HistogramInput;
        private System.Windows.Forms.TabPage m_HistogramOutput;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView m_dgvHisData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel m_HisOutTable;
        private System.Windows.Forms.TextBox m_tbSample;
        private System.Windows.Forms.TextBox m_tbVariance;
        private System.Windows.Forms.TextBox m_tbSD;
        private System.Windows.Forms.TextBox m_tbMean;
        private System.Windows.Forms.TextBox m_tbMode;
        private System.Windows.Forms.TextBox m_tbMedian;
        private System.Windows.Forms.TextBox m_tbMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox m_tbMin;
        private System.Windows.Forms.Label label8;
    }
}
