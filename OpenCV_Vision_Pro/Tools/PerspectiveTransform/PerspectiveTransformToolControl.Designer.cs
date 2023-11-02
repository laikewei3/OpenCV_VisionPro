namespace OpenCV_Vision_Pro
{
    partial class PerspectiveTransformToolControl
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
            this.m_PerspectiveTransformInput = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_PerspectiveTransformInput
            // 
            this.m_PerspectiveTransformInput.AutoScroll = true;
            this.m_PerspectiveTransformInput.Location = new System.Drawing.Point(4, 22);
            this.m_PerspectiveTransformInput.Name = "m_PerspectiveTransformInput";
            this.m_PerspectiveTransformInput.Padding = new System.Windows.Forms.Padding(3);
            this.m_PerspectiveTransformInput.Size = new System.Drawing.Size(337, 414);
            this.m_PerspectiveTransformInput.TabIndex = 0;
            this.m_PerspectiveTransformInput.Text = "Input";
            this.m_PerspectiveTransformInput.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.m_PerspectiveTransformInput);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(345, 440);
            this.tabControl2.TabIndex = 1;
            // 
            // PerspectiveTransformToolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl2);
            this.MinimumSize = new System.Drawing.Size(200, 0);
            this.Name = "PerspectiveTransformToolControl";
            this.Size = new System.Drawing.Size(345, 440);
            this.Load += new System.EventHandler(this.PerspectiveTransformToolControl_Load);
            this.tabControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage m_PerspectiveTransformInput;
        private System.Windows.Forms.TabControl tabControl2;
    }
}
