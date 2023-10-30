namespace OpenCV_Vision_Pro.Tools.ImageProcess.ProcessTool
{
    partial class RotateFlipToolControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_rbNoRotateFlip = new System.Windows.Forms.RadioButton();
            this.m_rbFlipBoth = new System.Windows.Forms.RadioButton();
            this.m_rbFlipVertical = new System.Windows.Forms.RadioButton();
            this.m_rbFlipHorizontal = new System.Windows.Forms.RadioButton();
            this.m_rb180 = new System.Windows.Forms.RadioButton();
            this.m_rb90CounterClock = new System.Windows.Forms.RadioButton();
            this.m_rb90Clock = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_rbNoRotateFlip);
            this.groupBox1.Controls.Add(this.m_rbFlipBoth);
            this.groupBox1.Controls.Add(this.m_rbFlipVertical);
            this.groupBox1.Controls.Add(this.m_rbFlipHorizontal);
            this.groupBox1.Controls.Add(this.m_rb180);
            this.groupBox1.Controls.Add(this.m_rb90CounterClock);
            this.groupBox1.Controls.Add(this.m_rb90Clock);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.MinimumSize = new System.Drawing.Size(215, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 222);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rotate / Flip";
            // 
            // m_rbNoRotateFlip
            // 
            this.m_rbNoRotateFlip.AutoSize = true;
            this.m_rbNoRotateFlip.Checked = true;
            this.m_rbNoRotateFlip.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_rbNoRotateFlip.Location = new System.Drawing.Point(3, 178);
            this.m_rbNoRotateFlip.Name = "m_rbNoRotateFlip";
            this.m_rbNoRotateFlip.Padding = new System.Windows.Forms.Padding(5);
            this.m_rbNoRotateFlip.Size = new System.Drawing.Size(209, 27);
            this.m_rbNoRotateFlip.TabIndex = 6;
            this.m_rbNoRotateFlip.TabStop = true;
            this.m_rbNoRotateFlip.Text = "No Rotation/Flip";
            this.m_rbNoRotateFlip.UseVisualStyleBackColor = true;
            this.m_rbNoRotateFlip.CheckedChanged += new System.EventHandler(this.m_rbX_CheckedChanged);
            // 
            // m_rbFlipBoth
            // 
            this.m_rbFlipBoth.AutoSize = true;
            this.m_rbFlipBoth.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_rbFlipBoth.Location = new System.Drawing.Point(3, 151);
            this.m_rbFlipBoth.Name = "m_rbFlipBoth";
            this.m_rbFlipBoth.Padding = new System.Windows.Forms.Padding(5);
            this.m_rbFlipBoth.Size = new System.Drawing.Size(209, 27);
            this.m_rbFlipBoth.TabIndex = 5;
            this.m_rbFlipBoth.TabStop = true;
            this.m_rbFlipBoth.Text = "Flip Both Vertical and Horizontal";
            this.m_rbFlipBoth.UseVisualStyleBackColor = true;
            this.m_rbFlipBoth.CheckedChanged += new System.EventHandler(this.m_rbX_CheckedChanged);
            // 
            // m_rbFlipVertical
            // 
            this.m_rbFlipVertical.AutoSize = true;
            this.m_rbFlipVertical.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_rbFlipVertical.Location = new System.Drawing.Point(3, 124);
            this.m_rbFlipVertical.Name = "m_rbFlipVertical";
            this.m_rbFlipVertical.Padding = new System.Windows.Forms.Padding(5);
            this.m_rbFlipVertical.Size = new System.Drawing.Size(209, 27);
            this.m_rbFlipVertical.TabIndex = 4;
            this.m_rbFlipVertical.TabStop = true;
            this.m_rbFlipVertical.Text = "Flip Vertical";
            this.m_rbFlipVertical.UseVisualStyleBackColor = true;
            this.m_rbFlipVertical.CheckedChanged += new System.EventHandler(this.m_rbX_CheckedChanged);
            // 
            // m_rbFlipHorizontal
            // 
            this.m_rbFlipHorizontal.AutoSize = true;
            this.m_rbFlipHorizontal.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_rbFlipHorizontal.Location = new System.Drawing.Point(3, 97);
            this.m_rbFlipHorizontal.Name = "m_rbFlipHorizontal";
            this.m_rbFlipHorizontal.Padding = new System.Windows.Forms.Padding(5);
            this.m_rbFlipHorizontal.Size = new System.Drawing.Size(209, 27);
            this.m_rbFlipHorizontal.TabIndex = 3;
            this.m_rbFlipHorizontal.TabStop = true;
            this.m_rbFlipHorizontal.Text = "Flip Horizontal";
            this.m_rbFlipHorizontal.UseVisualStyleBackColor = true;
            this.m_rbFlipHorizontal.CheckedChanged += new System.EventHandler(this.m_rbX_CheckedChanged);
            // 
            // m_rb180
            // 
            this.m_rb180.AutoSize = true;
            this.m_rb180.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_rb180.Location = new System.Drawing.Point(3, 70);
            this.m_rb180.Name = "m_rb180";
            this.m_rb180.Padding = new System.Windows.Forms.Padding(5);
            this.m_rb180.Size = new System.Drawing.Size(209, 27);
            this.m_rb180.TabIndex = 2;
            this.m_rb180.TabStop = true;
            this.m_rb180.Text = "Rotate 180 degree";
            this.m_rb180.UseVisualStyleBackColor = true;
            this.m_rb180.CheckedChanged += new System.EventHandler(this.m_rbX_CheckedChanged);
            // 
            // m_rb90CounterClock
            // 
            this.m_rb90CounterClock.AutoSize = true;
            this.m_rb90CounterClock.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_rb90CounterClock.Location = new System.Drawing.Point(3, 43);
            this.m_rb90CounterClock.Name = "m_rb90CounterClock";
            this.m_rb90CounterClock.Padding = new System.Windows.Forms.Padding(5);
            this.m_rb90CounterClock.Size = new System.Drawing.Size(209, 27);
            this.m_rb90CounterClock.TabIndex = 1;
            this.m_rb90CounterClock.TabStop = true;
            this.m_rb90CounterClock.Text = "Rotate 90 degree Counter Clockwise";
            this.m_rb90CounterClock.UseVisualStyleBackColor = true;
            this.m_rb90CounterClock.CheckedChanged += new System.EventHandler(this.m_rbX_CheckedChanged);
            // 
            // m_rb90Clock
            // 
            this.m_rb90Clock.AutoSize = true;
            this.m_rb90Clock.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_rb90Clock.Location = new System.Drawing.Point(3, 16);
            this.m_rb90Clock.Name = "m_rb90Clock";
            this.m_rb90Clock.Padding = new System.Windows.Forms.Padding(5);
            this.m_rb90Clock.Size = new System.Drawing.Size(209, 27);
            this.m_rb90Clock.TabIndex = 0;
            this.m_rb90Clock.TabStop = true;
            this.m_rb90Clock.Text = "Rotate 90 degree Clockwise";
            this.m_rb90Clock.UseVisualStyleBackColor = true;
            this.m_rb90Clock.CheckedChanged += new System.EventHandler(this.m_rbX_CheckedChanged);
            // 
            // RotateFlip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "RotateFlip";
            this.Size = new System.Drawing.Size(215, 222);
            this.Load += new System.EventHandler(this.RotateFlip_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton m_rbFlipBoth;
        private System.Windows.Forms.RadioButton m_rbFlipVertical;
        private System.Windows.Forms.RadioButton m_rbFlipHorizontal;
        private System.Windows.Forms.RadioButton m_rb180;
        private System.Windows.Forms.RadioButton m_rb90CounterClock;
        private System.Windows.Forms.RadioButton m_rb90Clock;
        private System.Windows.Forms.RadioButton m_rbNoRotateFlip;
    }
}
