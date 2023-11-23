namespace OpenCV_Vision_Pro.Tools.ImageProcess.ProcessTool
{
    partial class SuperResolutionToolControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_panelSuper = new System.Windows.Forms.FlowLayoutPanel();
            this.m_lbUpScale = new System.Windows.Forms.Label();
            this.m_tbUpScale = new System.Windows.Forms.TextBox();
            this.m_btnMode = new System.Windows.Forms.Button();
            this.m_panelTradisional = new System.Windows.Forms.FlowLayoutPanel();
            this.m_cbRatio = new System.Windows.Forms.CheckBox();
            this.m_btnInitialSize = new System.Windows.Forms.Button();
            this.m_tableTradisional = new System.Windows.Forms.TableLayoutPanel();
            this.m_tbHeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_tbWidth = new System.Windows.Forms.TextBox();
            this.m_mode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tradisionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bicubicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.superResolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edsrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.espcnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fsrcnnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lapsrnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.m_panelSuper.SuspendLayout();
            this.m_panelTradisional.SuspendLayout();
            this.m_tableTradisional.SuspendLayout();
            this.m_mode.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.m_panelSuper);
            this.groupBox1.Controls.Add(this.m_btnMode);
            this.groupBox1.Controls.Add(this.m_panelTradisional);
            this.groupBox1.Controls.Add(this.m_tableTradisional);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.MinimumSize = new System.Drawing.Size(215, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 251);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resize";
            // 
            // m_panelSuper
            // 
            this.m_panelSuper.AutoSize = true;
            this.m_panelSuper.Controls.Add(this.m_lbUpScale);
            this.m_panelSuper.Controls.Add(this.m_tbUpScale);
            this.m_panelSuper.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelSuper.Location = new System.Drawing.Point(3, 97);
            this.m_panelSuper.Name = "m_panelSuper";
            this.m_panelSuper.Size = new System.Drawing.Size(212, 26);
            this.m_panelSuper.TabIndex = 9;
            // 
            // m_lbUpScale
            // 
            this.m_lbUpScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lbUpScale.AutoSize = true;
            this.m_lbUpScale.Location = new System.Drawing.Point(3, 3);
            this.m_lbUpScale.Margin = new System.Windows.Forms.Padding(3);
            this.m_lbUpScale.Name = "m_lbUpScale";
            this.m_lbUpScale.Size = new System.Drawing.Size(54, 20);
            this.m_lbUpScale.TabIndex = 8;
            this.m_lbUpScale.Text = "Up Scale:";
            // 
            // m_tbUpScale
            // 
            this.m_tbUpScale.Location = new System.Drawing.Point(63, 3);
            this.m_tbUpScale.Name = "m_tbUpScale";
            this.m_tbUpScale.Size = new System.Drawing.Size(146, 20);
            this.m_tbUpScale.TabIndex = 9;
            this.m_tbUpScale.TextChanged += new System.EventHandler(this.m_tbUpScale_TextChanged);
            // 
            // m_btnMode
            // 
            this.m_btnMode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_btnMode.Location = new System.Drawing.Point(3, 225);
            this.m_btnMode.Name = "m_btnMode";
            this.m_btnMode.Size = new System.Drawing.Size(212, 23);
            this.m_btnMode.TabIndex = 9;
            this.m_btnMode.Text = "Selected Mode: ";
            this.m_btnMode.UseVisualStyleBackColor = true;
            this.m_btnMode.Click += new System.EventHandler(this.m_btnMode_Click);
            // 
            // m_panelTradisional
            // 
            this.m_panelTradisional.AutoSize = true;
            this.m_panelTradisional.Controls.Add(this.m_cbRatio);
            this.m_panelTradisional.Controls.Add(this.m_btnInitialSize);
            this.m_panelTradisional.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTradisional.Location = new System.Drawing.Point(3, 68);
            this.m_panelTradisional.Name = "m_panelTradisional";
            this.m_panelTradisional.Size = new System.Drawing.Size(212, 29);
            this.m_panelTradisional.TabIndex = 8;
            // 
            // m_cbRatio
            // 
            this.m_cbRatio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cbRatio.AutoSize = true;
            this.m_cbRatio.Checked = true;
            this.m_cbRatio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_cbRatio.Location = new System.Drawing.Point(3, 3);
            this.m_cbRatio.Name = "m_cbRatio";
            this.m_cbRatio.Size = new System.Drawing.Size(120, 23);
            this.m_cbRatio.TabIndex = 6;
            this.m_cbRatio.Text = "Maintain initial Ratio";
            this.m_cbRatio.UseVisualStyleBackColor = true;
            this.m_cbRatio.CheckedChanged += new System.EventHandler(this.m_cbRatio_CheckedChanged);
            // 
            // m_btnInitialSize
            // 
            this.m_btnInitialSize.Location = new System.Drawing.Point(129, 3);
            this.m_btnInitialSize.Name = "m_btnInitialSize";
            this.m_btnInitialSize.Size = new System.Drawing.Size(75, 23);
            this.m_btnInitialSize.TabIndex = 7;
            this.m_btnInitialSize.Text = "Initial Size";
            this.m_btnInitialSize.UseVisualStyleBackColor = true;
            this.m_btnInitialSize.Click += new System.EventHandler(this.m_btnInitialSize_Click);
            // 
            // m_tableTradisional
            // 
            this.m_tableTradisional.AutoSize = true;
            this.m_tableTradisional.ColumnCount = 2;
            this.m_tableTradisional.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_tableTradisional.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_tableTradisional.Controls.Add(this.m_tbHeight, 1, 1);
            this.m_tableTradisional.Controls.Add(this.label1, 0, 0);
            this.m_tableTradisional.Controls.Add(this.label2, 0, 1);
            this.m_tableTradisional.Controls.Add(this.m_tbWidth, 1, 0);
            this.m_tableTradisional.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_tableTradisional.Location = new System.Drawing.Point(3, 16);
            this.m_tableTradisional.Name = "m_tableTradisional";
            this.m_tableTradisional.RowCount = 2;
            this.m_tableTradisional.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_tableTradisional.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_tableTradisional.Size = new System.Drawing.Size(212, 52);
            this.m_tableTradisional.TabIndex = 5;
            // 
            // m_tbHeight
            // 
            this.m_tbHeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tbHeight.Location = new System.Drawing.Point(53, 29);
            this.m_tbHeight.Name = "m_tbHeight";
            this.m_tbHeight.Size = new System.Drawing.Size(156, 20);
            this.m_tbHeight.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Height: ";
            // 
            // m_tbWidth
            // 
            this.m_tbWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tbWidth.Location = new System.Drawing.Point(53, 3);
            this.m_tbWidth.Name = "m_tbWidth";
            this.m_tbWidth.Size = new System.Drawing.Size(156, 20);
            this.m_tbWidth.TabIndex = 2;
            // 
            // m_mode
            // 
            this.m_mode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tradisionalToolStripMenuItem,
            this.superResolutionToolStripMenuItem});
            this.m_mode.Name = "m_mode";
            this.m_mode.Size = new System.Drawing.Size(181, 70);
            // 
            // tradisionalToolStripMenuItem
            // 
            this.tradisionalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bicubicToolStripMenuItem});
            this.tradisionalToolStripMenuItem.Name = "tradisionalToolStripMenuItem";
            this.tradisionalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tradisionalToolStripMenuItem.Text = "Tradisional";
            // 
            // bicubicToolStripMenuItem
            // 
            this.bicubicToolStripMenuItem.Name = "bicubicToolStripMenuItem";
            this.bicubicToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bicubicToolStripMenuItem.Text = "Bicubic";
            this.bicubicToolStripMenuItem.Click += new System.EventHandler(this.m_modeSelectionT);
            // 
            // superResolutionToolStripMenuItem
            // 
            this.superResolutionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edsrToolStripMenuItem,
            this.espcnToolStripMenuItem,
            this.fsrcnnToolStripMenuItem,
            this.lapsrnToolStripMenuItem});
            this.superResolutionToolStripMenuItem.Name = "superResolutionToolStripMenuItem";
            this.superResolutionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.superResolutionToolStripMenuItem.Text = "Super Resolution";
            // 
            // edsrToolStripMenuItem
            // 
            this.edsrToolStripMenuItem.Name = "edsrToolStripMenuItem";
            this.edsrToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.edsrToolStripMenuItem.Text = "EDSR";
            this.edsrToolStripMenuItem.Click += new System.EventHandler(this.m_modeSelectionS);
            // 
            // espcnToolStripMenuItem
            // 
            this.espcnToolStripMenuItem.Name = "espcnToolStripMenuItem";
            this.espcnToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.espcnToolStripMenuItem.Text = "ESPCN";
            this.espcnToolStripMenuItem.Click += new System.EventHandler(this.m_modeSelectionS);
            // 
            // fsrcnnToolStripMenuItem
            // 
            this.fsrcnnToolStripMenuItem.Name = "fsrcnnToolStripMenuItem";
            this.fsrcnnToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fsrcnnToolStripMenuItem.Text = "FSRCNN";
            this.fsrcnnToolStripMenuItem.Click += new System.EventHandler(this.m_modeSelectionS);
            // 
            // lapsrnToolStripMenuItem
            // 
            this.lapsrnToolStripMenuItem.Name = "lapsrnToolStripMenuItem";
            this.lapsrnToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lapsrnToolStripMenuItem.Text = "LapSRN";
            this.lapsrnToolStripMenuItem.Click += new System.EventHandler(this.m_modeSelectionS);
            // 
            // SuperResolutionToolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox1);
            this.Name = "SuperResolutionToolControl";
            this.Size = new System.Drawing.Size(218, 251);
            this.Load += new System.EventHandler(this.SuperResolution_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.m_panelSuper.ResumeLayout(false);
            this.m_panelSuper.PerformLayout();
            this.m_panelTradisional.ResumeLayout(false);
            this.m_panelTradisional.PerformLayout();
            this.m_tableTradisional.ResumeLayout(false);
            this.m_tableTradisional.PerformLayout();
            this.m_mode.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel m_tableTradisional;
        private System.Windows.Forms.TextBox m_tbHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_tbWidth;
        private System.Windows.Forms.CheckBox m_cbRatio;
        private System.Windows.Forms.FlowLayoutPanel m_panelTradisional;
        private System.Windows.Forms.Button m_btnInitialSize;
        private System.Windows.Forms.Button m_btnMode;
        private System.Windows.Forms.ContextMenuStrip m_mode;
        private System.Windows.Forms.ToolStripMenuItem tradisionalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bicubicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem superResolutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edsrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem espcnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fsrcnnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lapsrnToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel m_panelSuper;
        private System.Windows.Forms.Label m_lbUpScale;
        private System.Windows.Forms.TextBox m_tbUpScale;
    }
}
