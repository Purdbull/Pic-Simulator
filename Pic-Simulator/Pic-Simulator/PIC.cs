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
        public DataField pc;
        public DataField timer;

        public Stack stack;

        public int quarzCycles;

        public List<int> breakpoints;


        public PIC()
        {
            this.progMem = new ProgramMemory();
            this.dataMem = new DataMemory();

            this.wReg = new DataField();
            this.pc = new DataField();
            this.timer = new DataField();

            this.stack = new Stack(8);

            this.quarzCycles = 0;
        }

        public bool Step()
        {
            UInt16 data = CodeExecution.Fetch();

            if (data == UInt16.MaxValue) return false; //end of code has been reached

            this.pc.Increment(); //increment pc after fetch

            CodeExecution.Instruction instruction = CodeExecution.Decode(data);

            bool success = CodeExecution.Execute(instruction, data);

            //refresh gui after

            return success;
        }

        public void Continue()
        {
            //TODO: continuously step and stop at breakpoints
        }

        public void Run()
        {
            //TODO: continuously step without stopping at breakpoints
        }
    }
}
