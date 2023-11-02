namespace OpenCV_Vision_Pro
{
    partial class AIForm
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
            this.openCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_GetInputImageMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openVideoFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_AddToolList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yOLOv7ObjectDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.m_BtnAddTool = new System.Windows.Forms.Button();
            this.m_OpenBtn = new System.Windows.Forms.Button();
            this.m_labelToMLDL = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m_GetInputImageMenu.SuspendLayout();
            this.m_AddToolList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openCameraToolStripMenuItem
            // 
            this.openCameraToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.camera;
            this.openCameraToolStripMenuItem.Name = "openCameraToolStripMenuItem";
            this.openCameraToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.openCameraToolStripMenuItem.Text = "Open Camera";
            this.openCameraToolStripMenuItem.Click += new System.EventHandler(this.openCamera_Click);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.folder;
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openImageFileToolStripMenuItem_Click);
            // 
            // openImageFileToolStripMenuItem
            // 
            this.openImageFileToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.file;
            this.openImageFileToolStripMenuItem.Name = "openImageFileToolStripMenuItem";
            this.openImageFileToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.openImageFileToolStripMenuItem.Text = "Open Image File";
            this.openImageFileToolStripMenuItem.Click += new System.EventHandler(this.openImageFileToolStripMenuItem_Click);
            // 
            // m_GetInputImageMenu
            // 
            this.m_GetInputImageMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageFileToolStripMenuItem,
            this.openFolderToolStripMenuItem,
            this.openVideoFileToolStripMenuItem,
            this.openCameraToolStripMenuItem});
            this.m_GetInputImageMenu.Name = "m_GetInputImageMenu";
            this.m_GetInputImageMenu.Size = new System.Drawing.Size(161, 92);
            // 
            // openVideoFileToolStripMenuItem
            // 
            this.openVideoFileToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.video;
            this.openVideoFileToolStripMenuItem.Name = "openVideoFileToolStripMenuItem";
            this.openVideoFileToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.openVideoFileToolStripMenuItem.Text = "Open Video File";
            this.openVideoFileToolStripMenuItem.Click += new System.EventHandler(this.openVideoFileToolStripMenuItem_Click);
            // 
            // m_AddToolList
            // 
            this.m_AddToolList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yOLOv7ObjectDetectionToolStripMenuItem});
            this.m_AddToolList.Name = "contextMenuStrip1";
            this.m_AddToolList.Size = new System.Drawing.Size(210, 26);
            // 
            // yOLOv7ObjectDetectionToolStripMenuItem
            // 
            this.yOLOv7ObjectDetectionToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.yolo;
            this.yOLOv7ObjectDetectionToolStripMenuItem.Name = "yOLOv7ObjectDetectionToolStripMenuItem";
            this.yOLOv7ObjectDetectionToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.yOLOv7ObjectDetectionToolStripMenuItem.Text = "YOLOv7 Object Detection";
            this.yOLOv7ObjectDetectionToolStripMenuItem.Click += new System.EventHandler(this.yOLOv7ObjectDetectionToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 35);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.splitContainer1.Size = new System.Drawing.Size(778, 423);
            this.splitContainer1.SplitterDistance = 257;
            this.splitContainer1.TabIndex = 3;
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(784, 461);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.m_BtnAddTool);
            this.flowLayoutPanel1.Controls.Add(this.m_OpenBtn);
            this.flowLayoutPanel1.Controls.Add(this.m_labelToMLDL);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(784, 32);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // m_BtnAddTool
            // 
            this.m_BtnAddTool.AutoSize = true;
            this.m_BtnAddTool.Image = global::OpenCV_Vision_Pro.Properties.Resources.tool;
            this.m_BtnAddTool.Location = new System.Drawing.Point(3, 3);
            this.m_BtnAddTool.Name = "m_BtnAddTool";
            this.m_BtnAddTool.Size = new System.Drawing.Size(80, 26);
            this.m_BtnAddTool.TabIndex = 3;
            this.m_BtnAddTool.Text = "Add Tool";
            this.m_BtnAddTool.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_BtnAddTool.UseVisualStyleBackColor = true;
            this.m_BtnAddTool.Click += new System.EventHandler(this.m_BtnAddTool_Click);
            // 
            // m_OpenBtn
            // 
            this.m_OpenBtn.AutoSize = true;
            this.m_OpenBtn.Image = global::OpenCV_Vision_Pro.Properties.Resources.open;
            this.m_OpenBtn.Location = new System.Drawing.Point(89, 3);
            this.m_OpenBtn.Name = "m_OpenBtn";
            this.m_OpenBtn.Size = new System.Drawing.Size(75, 26);
            this.m_OpenBtn.TabIndex = 1;
            this.m_OpenBtn.Text = "Open";
            this.m_OpenBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_OpenBtn.UseVisualStyleBackColor = true;
            this.m_OpenBtn.Click += new System.EventHandler(this.m_OpenBtn_Click);
            // 
            // m_labelToMLDL
            // 
            this.m_labelToMLDL.AutoSize = true;
            this.m_labelToMLDL.Image = global::OpenCV_Vision_Pro.Properties.Resources.opencv;
            this.m_labelToMLDL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_labelToMLDL.Location = new System.Drawing.Point(170, 3);
            this.m_labelToMLDL.Margin = new System.Windows.Forms.Padding(3);
            this.m_labelToMLDL.Name = "m_labelToMLDL";
            this.m_labelToMLDL.Padding = new System.Windows.Forms.Padding(5);
            this.m_labelToMLDL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_labelToMLDL.Size = new System.Drawing.Size(67, 23);
            this.m_labelToMLDL.TabIndex = 7;
            this.m_labelToMLDL.TabStop = true;
            this.m_labelToMLDL.Text = "     CVision";
            this.m_labelToMLDL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_labelToMLDL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_labelToMLDL_LinkClicked);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(0, 461);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // AIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "AIForm";
            this.Text = "AIForm";
            this.m_GetInputImageMenu.ResumeLayout(false);
            this.m_AddToolList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem openCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImageFileToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip m_GetInputImageMenu;
        private System.Windows.Forms.ToolStripMenuItem openVideoFileToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip m_AddToolList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button m_BtnAddTool;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem yOLOv7ObjectDetectionToolStripMenuItem;
        private System.Windows.Forms.Button m_OpenBtn;
        private System.Windows.Forms.LinkLabel m_labelToMLDL;
    }
}