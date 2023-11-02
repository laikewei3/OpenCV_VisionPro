namespace OpenCV_Vision_Pro.Tools.ImageProcess.ProcessTool
{
    partial class ArithmeticToolControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m_cbOverflow = new System.Windows.Forms.ComboBox();
            this.m_nudP3 = new System.Windows.Forms.NumericUpDown();
            this.m_nudP2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_cbMode = new System.Windows.Forms.ComboBox();
            this.m_nudP1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudP3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudP1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.MinimumSize = new System.Drawing.Size(215, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Arithmetic";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.m_cbOverflow, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.m_nudP3, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.m_nudP2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.m_cbMode, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.m_nudP1, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(209, 138);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // m_cbOverflow
            // 
            this.m_cbOverflow.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_cbOverflow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbOverflow.FormattingEnabled = true;
            this.m_cbOverflow.Items.AddRange(new object[] {
            "Clamp",
            "Wrap"});
            this.m_cbOverflow.Location = new System.Drawing.Point(62, 30);
            this.m_cbOverflow.Name = "m_cbOverflow";
            this.m_cbOverflow.Size = new System.Drawing.Size(144, 21);
            this.m_cbOverflow.TabIndex = 10;
            this.m_cbOverflow.SelectedIndexChanged += new System.EventHandler(this.m_cbOverflow_SelectedIndexChanged);
            // 
            // m_nudP3
            // 
            this.m_nudP3.DecimalPlaces = 1;
            this.m_nudP3.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_nudP3.Location = new System.Drawing.Point(62, 109);
            this.m_nudP3.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.m_nudP3.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.m_nudP3.Name = "m_nudP3";
            this.m_nudP3.Size = new System.Drawing.Size(144, 20);
            this.m_nudP3.TabIndex = 9;
            this.m_nudP3.ValueChanged += new System.EventHandler(this.m_nudP3_ValueChanged);
            // 
            // m_nudP2
            // 
            this.m_nudP2.DecimalPlaces = 1;
            this.m_nudP2.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_nudP2.Location = new System.Drawing.Point(62, 83);
            this.m_nudP2.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.m_nudP2.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.m_nudP2.Name = "m_nudP2";
            this.m_nudP2.Size = new System.Drawing.Size(144, 20);
            this.m_nudP2.TabIndex = 8;
            this.m_nudP2.ValueChanged += new System.EventHandler(this.m_nudP2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Overflow";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Plane 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Plane 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 111);
            this.label5.Margin = new System.Windows.Forms.Padding(5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Plane 3";
            // 
            // m_cbMode
            // 
            this.m_cbMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbMode.FormattingEnabled = true;
            this.m_cbMode.Items.AddRange(new object[] {
            "Add/Substract",
            "Multiply"});
            this.m_cbMode.Location = new System.Drawing.Point(62, 3);
            this.m_cbMode.Name = "m_cbMode";
            this.m_cbMode.Size = new System.Drawing.Size(144, 21);
            this.m_cbMode.TabIndex = 5;
            this.m_cbMode.SelectedIndexChanged += new System.EventHandler(this.m_cbMode_SelectedIndexChanged);
            // 
            // m_nudP1
            // 
            this.m_nudP1.DecimalPlaces = 1;
            this.m_nudP1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_nudP1.Location = new System.Drawing.Point(62, 57);
            this.m_nudP1.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.m_nudP1.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.m_nudP1.Name = "m_nudP1";
            this.m_nudP1.Size = new System.Drawing.Size(144, 20);
            this.m_nudP1.TabIndex = 7;
            this.m_nudP1.ValueChanged += new System.EventHandler(this.m_nudP1_ValueChanged);
            // 
            // ArithmeticToolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ArithmeticToolControl";
            this.Size = new System.Drawing.Size(215, 157);
            this.Load += new System.EventHandler(this.Arithmetic_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudP3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudP1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox m_cbMode;
        private System.Windows.Forms.NumericUpDown m_nudP3;
        private System.Windows.Forms.NumericUpDown m_nudP2;
        private System.Windows.Forms.NumericUpDown m_nudP1;
        private System.Windows.Forms.ComboBox m_cbOverflow;
    }
}
