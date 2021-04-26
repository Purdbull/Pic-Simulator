using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    static class CodeExecution
    {

        public enum Instruction
        {
            MOVLW  = 00110000_00000000,
            ADDLW  = ,
            SUBLW  = ,
            CALL   = ,
            GOTO   = ,
            MOVWF  = ,
            MOVF   = ,
            SUBWF  = ,
            ADDWF  = ,
            DECFSZ = ,
            INCFSZ = ,
            RLF    = ,
            RRF    = ,
            BSF    = ,
            BCF    = ,
            BTSFC  = ,
            BTFSS  = ,
            XORWF  = ,
            XORLW  = ,
            ANDLW  = ,
            ANDWF  = ,
            IORLW  = ,
            IORWF  = 
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