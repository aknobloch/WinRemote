using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTConnectionService.model;
using System.Runtime.Serialization.Json;

namespace BTConnectionService.control
{
    public enum ServerSignals : byte
    {
        BEGIN_SEND_ACTION
    }

    class BTDataIO
    {
        Stream m_DataStream;
        bool m_SocketOpen;

        public BTDataIO(Stream dataStream)
        {
            this.m_DataStream = dataStream;
            this.m_SocketOpen = true;
        }

        public Boolean CanRead()
        {
            return m_SocketOpen && m_DataStream.CanRead;
        }

        /// <summary>
        /// Reads in the next action command from
        /// the client application. This operation is 
        /// blocking, and will not return until a button
        /// is read in from the stream.
        /// </summary>
        /// 
        /// <returns>List<string> with the execution commands read from the server</returns>
        public List<WinAction> Read()
        {
            int nextByte = m_DataStream.ReadByte();

            List<WinAction> commands = new List<WinAction>();

            if (nextByte != -1)
            {
                int actionID = Convert.ToInt32(nextByte);

                WinAction sentAction = WinActionLoader.GetWinActionByID(actionID);
                Log.Write("Read " + sentAction.GetName());

                commands.Add(sentAction);
            }
            else
            {
                Log.Write("Socket connection closed.");
                m_SocketOpen = false;
            }

            return commands;
        }

        public void SendActionsToClient(List<WinAction> actionList)
        {
            if(m_SocketOpen == false)
            {
                Log.Write("Sending actions failed, socket not open!");
                return;
            }

            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<WinAction>));
            
            jsonSerializer.WriteObject(ms, actionList);

            byte[] jsonOut = ms.ToArray();
            ms.Close();

            Log.Write("Sending JSON WinActions:");
            Log.Write(Encoding.UTF8.GetString(jsonOut, 0, jsonOut.Length));

            m_DataStream.Write(jsonOut, 0, jsonOut.Length);
        }

        public void SendSignalToClient(ServerSignals signal)
        {
            if(m_SocketOpen == false)
            {
                Log.Write("Sending signal failed, socket not open!");
                return;
            }

            m_DataStream.Write(new byte[] {(byte) signal}, 0, 1);
        }
    }
}
