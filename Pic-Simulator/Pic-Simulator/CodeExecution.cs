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
            DECF   = 0b_00000011_00000000,  //0000 0011 dfff ffff
            RETURN = 0b_00000000_00001000   //0000 0000 0000 1000
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
            GOTO   = 0b_11111000_00000000,  //0010 1kkk kkkk kkkk
            RETURN = 0b_11111111_11111111   //0000 0000 0000 1000
        }

        public static UInt16 Fetch()
        {
            byte programCounter = Program.pic.pc.GetValue();

            UInt16 data;
            (_, data) = Program.pic.progMem.GetKeyValuePair(programCounter);
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
            byte operand1;
            byte operand2;

            bool carryBit;

            int  index;
            int  destinationBitIndex    = 7;
            int  overflowCheck;

            const byte DCMask           = 0b_00001111;
            const byte statusAdress     = 3;
            const UInt16 addressMask    = 0b_00000111_11111111;
            const bool BANK1            = true;

            bool bank = Program.pic.dataMem.GetFlag(BANK1, statusAdress, 5);


            switch (instruction)
            {
                
                case Instruction.ADDLW:
                    operand1 = (byte)(Program.pic.wReg.GetValue());
                    operand2 = (byte)(data);
                    overflowCheck = operand1 + operand2;

                    result = (byte)(operand1 + operand2);
                    Program.pic.wReg.SetValue(result);

                    if ((operand1 & DCMask) + (operand2 & DCMask) > 15)
                    {
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 1); //setting dc-flag
                    }
                    else
                    {
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 1); //clearing dc-flag
                    }

                    if (overflowCheck > 255) 
                    {
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 0); //setting c-flag
                    }
                    else
                    {
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 0); //clearing c-flag
                    }

                    if (result > 0) 
                    {
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 2); //clearing z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 2); //setting z-flag
                    }

                    if (operand2 == 0)
                    {
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 1); //clearing dc-flag
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 0); //clearing c-flag
                    }

                    return true;

                case Instruction.ADDWF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);

                    operand1 = (byte)(Program.pic.wReg.GetValue());
                    operand2 = (byte)(Program.pic.dataMem.GetValue(dataMemAddress));
                    overflowCheck = operand1 + operand2;

                    result = (byte)(operand1 + operand2);

                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.SetByte(bank, dataMemAddress, result);
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(result);
                    }

                    if ((operand1 & DCMask) + (operand2 & DCMask) > 15)
                    {
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 1); //setting dc-flag
                    }
                    else
                    {
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 1); //clearing dc-flag
                    }

                    if (overflowCheck > 255)
                    {
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 0); //setting c-flag
                    }
                    else
                    {
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 0); //clearing c-flag
                    }

                    if (result > 0)
                    {
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 2); //clearing z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 2); //setting z-flag
                    }

                    if (operand2 == 0)
                    {
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 1); //clearing dc-flag
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 0); //clearing c-flag
                    }

                    return true;

                case Instruction.ANDLW:
                    result = (byte)(Program.pic.wReg.GetValue() & (byte)(data));
                    Program.pic.wReg.SetValue(result);
                    if (result > 0)
                    {
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 2); //clearing z-flag
                    }
                    else 
                    {
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 2); //setting z-flag
                    }
                    return true;

                case Instruction.ANDWF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Program.pic.wReg.GetValue() & Program.pic.dataMem.GetValue(dataMemAddress));
                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.SetByte(bank, dataMemAddress, result);
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(result);
                    }

                    if (result > 0)
                    {
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 2); //clearing z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 2); //setting z-flag
                    }
                    return true;

                case Instruction.BCF:
                    //bits 9, 8 and 7 are used to define the index of the bit that is to be cleared
                    index = (Extensions.ConvertThreeBitsToInt(data.GetBit(9), data.GetBit(8), data.GetBit(7)));
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Program.pic.dataMem.GetValue(dataMemAddress));

                    result = Extensions.ClearBitInByte(result, index);
                    Program.pic.dataMem.SetByte(bank, dataMemAddress, result);
                    return true;

                case Instruction.BSF:
                    //bits 9, 8 and 7 are used to define the index of the bit that is to be set
                    index = (Extensions.ConvertThreeBitsToInt(data.GetBit(9), data.GetBit(8), data.GetBit(7)));
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Program.pic.dataMem.GetValue(dataMemAddress));

                    result = Extensions.SetBitInByte(result, index);
                    Program.pic.dataMem.SetByte(bank, dataMemAddress, result);
                    return true;

                case Instruction.BTFSC:
                    //bits 9, 8 and 7 are used to define the index of the bit that is to be evaluated
                    index = (Extensions.ConvertThreeBitsToInt(data.GetBit(9), data.GetBit(8), data.GetBit(7)));
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    if (Program.pic.dataMem.GetFlag(bank, dataMemAddress, index))
                    {
                        //nothing really happens
                    }
                    else
                    {
                        Program.pic.pc.Increment();
                        //skip and perform nop
                    }
                    return true;
                     
                case Instruction.BTFSS:
                    //bits 9, 8 and 7 are used to define the index of the bit that is to be evaluated
                    index = (Extensions.ConvertThreeBitsToInt(data.GetBit(9), data.GetBit(8), data.GetBit(7)));
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    if (!Program.pic.dataMem.GetFlag(bank, dataMemAddress, index))
                    {
                        //nothing really happens
                    }
                    else
                    {
                        Program.pic.pc.Increment();
                        //skip and perform nop
                    }
                    return true;

                case Instruction.CALL:
                    return true;

                case Instruction.CLRF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    Program.pic.dataMem.SetByte(bank, dataMemAddress, 0);
                    Program.pic.dataMem.SetFlag(BANK1, statusAdress, 2); //setting z-flag
                    return true;

                case Instruction.CLRW:
                    Program.pic.wReg.SetValue(0);
                    Program.pic.dataMem.SetFlag(BANK1, statusAdress, 2); //setting z-flag
                    return true;

                case Instruction.DECFSZ:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Program.pic.dataMem.GetValue(dataMemAddress) - 1);
                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.SetByte(bank, dataMemAddress, result);
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(result);
                    }
                    if (result == 0)
                    {
                        Program.pic.pc.Increment();
                    }
                    return true;
                case Instruction.INCFSZ:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Program.pic.dataMem.GetValue(dataMemAddress) + 1);
                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.SetByte(bank, dataMemAddress, result);
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(result);
                    }
                    if (result == 0)
                    {
                        Program.pic.pc.Increment();
                    }
                    return true;

                case Instruction.INCF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Program.pic.dataMem.GetValue(dataMemAddress) + 1);
                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.SetByte(bank, dataMemAddress, result);
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(result);
                    }

                    if (result > 0)
                    {
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 2); //clearing z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 2); //setting z-flag
                    }
                    return true;

                case Instruction.DECF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Program.pic.dataMem.GetValue(dataMemAddress) - 1);
                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.SetByte(bank, dataMemAddress, result);
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(result);
                    }

                    if (result > 0)
                    {
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 2); //clearing z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 2); //setting z-flag
                    }
                    return true;

                case Instruction.GOTO:
                    return true;

                case Instruction.IORLW:
                    result = (byte)(Program.pic.wReg.GetValue() | (byte)(data));
                    Program.pic.wReg.SetValue(result);

                    if (result > 0)
                    {
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 2); //clearing z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 2); //setting z-flag
                    }
                    return true;

                case Instruction.IORWF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Program.pic.wReg.GetValue() | Program.pic.dataMem.GetValue(dataMemAddress));
                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.SetByte(bank, dataMemAddress, result);
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(result);
                    }

                    if (result > 0)
                    {
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 2); //clearing z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 2); //setting z-flag
                    }
                    return true;

                case Instruction.MOVF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    if(data.GetBit(destinationBitIndex))
                    {
                        //its moved back to where it was removed so nothing really happens
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(Convert.ToByte(Program.pic.dataMem.GetValue(dataMemAddress)));
                    }

                    Program.pic.dataMem.SetFlag(BANK1, statusAdress, 2); //setting z-flag
                    return true;

                case Instruction.MOVLW:
                    Program.pic.wReg.SetValue((byte)(data));
                    return true;

                case Instruction.MOVWF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    Program.pic.dataMem.SetValue(dataMemAddress, Program.pic.wReg.GetValue());
                    return true;

                case Instruction.NOP:
                    return true;

                case Instruction.RETLW:
                    return true;

                case Instruction.RETURN:
                    return true;

                case Instruction.RLF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Program.pic.dataMem.GetValue(dataMemAddress));
                    carryBit = Program.pic.dataMem.GetFlag(BANK1, statusAdress, 2);
                    if (result.GetBit(7))
                    {
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 2);
                    }
                    else
                    {
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 2);
                    }
                    result = (byte)(result << 1);
                    if (carryBit)
                    {
                        Extensions.SetBitInByte(result, 0);
                    }
                    else
                    {
                        Extensions.ClearBitInByte(result, 0);
                    }

                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.SetByte(bank, dataMemAddress, result);
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(result);
                    }
                    return true;

                case Instruction.RRF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Program.pic.dataMem.GetValue(dataMemAddress));
                    carryBit = Program.pic.dataMem.GetFlag(BANK1, statusAdress, 2);
                    if (result.GetBit(0))
                    {
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 2);
                    }
                    else
                    {
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 2);
                    }
                    result = (byte)(result >> 1);
                    if (carryBit)
                    {
                        Extensions.SetBitInByte(result, 7);
                    }
                    else
                    {
                        Extensions.ClearBitInByte(result, 7);
                    }

                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.SetByte(bank, dataMemAddress, result);
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(result);
                    }
                    return true;

                case Instruction.SUBLW:
                    operand1 = (byte)(data);
                    operand2 = Program.pic.wReg.GetValue();
                    overflowCheck = operand1 - operand2;
                    result = (byte)(operand1 - operand2);

                    Program.pic.wReg.SetValue(result);

                    if (result > 0)
                    {
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 2); //clearing z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 2); //setting z-flag
                    }

                    if (overflowCheck >= 0)
                    {
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 0); //setting c-flag
                    }
                    else
                    {
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 0); //clearing c-flag
                    }

                    if (operand2 == 0)
                    {
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 0); //setting c-flag
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 1); //setting dc-flag
                    }

                    return true;

                case Instruction.SUBWF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    operand1 = (byte)(Program.pic.dataMem.GetValue(dataMemAddress));
                    operand2 = Program.pic.wReg.GetValue();
                    overflowCheck = operand1 - operand2;

                    result = (byte)(operand1 - operand2);

                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.SetByte(bank, dataMemAddress, result);
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(result);
                    }

                    if (result > 0)
                    {
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 2); //clearing z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 2); //setting z-flag
                    }

                    if (overflowCheck >= 0)
                    {
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 0); //setting c-flag
                    }
                    else
                    {
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 0); //clearing c-flag
                    }

                    if (operand2 == 0)
                    {
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 0); //setting c-flag
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 1); //setting dc-flag
                    }

                    return true;

                case Instruction.XORLW:
                    result = (byte)(Program.pic.wReg.GetValue() ^ (byte)(data));
                    Program.pic.wReg.SetValue(result);

                    if (result > 0)
                    {
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 2); //clearing z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 2); //setting z-flag
                    }
                    return true;

                case Instruction.XORWF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Program.pic.wReg.GetValue() ^ Program.pic.dataMem.GetValue(dataMemAddress));
                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.SetByte(bank, dataMemAddress, result);
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(result);
                    }

                    if (result > 0)
                    {
                        Program.pic.dataMem.ClearFlag(BANK1, statusAdress, 2); //clearing z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.SetFlag(BANK1, statusAdress, 2); //setting z-flag
                    }
                    return true;

                default:
                    return false;
                    
            }
        }
    }
}