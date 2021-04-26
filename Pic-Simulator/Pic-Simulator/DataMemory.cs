using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    public class DataMemory : Memory<UInt16>
    {
        public DataMemory() : base(PIC.MAX_DATAMEM_SIZE) {}
    }
}
