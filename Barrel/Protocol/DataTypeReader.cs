using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barrel.Protocol
{
    /// <summary>
    /// Generic class that abstracts reading from a binary stream.
    /// </summary>
    class DataTypeReader
    {
        private BinaryReader dataReader;
        
        public DataTypeReader(BinaryReader reader)
        {
            this.dataReader = reader;
        }

        /// <summary>
        /// Reads a single byte from the binary stream.
        /// </summary>
        /// <returns>Returns the byte read</returns>
        public byte ReadByte()
        {
            return dataReader.ReadByte();
        }

        /// <summary>
        /// Reads a single character from the binary stream.
        /// </summary>
        /// <returns>Returns the character read</returns>
        public char ReadChar()
        {
            return dataReader.ReadChar();
        }

        /// <summary>
        /// Reads a boolean value from the binary stream.
        /// </summary>
        /// <returns>Returns the boolean value read</returns>
        public bool ReadBoolean()
        {
            return dataReader.ReadBoolean();
        }

        
    }
}
