namespace OpenCV_Vision_Pro.Tools.ID
{
    partial class IDToolControl
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
            this.m_IDOutput = new System.Windows.Forms.TabPage();
            this.m_dgvIDResults = new System.Windows.Forms.DataGridView();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.m_IDInput = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.m_cbMode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_IDOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvIDResults)).BeginInit();
            this.tabControl3.SuspendLayout();
            this.m_IDInput.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_IDOutput
            // 
            this.m_IDOutput.Controls.Add(this.m_dgvIDResults);
            this.m_IDOutput.Location = new System.Drawing.Point(4, 22);
            this.m_IDOutput.Name = "m_IDOutput";
            this.m_IDOutput.Padding = new System.Windows.Forms.Padding(3);
            this.m_IDOutput.Size = new System.Drawing.Size(376, 574);
            this.m_IDOutput.TabIndex = 1;
            this.m_IDOutput.Text = "Output";
            this.m_IDOutput.UseVisualStyleBackColor = true;
            // 
            // m_dgvIDResults
            // 
            this.m_dgvIDResults.AllowUserToAddRows = false;
            this.m_dgvIDResults.AllowUserToDeleteRows = false;
            this.m_dgvIDResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvIDResults.Location = new System.Drawing.Point(3, 3);
            this.m_dgvIDResults.MultiSelect = false;
            this.m_dgvIDResults.Name = "m_dgvIDResults";
            this.m_dgvIDResults.ReadOnly = true;
            this.m_dgvIDResults.RowHeadersWidth = 60;
            this.m_dgvIDResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvIDResults.Size = new System.Drawing.Size(370, 568);
            this.m_dgvIDResults.TabIndex = 0;
            this.m_dgvIDResults.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.m_dgvIDbResults_DataBindingComplete);
            this.m_dgvIDResults.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.m_dgvIDResults_RowPrePaint);
            this.m_dgvIDResults.SelectionChanged += new System.EventHandler(this.m_dgvIDResults_SelectionChanged);
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.m_IDInput);
            this.tabControl3.Controls.Add(this.m_IDOutput);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(0, 0);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(384, 600);
            this.tabControl3.TabIndex = 3;
            // 
            // m_IDInput
            // 
            this.m_IDInput.AutoScroll = true;
            this.m_IDInput.Controls.Add(this.tableLayoutPanel3);
            this.m_IDInput.Location = new System.Drawing.Point(4, 22);
            this.m_IDInput.Name = "m_IDInput";
            this.m_IDInput.Padding = new System.Windows.Forms.Padding(3);
            this.m_IDInput.Size = new System.Drawing.Size(376, 574);
            this.m_IDInput.TabIndex = 0;
            this.m_IDInput.Text = "Input";
            this.m_IDInput.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.m_cbMode, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(370, 27);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // m_cbMode
            // 
            this.m_cbMode.CausesValidation = false;
            this.m_cbMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbMode.FormattingEnabled = true;
            this.m_cbMode.Items.AddRange(new object[] {
            "BarCode",
            "QRCode"});
            this.m_cbMode.Location = new System.Drawing.Point(50, 3);
            this.m_cbMode.Name = "m_cbMode";
            this.m_cbMode.Size = new System.Drawing.Size(150, 21);
            this.m_cbMode.TabIndex = 2;
            this.m_cbMode.SelectedIndexChanged += new System.EventHandler(this.m_cbMode_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mode:";
            // 
            // IDToolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl3);
            this.Name = "IDToolControl";
            this.Size = new System.Drawing.Size(384, 600);
            this.Load += new System.EventHandler(this.IDToolControl_Load);
            this.m_IDOutput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvIDResults)).EndInit();
            this.tabControl3.ResumeLayout(false);
            this.m_IDInput.ResumeLayout(false);
            this.m_IDInput.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage m_IDOutput;
        public System.Windows.Forms.DataGridView m_dgvIDResults;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage m_IDInput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox m_cbMode;
        private System.Windows.Forms.Label label3;
    }
}
