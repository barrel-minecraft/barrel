using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barrel.Protocol.VarLong
{
    /// <summary>
    /// Reads Minecraft VarLong data types from a binary stream. 
    /// </summary>
    class VarLongReader : DataTypeReader
    {
        public VarLongReader(BinaryReader reader) : base(reader)
        {
        }

        /// <summary>
        /// Reads a VarLong from the binary stream. VarLongs are never longer than 10 bytes
        /// to prevent the possibility of a Denial of Service (DoS) attack.
        /// </summary>
        /// <returns>Returns the VarInt value read</returns>
        public long ReadVarLong()
        {
            int bytesRead = 0;
            long result = 0;
            byte b = 0;

            do
            {
                // Read the byte
                b = ReadByte();
                int value = (b & 0b01111111);
                result |= (value << (7 * bytesRead));

                bytesRead++;
                if (bytesRead > 10)
                {
                    // VarLong is limited to a maximum of 10 bytes
                    throw new DataTypeRangeException("VarLong is too large");
                }
            } while ((b & 0b10000000) != 0);

            return result;
        }
    }
}
