using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System.IO;
using System.Threading;
using BTConnectionService.control;

namespace BTConnectionService
{
    public class BTConnectionServer
    {
        static readonly Guid UUID = new Guid("{2BBF4D1B-9A19-4709-9399-B6AB4A88E777}");
        static bool m_ServerRunning = true;

        public BTConnectionServer()
        {

        }
        
        public void StartSynchronousServer()
        {
            Log.write("Initializing server w/ UUID: " + UUID.ToString());

            var bluetoothListener = new BluetoothListener(UUID);
            bluetoothListener.Start();

            Log.write("Server socket initialized.");

            while (m_ServerRunning)
            {
                Log.write("Waiting for connection...");
                BluetoothClient connection = bluetoothListener.AcceptBluetoothClient();

                Log.write("Connection established.");
                BTDataIO clientStream = new BTDataIO(connection.GetStream());

                ButtonLoader loader = new ButtonLoader();
                loader.LoadButtons();

                clientStream.SendButtons(loader.GetButtons());
                
                while (clientStream.CanRead())
                {
                    ReadAndExecuteNextActions(clientStream);
                }
            }
            
            Log.write("Server closed.");
        }

        /// <summary>
        /// Reads the next set of actions from the given stream, then sends them to the 
        /// ExecuteAction utility to be executed.
        /// </summary>
        /// <param name="clientStream"></param>
        private void ReadAndExecuteNextActions(BTDataIO clientStream)
        {
            List<string> sentAction = clientStream.Read();

            if (sentAction.Count > 0) // TODO greater than 0
            {
                foreach (string action in sentAction)
                {
                    ExecuteAction.Execute(action);
                }
            }
        }
    }
}
