using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winRemoteDataBase.Model;

namespace BTConnectionService
{
    class KeySend
    {
        public void stringSend(string str)
        {
            Log.write("stringSend to focused application; value: " + str);
            SendKeys.Send(str);
        }

        public void buttonSend(DBButton dbBtn)
        {
            
            
        }
    }
}
