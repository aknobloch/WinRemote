namespace WinRemoteDesktop_Test
{
    partial class MacroForm
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
            this.descTxtBox = new System.Windows.Forms.TextBox();
            this.descLabel = new System.Windows.Forms.Label();
            this.cmdLabel = new System.Windows.Forms.Label();
            this.tagCombo = new System.Windows.Forms.ComboBox();
            this.macroTxtBox = new System.Windows.Forms.TextBox();
            this.submitMacroBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // descTxtBox
            // 
            this.descTxtBox.Location = new System.Drawing.Point(383, 253);
            this.descTxtBox.Multiline = true;
            this.descTxtBox.Name = "descTxtBox";
            this.descTxtBox.Size = new System.Drawing.Size(121, 86);
            this.descTxtBox.TabIndex = 14;
            this.descTxtBox.TextChanged += new System.EventHandler(this.descTxtBox_TextChanged);
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = true;
            this.descLabel.Location = new System.Drawing.Point(383, 237);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(60, 13);
            this.descLabel.TabIndex = 13;
            this.descLabel.Text = "Description";
            // 
            // cmdLabel
            // 
            this.cmdLabel.AutoSize = true;
            this.cmdLabel.Location = new System.Drawing.Point(383, 123);
            this.cmdLabel.Name = "cmdLabel";
            this.cmdLabel.Size = new System.Drawing.Size(54, 13);
            this.cmdLabel.TabIndex = 12;
            this.cmdLabel.Text = "Command";
            // 
            // tagCombo
            // 
            this.tagCombo.FormattingEnabled = true;
            this.tagCombo.Items.AddRange(new object[] {
            "String",
            "Button"});
            this.tagCombo.Location = new System.Drawing.Point(383, 25);
            this.tagCombo.Name = "tagCombo";
            this.tagCombo.Size = new System.Drawing.Size(121, 21);
            this.tagCombo.TabIndex = 11;
            this.tagCombo.SelectedIndexChanged += new System.EventHandler(this.tagCombo_SelectedIndexChanged);
            // 
            // macroTxtBox
            // 
            this.macroTxtBox.Location = new System.Drawing.Point(383, 139);
            this.macroTxtBox.Name = "macroTxtBox";
            this.macroTxtBox.Size = new System.Drawing.Size(121, 20);
            this.macroTxtBox.TabIndex = 10;
            this.macroTxtBox.TextChanged += new System.EventHandler(this.macroTxtBox_TextChanged);
            // 
            // submitMacroBtn
            // 
            this.submitMacroBtn.Location = new System.Drawing.Point(398, 426);
            this.submitMacroBtn.Name = "submitMacroBtn";
            this.submitMacroBtn.Size = new System.Drawing.Size(91, 23);
            this.submitMacroBtn.TabIndex = 9;
            this.submitMacroBtn.Text = "Submit";
            this.submitMacroBtn.UseVisualStyleBackColor = true;
            this.submitMacroBtn.Click += new System.EventHandler(this.submitMacroBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(383, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Type";
            // 
            // MacroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.descTxtBox);
            this.Controls.Add(this.descLabel);
            this.Controls.Add(this.cmdLabel);
            this.Controls.Add(this.tagCombo);
            this.Controls.Add(this.macroTxtBox);
            this.Controls.Add(this.submitMacroBtn);
            this.Name = "MacroForm";
            this.Text = "MacroForm";
            this.Load += new System.EventHandler(this.MacroForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox descTxtBox;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.Label cmdLabel;
        private System.Windows.Forms.ComboBox tagCombo;
        private System.Windows.Forms.TextBox macroTxtBox;
        private System.Windows.Forms.Button submitMacroBtn;
        private System.Windows.Forms.Label label1;
    }
}