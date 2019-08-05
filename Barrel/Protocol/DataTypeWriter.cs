using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barrel.Protocol
{
    /// <summary>
    /// Generic class that abstracts writing from a binary stream.
    /// </summary>
    class DataTypeWriter
    {
        private BinaryWriter dataWriter;

        public DataTypeWriter(BinaryWriter writer)
        {
            this.dataWriter = writer;
        }

        /// <summary>
        /// Writes a single byte to the binary stream.
        /// </summary>
        /// <param name="b">The byte to write</param>
        public void WriteByte(byte b)
        {
            dataWriter.Write(b);
        }
    }
}
