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
using BTConnectionService.model;

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
            Log.Write("Initializing server w/ UUID: " + UUID.ToString());

            var bluetoothListener = new BluetoothListener(UUID);
            bluetoothListener.Start();

            Log.Write("Server socket initialized.");

            while (m_ServerRunning)
            {
                Log.Write("Waiting for connection...");
                BluetoothClient connection = bluetoothListener.AcceptBluetoothClient();

                Log.Write("Connection established.");
                BTDataIO clientStream = new BTDataIO(connection.GetStream());
                List<WinAction> actions = WinActionLoader.GetWinActions();
                
                clientStream.SendActionsToClient(actions);
                
                while (clientStream.CanRead())
                {
                    ReadAndExecuteNextActions(clientStream);
                }
            }
            
            Log.Write("Server closed.");
        }

        /// <summary>
        /// Reads the next set of actions from the given stream, then sends them to the 
        /// ExecuteAction utility to be executed.
        /// </summary>
        /// <param name="clientStream"></param>
        private void ReadAndExecuteNextActions(BTDataIO clientStream)
        {
            List<WinAction> receivedActions = clientStream.Read();

            if (receivedActions.Count > 0) // TODO greater than 0
            {
                foreach (WinAction action in receivedActions)
                {
                    ExecuteAction.Execute(action);
                }
            }
        }
    }
}
