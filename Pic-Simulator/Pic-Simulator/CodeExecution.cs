using System;
using System.Collections.Generic;
using System.Text;
using ExtensionMethods;

namespace Pic_Simulator
{
    public static class CodeExecution
    {
        public enum Instruction
        {
            NOP    = 0b_00000000_00000000,  //0000 0000 0xx0 0000
            MOVLW  = 0b_00110000_00000000,  //0011 00xx kkkk kkkk
            RETLW  = 0b_00110100_00000000,  //0011 01xx kkkk kkkk
            ADDLW  = 0b_00111110_00000000,  //0011 111x kkkk kkkk
            SUBLW  = 0b_00111100_00000000,  //0011 110x kkkk kkkk
            CALL   = 0b_00100000_00000000,  //0010 0kkk kkkk kkkk
            GOTO   = 0b_00101000_00000000,  //0010 1kkk kkkk kkkk
            MOVWF  = 0b_00000000_10000000,  //0000 0000 1fff ffff
            MOVF   = 0b_00001000_00000000,  //0000 1000 dfff ffff
            CLRF   = 0b_00000001_10000000,  //0000 0001 1fff ffff
            CLRW   = 0b_00000001_00000000,  //0000 0001 0xxx xxxx
            SUBWF  = 0b_00000010_00000000,  //0000 0010 dfff ffff
            ADDWF  = 0b_00000111_00000000,  //0000 0111 dfff ffff
            DECFSZ = 0b_00001011_00000000,  //0000 1011 dfff ffff
            INCFSZ = 0b_00001111_00000000,  //0000 1111 dfff ffff
            RLF    = 0b_00001101_00000000,  //0000 1100 dfff ffff
            RRF    = 0b_00001100_00000000,  //0000 1100 dfff ffff
            BSF    = 0b_00010100_00000000,  //0001 01bb bfff ffff
            BCF    = 0b_00010000_00000000,  //0001 00bb bfff ffff
            BTFSC  = 0b_00011000_00000000,  //0001 10bb bfff ffff
            BTFSS  = 0b_00011100_00000000,  //0001 11bb bfff ffff
            XORWF  = 0b_00000110_00000000,  //0000 0110 dfff ffff
            XORLW  = 0b_00111010_00000000,  //0011 1010 kkkk kkkk
            ANDLW  = 0b_00111001_00000000,  //0011 1001 kkkk kkkk
            ANDWF  = 0b_00000101_00000000,  //0000 0101 dfff ffff
            IORLW  = 0b_00111000_00000000,  //0011 1000 kkkk kkkk
            IORWF  = 0b_00000100_00000000,  //0000 0100 dfff ffff
            INCF   = 0b_00001010_00000000,  //0000 1010 dfff ffff
            DECF   = 0b_00000011_00000000   //0000 0011 dfff ffff
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
            INCF   = 0b_11111111_00000000,  //0000 1010 dfff ffff
            DECF   = 0b_11111111_00000000,  //0000 0011 dfff ffff

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

