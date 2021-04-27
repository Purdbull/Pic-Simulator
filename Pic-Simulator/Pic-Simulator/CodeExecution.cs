using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    public static class CodeExecution
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

        public enum InstructionMask
        {
            XORWF  = 0b_11111111_00000000,  //0000 0110 dfff ffff
            XORLW  = 0b_11111111_00000000,  //0011 1010 kkkk kkkk
            ANDLW  = 0b_11111111_00000000,  //0011 1001 kkkk kkkk
            ANDWF  = 0b_11111111_00000000,  //0000 0101 dfff ffff
            IORLW  = 0b_11111111_00000000,  //0011 1000 kkkk kkkk
            IORWF  = 0b_11111111_00000000,  //0000 0100 dfff ffff
            SUBWF  = 0b_11111111_00000000,  //0000 0010 dfff ffff
            ADDWF  = 0b_11111111_00000000,  //0000 0111 dfff ffff
            DECFSZ = 0b_11111111_00000000,  //0000 1011 dfff ffff
            INCFSZ = 0b_11111111_00000000,  //0000 1111 dfff ffff
            RLF    = 0b_11111111_00000000,  //0000 1100 dfff ffff
            RRF    = 0b_11111111_00000000,  //0000 1100 dfff ffff
            MOVF   = 0b_11111111_00000000,  //0000 1000 dfff ffff

            MOVWF  = 0b_11111111_10000000,  //0000 0000 1fff ffff
            CLRF   = 0b_11111111_10000000,  //0000 0001 1fff ffff
            CLRW   = 0b_11111111_10000000,  //0000 0001 0xxx xxxx

            NOP    = 0b_11111111_10011111,  //0000 0000 0xx0 0000

            ADDLW  = 0b_11111110_00000000,  //0011 111x kkkk kkkk
            MOVLW  = 0b_11111100_00000000,  //0011 00xx kkkk kkkk
            RETLW  = 0b_11111100_00000000,  //0011 01xx kkkk kkkk
            SUBLW  = 0b_11111100_00000000,  //0011 110x kkkk kkkk
            BSF    = 0b_11111100_00000000,  //0001 01bb bfff ffff
            BCF    = 0b_11111100_00000000,  //0001 00bb bfff ffff
            BTFSC  = 0b_11111100_00000000,  //0001 10bb bfff ffff
            BTFSS  = 0b_11111100_00000000,  //0001 11bb bfff ffff
            CALL   = 0b_11111000_00000000,  //0010 0kkk kkkk kkkk
            GOTO   = 0b_11111000_00000000   //0010 1kkk kkkk kkkk
            
            
        }

        public static UInt16 Fetch()
        {
            DataField pc = Form1.pic.pc;
            ProgramMemory progMem = Form1.pic.progMem;
            byte programCounter;
            (_, programCounter) = pc.GetKeyValuePair(0);

            UInt16 data;
            (_, data) = progMem.GetKeyValuePair(programCounter);
            return data;
        }

        public static (Instruction, UInt16) Decode(UInt16 data)
        {
            foreach(Instruction instruction in Enum.GetValues(typeof(Instruction)))
            {
                //extract code and name from the Instruction enum
                UInt16 instrCode = (UInt16)instruction;
                string instrName = Enum.GetName(typeof(Instruction), instruction);
                UInt16 instrMask = Convert.ToUInt16(Enum.Parse(typeof(InstructionMask), instrName));

                //apply mask to data
                UInt16 maskedData = (UInt16)(data & instrMask);

                if(maskedData == instrCode)
                {
                    return(instruction, data);
                }
                else
                {
                    continue;
                }
            }
            //TODO: maybe catch unknown instruction
            return (Instruction.NOP, (UInt16)Instruction.NOP);
        }

        public static bool Execute(Instruction instruction, UInt16 param)
        {
            byte result;
            switch (instruction)
            {
                case Instruction.ADDLW:
                    //calculating wreg + param. result is being stored in wreg
                    result = (byte)(Form1.pic.wReg.GetValue() + Convert.ToByte(param));
                    Form1.pic.wReg.SetValue(result);
                    return true;
                    break;
                case Instruction.ADDWF:
                    return true;
                    break;
                case Instruction.ANDLW:
                    //calculating wreg & param. result is being stored in wreg
                    result = (byte)(Form1.pic.wReg.GetValue() & Convert.ToByte(param));
                    Form1.pic.wReg.SetValue(result);
                    return true;
                    break;
                case Instruction.ANDWF:
                    return true;
                    break;
                case Instruction.BCF:
                    return true;
                    break;
                case Instruction.BSF:
                    return true;
                    break;
                case Instruction.BTFSC:
                    return true;
                    break;
                case Instruction.BTFSS:
                    return true;
                    break;
                case Instruction.CALL:
                    return true;
                    break;
                case Instruction.CLRF:
                    return true;
                    break;
                case Instruction.CLRW:
                    return true;
                    break;
                case Instruction.DECFSZ:
                    return true;
                    break;
                case Instruction.GOTO:
                    return true;
                    break;
                case Instruction.INCFSZ:
                    return true;
                    break;
                case Instruction.IORLW:
                    return true;
                    return true;
                    break;
                case Instruction.IORWF:
                    return true;
                    break;
                case Instruction.MOVF:
                    return true;
                    break;
                case Instruction.MOVLW:
                    return true;
                    break;
                case Instruction.MOVWF:
                    return true;
                    break;
                case Instruction.NOP:
                    return true;
                    break;
                case Instruction.RETLW:
                    return true;
                    break;
                case Instruction.RLF:
                    return true;
                    break;
                case Instruction.RRF:
                    return true;
                    break;
                case Instruction.SUBLW:
                    return true;
                    break;
                case Instruction.SUBWF:
                    return true;
                    break;
                case Instruction.XORLW:
                    return true;
                    break;
                case Instruction.XORWF:
                    return true;
                    break;
                default:
                    return false;
                    
            }
        }
    }
}