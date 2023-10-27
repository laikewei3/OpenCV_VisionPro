namespace OpenCV_Vision_Pro
{
    partial class ImageProcessToolControl
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
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.m_cbProcessMode = new System.Windows.Forms.ComboBox();
            this.m_btnDeleteProcess = new System.Windows.Forms.Button();
            this.m_ProcessTable = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_ProcessTable)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.m_ProcessTable, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(298, 377);
            this.tableLayoutPanel6.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(292, 30);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.m_cbProcessMode);
            this.flowLayoutPanel3.Controls.Add(this.m_btnDeleteProcess);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(292, 30);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // m_cbProcessMode
            // 
            this.m_cbProcessMode.DropDownHeight = 200;
            this.m_cbProcessMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbProcessMode.DropDownWidth = 150;
            this.m_cbProcessMode.FormattingEnabled = true;
            this.m_cbProcessMode.IntegralHeight = false;
            this.m_cbProcessMode.Items.AddRange(new object[] {
            "Rotate / Flip",
            "Equalise(Fixed)",
            "Equalise(Adaptive)"});
            this.m_cbProcessMode.Location = new System.Drawing.Point(3, 3);
            this.m_cbProcessMode.MaxDropDownItems = 50;
            this.m_cbProcessMode.Name = "m_cbProcessMode";
            this.m_cbProcessMode.Size = new System.Drawing.Size(21, 21);
            this.m_cbProcessMode.TabIndex = 0;
            this.m_cbProcessMode.SelectedIndexChanged += new System.EventHandler(this.m_cbProcessMode_SelectedIndexChanged);
            // 
            // m_btnDeleteProcess
            // 
            this.m_btnDeleteProcess.Location = new System.Drawing.Point(30, 3);
            this.m_btnDeleteProcess.Name = "m_btnDeleteProcess";
            this.m_btnDeleteProcess.Size = new System.Drawing.Size(21, 21);
            this.m_btnDeleteProcess.TabIndex = 1;
            this.m_btnDeleteProcess.Text = "X";
            this.m_btnDeleteProcess.UseVisualStyleBackColor = true;
            this.m_btnDeleteProcess.Click += new System.EventHandler(this.m_btnDeleteProcess_Click);
            // 
            // m_ProcessTable
            // 
            this.m_ProcessTable.AllowUserToAddRows = false;
            this.m_ProcessTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_ProcessTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ProcessTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.m_ProcessTable.Location = new System.Drawing.Point(3, 39);
            this.m_ProcessTable.Name = "m_ProcessTable";
            this.m_ProcessTable.RowHeadersVisible = false;
            this.m_ProcessTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_ProcessTable.Size = new System.Drawing.Size(292, 335);
            this.m_ProcessTable.TabIndex = 2;
            this.m_ProcessTable.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.m_ProcessTable_ColumnAdded);
            this.m_ProcessTable.SelectionChanged += new System.EventHandler(this.m_ProcessTable_SelectionChanged);
            // 
            // ImageProcessToolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.tableLayoutPanel6);
            this.Name = "ImageProcessToolControl";
            this.Size = new System.Drawing.Size(298, 504);
            this.Load += new System.EventHandler(this.ImageProcessToolControl_Load);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_ProcessTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.ComboBox m_cbProcessMode;
        private System.Windows.Forms.Button m_btnDeleteProcess;
        private System.Windows.Forms.DataGridView m_ProcessTable;
    }
}
