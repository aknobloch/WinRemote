namespace KeyService
{
    partial class TestForm
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
            this.Btn_AltTab = new System.Windows.Forms.Button();
            this.Btn_CtrlAltDel = new System.Windows.Forms.Button();
            this.Btn_Copy = new System.Windows.Forms.Button();
            this.Btn_Paste = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Btn_CtrlA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_AltTab
            // 
            this.Btn_AltTab.Location = new System.Drawing.Point(22, 106);
            this.Btn_AltTab.Name = "Btn_AltTab";
            this.Btn_AltTab.Size = new System.Drawing.Size(75, 23);
            this.Btn_AltTab.TabIndex = 0;
            this.Btn_AltTab.Text = "Alt-Tab";
            this.Btn_AltTab.UseVisualStyleBackColor = true;
            this.Btn_AltTab.Click += new System.EventHandler(this.Btn_AltTab_Click);
            // 
            // Btn_CtrlAltDel
            // 
            this.Btn_CtrlAltDel.BackColor = System.Drawing.SystemColors.GrayText;
            this.Btn_CtrlAltDel.Enabled = false;
            this.Btn_CtrlAltDel.Location = new System.Drawing.Point(22, 19);
            this.Btn_CtrlAltDel.Name = "Btn_CtrlAltDel";
            this.Btn_CtrlAltDel.Size = new System.Drawing.Size(75, 23);
            this.Btn_CtrlAltDel.TabIndex = 1;
            this.Btn_CtrlAltDel.Text = "Ctrl-Alt-Del";
            this.Btn_CtrlAltDel.UseVisualStyleBackColor = false;
            this.Btn_CtrlAltDel.Click += new System.EventHandler(this.Btn_CtrlAltDel_Click);
            // 
            // Btn_Copy
            // 
            this.Btn_Copy.Location = new System.Drawing.Point(22, 60);
            this.Btn_Copy.Name = "Btn_Copy";
            this.Btn_Copy.Size = new System.Drawing.Size(75, 23);
            this.Btn_Copy.TabIndex = 2;
            this.Btn_Copy.Text = "Copy";
            this.Btn_Copy.UseVisualStyleBackColor = true;
            this.Btn_Copy.Click += new System.EventHandler(this.Btn_Copy_Click);
            // 
            // Btn_Paste
            // 
            this.Btn_Paste.Location = new System.Drawing.Point(22, 148);
            this.Btn_Paste.Name = "Btn_Paste";
            this.Btn_Paste.Size = new System.Drawing.Size(75, 23);
            this.Btn_Paste.TabIndex = 3;
            this.Btn_Paste.Text = "Paste";
            this.Btn_Paste.UseVisualStyleBackColor = true;
            this.Btn_Paste.Click += new System.EventHandler(this.Btn_Paste_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.Location = new System.Drawing.Point(126, 46);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(221, 49);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Copy and Paste Both hold a 5 second delay before the command is executed. use thi" +
    "s time to make ur appropriate window selection";
            // 
            // Btn_CtrlA
            // 
            this.Btn_CtrlA.Location = new System.Drawing.Point(22, 189);
            this.Btn_CtrlA.Name = "Btn_CtrlA";
            this.Btn_CtrlA.Size = new System.Drawing.Size(75, 23);
            this.Btn_CtrlA.TabIndex = 6;
            this.Btn_CtrlA.Text = "Ctrl-A";
            this.Btn_CtrlA.UseVisualStyleBackColor = true;
            this.Btn_CtrlA.Click += new System.EventHandler(this.Btn_CtrlA_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 224);
            this.Controls.Add(this.Btn_CtrlA);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_Paste);
            this.Controls.Add(this.Btn_Copy);
            this.Controls.Add(this.Btn_CtrlAltDel);
            this.Controls.Add(this.Btn_AltTab);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_AltTab;
        private System.Windows.Forms.Button Btn_CtrlAltDel;
        private System.Windows.Forms.Button Btn_Copy;
        private System.Windows.Forms.Button Btn_Paste;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Btn_CtrlA;
    }
}