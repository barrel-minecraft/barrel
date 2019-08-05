using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barrel.Protocol.VarInt
{
    class VarIntWriter
    {
        private BinaryWriter binaryWriter;

        public VarIntWriter(BinaryWriter writer)
        {
            this.binaryWriter = writer;
        }
        
        /// <summary>
        /// Write a VarInt to the binary stream
        /// </summary>
        /// <param name="value">The VarInt value to write</param>
        public void WriteVarInt(int value)
        {
            while (value != 0)
            {
                byte temp = (byte)(value & 0x7f);

                // >>> means the sign bit is shifted with the rest of the number
                value = (int)((uint)value >> 7); // value >>>= 7;

                if (value != 0)
                {
                    temp |= 0x80;
                }

                WriteByte(temp);
            }
        }
    }
}
