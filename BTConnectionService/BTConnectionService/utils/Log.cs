using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTConnectionService
{
    class Log
    {
        public const bool DEBUG_MODE = true;

        public static void write(string message)
        {
            if (DEBUG_MODE == false)
            {
                #pragma warning disable CS0162 // Unreachable code detected
                return;
                #pragma warning restore CS0162 // Unreachable code detected
            }

            // TODO line number, etc
            Console.WriteLine(message);
        }

        internal static void write(int message)
        {
            write("" + message);
        }
    }
}
