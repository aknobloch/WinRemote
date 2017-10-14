using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyService
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {

        }

        //Alt-Tab Button Execution.
        private void Btn_AltTab_Click(object sender, EventArgs e)
        {
            label1.Text = "Alt-Tabbed";
            Thread.Sleep(100);
            SendKeys.SendWait("%({TAB})");
        }

        //So not working. Apparently Ctrl-Alt-Del is not just a key sequence. Do some research on this.
        private void Btn_CtrlAltDel_Click(object sender, EventArgs e)
        {            
            Thread.Sleep(100);
            SendKeys.Send("^%{DELETE}");           
        }

        //Copy Button Click
        private void Btn_Copy_Click(object sender, EventArgs e)
        {
            label1.Text = "Copied";
            Thread.Sleep(5000);
            SendKeys.SendWait("^c");
        }

        //Paste Button Click
        private void Btn_Paste_Click(object sender, EventArgs e)
        {
            label1.Text = "Pasted";
            Thread.Sleep(5000);
            SendKeys.SendWait("^v");
        }

        //Select All Button Click
        private void Btn_CtrlA_Click(object sender, EventArgs e)
        {
            label1.Text = "All Selected";
            Thread.Sleep(5000);
            SendKeys.SendWait("^a");
        }
    }
}
