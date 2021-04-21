using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    class ProgramMemory : Memory<byte>
    {
        public ProgramMemory() : base(PIC.MAX_DATAMEM_SIZE) { }
    }
}
