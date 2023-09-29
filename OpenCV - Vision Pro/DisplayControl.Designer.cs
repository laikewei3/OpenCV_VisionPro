using Emgu.CV;

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
            this.m_cbImages = new System.Windows.Forms.ComboBox();
            this.m_display = new Emgu.CV.UI.ImageBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.m_display)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_cbImages
            // 
            this.m_cbImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_cbImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbImages.FormattingEnabled = true;
            this.m_cbImages.Location = new System.Drawing.Point(3, 3);
            this.m_cbImages.Name = "m_cbImages";
            this.m_cbImages.Size = new System.Drawing.Size(519, 21);
            this.m_cbImages.TabIndex = 7;
            this.m_cbImages.SelectedIndexChanged += new System.EventHandler(this.m_cbImages_SelectedIndexChanged);
            // 
            // m_display
            // 
            this.m_display.BackColor = System.Drawing.Color.Transparent;
            this.m_display.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.m_display.Location = new System.Drawing.Point(0, 0);
            this.m_display.Margin = new System.Windows.Forms.Padding(0);
            this.m_display.Name = "m_display";
            this.m_display.Size = new System.Drawing.Size(489, 451);
            this.m_display.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_display.TabIndex = 8;
            this.m_display.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(525, 510);
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
            this.panel2.Size = new System.Drawing.Size(519, 477);
            this.panel2.TabIndex = 8;
            // 
            // DisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DisplayControl";
            this.Size = new System.Drawing.Size(525, 510);
            this.Resize += new System.EventHandler(this.resize);
            ((System.ComponentModel.ISupportInitialize)(this.m_display)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ComboBox m_cbImages;
        public Emgu.CV.UI.ImageBox m_display;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
    }
}
