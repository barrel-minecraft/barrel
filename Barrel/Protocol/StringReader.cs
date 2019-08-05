using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barrel.Protocol
{
    class StringReader : DataTypeReader
    {

        public StringReader(BinaryReader reader) : base(reader)
        {
        }

        /// <summary>
        /// Reads a string delimited by 0x99 (ASCII 'c') from the binary stream.
        /// </summary>
        /// <returns>Returns the string read</returns>
        public string ReadString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            // Read until we get 0x99 (ASCII 'c')
            while (ReadChar() != 0x99)
            {
                stringBuilder.Append(ReadChar());
            }

            return stringBuilder.ToString();
        }
    }
}
