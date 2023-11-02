namespace OpenCV_Vision_Pro
{
    partial class ROI
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
            bs.Dispose();
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
            this.m_comboBoxROI = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.m_PointTable = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.m_btnAddPoint = new System.Windows.Forms.Button();
            this.m_btnDeletePoint = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_PointTable)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_comboBoxROI
            // 
            this.m_comboBoxROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_comboBoxROI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxROI.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_comboBoxROI.ItemHeight = 13;
            this.m_comboBoxROI.Items.AddRange(new object[] {
            "<None - Use Entire Image>",
            "CogRectangle",
            "CogPolygon"});
            this.m_comboBoxROI.Location = new System.Drawing.Point(3, 16);
            this.m_comboBoxROI.Margin = new System.Windows.Forms.Padding(10);
            this.m_comboBoxROI.Name = "m_comboBoxROI";
            this.m_comboBoxROI.Size = new System.Drawing.Size(284, 21);
            this.m_comboBoxROI.TabIndex = 1;
            this.m_comboBoxROI.SelectedIndexChanged += new System.EventHandler(this.m_comboBoxROI_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_comboBoxROI);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 53);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Region";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.m_PointTable, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.flowLayoutPanel3, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(296, 188);
            this.tableLayoutPanel6.TabIndex = 6;
            // 
            // m_PointTable
            // 
            this.m_PointTable.AllowUserToAddRows = false;
            this.m_PointTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_PointTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.m_PointTable.Location = new System.Drawing.Point(3, 92);
            this.m_PointTable.Name = "m_PointTable";
            this.m_PointTable.RowHeadersVisible = false;
            this.m_PointTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_PointTable.Size = new System.Drawing.Size(290, 93);
            this.m_PointTable.TabIndex = 2;
            this.m_PointTable.Visible = false;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.m_btnAddPoint);
            this.flowLayoutPanel3.Controls.Add(this.m_btnDeletePoint);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 59);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(296, 30);
            this.flowLayoutPanel3.TabIndex = 1;
            this.flowLayoutPanel3.Visible = false;
            // 
            // m_btnAddPoint
            // 
            this.m_btnAddPoint.Location = new System.Drawing.Point(3, 3);
            this.m_btnAddPoint.Name = "m_btnAddPoint";
            this.m_btnAddPoint.Size = new System.Drawing.Size(21, 21);
            this.m_btnAddPoint.TabIndex = 1;
            this.m_btnAddPoint.Text = "+";
            this.m_btnAddPoint.UseVisualStyleBackColor = true;
            this.m_btnAddPoint.Click += new System.EventHandler(this.m_btnAddPoint_Click);
            // 
            // m_btnDeletePoint
            // 
            this.m_btnDeletePoint.Location = new System.Drawing.Point(30, 3);
            this.m_btnDeletePoint.Name = "m_btnDeletePoint";
            this.m_btnDeletePoint.Size = new System.Drawing.Size(21, 21);
            this.m_btnDeletePoint.TabIndex = 2;
            this.m_btnDeletePoint.Text = "X";
            this.m_btnDeletePoint.UseVisualStyleBackColor = true;
            // 
            // ROI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel6);
            this.Name = "ROI";
            this.Size = new System.Drawing.Size(296, 188);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_PointTable)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox m_comboBoxROI;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button m_btnAddPoint;
        private System.Windows.Forms.Button m_btnDeletePoint;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        public System.Windows.Forms.DataGridView m_PointTable;
    }
}
