using System;

namespace WinRemoteDesktop_Test
{
    partial class HomeScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeScreen));
            this.macroDataGrid = new System.Windows.Forms.DataGridView();
            this.buttonDataGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.createButtonBtn = new System.Windows.Forms.Button();
            this.deleteButtonBtn = new System.Windows.Forms.Button();
            this.createMacroBtn = new System.Windows.Forms.Button();
            this.deleteMacroBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.macroDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // macroDataGrid
            // 
            this.macroDataGrid.AllowUserToAddRows = false;
            this.macroDataGrid.AllowUserToDeleteRows = false;
            this.macroDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.macroDataGrid.Location = new System.Drawing.Point(574, 12);
            this.macroDataGrid.Name = "macroDataGrid";
            this.macroDataGrid.Size = new System.Drawing.Size(298, 415);
            this.macroDataGrid.TabIndex = 3;
            this.macroDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.macroDataGrid_CellContentClick);
            // 
            // buttonDataGrid
            // 
            this.buttonDataGrid.AllowUserToAddRows = false;
            this.buttonDataGrid.AllowUserToDeleteRows = false;
            this.buttonDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.buttonDataGrid.Location = new System.Drawing.Point(12, 12);
            this.buttonDataGrid.Name = "buttonDataGrid";
            this.buttonDataGrid.Size = new System.Drawing.Size(298, 415);
            this.buttonDataGrid.TabIndex = 4;
            this.buttonDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.buttonDataGrid_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(354, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = "WinRemote";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(326, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 144);
            this.label2.TabIndex = 6;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // createButtonBtn
            // 
            this.createButtonBtn.Location = new System.Drawing.Point(12, 433);
            this.createButtonBtn.Name = "createButtonBtn";
            this.createButtonBtn.Size = new System.Drawing.Size(142, 23);
            this.createButtonBtn.TabIndex = 7;
            this.createButtonBtn.Text = "Create Button";
            this.createButtonBtn.UseVisualStyleBackColor = true;
            this.createButtonBtn.Click += new System.EventHandler(this.createButtonBtn_Click);
            // 
            // deleteButtonBtn
            // 
            this.deleteButtonBtn.Location = new System.Drawing.Point(168, 433);
            this.deleteButtonBtn.Name = "deleteButtonBtn";
            this.deleteButtonBtn.Size = new System.Drawing.Size(142, 23);
            this.deleteButtonBtn.TabIndex = 8;
            this.deleteButtonBtn.Text = "Delete Button";
            this.deleteButtonBtn.UseVisualStyleBackColor = true;
            this.deleteButtonBtn.Visible = false;
            this.deleteButtonBtn.Click += new System.EventHandler(this.deleteButtonBtn_Click);
            // 
            // createMacroBtn
            // 
            this.createMacroBtn.Location = new System.Drawing.Point(574, 433);
            this.createMacroBtn.Name = "createMacroBtn";
            this.createMacroBtn.Size = new System.Drawing.Size(142, 23);
            this.createMacroBtn.TabIndex = 9;
            this.createMacroBtn.Text = "Create Macro";
            this.createMacroBtn.UseVisualStyleBackColor = true;
            this.createMacroBtn.Click += new System.EventHandler(this.createMacroBtn_Click);
            // 
            // deleteMacroBtn
            // 
            this.deleteMacroBtn.Location = new System.Drawing.Point(730, 433);
            this.deleteMacroBtn.Name = "deleteMacroBtn";
            this.deleteMacroBtn.Size = new System.Drawing.Size(142, 23);
            this.deleteMacroBtn.TabIndex = 10;
            this.deleteMacroBtn.Text = "Delete Macro";
            this.deleteMacroBtn.UseVisualStyleBackColor = true;
            this.deleteMacroBtn.Visible = false;
            this.deleteMacroBtn.Click += new System.EventHandler(this.deleteMacroBtn_Click);
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.deleteMacroBtn);
            this.Controls.Add(this.createMacroBtn);
            this.Controls.Add(this.deleteButtonBtn);
            this.Controls.Add(this.createButtonBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDataGrid);
            this.Controls.Add(this.macroDataGrid);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.Name = "HomeScreen";
            this.Text = "HomeScreen";
            this.Load += new System.EventHandler(this.HomeScreen_Load);
            this.Shown += new System.EventHandler(this.HomeScreen_Show);
            ((System.ComponentModel.ISupportInitialize)(this.macroDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView macroDataGrid;
        private System.Windows.Forms.DataGridView buttonDataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button createButtonBtn;
        private System.Windows.Forms.Button deleteButtonBtn;
        private System.Windows.Forms.Button createMacroBtn;
        private System.Windows.Forms.Button deleteMacroBtn;
    }
}