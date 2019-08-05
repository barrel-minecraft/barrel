using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barrel.Protocol.VarLong
{
    class VarLongReader : DataTypeReader
    {
        public VarLongReader(BinaryReader reader) : base(reader)
        {
        }
    }
}
