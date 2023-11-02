namespace OpenCV_Vision_Pro
{
    partial class TextRecognitionToolControl
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
            this.m_TextRecognitionInput = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m_cbLanguage = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cbMode = new System.Windows.Forms.ComboBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.m_TextRecognitionOutput = new System.Windows.Forms.TabPage();
            this.m_tbResultText = new System.Windows.Forms.TextBox();
            this.m_TextRecognitionInput.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.m_TextRecognitionOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_TextRecognitionInput
            // 
            this.m_TextRecognitionInput.AutoScroll = true;
            this.m_TextRecognitionInput.Controls.Add(this.tableLayoutPanel1);
            this.m_TextRecognitionInput.Location = new System.Drawing.Point(4, 22);
            this.m_TextRecognitionInput.Name = "m_TextRecognitionInput";
            this.m_TextRecognitionInput.Padding = new System.Windows.Forms.Padding(3);
            this.m_TextRecognitionInput.Size = new System.Drawing.Size(337, 414);
            this.m_TextRecognitionInput.TabIndex = 0;
            this.m_TextRecognitionInput.Text = "Input";
            this.m_TextRecognitionInput.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.m_cbLanguage, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.m_cbMode, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(331, 54);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // m_cbLanguage
            // 
            this.m_cbLanguage.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbLanguage.FormattingEnabled = true;
            this.m_cbLanguage.Items.AddRange(new object[] {
            "eng",
            "chi_sim",
            "chi_tra"});
            this.m_cbLanguage.Location = new System.Drawing.Point(68, 30);
            this.m_cbLanguage.Name = "m_cbLanguage";
            this.m_cbLanguage.Size = new System.Drawing.Size(260, 21);
            this.m_cbLanguage.TabIndex = 3;
            this.m_cbLanguage.SelectedIndexChanged += new System.EventHandler(this.m_cbLanguage_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Language";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mode";
            // 
            // m_cbMode
            // 
            this.m_cbMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbMode.FormattingEnabled = true;
            this.m_cbMode.Items.AddRange(new object[] {
            "Symbol",
            "Block",
            "TextLine",
            "Para",
            "Word"});
            this.m_cbMode.Location = new System.Drawing.Point(68, 3);
            this.m_cbMode.Name = "m_cbMode";
            this.m_cbMode.Size = new System.Drawing.Size(260, 21);
            this.m_cbMode.TabIndex = 1;
            this.m_cbMode.SelectedIndexChanged += new System.EventHandler(this.m_cbMode_SelectedIndexChanged);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.m_TextRecognitionInput);
            this.tabControl2.Controls.Add(this.m_TextRecognitionOutput);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(345, 440);
            this.tabControl2.TabIndex = 1;
            // 
            // m_TextRecognitionOutput
            // 
            this.m_TextRecognitionOutput.Controls.Add(this.m_tbResultText);
            this.m_TextRecognitionOutput.Location = new System.Drawing.Point(4, 22);
            this.m_TextRecognitionOutput.Name = "m_TextRecognitionOutput";
            this.m_TextRecognitionOutput.Size = new System.Drawing.Size(337, 414);
            this.m_TextRecognitionOutput.TabIndex = 1;
            this.m_TextRecognitionOutput.Text = "Output";
            this.m_TextRecognitionOutput.UseVisualStyleBackColor = true;
            // 
            // m_tbResultText
            // 
            this.m_tbResultText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tbResultText.Location = new System.Drawing.Point(0, 0);
            this.m_tbResultText.Multiline = true;
            this.m_tbResultText.Name = "m_tbResultText";
            this.m_tbResultText.ReadOnly = true;
            this.m_tbResultText.Size = new System.Drawing.Size(337, 414);
            this.m_tbResultText.TabIndex = 1;
            // 
            // TextRecognitionToolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl2);
            this.MinimumSize = new System.Drawing.Size(200, 0);
            this.Name = "TextRecognitionToolControl";
            this.Size = new System.Drawing.Size(345, 440);
            this.Load += new System.EventHandler(this.TextRecognitionToolControl_Load);
            this.m_TextRecognitionInput.ResumeLayout(false);
            this.m_TextRecognitionInput.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.m_TextRecognitionOutput.ResumeLayout(false);
            this.m_TextRecognitionOutput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage m_TextRecognitionInput;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage m_TextRecognitionOutput;
        private System.Windows.Forms.TextBox m_tbResultText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox m_cbLanguage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox m_cbMode;
    }
}
