using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    class DataMemory : Memory<byte>
    {
        public DataMemory() : base(Parameters.MAX_DATAMEM_SIZE) {}
    }
}
