using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinRemoteDesktop_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DBHelper.CreateDatabase();
            //DBHelper.buildStockDB();
            //DBHelper.addKeyCodes("");
            fillDataGrids();            
        }

        private void macroTxtBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void submitMacroBtn_Click(object sender, EventArgs e)
        {
            string macroFromTxt = macroTxtBox.Text;
            string tag = tagCombo.Text;
            string description = descTxtBox.Text;
            DBHelper.createSimpleMacro(macroFromTxt, tag, description);
            //DBHelper.addKeyCodes(macroFromTxt);
            macroTxtBox.Clear();
            descTxtBox.Clear();
            fillDataGrids();  
            
        }

        private void macroDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void buttonDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void keycodeDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        
        private void fillDataGrids()
        {
            macroDataGrid.DataSource = DBHelper.grabDataset("WR_MACRO").Tables[0].DefaultView;
            keycodeDataGrid.DataSource = DBHelper.grabDataset("WR_KEYCODE").Tables[0].DefaultView;
            buttonDataGrid.DataSource = DBHelper.grabDataset("WR_Button").Tables[0].DefaultView;
        }

        private void descTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void tagCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tagCombo.Text == "String")
            {
                cmdLabel.Visible = true;
                macroTxtBox.Visible = true;
                descLabel.Visible = true;
                descTxtBox.Visible = true;
            }

        }
    }
}
