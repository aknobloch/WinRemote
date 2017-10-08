using System;
using System.Collections.Generic;

namespace MonoExample
{
    using System;
    using System.Windows.Forms;

    public class HelloGUI : Form
    {
        public static void Main()
        {
            Application.Run(new HelloGUI());
        }

        public HelloGUI()
        {
            Text = "Simple Mono Example";
        
            Button clickableButton = new Button();
        
            clickableButton.Text = "Click Me!";
            clickableButton.Click += new EventHandler(Button_Click);
        
            Controls.Add(clickableButton);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Great job!");
        }
    }
}