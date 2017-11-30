using System;
using System.Collections;
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
    public partial class ButtonForm : Form
    {
        public ButtonForm()
        {
            InitializeComponent();
            fillDataGrids();

            btnTempDataGrid.ColumnCount = 2;
            btnTempDataGrid.Columns[0].Name = "Command ID";
            btnTempDataGrid.Columns[1].Name = "Description";
            macroDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            btnTempDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void fillDataGrids()
        {
            macroDataGrid.DataSource = DBHelper.grabDataset("WR_Macro").Tables[0].DefaultView;
        }

        private void addTempButton(string ID, string desc)
        {            
            btnTempDataGrid.Rows.Add(ID, desc);
        }

        private void addMacroBtn_Click(object sender, EventArgs e)
        {
            string ID = "", desc = "";

            foreach(DataGridViewRow row in macroDataGrid.SelectedRows)
            {
                ID = row.Cells[0].Value.ToString();
                desc = row.Cells[1].Value.ToString();
            }

            addTempButton(ID, desc);

        }

        private void ButtonForm_Load(object sender, EventArgs e)
        {

        }

        private void removeMacroBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in btnTempDataGrid.SelectedRows)
            {
                btnTempDataGrid.Rows.RemoveAt(row.Index);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            ArrayList macroIDs = new ArrayList();
            string ID = "";
            foreach (DataGridViewRow row in btnTempDataGrid.Rows)
            {
                ID = row.Cells[0].Value.ToString();
                macroIDs.Add(ID);
                //MessageBox.Show(ID);
            }

            string csvcmd = string.Join(",", (string[])macroIDs.ToArray(Type.GetType("System.String")));
            string tag = "BTN";
            string description = descTxtBox.Text;

            DBHelper.createSimpleMacro(csvcmd, tag, "customer user button");
            string mcid = DBHelper.getNewBtnID();
            DBHelper.createSimpleButton(mcid, description);
            this.Close();

        }

        private void descTxtBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
