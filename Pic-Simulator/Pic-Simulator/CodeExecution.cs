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
            MOVWF  = 00000000_10000000,
            MOVF   = 00001000_00000000,
            CLRF   = 00000001_10000000,
            CLRW   = 00000001_00000000,
            SUBWF  = 00000010_00000000,
            ADDWF  = 00000111_00000000,
            DECFSZ = 00001011_00000000,
            INCFSZ = 00001111_00000000,
            RLF    = 00001101_00000000,
            RRF    = 00001100_00000000,
            BSF    = 00010100_00000000,
            BCF    = 00010000_00000000,
            BTFSC  = 00011000_00000000,
            BTFSS  = 00011100_00000000,
            XORWF  = 00000110_00000000,
            XORLW  = 00111010_00000000,
            ANDLW  = 00111001_00000000,
            ANDWF  = 00000101_00000000,
            IORLW  = 00111000_00000000,
            IORWF  = 00000100_00000000
        }

        public (byte, byte, byte, byte) Fetch()
        {
            DataField pc = Form1.pic.pc;
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