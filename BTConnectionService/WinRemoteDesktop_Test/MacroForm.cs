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
    public partial class MacroForm : Form
    {
        public MacroForm()
        {
            InitializeComponent();
        }

        private void MacroForm_Load(object sender, EventArgs e)
        {

        }

        private void descTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void tagCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tagCombo.Text == "String")
            {
                
            }
            else if (tagCombo.Text == "WinShortcut")
            {
                //Nothing yet but hide buttons.
                

            }
        }

        private void submitMacroBtn_Click(object sender, EventArgs e)
        {
            string cmd = macroTxtBox.Text;
            string tag = tagCombo.Text;
            string description = descTxtBox.Text;
            DBHelper.createSimpleMacro(cmd, tag, description);
            //DBHelper.addKeyCodes(macroFromTxt);
            macroTxtBox.Clear();
            descTxtBox.Clear();
            this.Close();
            
        }

        private void macroTxtBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
