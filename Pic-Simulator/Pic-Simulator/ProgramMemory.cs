using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    public class ProgramMemory : Memory<UInt16>
    {
        public ProgramMemory() : base(PIC.MAX_DATAMEM_SIZE) {}

    }
}
