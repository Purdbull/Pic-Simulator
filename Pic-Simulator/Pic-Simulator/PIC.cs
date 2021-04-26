using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    public class PIC
    {
        public static int MAX_DATAMEM_SIZE = 512;
        public static int MAX_PROGMEM_SIZE = 512;

        public ProgramMemory progMem;
        public DataMemory dataMem;

        public DataField wReg;
        public DataField timer;
        public DataField pc;

        public PIC()
        {
            this.progMem = new ProgramMemory();
            this.dataMem = new DataMemory();

            this.wReg = new DataField();
            this.timer = new DataField();
        }
    }
}
