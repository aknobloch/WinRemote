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
    public partial class HomeScreen : Form
    {
        public HomeScreen()
        {
            InitializeComponent();
            DBHelper.CreateDatabase();
            fillDataGrids();
            //Form1 form = new Form1();
            //form.Show();
        }

        private void fillDataGrids()
        {
            macroDataGrid.DataSource = DBHelper.grabDataset("WR_MACRO").Tables[0].DefaultView;
            buttonDataGrid.DataSource = DBHelper.grabDataset("WR_Button").Tables[0].DefaultView;            
        }

        private void createButtonBtn_Click(object sender, EventArgs e)
        { 
            ButtonForm btnform = new ButtonForm();
            btnform.Closed += (s, args) => this.Show();
            btnform.Closed += (s, args) => fillDataGrids();
            btnform.Show();
            this.Hide();
        }

        private void deleteButtonBtn_Click(object sender, EventArgs e)
        {
            string ID = "";
            foreach (DataGridViewRow row in buttonDataGrid.SelectedRows)
            {
                ID = row.Cells[0].Value.ToString();
            }
            //call DBHelper with ID to delete button.

            fillDataGrids();
        }

        private void createMacroBtn_Click(object sender, EventArgs e)
        {
            MacroForm macroform = new MacroForm();
            macroform.Closed += (s, args) => this.Show();
            macroform.Closed += (s, args) => fillDataGrids();
            macroform.Show();
           
            this.Hide();
        }

        private void deleteMacroBtn_Click(object sender, EventArgs e)
        {
            string ID = "";
            foreach (DataGridViewRow row in macroDataGrid.SelectedRows)
            {
                ID = row.Cells[0].Value.ToString();
            }
            //call DBHelper with ID to delete macro.

            fillDataGrids();
        }

        private void buttonDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void macroDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            macroDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            buttonDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DBHelper.CreateDatabase();
            fillDataGrids();
        }

        private void HomeScreen_Show(object sender, EventArgs e )
        {
            fillDataGrids();
        }
    }
}
