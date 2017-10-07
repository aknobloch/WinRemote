using System;
using System.Collections.Generic;

namespace BTConnectionService
{
    class Start
    {

        static void Main(string[] args)
        {
            new BTConnectionServer().StartServer();
            Console.ReadLine();
        }
    }
}
