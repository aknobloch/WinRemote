﻿using System;
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

        public BTConnectionServer()
        {

        }

        [System.Obsolete("Asynchronous server is deprecated, use the StartSynchronousServer method.")]
        public void StartAsynchronousServer()
        {
            Log.write("Initializing server w/ UUID: " + UUID.ToString());

            var bluetoothListener = new BluetoothListener(UUID);
            bluetoothListener.Start();

            Log.write("Server socket initialized. Waiting...");
            BluetoothClient connection = bluetoothListener.AcceptBluetoothClient();

            Log.write("Connection established.");
            BTDataIO clientStream = new BTDataIO(connection.GetStream());

            while (clientStream.CanRead())
            {
                WinAction sentAction = clientStream.Read();
                if (sentAction.ID >= 0)
                {
                    Log.write("Valid button ID read.");
                    ExecuteAction.Execute(sentAction);
                }
            }

            Log.write("End reading.");
        }

        public void StartSynchronousServer()
        {
            // TODO SDP discovery not successful in background thread.
            Thread serverThread = new Thread(() =>
           {
               Log.write("Initializing server w/ UUID: " + UUID.ToString());

               var bluetoothListener = new BluetoothListener(UUID);
               bluetoothListener.Start();

               Log.write("Server socket initialized. Waiting for connection...");
               BluetoothClient connection = bluetoothListener.AcceptBluetoothClient();      

               Log.write("Connection established.");
               BTDataIO clientStream = new BTDataIO(connection.GetStream());

               while (clientStream.CanRead())
               {
                   WinAction sentAction = clientStream.Read();
                   if(sentAction.ID >= 0)
                   {
                       Log.write("Valid button ID read.");
                       ExecuteAction.Execute(sentAction);
                   }
               }

               Log.write("End reading.");
           });

            serverThread.IsBackground = false;
            serverThread.Start();
        }
    }
}