        public static Instruction Decode(UInt16 data)
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
                    return(instruction);
                }
            }
            //TODO: maybe catch unknown instruction
            return (Instruction.NOP);
        }

        public static bool Execute(Instruction instruction, UInt16 data)
        {
            byte result;
            byte param;
            byte dataMemAddress;
            byte mask;
            int  index;
            int  destinationBitIndex = 7;

            const byte BSFMask = 0b_00000001;
            const byte BCFMask = 0b_11111110;
            const int  statusAdress = 3;

            switch (instruction)
            {
                case Instruction.ADDLW:
                    //TODO: affects on C, DC, Z
                    result = (byte)(Form1.pic.wReg.GetValue() + Convert.ToByte(data));
                    Form1.pic.wReg.SetValue(result);
                    return true;

                case Instruction.ADDWF:
                    //TODO: affects on C, DC, Z
                    param = Convert.ToByte(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Form1.pic.wReg.GetValue() + Form1.pic.dataMem.GetValue(dataMemAddress));
                    if (data.GetBit(destinationBitIndex))
                    {
                        Form1.pic.dataMem.SetValue(dataMemAddress, result);
                    }
                    else
                    {
                        Form1.pic.wReg.SetValue(result);
                    }
                    return true;

                case Instruction.ANDLW:
                    result = (byte)(Form1.pic.wReg.GetValue() & Convert.ToByte(data));
                    Form1.pic.wReg.SetValue(result);
                    if (result > 0)
                    {
                        // TODO: clear z
                    }
                    else 
                    {
                        //TODO: set z
                    }
                    return true;

                case Instruction.ANDWF:
                    //TODO: affects on C, DC, Z
                    param = Convert.ToByte(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Form1.pic.wReg.GetValue() & Form1.pic.dataMem.GetValue(dataMemAddress));
                    if (data.GetBit(destinationBitIndex))
                    {
                        Form1.pic.dataMem.SetValue(dataMemAddress, result);
                    }
                    else
                    {
                        Form1.pic.wReg.SetValue(result);
                    }
                    return true;

                case Instruction.BCF:
                    //bits 9, 8 and 7 are used to define the index of the bit that is to be cleared
                    index = (Extensions.ConvertThreeBitsToInt(data.GetBit(9), data.GetBit(8), data.GetBit(7)));
                    param = Convert.ToByte(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Form1.pic.dataMem.GetValue(dataMemAddress));

                    result = Extensions.ClearBitInByte(result, index);
                    Form1.pic.dataMem.SetValue(dataMemAddress, result);
                    return true;

                case Instruction.BSF:
                    //bits 9, 8 and 7 are used to define the index of the bit that is to be set
                    index = (Extensions.ConvertThreeBitsToInt(data.GetBit(9), data.GetBit(8), data.GetBit(7)));
                    param = Convert.ToByte(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Form1.pic.dataMem.GetValue(dataMemAddress));

                    result = Extensions.SetBitInByte(result, index);
                    Form1.pic.dataMem.SetValue(dataMemAddress, result);
                    return true;

                case Instruction.BTFSC:
                    return true;
                case Instruction.BTFSS:
                    return true;
                case Instruction.CALL:
                    return true;
                case Instruction.CLRF:
                    //TODO: affects on Z
                    param = Convert.ToByte(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    Form1.pic.dataMem.SetValue(dataMemAddress, 0);
                    return true;

                case Instruction.CLRW:
                    //TODO: affects on Z
                    Form1.pic.wReg.SetValue(0);
                    return true;

                case Instruction.DECFSZ:
                    return true;
                case Instruction.INCFSZ:
                    return true;

                case Instruction.INCF:
                    param = Convert.ToByte(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Form1.pic.dataMem.GetValue(dataMemAddress) + 1);
                    if (data.GetBit(destinationBitIndex))
                    {
                        Form1.pic.dataMem.SetValue(dataMemAddress, result);
                    }
                    else
                    {
                        Form1.pic.wReg.SetValue(result);
                    }

                    if (result > 0)
                    {
                        // TODO: clear z
                    }
                    else
                    {
                        //TODO: set z
                    }
                    return true;

                case Instruction.DECF:
                    param = Convert.ToByte(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Form1.pic.dataMem.GetValue(dataMemAddress) - 1);
                    if (data.GetBit(destinationBitIndex))
                    {
                        Form1.pic.dataMem.SetValue(dataMemAddress, result);
                    }
                    else
                    {
                        Form1.pic.wReg.SetValue(result);
                    }

                    if (result > 0)
                    {
                        // TODO: clear z
                    }
                    else
                    {
                        //TODO: set z
                    }
                    return true;

                case Instruction.GOTO:
                    return true;

                case Instruction.IORLW:
                    result = (byte)(Form1.pic.wReg.GetValue() | Convert.ToByte(data));
                    Form1.pic.wReg.SetValue(result);

                    if (result > 0)
                    {
                        // TODO: clear z
                    }
                    else
                    {
                        //TODO: set z
                    }
                    return true;

                case Instruction.IORWF:
                    param = Convert.ToByte(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Form1.pic.wReg.GetValue() | Form1.pic.dataMem.GetValue(dataMemAddress));
                    if (data.GetBit(destinationBitIndex))
                    {
                        Form1.pic.dataMem.SetValue(dataMemAddress, result);
                    }
                    else
                    {
                        Form1.pic.wReg.SetValue(result);
                    }

                    if (result > 0)
                    {
                        // TODO: clear z
                    }
                    else
                    {
                        //TODO: set z
                    }
                    return true;

                case Instruction.MOVF:
                    //TODO: affects on Z
                    param = Convert.ToByte(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    if(data.GetBit(destinationBitIndex))
                    {
                        //its moved back to where it was removed so nothing really happens
                    }
                    else
                    {
                        Form1.pic.wReg.SetValue(Convert.ToByte(Form1.pic.dataMem.GetValue(dataMemAddress)));
                    }
                    return true;

                case Instruction.MOVLW:
                    Form1.pic.wReg.SetValue(Convert.ToByte(data));
                    return true;

                case Instruction.MOVWF:
                    param = Convert.ToByte(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    Form1.pic.dataMem.SetValue(dataMemAddress, Form1.pic.wReg.GetValue());
                    return true;

                case Instruction.NOP:
                    return true;

                case Instruction.RETLW:
                    return true;
                case Instruction.RLF:
                    return true;
                case Instruction.RRF:
                    return true;
                case Instruction.SUBLW:
                    //TODO: affects on C, DC, Z
                    result = (byte)(Convert.ToByte(data) - Form1.pic.wReg.GetValue());
                    Form1.pic.wReg.SetValue(result);
                    return true;

                case Instruction.SUBWF:
                    //TODO: affects on C, DC, Z
                    param = Convert.ToByte(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Form1.pic.dataMem.GetValue(dataMemAddress) - Form1.pic.wReg.GetValue());

                    if (data.GetBit(destinationBitIndex))
                    {
                        Form1.pic.dataMem.SetValue(dataMemAddress, result);
                    }
                    else
                    {
                        Form1.pic.wReg.SetValue(result);
                    }
                    return true;

                case Instruction.XORLW:
                    result = (byte)(Form1.pic.wReg.GetValue() ^ Convert.ToByte(data));
                    Form1.pic.wReg.SetValue(result);

                    if (result > 0)
                    {
                        // TODO: clear z
                    }
                    else
                    {
                        //TODO: set z
                    }
                    return true;

                case Instruction.XORWF:
                    param = Convert.ToByte(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Form1.pic.wReg.GetValue() ^ Form1.pic.dataMem.GetValue(dataMemAddress));
                    if (data.GetBit(destinationBitIndex))
                    {
                        Form1.pic.dataMem.SetValue(dataMemAddress, result);
                    }
                    else
                    {
                        Form1.pic.wReg.SetValue(result);
                    }

                    if (result > 0)
                    {
                        // TODO: clear z
                    }
                    else
                    {
                        //TODO: set z
                    }
                    return true;

                default:
                    return false;
                    
            }
        }
    }
}