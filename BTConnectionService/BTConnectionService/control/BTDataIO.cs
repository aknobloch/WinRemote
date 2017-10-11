using BTConnectionService.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <returns>WinAction with the data read from the server</returns>
        public WinAction Read()
        {
            WinAction data = new WinAction();

            data.name = "TODO: Interface w/ database"; // TODO
            data.action = "TODO: Interface w/ database";

            int nextByte = m_DataStream.ReadByte();

            if (nextByte != -1)
            {
                Log.write("Read " + nextByte);
            }

            return data;
        }
    }
}
