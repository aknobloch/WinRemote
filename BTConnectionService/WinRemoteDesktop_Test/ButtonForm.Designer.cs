namespace WinRemoteDesktop_Test
{
    partial class ButtonForm
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
            this.macroDataGrid = new System.Windows.Forms.DataGridView();
            this.addMacroBtn = new System.Windows.Forms.Button();
            this.btnTempDataGrid = new System.Windows.Forms.DataGridView();
            this.saveBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.removeMacroBtn = new System.Windows.Forms.Button();
            this.descTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.macroDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTempDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // macroDataGrid
            // 
            this.macroDataGrid.AllowUserToAddRows = false;
            this.macroDataGrid.AllowUserToDeleteRows = false;
            this.macroDataGrid.AllowUserToResizeColumns = false;
            this.macroDataGrid.AllowUserToResizeRows = false;
            this.macroDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.macroDataGrid.Location = new System.Drawing.Point(12, 34);
            this.macroDataGrid.MultiSelect = false;
            this.macroDataGrid.Name = "macroDataGrid";
            this.macroDataGrid.ReadOnly = true;
            this.macroDataGrid.Size = new System.Drawing.Size(298, 415);
            this.macroDataGrid.TabIndex = 4;
            //this.macroDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.macroDataGrid_CellContentClick);
            // 
            // addMacroBtn
            // 
            this.addMacroBtn.Location = new System.Drawing.Point(382, 219);
            this.addMacroBtn.Name = "addMacroBtn";
            this.addMacroBtn.Size = new System.Drawing.Size(121, 23);
            this.addMacroBtn.TabIndex = 5;
            this.addMacroBtn.Text = "Add Macro";
            this.addMacroBtn.UseVisualStyleBackColor = true;
            this.addMacroBtn.Click += new System.EventHandler(this.addMacroBtn_Click);
            // 
            // btnTempDataGrid
            // 
            this.btnTempDataGrid.AllowUserToAddRows = false;
            this.btnTempDataGrid.AllowUserToDeleteRows = false;
            this.btnTempDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.btnTempDataGrid.Location = new System.Drawing.Point(574, 34);
            this.btnTempDataGrid.Name = "btnTempDataGrid";
            this.btnTempDataGrid.Size = new System.Drawing.Size(298, 415);
            this.btnTempDataGrid.TabIndex = 6;
            //this.btnTempDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.btnTempDataGrid_CellContentClick);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(405, 427);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 22);
            this.saveBtn.TabIndex = 7;
            this.saveBtn.Text = "Save Button";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Macros:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(670, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "New Button:";
            // 
            // removeMacroBtn
            // 
            this.removeMacroBtn.Location = new System.Drawing.Point(382, 249);
            this.removeMacroBtn.Name = "removeMacroBtn";
            this.removeMacroBtn.Size = new System.Drawing.Size(121, 23);
            this.removeMacroBtn.TabIndex = 10;
            this.removeMacroBtn.Text = "Remove Macro";
            this.removeMacroBtn.UseVisualStyleBackColor = true;
            this.removeMacroBtn.Click += new System.EventHandler(this.removeMacroBtn_Click);
            // 
            // descTxtBox
            // 
            this.descTxtBox.Location = new System.Drawing.Point(382, 312);
            this.descTxtBox.Multiline = true;
            this.descTxtBox.Name = "descTxtBox";
            this.descTxtBox.Size = new System.Drawing.Size(121, 96);
            this.descTxtBox.TabIndex = 11;
            this.descTxtBox.TextChanged += new System.EventHandler(this.descTxtBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(411, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Description:";
            // 
            // ButtonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.descTxtBox);
            this.Controls.Add(this.removeMacroBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.btnTempDataGrid);
            this.Controls.Add(this.addMacroBtn);
            this.Controls.Add(this.macroDataGrid);
            this.Name = "ButtonForm";
            this.Text = "ButtonForm";
            this.Load += new System.EventHandler(this.ButtonForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.macroDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTempDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView macroDataGrid;
        private System.Windows.Forms.Button addMacroBtn;
        private System.Windows.Forms.DataGridView btnTempDataGrid;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button removeMacroBtn;
        private System.Windows.Forms.TextBox descTxtBox;
        private System.Windows.Forms.Label label3;
    }
}