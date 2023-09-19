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
            this.groupBox1.SuspendLayout();
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
            "CogRectangleAffine"});
            this.m_comboBoxROI.Location = new System.Drawing.Point(3, 16);
            this.m_comboBoxROI.Margin = new System.Windows.Forms.Padding(10);
            this.m_comboBoxROI.Name = "m_comboBoxROI";
            this.m_comboBoxROI.Size = new System.Drawing.Size(309, 21);
            this.m_comboBoxROI.TabIndex = 1;
            this.m_comboBoxROI.SelectedIndexChanged += new System.EventHandler(this.m_comboBoxROI_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_comboBoxROI);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 53);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Region";
            // 
            // ROI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ROI";
            this.Size = new System.Drawing.Size(315, 56);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox m_comboBoxROI;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
