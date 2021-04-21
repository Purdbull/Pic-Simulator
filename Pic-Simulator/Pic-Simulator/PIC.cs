using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    class PIC
    {
        public static int MAX_DATAMEM_SIZE = 512;
        public static int MAX_PROGMEM_SIZE = 512;

        public ProgramMemory progMem;
        public DataMemory dataMem;

        public DataField wReg;
        public DataField timer;

        public PIC()
        {
            this.progMem = new ProgramMemory();
            this.dataMem = new DataMemory();

            this.wReg = new DataField();
            this.timer = new DataField();
        }
    }
}
