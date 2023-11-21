namespace OpenCV_Vision_Pro.Tools.ImageBlending
{
    partial class ImageBlendingToolControl
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
            this.m_btnBlendingOpen = new System.Windows.Forms.Button();
            this.m_cbBlendingOperation = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_listImagesSelected = new System.Windows.Forms.ListBox();
            this.m_tableHDR = new System.Windows.Forms.TableLayoutPanel();
            this.m_btnOpenWeight = new System.Windows.Forms.Button();
            this.m_labelLoadTimes = new System.Windows.Forms.Label();
            this.m_tbWeightQue = new System.Windows.Forms.TextBox();
            this.m_openMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imagestiftiffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.m_tableHDR.SuspendLayout();
            this.m_openMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnBlendingOpen
            // 
            this.m_btnBlendingOpen.Location = new System.Drawing.Point(3, 3);
            this.m_btnBlendingOpen.Name = "m_btnBlendingOpen";
            this.m_btnBlendingOpen.Size = new System.Drawing.Size(75, 23);
            this.m_btnBlendingOpen.TabIndex = 0;
            this.m_btnBlendingOpen.Text = "Open Images";
            this.m_btnBlendingOpen.UseVisualStyleBackColor = true;
            this.m_btnBlendingOpen.Click += new System.EventHandler(this.m_btnBlendingOpen_Click);
            // 
            // m_cbBlendingOperation
            // 
            this.m_cbBlendingOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbBlendingOperation.FormattingEnabled = true;
            this.m_cbBlendingOperation.Items.AddRange(new object[] {
            "LAB",
            "RGB"});
            this.m_cbBlendingOperation.Location = new System.Drawing.Point(77, 3);
            this.m_cbBlendingOperation.Name = "m_cbBlendingOperation";
            this.m_cbBlendingOperation.Size = new System.Drawing.Size(200, 21);
            this.m_cbBlendingOperation.TabIndex = 1;
            this.m_cbBlendingOperation.SelectedIndexChanged += new System.EventHandler(this.m_cbBlendingOperation_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.m_listImagesSelected, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.m_btnBlendingOpen, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.m_tableHDR, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.m_tbWeightQue, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(521, 247);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.m_cbBlendingOperation);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 132);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(515, 27);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Color Mode:";
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
            // m_tableHDR
            // 
            this.m_tableHDR.AutoSize = true;
            this.m_tableHDR.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_tableHDR.ColumnCount = 2;
            this.m_tableHDR.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_tableHDR.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_tableHDR.Controls.Add(this.m_btnOpenWeight, 0, 0);
            this.m_tableHDR.Controls.Add(this.m_labelLoadTimes, 1, 0);
            this.m_tableHDR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tableHDR.Location = new System.Drawing.Point(3, 165);
            this.m_tableHDR.Name = "m_tableHDR";
            this.m_tableHDR.RowCount = 1;
            this.m_tableHDR.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_tableHDR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.m_tableHDR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.m_tableHDR.Size = new System.Drawing.Size(515, 29);
            this.m_tableHDR.TabIndex = 4;
            // 
            // m_btnOpenWeight
            // 
            this.m_btnOpenWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_btnOpenWeight.Location = new System.Drawing.Point(3, 3);
            this.m_btnOpenWeight.Name = "m_btnOpenWeight";
            this.m_btnOpenWeight.Size = new System.Drawing.Size(110, 23);
            this.m_btnOpenWeight.TabIndex = 0;
            this.m_btnOpenWeight.Text = "Weight Files";
            this.m_btnOpenWeight.UseVisualStyleBackColor = true;
            this.m_btnOpenWeight.Click += new System.EventHandler(this.m_btnOpenWeight_Click);
            // 
            // m_labelLoadTimes
            // 
            this.m_labelLoadTimes.AutoSize = true;
            this.m_labelLoadTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_labelLoadTimes.ForeColor = System.Drawing.Color.Gray;
            this.m_labelLoadTimes.Location = new System.Drawing.Point(121, 5);
            this.m_labelLoadTimes.Margin = new System.Windows.Forms.Padding(5);
            this.m_labelLoadTimes.Name = "m_labelLoadTimes";
            this.m_labelLoadTimes.Size = new System.Drawing.Size(46, 15);
            this.m_labelLoadTimes.TabIndex = 1;
            this.m_labelLoadTimes.Text = "Empty";
            // 
            // m_tbWeightQue
            // 
            this.m_tbWeightQue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tbWeightQue.Location = new System.Drawing.Point(3, 200);
            this.m_tbWeightQue.Multiline = true;
            this.m_tbWeightQue.Name = "m_tbWeightQue";
            this.m_tbWeightQue.Size = new System.Drawing.Size(515, 44);
            this.m_tbWeightQue.TabIndex = 5;
            this.m_tbWeightQue.Text = "Enter the weight in format (***,***,***,......)";
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
            // ImageBlendingToolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ImageBlendingToolControl";
            this.Size = new System.Drawing.Size(521, 682);
            this.Load += new System.EventHandler(this.ImageBlendingToolContorl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.m_tableHDR.ResumeLayout(false);
            this.m_tableHDR.PerformLayout();
            this.m_openMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_btnBlendingOpen;
        private System.Windows.Forms.ComboBox m_cbBlendingOperation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox m_listImagesSelected;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip m_openMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem imagestiftiffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel m_tableHDR;
        private System.Windows.Forms.Button m_btnOpenWeight;
        private System.Windows.Forms.Label m_labelLoadTimes;
        private System.Windows.Forms.TextBox m_tbWeightQue;
    }
}
