using System;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.InteropServices;
using winRemoteDataBase.Controller;
using winRemoteDataBase.Model;

namespace BTConnectionService
{
    class Start
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int CONSOLE_HIDE = 0;

        static void Main(string[] args)
        {
            /*
            if(Log.DEBUG_MODE == false)
            {
                #pragma warning disable CS0162 // Unreachable code detected
                var handle = GetConsoleWindow();
                #pragma warning restore CS0162 // Unreachable code detected

                ShowWindow(handle, CONSOLE_HIDE);
                #pragma warning restore CS0162 // Unreachable code detected
            }

            new BTConnectionServer().StartAsynchronousServer();
            Console.ReadLine();
            */

            /*
            DBButton copy = new DBButton(3, "Select All");
            DBMacro macro = new DBMacro(3, 1, 1);
            DBKeyCode key = new DBKeyCode("^a", "Select All", true);

            DBHelper.InsertButton(copy);
            DBHelper.InsertMacro(macro);
            DBHelper.InsertKeycode(key);
            */

            var commands = DBHelper.GetActions(1);
            foreach(string c in commands)
            {
                Console.WriteLine(commands);
            }
            
            Console.ReadLine();
            
        }
    }
}
