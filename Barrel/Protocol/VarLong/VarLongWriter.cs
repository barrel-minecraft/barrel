using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barrel.Protocol.VarLong
{
    /// <summary>
    /// Writes Minecraft VarLong data types to a binary stream.
    /// </summary>
    class VarLongWriter : DataTypeWriter
    {
        public VarLongWriter(BinaryWriter writer) : base(writer)
        {

        }

        /// <summary>
        /// Writes a VarLong to the binary stream.
        /// </summary>
        /// <param name="value">The VarLong value to write</param>
        public void WriteVarLong(long value)
        {
            do
            {
                byte temp = (byte)(value & 0b01111111);

                // NOTE: >>> means the sign bit is shifted with the rest of the number
                value = (int)((uint)value >> 7); // value >>>= 7;

                if (value != 0)
                {
                    temp |= 0b10000000;
                }

                WriteByte(temp);
            } while (value != 0);
        }
    }
}
