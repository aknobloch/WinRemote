namespace WinRemoteDesktop_Test
{
    partial class Form1
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
            this.submitMacroBtn = new System.Windows.Forms.Button();
            this.macroTxtBox = new System.Windows.Forms.TextBox();
            this.macroDataGrid = new System.Windows.Forms.DataGridView();
            this.buttonDataGrid = new System.Windows.Forms.DataGridView();
            this.keycodeDataGrid = new System.Windows.Forms.DataGridView();
            this.tagCombo = new System.Windows.Forms.ComboBox();
            this.cmdLabel = new System.Windows.Forms.Label();
            this.descLabel = new System.Windows.Forms.Label();
            this.descTxtBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.macroDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keycodeDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // submitMacroBtn
            // 
            this.submitMacroBtn.Location = new System.Drawing.Point(12, 332);
            this.submitMacroBtn.Name = "submitMacroBtn";
            this.submitMacroBtn.Size = new System.Drawing.Size(91, 23);
            this.submitMacroBtn.TabIndex = 0;
            this.submitMacroBtn.Text = "Submit";
            this.submitMacroBtn.UseVisualStyleBackColor = true;
            this.submitMacroBtn.Click += new System.EventHandler(this.submitMacroBtn_Click);
            // 
            // macroTxtBox
            // 
            this.macroTxtBox.Location = new System.Drawing.Point(5, 68);
            this.macroTxtBox.Name = "macroTxtBox";
            this.macroTxtBox.Size = new System.Drawing.Size(111, 20);
            this.macroTxtBox.TabIndex = 1;
            this.macroTxtBox.Visible = false;
            this.macroTxtBox.TextChanged += new System.EventHandler(this.macroTxtBox_TextChanged);
            // 
            // macroDataGrid
            // 
            this.macroDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.macroDataGrid.Location = new System.Drawing.Point(129, 12);
            this.macroDataGrid.Name = "macroDataGrid";
            this.macroDataGrid.Size = new System.Drawing.Size(298, 343);
            this.macroDataGrid.TabIndex = 2;
            this.macroDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.macroDataGrid_CellContentClick);
            // 
            // buttonDataGrid
            // 
            this.buttonDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.buttonDataGrid.Location = new System.Drawing.Point(434, 12);
            this.buttonDataGrid.Name = "buttonDataGrid";
            this.buttonDataGrid.Size = new System.Drawing.Size(295, 343);
            this.buttonDataGrid.TabIndex = 3;
            this.buttonDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.buttonDataGrid_CellContentClick);
            // 
            // keycodeDataGrid
            // 
            this.keycodeDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.keycodeDataGrid.Location = new System.Drawing.Point(735, 12);
            this.keycodeDataGrid.Name = "keycodeDataGrid";
            this.keycodeDataGrid.Size = new System.Drawing.Size(295, 343);
            this.keycodeDataGrid.TabIndex = 4;
            this.keycodeDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.keycodeDataGrid_CellContentClick);
            // 
            // tagCombo
            // 
            this.tagCombo.FormattingEnabled = true;
            this.tagCombo.Items.AddRange(new object[] {
            "String",
            "Button"});
            this.tagCombo.Location = new System.Drawing.Point(2, 19);
            this.tagCombo.Name = "tagCombo";
            this.tagCombo.Size = new System.Drawing.Size(121, 21);
            this.tagCombo.TabIndex = 5;
            this.tagCombo.SelectedIndexChanged += new System.EventHandler(this.tagCombo_SelectedIndexChanged);
            // 
            // cmdLabel
            // 
            this.cmdLabel.AutoSize = true;
            this.cmdLabel.Location = new System.Drawing.Point(2, 52);
            this.cmdLabel.Name = "cmdLabel";
            this.cmdLabel.Size = new System.Drawing.Size(54, 13);
            this.cmdLabel.TabIndex = 6;
            this.cmdLabel.Text = "Command";
            this.cmdLabel.Visible = false;
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = true;
            this.descLabel.Location = new System.Drawing.Point(2, 111);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(60, 13);
            this.descLabel.TabIndex = 7;
            this.descLabel.Text = "Description";
            this.descLabel.Visible = false;
            // 
            // descTxtBox
            // 
            this.descTxtBox.Location = new System.Drawing.Point(5, 127);
            this.descTxtBox.Multiline = true;
            this.descTxtBox.Name = "descTxtBox";
            this.descTxtBox.Size = new System.Drawing.Size(111, 86);
            this.descTxtBox.TabIndex = 8;
            this.descTxtBox.Visible = false;
            this.descTxtBox.TextChanged += new System.EventHandler(this.descTxtBox_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 367);
            this.Controls.Add(this.descTxtBox);
            this.Controls.Add(this.descLabel);
            this.Controls.Add(this.cmdLabel);
            this.Controls.Add(this.tagCombo);
            this.Controls.Add(this.buttonDataGrid);
            this.Controls.Add(this.macroDataGrid);
            this.Controls.Add(this.macroTxtBox);
            this.Controls.Add(this.submitMacroBtn);
            this.Controls.Add(this.keycodeDataGrid);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.macroDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keycodeDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitMacroBtn;
        private System.Windows.Forms.TextBox macroTxtBox;
        private System.Windows.Forms.DataGridView macroDataGrid;
        private System.Windows.Forms.DataGridView buttonDataGrid;
        private System.Windows.Forms.DataGridView keycodeDataGrid;
        private System.Windows.Forms.ComboBox tagCombo;
        private System.Windows.Forms.Label cmdLabel;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.TextBox descTxtBox;
    }
}

