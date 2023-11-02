using OpenCV_Vision_Pro.Properties;

namespace OpenCV_Vision_Pro
{
    public partial class Form1
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
            this.m_RunBtnContinuous = new System.Windows.Forms.Button();
            this.m_labelToMLDL = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.m_treeViewTools = new System.Windows.Forms.TreeView();
            this.m_AddToolList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imageToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageConvertToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageSharpenerToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polarUnwarpToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perspectiveTransformToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageProcessToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorSegmentorToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorMatchToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorExtractorToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blobToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caliperToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findLineToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textRecognitionToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iDToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_GetInputImageMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openImageFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openVideoFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagePaintToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            // m_RunBtn
            // 
            this.m_RunBtn.AutoSize = true;
            this.m_RunBtn.Image = global::OpenCV_Vision_Pro.Properties.Resources.run;
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
            this.m_OpenBtn.Image = global::OpenCV_Vision_Pro.Properties.Resources.open;
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
            this.m_RunBtnContinuous.Image = global::OpenCV_Vision_Pro.Properties.Resources.continuous;
            this.m_RunBtnContinuous.Location = new System.Drawing.Point(251, 3);
            this.m_RunBtnContinuous.Name = "m_RunBtnContinuous";
            this.m_RunBtnContinuous.Size = new System.Drawing.Size(113, 26);
            this.m_RunBtnContinuous.TabIndex = 4;
            this.m_RunBtnContinuous.Text = "Run Continuous";
            this.m_RunBtnContinuous.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_RunBtnContinuous.UseVisualStyleBackColor = true;
            this.m_RunBtnContinuous.MouseClick += new System.Windows.Forms.MouseEventHandler(this.m_RunBtnContinuous_MouseClick);
            // 
            // m_labelToMLDL
            // 
            this.m_labelToMLDL.AutoSize = true;
            this.m_labelToMLDL.Image = global::OpenCV_Vision_Pro.Properties.Resources.mldl;
            this.m_labelToMLDL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_labelToMLDL.Location = new System.Drawing.Point(370, 3);
            this.m_labelToMLDL.Margin = new System.Windows.Forms.Padding(3);
            this.m_labelToMLDL.Name = "m_labelToMLDL";
            this.m_labelToMLDL.Padding = new System.Windows.Forms.Padding(5);
            this.m_labelToMLDL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_labelToMLDL.Size = new System.Drawing.Size(75, 23);
            this.m_labelToMLDL.TabIndex = 5;
            this.m_labelToMLDL.TabStop = true;
            this.m_labelToMLDL.Text = "       ML/ DL";
            this.m_labelToMLDL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_labelToMLDL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_labelToMLDL_LinkClicked);
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
            this.splitContainer1.Panel1.Controls.Add(this.label1);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 510);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // m_treeViewTools
            // 
            this.m_treeViewTools.AllowDrop = true;
            this.m_treeViewTools.BackColor = System.Drawing.SystemColors.ControlLight;
            this.m_treeViewTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_treeViewTools.Location = new System.Drawing.Point(0, 0);
            this.m_treeViewTools.Name = "m_treeViewTools";
            this.m_treeViewTools.Size = new System.Drawing.Size(258, 523);
            this.m_treeViewTools.TabIndex = 0;
            this.m_treeViewTools.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.m_treeViewTools_NodeMouseClick);
            this.m_treeViewTools.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.m_treeViewTools_NodeMouseDoubleClick);
            this.m_treeViewTools.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_treeViewTools_DragDrop);
            this.m_treeViewTools.DragEnter += new System.Windows.Forms.DragEventHandler(this.m_treeViewTools_DragEnter);
            this.m_treeViewTools.DragOver += new System.Windows.Forms.DragEventHandler(this.m_treeViewTools_DragOver);
            // 
            // m_AddToolList
            // 
            this.m_AddToolList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToolToolStripMenuItem,
            this.colorToolToolStripMenuItem,
            this.blobToolMenuItem,
            this.caliperToolMenuItem,
            this.histogramToolMenuItem,
            this.findLineToolToolStripMenuItem,
            this.textRecognitionToolToolStripMenuItem,
            this.iDToolToolStripMenuItem});
            this.m_AddToolList.Name = "contextMenuStrip1";
            this.m_AddToolList.Size = new System.Drawing.Size(188, 202);
            // 
            // imageToolToolStripMenuItem
            // 
            this.imageToolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageConvertToolToolStripMenuItem,
            this.imageSharpenerToolToolStripMenuItem,
            this.polarUnwarpToolToolStripMenuItem,
            this.perspectiveTransformToolToolStripMenuItem,
            this.imageProcessToolToolStripMenuItem,
            this.imagePaintToolToolStripMenuItem});
            this.imageToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.image;
            this.imageToolToolStripMenuItem.Name = "imageToolToolStripMenuItem";
            this.imageToolToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.imageToolToolStripMenuItem.Text = "Image Tool";
            // 
            // imageConvertToolToolStripMenuItem
            // 
            this.imageConvertToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.convert;
            this.imageConvertToolToolStripMenuItem.Name = "imageConvertToolToolStripMenuItem";
            this.imageConvertToolToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.imageConvertToolToolStripMenuItem.Text = "Image Convert Tool";
            this.imageConvertToolToolStripMenuItem.Click += new System.EventHandler(this.AddToolMenuItem_Click);
            // 
            // imageSharpenerToolToolStripMenuItem
            // 
            this.imageSharpenerToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.editor;
            this.imageSharpenerToolToolStripMenuItem.Name = "imageSharpenerToolToolStripMenuItem";
            this.imageSharpenerToolToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.imageSharpenerToolToolStripMenuItem.Text = "Image Sharpener Tool";
            this.imageSharpenerToolToolStripMenuItem.Click += new System.EventHandler(this.AddToolMenuItem_Click);
            // 
            // polarUnwarpToolToolStripMenuItem
            // 
            this.polarUnwarpToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.polarUnwrap;
            this.polarUnwarpToolToolStripMenuItem.Name = "polarUnwarpToolToolStripMenuItem";
            this.polarUnwarpToolToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.polarUnwarpToolToolStripMenuItem.Text = "Polar Unwarp Tool";
            this.polarUnwarpToolToolStripMenuItem.Click += new System.EventHandler(this.AddToolMenuItem_Click);
            // 
            // perspectiveTransformToolToolStripMenuItem
            // 
            this.perspectiveTransformToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.transform;
            this.perspectiveTransformToolToolStripMenuItem.Name = "perspectiveTransformToolToolStripMenuItem";
            this.perspectiveTransformToolToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.perspectiveTransformToolToolStripMenuItem.Text = "Perspective Transform Tool";
            this.perspectiveTransformToolToolStripMenuItem.Click += new System.EventHandler(this.AddToolMenuItem_Click);
            // 
            // imageProcessToolToolStripMenuItem
            // 
            this.imageProcessToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.process;
            this.imageProcessToolToolStripMenuItem.Name = "imageProcessToolToolStripMenuItem";
            this.imageProcessToolToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.imageProcessToolToolStripMenuItem.Text = "Image Process Tool";
            this.imageProcessToolToolStripMenuItem.Click += new System.EventHandler(this.AddToolMenuItem_Click);
            // 
            // colorToolToolStripMenuItem
            // 
            this.colorToolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorSegmentorToolToolStripMenuItem,
            this.colorMatchToolToolStripMenuItem,
            this.colorExtractorToolToolStripMenuItem});
            this.colorToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.color;
            this.colorToolToolStripMenuItem.Name = "colorToolToolStripMenuItem";
            this.colorToolToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.colorToolToolStripMenuItem.Text = "Color Tool";
            // 
            // colorSegmentorToolToolStripMenuItem
            // 
            this.colorSegmentorToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.segmentor;
            this.colorSegmentorToolToolStripMenuItem.Name = "colorSegmentorToolToolStripMenuItem";
            this.colorSegmentorToolToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.colorSegmentorToolToolStripMenuItem.Text = "Color Segmentor Tool";
            this.colorSegmentorToolToolStripMenuItem.Click += new System.EventHandler(this.AddToolMenuItem_Click);
            // 
            // colorMatchToolToolStripMenuItem
            // 
            this.colorMatchToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.match;
            this.colorMatchToolToolStripMenuItem.Name = "colorMatchToolToolStripMenuItem";
            this.colorMatchToolToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.colorMatchToolToolStripMenuItem.Text = "Color Match Tool";
            this.colorMatchToolToolStripMenuItem.Click += new System.EventHandler(this.AddToolMenuItem_Click);
            // 
            // colorExtractorToolToolStripMenuItem
            // 
            this.colorExtractorToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.extractor;
            this.colorExtractorToolToolStripMenuItem.Name = "colorExtractorToolToolStripMenuItem";
            this.colorExtractorToolToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.colorExtractorToolToolStripMenuItem.Text = "Color Extractor Tool";
            this.colorExtractorToolToolStripMenuItem.Click += new System.EventHandler(this.AddToolMenuItem_Click);
            // 
            // blobToolMenuItem
            // 
            this.blobToolMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.blob;
            this.blobToolMenuItem.Name = "blobToolMenuItem";
            this.blobToolMenuItem.Size = new System.Drawing.Size(187, 22);
            this.blobToolMenuItem.Text = "Blob Tool";
            this.blobToolMenuItem.Click += new System.EventHandler(this.AddToolMenuItem_Click);
            // 
            // caliperToolMenuItem
            // 
            this.caliperToolMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.caliper;
            this.caliperToolMenuItem.Name = "caliperToolMenuItem";
            this.caliperToolMenuItem.Size = new System.Drawing.Size(187, 22);
            this.caliperToolMenuItem.Text = "Caliper Tool";
            this.caliperToolMenuItem.Click += new System.EventHandler(this.AddToolMenuItem_Click);
            // 
            // histogramToolMenuItem
            // 
            this.histogramToolMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.histogram;
            this.histogramToolMenuItem.Name = "histogramToolMenuItem";
            this.histogramToolMenuItem.Size = new System.Drawing.Size(187, 22);
            this.histogramToolMenuItem.Text = "Histogram Tool";
            this.histogramToolMenuItem.Click += new System.EventHandler(this.AddToolMenuItem_Click);
            // 
            // findLineToolToolStripMenuItem
            // 
            this.findLineToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.line;
            this.findLineToolToolStripMenuItem.Name = "findLineToolToolStripMenuItem";
            this.findLineToolToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.findLineToolToolStripMenuItem.Text = "Find Line Tool";
            this.findLineToolToolStripMenuItem.Click += new System.EventHandler(this.AddToolMenuItem_Click);
            // 
            // textRecognitionToolToolStripMenuItem
            // 
            this.textRecognitionToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.ocr;
            this.textRecognitionToolToolStripMenuItem.Name = "textRecognitionToolToolStripMenuItem";
            this.textRecognitionToolToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.textRecognitionToolToolStripMenuItem.Text = "Text Recognition Tool";
            this.textRecognitionToolToolStripMenuItem.Click += new System.EventHandler(this.AddToolMenuItem_Click);
            // 
            // iDToolToolStripMenuItem
            // 
            this.iDToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.id;
            this.iDToolToolStripMenuItem.Name = "iDToolToolStripMenuItem";
            this.iDToolToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.iDToolToolStripMenuItem.Text = "ID Tool";
            this.iDToolToolStripMenuItem.Click += new System.EventHandler(this.AddToolMenuItem_Click);
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
            this.openImageFileToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.file;
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
            this.openVideoFileToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.video;
            this.openVideoFileToolStripMenuItem.Name = "openVideoFileToolStripMenuItem";
            this.openVideoFileToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.openVideoFileToolStripMenuItem.Text = "Open Video File";
            this.openVideoFileToolStripMenuItem.Click += new System.EventHandler(this.openVideoFileToolStripMenuItem_Click);
            // 
            // openCameraToolStripMenuItem
            // 
            this.openCameraToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.camera;
            this.openCameraToolStripMenuItem.Name = "openCameraToolStripMenuItem";
            this.openCameraToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.openCameraToolStripMenuItem.Text = "Open Camera";
            // 
            // imagePaintToolToolStripMenuItem
            // 
            this.imagePaintToolToolStripMenuItem.Name = "imagePaintToolToolStripMenuItem";
            this.imagePaintToolToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.imagePaintToolToolStripMenuItem.Text = "Image Paint Tool";
            this.imagePaintToolToolStripMenuItem.Click += new System.EventHandler(this.AddToolMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = global::OpenCV_Vision_Pro.Properties.Resources.vision;
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
            this.splitContainer1.Panel1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem colorToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorSegmentorToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorMatchToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorExtractorToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findLineToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageConvertToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageSharpenerToolToolStripMenuItem;
        private System.Windows.Forms.LinkLabel m_labelToMLDL;
        private System.Windows.Forms.ToolStripMenuItem polarUnwarpToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem perspectiveTransformToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textRecognitionToolToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem imageProcessToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iDToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imagePaintToolToolStripMenuItem;
    }
}

