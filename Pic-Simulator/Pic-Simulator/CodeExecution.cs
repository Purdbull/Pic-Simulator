using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    static class CodeExecution
    {

        public enum Instruction
        {
            
        }

        public (byte, byte, byte, byte) Fetch()
        {

        }

        public bool Execute(Instruction instruction, byte param1, byte param2)
        {
            switch (instruction)
            {
                case Instruction.MOVLW:
                    break;
                default:
                    return false;
                    
            }
        }
    }
}