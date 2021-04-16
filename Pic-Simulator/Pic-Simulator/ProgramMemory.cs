using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    class ProgramMemory : Memory<string>
    {
        public ProgramMemory() : base(Parameters.MAX_DATAMEM_SIZE) { }
    }
}
