﻿using Emgu.CV;
using System.Drawing;

namespace OpenCV_Vision_Pro
{
    partial class DisplayControl
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
            m_VideoCapture?.Dispose();
            m_bitmapList?.Dispose();
            m_roi?.Dispose(); 

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayControl));
            this.m_cbImages = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_display = new Emgu.CV.UI.ImageBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_labelTotalTime = new System.Windows.Forms.Label();
            this.m_labelCurrentTime = new System.Windows.Forms.Label();
            this.m_playPauseButton = new System.Windows.Forms.Button();
            this.m_trackBarVideoDuration = new System.Windows.Forms.TrackBar();
            this.m_toolTipTrackBar = new System.Windows.Forms.ToolTip(this.components);
            this.m_panelContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDisplayInNewWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_display)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_trackBarVideoDuration)).BeginInit();
            this.m_panelContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_cbImages
            // 
            this.m_cbImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_cbImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbImages.FormattingEnabled = true;
            this.m_cbImages.Location = new System.Drawing.Point(3, 3);
            this.m_cbImages.Name = "m_cbImages";
            this.m_cbImages.Size = new System.Drawing.Size(522, 21);
            this.m_cbImages.TabIndex = 7;
            this.m_cbImages.SelectedIndexChanged += new System.EventHandler(this.m_cbImages_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.m_cbImages, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(528, 463);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.Navy;
            this.panel2.Controls.Add(this.m_display);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(522, 433);
            this.panel2.TabIndex = 8;
            this.panel2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseClick);
            // 
            // m_display
            // 
            this.m_display.BackColor = System.Drawing.Color.Transparent;
            this.m_display.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.m_display.Location = new System.Drawing.Point(0, 0);
            this.m_display.Margin = new System.Windows.Forms.Padding(0);
            this.m_display.Name = "m_display";
            this.m_display.Size = new System.Drawing.Size(489, 425);
            this.m_display.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_display.TabIndex = 8;
            this.m_display.TabStop = false;
            this.m_display.Paint += new System.Windows.Forms.PaintEventHandler(this.m_display_Paint);
            this.m_display.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_display_MouseDown);
            this.m_display.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_display_MouseMove);
            this.m_display.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_display_MouseUp);
            this.m_display.Resize += new System.EventHandler(this.m_display_Resize);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Blue;
            this.panel1.Controls.Add(this.m_labelTotalTime);
            this.panel1.Controls.Add(this.m_labelCurrentTime);
            this.panel1.Controls.Add(this.m_playPauseButton);
            this.panel1.Controls.Add(this.m_trackBarVideoDuration);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel1.Location = new System.Drawing.Point(55, 364);
            this.panel1.Margin = new System.Windows.Forms.Padding(50, 0, 50, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 71);
            this.panel1.TabIndex = 10;
            this.panel1.Visible = false;
            this.panel1.VisibleChanged += new System.EventHandler(this.panel1_VisibleChanged);
            // 
            // m_labelTotalTime
            // 
            this.m_labelTotalTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_labelTotalTime.AutoSize = true;
            this.m_labelTotalTime.ForeColor = System.Drawing.Color.White;
            this.m_labelTotalTime.Location = new System.Drawing.Point(343, 45);
            this.m_labelTotalTime.Name = "m_labelTotalTime";
            this.m_labelTotalTime.Size = new System.Drawing.Size(57, 13);
            this.m_labelTotalTime.TabIndex = 11;
            this.m_labelTotalTime.Text = "/ 00:00:00";
            // 
            // m_labelCurrentTime
            // 
            this.m_labelCurrentTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_labelCurrentTime.AutoSize = true;
            this.m_labelCurrentTime.ForeColor = System.Drawing.Color.White;
            this.m_labelCurrentTime.Location = new System.Drawing.Point(297, 45);
            this.m_labelCurrentTime.Name = "m_labelCurrentTime";
            this.m_labelCurrentTime.Size = new System.Drawing.Size(49, 13);
            this.m_labelCurrentTime.TabIndex = 10;
            this.m_labelCurrentTime.Text = "00:00:00";
            // 
            // m_playPauseButton
            // 
            this.m_playPauseButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_playPauseButton.BackColor = System.Drawing.Color.Transparent;
            this.m_playPauseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_playPauseButton.FlatAppearance.BorderSize = 0;
            this.m_playPauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_playPauseButton.ForeColor = System.Drawing.Color.Transparent;
            this.m_playPauseButton.Image = ((System.Drawing.Image)(resources.GetObject("m_playPauseButton.Image")));
            this.m_playPauseButton.Location = new System.Drawing.Point(176, 26);
            this.m_playPauseButton.Name = "m_playPauseButton";
            this.m_playPauseButton.Size = new System.Drawing.Size(47, 42);
            this.m_playPauseButton.TabIndex = 0;
            this.m_playPauseButton.UseVisualStyleBackColor = false;
            // 
            // m_trackBarVideoDuration
            // 
            this.m_trackBarVideoDuration.BackColor = System.Drawing.Color.Blue;
            this.m_trackBarVideoDuration.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_trackBarVideoDuration.Location = new System.Drawing.Point(0, 0);
            this.m_trackBarVideoDuration.Margin = new System.Windows.Forms.Padding(0);
            this.m_trackBarVideoDuration.Maximum = 2147483647;
            this.m_trackBarVideoDuration.Name = "m_trackBarVideoDuration";
            this.m_trackBarVideoDuration.Size = new System.Drawing.Size(419, 45);
            this.m_trackBarVideoDuration.TabIndex = 9;
            this.m_trackBarVideoDuration.TickFrequency = 0;
            this.m_trackBarVideoDuration.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.m_trackBarVideoDuration.Scroll += new System.EventHandler(this.m_trackBarVideoDuration_Scroll);
            this.m_trackBarVideoDuration.ValueChanged += new System.EventHandler(this.m_trackBarVideoDuration_ValueChanged);
            // 
            // m_panelContextMenu
            // 
            this.m_panelContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openDisplayInNewWindowToolStripMenuItem});
            this.m_panelContextMenu.Name = "m_panelContextMenu";
            this.m_panelContextMenu.Size = new System.Drawing.Size(228, 70);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allImagesToolStripMenuItem,
            this.ImageToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // allImagesToolStripMenuItem
            // 
            this.allImagesToolStripMenuItem.Name = "allImagesToolStripMenuItem";
            this.allImagesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.allImagesToolStripMenuItem.Text = "All Images";
            this.allImagesToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // ImageToolStripMenuItem
            // 
            this.ImageToolStripMenuItem.Name = "ImageToolStripMenuItem";
            this.ImageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ImageToolStripMenuItem.Text = "Current Image";
            this.ImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // openDisplayInNewWindowToolStripMenuItem
            // 
            this.openDisplayInNewWindowToolStripMenuItem.Name = "openDisplayInNewWindowToolStripMenuItem";
            this.openDisplayInNewWindowToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.openDisplayInNewWindowToolStripMenuItem.Text = "Open Display in new window";
            this.openDisplayInNewWindowToolStripMenuItem.Click += new System.EventHandler(this.openDisplayInNewWindowToolStripMenuItem_Click);
            // 
            // DisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DisplayControl";
            this.Size = new System.Drawing.Size(528, 463);
            this.Resize += new System.EventHandler(this.resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_display)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_trackBarVideoDuration)).EndInit();
            this.m_panelContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ComboBox m_cbImages;
        public Emgu.CV.UI.ImageBox m_display;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button m_playPauseButton;
        public System.Windows.Forms.TrackBar m_trackBarVideoDuration;
        private System.Windows.Forms.ToolTip m_toolTipTrackBar;
        private System.Windows.Forms.Label m_labelTotalTime;
        private System.Windows.Forms.Label m_labelCurrentTime;
        private System.Windows.Forms.ContextMenuStrip m_panelContextMenu;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDisplayInNewWindowToolStripMenuItem;
    }
}
