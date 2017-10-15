using BTConnectionService.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTConnectionService.control
{
    class ExecuteAction
    {
        public static void Copy()
        {
            SendKeys.SendWait("^c");
        }

        public static void Paste()
        {
            SendKeys.SendWait("^v");
        }

        public static void SelectAll()
        {
            SendKeys.SendWait("^a");
        }

        public static void AltTab()
        {
            SendKeys.SendWait("%({TAB})");
        }

        public static void Execute(WinAction action)
        {
            // TODO remove this, it's hardcoded crap
            switch(action.ID)
            {
                case 0:
                    Copy();
                    break;
                case 1:
                    Paste();
                    break;
                case 2:
                    SelectAll();
                    break;
            }

            // Execute(action.Action); TODO
        }

        public static void Execute(string keyCommand)
        {
            SendKeys.SendWait(keyCommand);
        }
    }
}
