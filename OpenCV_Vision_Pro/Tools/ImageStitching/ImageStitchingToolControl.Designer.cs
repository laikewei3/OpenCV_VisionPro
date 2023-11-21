namespace OpenCV_Vision_Pro.Tools.ImageStitching
{
    partial class ImageStitchingToolControl
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
            this.components = new System.ComponentModel.Container();
            this.m_btnStitchingOpen = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m_listImagesSelected = new System.Windows.Forms.ListBox();
            this.m_openMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imagestiftiffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.m_openMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnStitchingOpen
            // 
            this.m_btnStitchingOpen.Location = new System.Drawing.Point(3, 3);
            this.m_btnStitchingOpen.Name = "m_btnStitchingOpen";
            this.m_btnStitchingOpen.Size = new System.Drawing.Size(75, 23);
            this.m_btnStitchingOpen.TabIndex = 0;
            this.m_btnStitchingOpen.Text = "Open Images";
            this.m_btnStitchingOpen.UseVisualStyleBackColor = true;
            this.m_btnStitchingOpen.Click += new System.EventHandler(this.m_btnStitchingOpen_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.m_listImagesSelected, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.m_btnStitchingOpen, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(521, 129);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // m_listImagesSelected
            // 
            this.m_listImagesSelected.BackColor = System.Drawing.SystemColors.ControlLight;
            this.m_listImagesSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_listImagesSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_listImagesSelected.FormattingEnabled = true;
            this.m_listImagesSelected.Location = new System.Drawing.Point(3, 32);
            this.m_listImagesSelected.Name = "m_listImagesSelected";
            this.m_listImagesSelected.Size = new System.Drawing.Size(515, 94);
            this.m_listImagesSelected.TabIndex = 3;
            this.m_listImagesSelected.SelectedIndexChanged += new System.EventHandler(this.m_listImagesSelected_SelectedIndexChanged);
            // 
            // m_openMenuStrip
            // 
            this.m_openMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imagestiftiffToolStripMenuItem,
            this.folderToolStripMenuItem});
            this.m_openMenuStrip.Name = "m_openMenuStrip";
            this.m_openMenuStrip.Size = new System.Drawing.Size(161, 48);
            // 
            // imagestiftiffToolStripMenuItem
            // 
            this.imagestiftiffToolStripMenuItem.Name = "imagestiftiffToolStripMenuItem";
            this.imagestiftiffToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.imagestiftiffToolStripMenuItem.Text = "Images (.tif/.tiff)";
            this.imagestiftiffToolStripMenuItem.Click += new System.EventHandler(this.OpenEvent);
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.folderToolStripMenuItem.Text = "Folder";
            this.folderToolStripMenuItem.Click += new System.EventHandler(this.OpenEvent);
            // 
            // ImageStitchingToolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ImageStitchingToolControl";
            this.Size = new System.Drawing.Size(521, 682);
            this.Load += new System.EventHandler(this.ImageStitchingToolContorl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.m_openMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_btnStitchingOpen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox m_listImagesSelected;
        private System.Windows.Forms.ContextMenuStrip m_openMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem imagestiftiffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
    }
}
