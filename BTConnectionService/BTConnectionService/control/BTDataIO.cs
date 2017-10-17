using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winRemoteDataBase.Controller;
using winRemoteDataBase.Model;

namespace BTConnectionService.control
{
    class BTDataIO
    {
        Stream m_DataStream;

        public BTDataIO(Stream dataStream)
        {
            this.m_DataStream = dataStream;
        }

        public Boolean CanRead()
        {
            return m_DataStream.CanRead;
        }

        /// <summary>
        /// Reads in the next action command from
        /// the client application. This operation is 
        /// blocking, and will not return until a button
        /// is read in from the stream.
        /// </summary>
        /// 
        /// <returns>List<string> with the execution commands read from the server</returns>
        public List<string> Read()
        {
            int nextByte = m_DataStream.ReadByte();

            List<string> commands = new List<string>();

            if (nextByte != -1)
            {
                Log.write("Read " + nextByte);
                int buttonID = Convert.ToInt32(nextByte);
                commands = DBHelper.GetActions(buttonID);
            }

            return commands;
        }
    }
}
