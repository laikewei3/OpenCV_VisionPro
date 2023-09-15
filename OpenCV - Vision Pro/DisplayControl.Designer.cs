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
            this.m_cbImages = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_display = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_display)).BeginInit();
            this.SuspendLayout();
            // 
            // m_cbImages
            // 
            this.m_cbImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_cbImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbImages.FormattingEnabled = true;
            this.m_cbImages.Location = new System.Drawing.Point(0, 0);
            this.m_cbImages.Name = "m_cbImages";
            this.m_cbImages.Size = new System.Drawing.Size(564, 21);
            this.m_cbImages.TabIndex = 7;
            this.m_cbImages.SelectedIndexChanged += new System.EventHandler(this.m_cbImages_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.Navy;
            this.panel2.Controls.Add(this.m_display);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(50);
            this.panel2.Size = new System.Drawing.Size(564, 544);
            this.panel2.TabIndex = 8;
            this.panel2.Resize += new System.EventHandler(this.panel2_Resize);
            // 
            // m_display
            // 
            this.m_display.BackColor = System.Drawing.Color.Transparent;
            this.m_display.Location = new System.Drawing.Point(100, 138);
            this.m_display.Margin = new System.Windows.Forms.Padding(50);
            this.m_display.Name = "m_display";
            this.m_display.Size = new System.Drawing.Size(341, 270);
            this.m_display.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_display.TabIndex = 0;
            this.m_display.TabStop = false;
            // 
            // DisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.m_cbImages);
            this.Controls.Add(this.panel2);
            this.Name = "DisplayControl";
            this.Size = new System.Drawing.Size(564, 544);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_display)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.PictureBox m_display;
        public System.Windows.Forms.ComboBox m_cbImages;
    }
}
