using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    static class CodeExecution
    {

        public enum Instruction
        {
            NOP    = 00000000_00000000,
            MOVLW  = 00110000_00000000,
            RETLW  = 00110100_00000000,
            ADDLW  = 00111110_00000000,
            SUBLW  = 00111100_00000000,
            CALL   = 00100000_00000000,
            GOTO   = 00101000_00000000,
            MOVWF  = ,
            MOVF   = ,
            CLRF   = ,
            CLRW   = ,
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