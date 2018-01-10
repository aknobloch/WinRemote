using System;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.InteropServices;
using BTConnectionService.control;

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
            // If not in debug mode, hide the console window.
            if(Log.DEBUG_MODE == false)
            {
                #pragma warning disable CS0162 // Unreachable code detected
                var handle = GetConsoleWindow();
                ShowWindow(handle, CONSOLE_HIDE);
                #pragma warning restore CS0162 // Unreachable code detected
            }

            new BTConnectionServer().StartSynchronousServer();
            Console.ReadLine(); // blocking method keeps the window active
        }
    }
}
