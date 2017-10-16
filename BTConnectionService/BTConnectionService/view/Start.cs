using System;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.InteropServices;

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
            if(Log.DEBUG_MODE == false)
            {
<<<<<<< HEAD

=======
>>>>>>> 5393041503d602b4c5a8fba734f25ac6176e4bb5
                #pragma warning disable CS0162 // Unreachable code detected
                var handle = GetConsoleWindow();
                #pragma warning restore CS0162 // Unreachable code detected

                ShowWindow(handle, CONSOLE_HIDE);
                #pragma warning restore CS0162 // Unreachable code detected
            }

            new BTConnectionServer().StartAsynchronousServer();
            Console.ReadLine();
        }
    }
}
