using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    static class CodeExecution
    {

        public enum Instruction
        {
            NOP    = 0b_00000000_00000000,     //0000 0000 0xx0 0000
            MOVLW  = 0b_00110000_00000000,     //0011 00xx kkkk kkkk
            RETLW  = 0b_00110100_00000000,     //0011 01xx kkkk kkkk
            ADDLW  = 0b_00111110_00000000,     //0011 111x kkkk kkkk
            SUBLW  = 0b_00111100_00000000,     //0011 110x kkkk kkkk
            CALL   = 0b_00100000_00000000,     //0010 0kkk kkkk kkkk
            GOTO   = 0b_00101000_00000000,     //0010 1kkk kkkk kkkk
            MOVWF  = 0b_00000000_10000000,     //0000 0000 1fff ffff
            MOVF   = 0b_00001000_00000000,     //0000 1000 dfff ffff
            CLRF   = 0b_00000001_10000000,     //0000 0001 1fff ffff
            CLRW   = 0b_00000001_00000000,     //0000 0001 0xxx xxxx
            SUBWF  = 0b_00000010_00000000,     //0000 0010 dfff ffff
            ADDWF  = 0b_00000111_00000000,     //0000 0111 dfff ffff
            DECFSZ = 0b_00001011_00000000,     //0000 1011 dfff ffff
            INCFSZ = 0b_00001111_00000000,     //0000 1111 dfff ffff
            RLF    = 0b_00001101_00000000,     //0000 1100 dfff ffff
            RRF    = 0b_00001100_00000000,     //0000 1100 dfff ffff
            BSF    = 0b_00010100_00000000,     //0001 01bb bfff ffff
            BCF    = 0b_00010000_00000000,     //0001 00bb bfff ffff
            BTFSC  = 0b_00011000_00000000,     //0001 10bb bfff ffff
            BTFSS  = 0b_00011100_00000000,     //0001 11bb bfff ffff
            XORWF  = 0b_00000110_00000000,     //0000 0110 dfff ffff
            XORLW  = 0b_00111010_00000000,     //0011 1010 kkkk kkkk
            ANDLW  = 0b_00111001_00000000,     //0011 1001 kkkk kkkk
            ANDWF  = 0b_00000101_00000000,     //0000 0101 dfff ffff
            IORLW  = 0b_00111000_00000000,     //0011 1000 kkkk kkkk
            IORWF  = 0b_00000100_00000000      //0000 0100 dfff ffff
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