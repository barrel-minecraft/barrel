using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barrel.Protocol.VarInt
{
    /// <summary>
    /// Reads Minecraft VarInt data types from a binary stream. 
    /// </summary>
    class VarIntReader : DataTypeReader
    {
        public VarIntReader(BinaryReader reader) : base(reader)
        {
        }

        /// <summary>
        /// Reads a VarInt from the binary stream. To prevent the possibility of a DoS 
        /// (Denial of Service) attack the length is capped at a maximum of 5 bytes.
        /// </summary>
        /// <returns>Returns the VarInt value read</returns>
        public int ReadVarInt()
        {
            int bytesRead = 0;
            int result = 0;
            byte b = 0;

            do
            {
                // Read the byte
                b = ReadByte();
                int value = (b & 0x7f);
                result |= (value << (7 * bytesRead));

                bytesRead++;
                if (bytesRead > 5)
                {
                    // VarInt is capped at a maximum of 5 bytes, to prevent DoS attack.
                    throw new ArgumentOutOfRangeException("bytesRead");
                }
            }
            while ((b & 0x80) != 0);

            return result;
        }
    }
}
