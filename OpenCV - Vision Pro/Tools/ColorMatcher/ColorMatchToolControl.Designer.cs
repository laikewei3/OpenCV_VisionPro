namespace OpenCV_Vision_Pro.Tools.ColorMatcher
{
    partial class ColorMatchToolControl
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
            this.m_MatcherResult = new System.Windows.Forms.DataGridView();
            this.m_CaliperOutput = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_observedR = new System.Windows.Forms.TextBox();
            this.m_observedG = new System.Windows.Forms.TextBox();
            this.m_observedB = new System.Windows.Forms.TextBox();
            this.m_observedColor = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.m_bestColorConfidence = new System.Windows.Forms.TextBox();
            this.m_bestColorScore = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_bestColorName = new System.Windows.Forms.TextBox();
            this.m_MatcherInput = new System.Windows.Forms.TabPage();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.m_MatcherResult)).BeginInit();
            this.m_CaliperOutput.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_MatcherResult
            // 
            this.m_MatcherResult.AllowUserToAddRows = false;
            this.m_MatcherResult.AllowUserToDeleteRows = false;
            this.m_MatcherResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_MatcherResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_MatcherResult.Location = new System.Drawing.Point(3, 3);
            this.m_MatcherResult.Name = "m_MatcherResult";
            this.m_MatcherResult.ReadOnly = true;
            this.m_MatcherResult.RowHeadersVisible = false;
            this.m_MatcherResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.m_MatcherResult.Size = new System.Drawing.Size(254, 280);
            this.m_MatcherResult.TabIndex = 0;
            this.m_MatcherResult.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.m_MatcherResult_CellFormatting);
            this.m_MatcherResult.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.m_MatcherResult_ColumnAdded);
            // 
            // m_CaliperOutput
            // 
            this.m_CaliperOutput.Controls.Add(this.tableLayoutPanel4);
            this.m_CaliperOutput.Location = new System.Drawing.Point(4, 22);
            this.m_CaliperOutput.Name = "m_CaliperOutput";
            this.m_CaliperOutput.Padding = new System.Windows.Forms.Padding(3);
            this.m_CaliperOutput.Size = new System.Drawing.Size(266, 484);
            this.m_CaliperOutput.TabIndex = 1;
            this.m_CaliperOutput.Text = "Output";
            this.m_CaliperOutput.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.m_MatcherResult, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(260, 478);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 289);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(254, 186);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(155, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(96, 180);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Observed Color";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanel1.Controls.Add(this.m_observedColor);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(90, 161);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.m_observedR, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.m_observedG, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.m_observedB, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(97, 92);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "B";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "R";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "G";
            // 
            // m_observedR
            // 
            this.m_observedR.Location = new System.Drawing.Point(24, 3);
            this.m_observedR.Name = "m_observedR";
            this.m_observedR.ReadOnly = true;
            this.m_observedR.Size = new System.Drawing.Size(70, 20);
            this.m_observedR.TabIndex = 6;
            // 
            // m_observedG
            // 
            this.m_observedG.Location = new System.Drawing.Point(24, 33);
            this.m_observedG.Name = "m_observedG";
            this.m_observedG.ReadOnly = true;
            this.m_observedG.Size = new System.Drawing.Size(70, 20);
            this.m_observedG.TabIndex = 7;
            // 
            // m_observedB
            // 
            this.m_observedB.Location = new System.Drawing.Point(24, 63);
            this.m_observedB.Name = "m_observedB";
            this.m_observedB.ReadOnly = true;
            this.m_observedB.Size = new System.Drawing.Size(70, 20);
            this.m_observedB.TabIndex = 8;
            // 
            // m_observedColor
            // 
            this.m_observedColor.BackColor = System.Drawing.Color.Black;
            this.m_observedColor.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_observedColor.Location = new System.Drawing.Point(48, 101);
            this.m_observedColor.Name = "m_observedColor";
            this.m_observedColor.Size = new System.Drawing.Size(52, 52);
            this.m_observedColor.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 180);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Best Match";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.m_bestColorConfidence, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.m_bestColorScore, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.m_bestColorName, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(140, 161);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // m_bestColorConfidence
            // 
            this.m_bestColorConfidence.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_bestColorConfidence.Location = new System.Drawing.Point(70, 63);
            this.m_bestColorConfidence.Name = "m_bestColorConfidence";
            this.m_bestColorConfidence.ReadOnly = true;
            this.m_bestColorConfidence.Size = new System.Drawing.Size(67, 20);
            this.m_bestColorConfidence.TabIndex = 5;
            // 
            // m_bestColorScore
            // 
            this.m_bestColorScore.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_bestColorScore.Location = new System.Drawing.Point(70, 33);
            this.m_bestColorScore.Name = "m_bestColorScore";
            this.m_bestColorScore.ReadOnly = true;
            this.m_bestColorScore.Size = new System.Drawing.Size(67, 20);
            this.m_bestColorScore.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Score";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Confidence";
            // 
            // m_bestColorName
            // 
            this.m_bestColorName.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_bestColorName.Location = new System.Drawing.Point(70, 3);
            this.m_bestColorName.Name = "m_bestColorName";
            this.m_bestColorName.ReadOnly = true;
            this.m_bestColorName.Size = new System.Drawing.Size(67, 20);
            this.m_bestColorName.TabIndex = 3;
            // 
            // m_MatcherInput
            // 
            this.m_MatcherInput.AutoScroll = true;
            this.m_MatcherInput.Location = new System.Drawing.Point(4, 22);
            this.m_MatcherInput.Name = "m_MatcherInput";
            this.m_MatcherInput.Padding = new System.Windows.Forms.Padding(3);
            this.m_MatcherInput.Size = new System.Drawing.Size(266, 484);
            this.m_MatcherInput.TabIndex = 0;
            this.m_MatcherInput.Text = "Input";
            this.m_MatcherInput.UseVisualStyleBackColor = true;
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.m_MatcherInput);
            this.tabControl4.Controls.Add(this.m_CaliperOutput);
            this.tabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl4.Location = new System.Drawing.Point(0, 0);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(274, 510);
            this.tabControl4.TabIndex = 3;
            // 
            // ColorMatchToolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl4);
            this.Name = "ColorMatchToolControl";
            this.Size = new System.Drawing.Size(274, 510);
            this.Load += new System.EventHandler(this.ColorMatchToolControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_MatcherResult)).EndInit();
            this.m_CaliperOutput.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabControl4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView m_MatcherResult;
        private System.Windows.Forms.TabPage m_CaliperOutput;
        private System.Windows.Forms.TabPage m_MatcherInput;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel m_observedColor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox m_bestColorConfidence;
        private System.Windows.Forms.TextBox m_bestColorScore;
        private System.Windows.Forms.TextBox m_bestColorName;
        private System.Windows.Forms.TextBox m_observedR;
        private System.Windows.Forms.TextBox m_observedG;
        private System.Windows.Forms.TextBox m_observedB;
    }
}
