namespace OpenCV_Vision_Pro
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.m_BtnAddTool = new System.Windows.Forms.Button();
            this.m_RunBtn = new System.Windows.Forms.Button();
            this.m_OpenBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_treeViewTools = new System.Windows.Forms.TreeView();
            this.m_AddToolList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.blobToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caliperToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.m_AddToolList.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(0, 450);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.m_BtnAddTool);
            this.flowLayoutPanel1.Controls.Add(this.m_RunBtn);
            this.flowLayoutPanel1.Controls.Add(this.m_OpenBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 25);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // m_BtnAddTool
            // 
            this.m_BtnAddTool.Location = new System.Drawing.Point(3, 3);
            this.m_BtnAddTool.Name = "m_BtnAddTool";
            this.m_BtnAddTool.Size = new System.Drawing.Size(75, 23);
            this.m_BtnAddTool.TabIndex = 3;
            this.m_BtnAddTool.Text = "Add Tool";
            this.m_BtnAddTool.UseVisualStyleBackColor = true;
            this.m_BtnAddTool.Click += new System.EventHandler(this.m_BtnAddTool_Click);
            // 
            // m_RunBtn
            // 
            this.m_RunBtn.Location = new System.Drawing.Point(84, 3);
            this.m_RunBtn.Name = "m_RunBtn";
            this.m_RunBtn.Size = new System.Drawing.Size(75, 23);
            this.m_RunBtn.TabIndex = 0;
            this.m_RunBtn.Text = "Run";
            this.m_RunBtn.UseVisualStyleBackColor = true;
            this.m_RunBtn.Click += new System.EventHandler(this.m_RunBtn_Click);
            // 
            // m_OpenBtn
            // 
            this.m_OpenBtn.Location = new System.Drawing.Point(165, 3);
            this.m_OpenBtn.Name = "m_OpenBtn";
            this.m_OpenBtn.Size = new System.Drawing.Size(75, 23);
            this.m_OpenBtn.TabIndex = 1;
            this.m_OpenBtn.Text = "Open";
            this.m_OpenBtn.UseVisualStyleBackColor = true;
            this.m_OpenBtn.Click += new System.EventHandler(this.m_OpenBtn_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer1.Panel1.Controls.Add(this.m_treeViewTools);
            this.splitContainer1.Size = new System.Drawing.Size(794, 419);
            this.splitContainer1.SplitterDistance = 264;
            this.splitContainer1.TabIndex = 3;
            // 
            // m_treeViewTools
            // 
            this.m_treeViewTools.BackColor = System.Drawing.SystemColors.ControlLight;
            this.m_treeViewTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_treeViewTools.Location = new System.Drawing.Point(0, 0);
            this.m_treeViewTools.Name = "m_treeViewTools";
            this.m_treeViewTools.Size = new System.Drawing.Size(264, 419);
            this.m_treeViewTools.TabIndex = 0;
            this.m_treeViewTools.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.m_treeViewTools_NodeMouseClick);
            this.m_treeViewTools.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.m_treeViewTools_NodeMouseDoubleClick);
            // 
            // m_AddToolList
            // 
            this.m_AddToolList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blobToolMenuItem,
            this.caliperToolMenuItem,
            this.histogramToolMenuItem});
            this.m_AddToolList.Name = "contextMenuStrip1";
            this.m_AddToolList.Size = new System.Drawing.Size(156, 70);
            // 
            // blobToolMenuItem
            // 
            this.blobToolMenuItem.Name = "blobToolMenuItem";
            this.blobToolMenuItem.Size = new System.Drawing.Size(155, 22);
            this.blobToolMenuItem.Text = "Blob Tool";
            this.blobToolMenuItem.Click += new System.EventHandler(this.blobToolMenuItem_Click);
            // 
            // caliperToolMenuItem
            // 
            this.caliperToolMenuItem.Name = "caliperToolMenuItem";
            this.caliperToolMenuItem.Size = new System.Drawing.Size(155, 22);
            this.caliperToolMenuItem.Text = "Caliper Tool";
            this.caliperToolMenuItem.Click += new System.EventHandler(this.caliperToolMenuItem_Click);
            // 
            // histogramToolMenuItem
            // 
            this.histogramToolMenuItem.Name = "histogramToolMenuItem";
            this.histogramToolMenuItem.Size = new System.Drawing.Size(155, 22);
            this.histogramToolMenuItem.Text = "Histogram Tool";
            this.histogramToolMenuItem.Click += new System.EventHandler(this.histogramToolMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "OpenCV - Vision Pro";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.m_AddToolList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button m_BtnAddTool;
        private System.Windows.Forms.Button m_RunBtn;
        private System.Windows.Forms.Button m_OpenBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip m_AddToolList;
        private System.Windows.Forms.ToolStripMenuItem blobToolMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caliperToolMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolMenuItem;
        private System.Windows.Forms.TreeView m_treeViewTools;
    }
}

