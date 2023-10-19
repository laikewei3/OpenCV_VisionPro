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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.m_BtnAddTool = new System.Windows.Forms.Button();
            this.m_RunBtn = new System.Windows.Forms.Button();
            this.m_OpenBtn = new System.Windows.Forms.Button();
            this.m_RunBtnContinuous = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_treeViewTools = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_AddToolList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.blobToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caliperToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageConvertToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorSegmentorToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorMatchToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorExtractorToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mLDLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yOLOv7ObjectDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_GetInputImageMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openImageFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openVideoFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findLineToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.m_AddToolList.SuspendLayout();
            this.m_GetInputImageMenu.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(0, 561);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.m_BtnAddTool);
            this.flowLayoutPanel1.Controls.Add(this.m_RunBtn);
            this.flowLayoutPanel1.Controls.Add(this.m_OpenBtn);
            this.flowLayoutPanel1.Controls.Add(this.m_RunBtnContinuous);
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
            this.m_BtnAddTool.Image = ((System.Drawing.Image)(resources.GetObject("m_BtnAddTool.Image")));
            this.m_BtnAddTool.Location = new System.Drawing.Point(3, 3);
            this.m_BtnAddTool.Name = "m_BtnAddTool";
            this.m_BtnAddTool.Size = new System.Drawing.Size(80, 26);
            this.m_BtnAddTool.TabIndex = 3;
            this.m_BtnAddTool.Text = "Add Tool";
            this.m_BtnAddTool.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_BtnAddTool.UseVisualStyleBackColor = true;
            this.m_BtnAddTool.Click += new System.EventHandler(this.m_BtnAddTool_Click);
            // 
            // m_RunBtn
            // 
            this.m_RunBtn.AutoSize = true;
            this.m_RunBtn.Image = ((System.Drawing.Image)(resources.GetObject("m_RunBtn.Image")));
            this.m_RunBtn.Location = new System.Drawing.Point(89, 3);
            this.m_RunBtn.Name = "m_RunBtn";
            this.m_RunBtn.Size = new System.Drawing.Size(75, 26);
            this.m_RunBtn.TabIndex = 0;
            this.m_RunBtn.Text = "Run";
            this.m_RunBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_RunBtn.UseVisualStyleBackColor = true;
            this.m_RunBtn.Click += new System.EventHandler(this.m_RunBtn_Click);
            // 
            // m_OpenBtn
            // 
            this.m_OpenBtn.AutoSize = true;
            this.m_OpenBtn.Image = ((System.Drawing.Image)(resources.GetObject("m_OpenBtn.Image")));
            this.m_OpenBtn.Location = new System.Drawing.Point(170, 3);
            this.m_OpenBtn.Name = "m_OpenBtn";
            this.m_OpenBtn.Size = new System.Drawing.Size(75, 26);
            this.m_OpenBtn.TabIndex = 1;
            this.m_OpenBtn.Text = "Open";
            this.m_OpenBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_OpenBtn.UseVisualStyleBackColor = true;
            this.m_OpenBtn.Click += new System.EventHandler(this.m_OpenBtn_Click);
            // 
            // m_RunBtnContinuous
            // 
            this.m_RunBtnContinuous.AutoSize = true;
            this.m_RunBtnContinuous.Image = ((System.Drawing.Image)(resources.GetObject("m_RunBtnContinuous.Image")));
            this.m_RunBtnContinuous.Location = new System.Drawing.Point(251, 3);
            this.m_RunBtnContinuous.Name = "m_RunBtnContinuous";
            this.m_RunBtnContinuous.Size = new System.Drawing.Size(113, 26);
            this.m_RunBtnContinuous.TabIndex = 4;
            this.m_RunBtnContinuous.Text = "Run Continuous";
            this.m_RunBtnContinuous.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_RunBtnContinuous.UseVisualStyleBackColor = true;
            this.m_RunBtnContinuous.MouseClick += new System.Windows.Forms.MouseEventHandler(this.m_RunBtnContinuous_MouseClick);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanel2.TabIndex = 4;
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
            this.splitContainer1.Panel1.Controls.Add(this.m_treeViewTools);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.splitContainer1.Size = new System.Drawing.Size(778, 523);
            this.splitContainer1.SplitterDistance = 258;
            this.splitContainer1.TabIndex = 3;
            // 
            // m_treeViewTools
            // 
            this.m_treeViewTools.AllowDrop = true;
            this.m_treeViewTools.BackColor = System.Drawing.SystemColors.ControlLight;
            this.m_treeViewTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_treeViewTools.ImageIndex = 0;
            this.m_treeViewTools.ImageList = this.imageList1;
            this.m_treeViewTools.Location = new System.Drawing.Point(0, 0);
            this.m_treeViewTools.Name = "m_treeViewTools";
            this.m_treeViewTools.SelectedImageIndex = 0;
            this.m_treeViewTools.Size = new System.Drawing.Size(258, 523);
            this.m_treeViewTools.TabIndex = 0;
            this.m_treeViewTools.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.m_treeViewTools_NodeMouseClick);
            this.m_treeViewTools.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.m_treeViewTools_NodeMouseDoubleClick);
            this.m_treeViewTools.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_treeViewTools_DragDrop);
            this.m_treeViewTools.DragEnter += new System.Windows.Forms.DragEventHandler(this.m_treeViewTools_DragEnter);
            this.m_treeViewTools.DragOver += new System.Windows.Forms.DragEventHandler(this.m_treeViewTools_DragOver);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "blob.png");
            this.imageList1.Images.SetKeyName(1, "caliper.png");
            this.imageList1.Images.SetKeyName(2, "histogram.png");
            this.imageList1.Images.SetKeyName(3, "convert.png");
            this.imageList1.Images.SetKeyName(4, "segmentor.png");
            this.imageList1.Images.SetKeyName(5, "match.png");
            this.imageList1.Images.SetKeyName(6, "extractor.png");
            // 
            // m_AddToolList
            // 
            this.m_AddToolList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blobToolMenuItem,
            this.caliperToolMenuItem,
            this.histogramToolMenuItem,
            this.findLineToolToolStripMenuItem,
            this.imageConvertToolToolStripMenuItem,
            this.colorToolToolStripMenuItem,
            this.mLDLToolStripMenuItem});
            this.m_AddToolList.Name = "contextMenuStrip1";
            this.m_AddToolList.Size = new System.Drawing.Size(181, 180);
            // 
            // blobToolMenuItem
            // 
            this.blobToolMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("blobToolMenuItem.Image")));
            this.blobToolMenuItem.Name = "blobToolMenuItem";
            this.blobToolMenuItem.Size = new System.Drawing.Size(180, 22);
            this.blobToolMenuItem.Text = "Blob Tool";
            this.blobToolMenuItem.Click += new System.EventHandler(this.blobToolMenuItem_Click);
            // 
            // caliperToolMenuItem
            // 
            this.caliperToolMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("caliperToolMenuItem.Image")));
            this.caliperToolMenuItem.Name = "caliperToolMenuItem";
            this.caliperToolMenuItem.Size = new System.Drawing.Size(180, 22);
            this.caliperToolMenuItem.Text = "Caliper Tool";
            this.caliperToolMenuItem.Click += new System.EventHandler(this.caliperToolMenuItem_Click);
            // 
            // histogramToolMenuItem
            // 
            this.histogramToolMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("histogramToolMenuItem.Image")));
            this.histogramToolMenuItem.Name = "histogramToolMenuItem";
            this.histogramToolMenuItem.Size = new System.Drawing.Size(180, 22);
            this.histogramToolMenuItem.Text = "Histogram Tool";
            this.histogramToolMenuItem.Click += new System.EventHandler(this.histogramToolMenuItem_Click);
            // 
            // imageConvertToolToolStripMenuItem
            // 
            this.imageConvertToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.convert;
            this.imageConvertToolToolStripMenuItem.Name = "imageConvertToolToolStripMenuItem";
            this.imageConvertToolToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.imageConvertToolToolStripMenuItem.Text = "Image Convert Tool";
            this.imageConvertToolToolStripMenuItem.Click += new System.EventHandler(this.imageConvertToolToolStripMenuItem_Click);
            // 
            // colorToolToolStripMenuItem
            // 
            this.colorToolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorSegmentorToolToolStripMenuItem,
            this.colorMatchToolToolStripMenuItem,
            this.colorExtractorToolToolStripMenuItem});
            this.colorToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.color1;
            this.colorToolToolStripMenuItem.Name = "colorToolToolStripMenuItem";
            this.colorToolToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.colorToolToolStripMenuItem.Text = "Color Tool";
            // 
            // colorSegmentorToolToolStripMenuItem
            // 
            this.colorSegmentorToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.segmentor;
            this.colorSegmentorToolToolStripMenuItem.Name = "colorSegmentorToolToolStripMenuItem";
            this.colorSegmentorToolToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.colorSegmentorToolToolStripMenuItem.Text = "Color Segmentor Tool";
            this.colorSegmentorToolToolStripMenuItem.Click += new System.EventHandler(this.colorSegmentorToolToolStripMenuItem_Click);
            // 
            // colorMatchToolToolStripMenuItem
            // 
            this.colorMatchToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.match;
            this.colorMatchToolToolStripMenuItem.Name = "colorMatchToolToolStripMenuItem";
            this.colorMatchToolToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.colorMatchToolToolStripMenuItem.Text = "Color Match Tool";
            this.colorMatchToolToolStripMenuItem.Click += new System.EventHandler(this.colorMatchToolToolStripMenuItem_Click);
            // 
            // colorExtractorToolToolStripMenuItem
            // 
            this.colorExtractorToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.extractor;
            this.colorExtractorToolToolStripMenuItem.Name = "colorExtractorToolToolStripMenuItem";
            this.colorExtractorToolToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.colorExtractorToolToolStripMenuItem.Text = "Color Extractor Tool";
            this.colorExtractorToolToolStripMenuItem.Click += new System.EventHandler(this.colorExtractorToolToolStripMenuItem_Click);
            // 
            // mLDLToolStripMenuItem
            // 
            this.mLDLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yOLOv7ObjectDetectionToolStripMenuItem});
            this.mLDLToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.mldl;
            this.mLDLToolStripMenuItem.Name = "mLDLToolStripMenuItem";
            this.mLDLToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mLDLToolStripMenuItem.Text = "ML/DL";
            // 
            // yOLOv7ObjectDetectionToolStripMenuItem
            // 
            this.yOLOv7ObjectDetectionToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.yolo;
            this.yOLOv7ObjectDetectionToolStripMenuItem.Name = "yOLOv7ObjectDetectionToolStripMenuItem";
            this.yOLOv7ObjectDetectionToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.yOLOv7ObjectDetectionToolStripMenuItem.Text = "YOLOv7 Object Detection";
            this.yOLOv7ObjectDetectionToolStripMenuItem.Click += new System.EventHandler(this.yOLOv7ObjectDetectionToolStripMenuItem_Click);
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
            // openImageFileToolStripMenuItem
            // 
            this.openImageFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openImageFileToolStripMenuItem.Image")));
            this.openImageFileToolStripMenuItem.Name = "openImageFileToolStripMenuItem";
            this.openImageFileToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.openImageFileToolStripMenuItem.Text = "Open Image File";
            this.openImageFileToolStripMenuItem.Click += new System.EventHandler(this.openImageFileToolStripMenuItem_Click);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.folder;
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openImageFileToolStripMenuItem_Click);
            // 
            // openVideoFileToolStripMenuItem
            // 
            this.openVideoFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openVideoFileToolStripMenuItem.Image")));
            this.openVideoFileToolStripMenuItem.Name = "openVideoFileToolStripMenuItem";
            this.openVideoFileToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.openVideoFileToolStripMenuItem.Text = "Open Video File";
            this.openVideoFileToolStripMenuItem.Click += new System.EventHandler(this.openVideoFileToolStripMenuItem_Click);
            // 
            // openCameraToolStripMenuItem
            // 
            this.openCameraToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openCameraToolStripMenuItem.Image")));
            this.openCameraToolStripMenuItem.Name = "openCameraToolStripMenuItem";
            this.openCameraToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.openCameraToolStripMenuItem.Text = "Open Camera";
            // 
            // findLineToolToolStripMenuItem
            // 
            this.findLineToolToolStripMenuItem.Name = "findLineToolToolStripMenuItem";
            this.findLineToolToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.findLineToolToolStripMenuItem.Text = "Find Line Tool";
            this.findLineToolToolStripMenuItem.Click += new System.EventHandler(this.findLineToolToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "OpenCV - Vision Pro";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.m_AddToolList.ResumeLayout(false);
            this.m_GetInputImageMenu.ResumeLayout(false);
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
        private System.Windows.Forms.Button m_RunBtnContinuous;
        private System.Windows.Forms.ContextMenuStrip m_GetInputImageMenu;
        private System.Windows.Forms.ToolStripMenuItem openImageFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openVideoFileToolStripMenuItem;
        public System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem imageConvertToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorSegmentorToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorMatchToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorExtractorToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mLDLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yOLOv7ObjectDetectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findLineToolToolStripMenuItem;
    }
}

