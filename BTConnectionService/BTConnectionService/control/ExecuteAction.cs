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

        public static void Execute(string keyCommand)
        {
            SendKeys.SendWait(keyCommand);
        }
    }
}
