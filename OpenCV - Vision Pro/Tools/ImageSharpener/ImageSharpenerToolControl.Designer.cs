namespace OpenCV_Vision_Pro
{
    partial class ImageSharpenerToolControl
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
            this.m_comboBoxColorMode = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_scoreVariance = new System.Windows.Forms.TextBox();
            this.m_labelGamma = new System.Windows.Forms.Label();
            this.m_nudgamma = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudgamma)).BeginInit();
            this.SuspendLayout();
            // 
            // m_comboBoxColorMode
            // 
            this.m_comboBoxColorMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_comboBoxColorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxColorMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_comboBoxColorMode.ItemHeight = 13;
            this.m_comboBoxColorMode.Items.AddRange(new object[] {
            "Sharper",
            "Expose",
            "Equalise(Fixed)",
            "Equalise(Adaptive)"});
            this.m_comboBoxColorMode.Location = new System.Drawing.Point(3, 16);
            this.m_comboBoxColorMode.Margin = new System.Windows.Forms.Padding(10);
            this.m_comboBoxColorMode.Name = "m_comboBoxColorMode";
            this.m_comboBoxColorMode.Size = new System.Drawing.Size(286, 21);
            this.m_comboBoxColorMode.TabIndex = 1;
            this.m_comboBoxColorMode.SelectedIndexChanged += new System.EventHandler(this.m_comboBoxColorMode_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_comboBoxColorMode);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 63);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Run Mode";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(298, 504);
            this.tableLayoutPanel6.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.m_scoreVariance, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.m_labelGamma, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.m_nudgamma, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 72);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(292, 429);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sharp Score";
            // 
            // m_scoreVariance
            // 
            this.m_scoreVariance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_scoreVariance.Location = new System.Drawing.Point(93, 41);
            this.m_scoreVariance.Margin = new System.Windows.Forms.Padding(7);
            this.m_scoreVariance.Name = "m_scoreVariance";
            this.m_scoreVariance.ReadOnly = true;
            this.m_scoreVariance.Size = new System.Drawing.Size(192, 20);
            this.m_scoreVariance.TabIndex = 1;
            // 
            // m_labelGamma
            // 
            this.m_labelGamma.AutoSize = true;
            this.m_labelGamma.Location = new System.Drawing.Point(10, 10);
            this.m_labelGamma.Margin = new System.Windows.Forms.Padding(10);
            this.m_labelGamma.Name = "m_labelGamma";
            this.m_labelGamma.Size = new System.Drawing.Size(43, 13);
            this.m_labelGamma.TabIndex = 2;
            this.m_labelGamma.Text = "Gamma";
            // 
            // m_nudgamma
            // 
            this.m_nudgamma.DecimalPlaces = 2;
            this.m_nudgamma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_nudgamma.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudgamma.Location = new System.Drawing.Point(93, 7);
            this.m_nudgamma.Margin = new System.Windows.Forms.Padding(7);
            this.m_nudgamma.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_nudgamma.Name = "m_nudgamma";
            this.m_nudgamma.Size = new System.Drawing.Size(192, 20);
            this.m_nudgamma.TabIndex = 3;
            this.m_nudgamma.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.m_nudgamma.ValueChanged += new System.EventHandler(this.m_nudgamma_ValueChanged);
            // 
            // ImageSharpenerToolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel6);
            this.Name = "ImageSharpenerToolControl";
            this.Size = new System.Drawing.Size(298, 504);
            this.Load += new System.EventHandler(this.ImageSharpenerToolControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudgamma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox m_comboBoxColorMode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_scoreVariance;
        private System.Windows.Forms.Label m_labelGamma;
        private System.Windows.Forms.NumericUpDown m_nudgamma;
    }
}
