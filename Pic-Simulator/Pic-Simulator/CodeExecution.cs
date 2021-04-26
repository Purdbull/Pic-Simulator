using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    static class CodeExecution
    {

        public enum Instruction
        {
            NOP    = 0b_00000000_00000000,
            MOVLW  = 0b_00110000_00000000,
            RETLW  = 0b_00110100_00000000,
            ADDLW  = 0b_00111110_00000000,
            SUBLW  = 0b_00111100_00000000,
            CALL   = 0b_00100000_00000000,
            GOTO   = 0b_00101000_00000000,
            MOVWF  = 0b_00000000_10000000,
            MOVF   = 0b_00001000_00000000,
            CLRF   = 0b_00000001_10000000,
            CLRW   = 0b_00000001_00000000,
            SUBWF  = 0b_00000010_00000000,
            ADDWF  = 0b_00000111_00000000,
            DECFSZ = 0b_00001011_00000000,
            INCFSZ = 0b_00001111_00000000,
            RLF    = 0b_00001101_00000000,
            RRF    = 0b_00001100_00000000,
            BSF    = 0b_00010100_00000000,
            BCF    = 0b_00010000_00000000,
            BTFSC  = 0b_00011000_00000000,
            BTFSS  = 0b_00011100_00000000,
            XORWF  = 0b_00000110_00000000,
            XORLW  = 0b_00111010_00000000,
            ANDLW  = 0b_00111001_00000000,
            ANDWF  = 0b_00000101_00000000,
            IORLW  = 0b_00111000_00000000,
            IORWF  = 0b_00000100_00000000
        }

        public (byte, byte, byte, byte) Fetch()
        {
            DataField pc = Form1.pic.pc;
        }

        public (Instruction, byte, byte) Decode(byte instrByte1, byte instrByte2, byte paramByte1, byte paramByte2)
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