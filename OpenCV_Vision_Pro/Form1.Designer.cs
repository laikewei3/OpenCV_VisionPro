using OpenCV_Vision_Pro.Properties;
using System.Diagnostics;

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
            this.m_AddToolList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imageToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageConvertToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageSharpenerToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polarUnwarpToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perspectiveTransformToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageProcessToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagePaintToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorSegmentorToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorMatchToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorExtractorToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blobToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caliperToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.findLineToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textRecognitionToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iDToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.imageFileToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageStackingToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageStitchingToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageBlendingToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bioInspiredToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retinexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_GetInputImageMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openImageFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openVideoFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.m_treeViewTools = new System.Windows.Forms.TreeView();
            this.m_labelToMLDL = new System.Windows.Forms.LinkLabel();
            this.m_RunBtnContinuous = new System.Windows.Forms.Button();
            this.m_OpenBtn = new System.Windows.Forms.Button();
            this.m_RunBtn = new System.Windows.Forms.Button();
            this.m_BtnAddTool = new System.Windows.Forms.Button();
            this.m_rbCameraCalibrated = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.m_labelTo3D = new System.Windows.Forms.LinkLabel();
            this.m_loopStitchLabel = new System.Windows.Forms.LinkLabel();
            this.m_AddToolList.SuspendLayout();
            this.m_GetInputImageMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(0, 561);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // m_AddToolList
            // 
            this.m_AddToolList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToolToolStripMenuItem,
            this.colorToolToolStripMenuItem,
            this.blobToolMenuItem,
            this.caliperToolMenuItem,
            this.histogramToolMenuItem,
            this.toolStripSeparator1,
            this.findLineToolToolStripMenuItem,
            this.textRecognitionToolToolStripMenuItem,
            this.iDToolToolStripMenuItem,
            this.toolStripSeparator2,
            this.imageFileToolToolStripMenuItem,
            this.toolStripSeparator3,
            this.bioInspiredToolToolStripMenuItem});
            this.m_AddToolList.Name = "contextMenuStrip1";
            this.m_AddToolList.Size = new System.Drawing.Size(188, 242);
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
            // imagePaintToolToolStripMenuItem
            // 
            this.imagePaintToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.paint;
            this.imagePaintToolToolStripMenuItem.Name = "imagePaintToolToolStripMenuItem";
            this.imagePaintToolToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.imagePaintToolToolStripMenuItem.Text = "Image Paint Tool";
            this.imagePaintToolToolStripMenuItem.Click += new System.EventHandler(this.AddToolMenuItem_Click);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(184, 6);
            // 
            // imageFileToolToolStripMenuItem
            // 
            this.imageFileToolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageStackingToolToolStripMenuItem,
            this.imageStitchingToolToolStripMenuItem,
            this.imageBlendingToolToolStripMenuItem});
            this.imageFileToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.imagefile;
            this.imageFileToolToolStripMenuItem.Name = "imageFileToolToolStripMenuItem";
            this.imageFileToolToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.imageFileToolToolStripMenuItem.Text = "Image File Tool";
            // 
            // imageStackingToolToolStripMenuItem
            // 
            this.imageStackingToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.stack;
            this.imageStackingToolToolStripMenuItem.Name = "imageStackingToolToolStripMenuItem";
            this.imageStackingToolToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.imageStackingToolToolStripMenuItem.Text = "Image Stacking Tool";
            this.imageStackingToolToolStripMenuItem.Click += new System.EventHandler(this.AddToolMenuItem_Click);
            // 
            // imageStitchingToolToolStripMenuItem
            // 
            this.imageStitchingToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.stitch;
            this.imageStitchingToolToolStripMenuItem.Name = "imageStitchingToolToolStripMenuItem";
            this.imageStitchingToolToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.imageStitchingToolToolStripMenuItem.Text = "Image Stitching Tool";
            this.imageStitchingToolToolStripMenuItem.Click += new System.EventHandler(this.AddToolMenuItem_Click);
            // 
            // imageBlendingToolToolStripMenuItem
            // 
            this.imageBlendingToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.blend;
            this.imageBlendingToolToolStripMenuItem.Name = "imageBlendingToolToolStripMenuItem";
            this.imageBlendingToolToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.imageBlendingToolToolStripMenuItem.Text = "Image Blending Tool";
            this.imageBlendingToolToolStripMenuItem.Click += new System.EventHandler(this.AddToolMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(184, 6);
            // 
            // bioInspiredToolToolStripMenuItem
            // 
            this.bioInspiredToolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.retinaToolStripMenuItem,
            this.retinexToolStripMenuItem});
            this.bioInspiredToolToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.bioinspired;
            this.bioInspiredToolToolStripMenuItem.Name = "bioInspiredToolToolStripMenuItem";
            this.bioInspiredToolToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.bioInspiredToolToolStripMenuItem.Text = "BioInspired Tool";
            // 
            // retinaToolStripMenuItem
            // 
            this.retinaToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.retina;
            this.retinaToolStripMenuItem.Name = "retinaToolStripMenuItem";
            this.retinaToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.retinaToolStripMenuItem.Text = "Retina";
            this.retinaToolStripMenuItem.Click += new System.EventHandler(this.AddToolMenuItem_Click);
            // 
            // retinexToolStripMenuItem
            // 
            this.retinexToolStripMenuItem.Image = global::OpenCV_Vision_Pro.Properties.Resources.retinex;
            this.retinexToolStripMenuItem.Name = "retinexToolStripMenuItem";
            this.retinexToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.retinexToolStripMenuItem.Text = "Retinex";
            this.retinexToolStripMenuItem.Click += new System.EventHandler(this.AddToolMenuItem_Click);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 38);
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
            this.splitContainer1.Size = new System.Drawing.Size(778, 520);
            this.splitContainer1.SplitterDistance = 258;
            this.splitContainer1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 507);
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
            this.m_treeViewTools.Size = new System.Drawing.Size(258, 520);
            this.m_treeViewTools.TabIndex = 0;
            this.m_treeViewTools.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.m_treeViewTools_NodeMouseClick);
            this.m_treeViewTools.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.m_treeViewTools_NodeMouseDoubleClick);
            this.m_treeViewTools.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_treeViewTools_DragDrop);
            this.m_treeViewTools.DragEnter += new System.Windows.Forms.DragEventHandler(this.m_treeViewTools_DragEnter);
            this.m_treeViewTools.DragOver += new System.Windows.Forms.DragEventHandler(this.m_treeViewTools_DragOver);
            // 
            // m_labelToMLDL
            // 
            this.m_labelToMLDL.Image = global::OpenCV_Vision_Pro.Properties.Resources.mldl;
            this.m_labelToMLDL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_labelToMLDL.Location = new System.Drawing.Point(351, 3);
            this.m_labelToMLDL.Margin = new System.Windows.Forms.Padding(3);
            this.m_labelToMLDL.Name = "m_labelToMLDL";
            this.m_labelToMLDL.Padding = new System.Windows.Forms.Padding(5);
            this.m_labelToMLDL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_labelToMLDL.Size = new System.Drawing.Size(80, 26);
            this.m_labelToMLDL.TabIndex = 5;
            this.m_labelToMLDL.TabStop = true;
            this.m_labelToMLDL.Text = "       ML/ DL";
            this.m_labelToMLDL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_labelToMLDL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_labelToMLDL_LinkClicked);
            // 
            // m_RunBtnContinuous
            // 
            this.m_RunBtnContinuous.AutoSize = true;
            this.m_RunBtnContinuous.Image = global::OpenCV_Vision_Pro.Properties.Resources.continuous;
            this.m_RunBtnContinuous.Location = new System.Drawing.Point(261, 3);
            this.m_RunBtnContinuous.Name = "m_RunBtnContinuous";
            this.m_RunBtnContinuous.Size = new System.Drawing.Size(84, 26);
            this.m_RunBtnContinuous.TabIndex = 4;
            this.m_RunBtnContinuous.Text = "Run Loop";
            this.m_RunBtnContinuous.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_RunBtnContinuous.UseVisualStyleBackColor = true;
            this.m_RunBtnContinuous.MouseClick += new System.Windows.Forms.MouseEventHandler(this.m_RunBtnContinuous_MouseClick);
            // 
            // m_OpenBtn
            // 
            this.m_OpenBtn.AutoSize = true;
            this.m_OpenBtn.Image = global::OpenCV_Vision_Pro.Properties.Resources.open;
            this.m_OpenBtn.Location = new System.Drawing.Point(89, 3);
            this.m_OpenBtn.Name = "m_OpenBtn";
            this.m_OpenBtn.Size = new System.Drawing.Size(80, 26);
            this.m_OpenBtn.TabIndex = 1;
            this.m_OpenBtn.Text = "Open";
            this.m_OpenBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_OpenBtn.UseVisualStyleBackColor = true;
            this.m_OpenBtn.Click += new System.EventHandler(this.m_OpenBtn_Click);
            // 
            // m_RunBtn
            // 
            this.m_RunBtn.AutoSize = true;
            this.m_RunBtn.Image = global::OpenCV_Vision_Pro.Properties.Resources.run;
            this.m_RunBtn.Location = new System.Drawing.Point(175, 3);
            this.m_RunBtn.Name = "m_RunBtn";
            this.m_RunBtn.Size = new System.Drawing.Size(80, 26);
            this.m_RunBtn.TabIndex = 0;
            this.m_RunBtn.Text = "Run";
            this.m_RunBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_RunBtn.UseVisualStyleBackColor = true;
            this.m_RunBtn.Click += new System.EventHandler(this.m_RunBtn_Click);
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
            // m_rbCameraCalibrated
            // 
            this.m_rbCameraCalibrated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_rbCameraCalibrated.Location = new System.Drawing.Point(664, 5);
            this.m_rbCameraCalibrated.Margin = new System.Windows.Forms.Padding(5);
            this.m_rbCameraCalibrated.Name = "m_rbCameraCalibrated";
            this.m_rbCameraCalibrated.Size = new System.Drawing.Size(115, 28);
            this.m_rbCameraCalibrated.TabIndex = 6;
            this.m_rbCameraCalibrated.TabStop = true;
            this.m_rbCameraCalibrated.Text = "Camera Calibrated";
            this.m_rbCameraCalibrated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_rbCameraCalibrated.UseVisualStyleBackColor = true;
            this.m_rbCameraCalibrated.CheckedChanged += new System.EventHandler(this.m_rbCameraCalibrated_CheckedChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.m_rbCameraCalibrated, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(784, 35);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 7;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel4.Controls.Add(this.m_labelToMLDL, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.m_RunBtnContinuous, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.m_BtnAddTool, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.m_labelTo3D, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.m_RunBtn, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.m_OpenBtn, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.m_loopStitchLabel, 6, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(644, 32);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // m_labelTo3D
            // 
            this.m_labelTo3D.Image = global::OpenCV_Vision_Pro.Properties.Resources._3d;
            this.m_labelTo3D.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_labelTo3D.Location = new System.Drawing.Point(437, 3);
            this.m_labelTo3D.Margin = new System.Windows.Forms.Padding(3);
            this.m_labelTo3D.Name = "m_labelTo3D";
            this.m_labelTo3D.Padding = new System.Windows.Forms.Padding(5);
            this.m_labelTo3D.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_labelTo3D.Size = new System.Drawing.Size(80, 26);
            this.m_labelTo3D.TabIndex = 6;
            this.m_labelTo3D.TabStop = true;
            this.m_labelTo3D.Text = "     Python3D";
            this.m_labelTo3D.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_labelTo3D.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_labelTo3D_LinkClicked);
            // 
            // m_loopStitchLabel
            // 
            this.m_loopStitchLabel.Image = global::OpenCV_Vision_Pro.Properties.Resources.stitch;
            this.m_loopStitchLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_loopStitchLabel.Location = new System.Drawing.Point(523, 3);
            this.m_loopStitchLabel.Margin = new System.Windows.Forms.Padding(3);
            this.m_loopStitchLabel.Name = "m_loopStitchLabel";
            this.m_loopStitchLabel.Padding = new System.Windows.Forms.Padding(5);
            this.m_loopStitchLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_loopStitchLabel.Size = new System.Drawing.Size(101, 26);
            this.m_loopStitchLabel.TabIndex = 7;
            this.m_loopStitchLabel.TabStop = true;
            this.m_loopStitchLabel.Text = "       Loop Stitch";
            this.m_loopStitchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_loopStitchLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_loopStitchLabel_LinkClicked);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.m_AddToolList.ResumeLayout(false);
            this.m_GetInputImageMenu.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ContextMenuStrip m_AddToolList;
        private System.Windows.Forms.ToolStripMenuItem blobToolMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caliperToolMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem polarUnwarpToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem perspectiveTransformToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textRecognitionToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageProcessToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iDToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imagePaintToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView m_treeViewTools;
        private System.Windows.Forms.Button m_BtnAddTool;
        private System.Windows.Forms.Button m_RunBtn;
        private System.Windows.Forms.Button m_OpenBtn;
        private System.Windows.Forms.Button m_RunBtnContinuous;
        private System.Windows.Forms.LinkLabel m_labelToMLDL;
        private System.Windows.Forms.RadioButton m_rbCameraCalibrated;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.LinkLabel m_labelTo3D;
        private System.Windows.Forms.ToolStripMenuItem imageFileToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageStackingToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageStitchingToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageBlendingToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem bioInspiredToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retinaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retinexToolStripMenuItem;
        private System.Windows.Forms.LinkLabel m_loopStitchLabel;
    }
}

