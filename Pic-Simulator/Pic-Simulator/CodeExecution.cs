using System;
using System.Collections.Generic;
using System.Text;
using static ExtensionMethods.Extensions;

namespace Pic_Simulator
{
    public static class CodeExecution
    {
        public enum Instruction
        {
            NOP     = 0b_00000000_00000000,     //0000 0000 0xx0 0000
            MOVLW   = 0b_00110000_00000000,     //0011 00xx kkkk kkkk
            RETLW   = 0b_00110100_00000000,     //0011 01xx kkkk kkkk
            ADDLW   = 0b_00111110_00000000,     //0011 111x kkkk kkkk
            SUBLW   = 0b_00111100_00000000,     //0011 110x kkkk kkkk
            CALL    = 0b_00100000_00000000,     //0010 0kkk kkkk kkkk
            GOTO    = 0b_00101000_00000000,     //0010 1kkk kkkk kkkk
            MOVWF   = 0b_00000000_10000000,     //0000 0000 1fff ffff
            MOVF    = 0b_00001000_00000000,     //0000 1000 dfff ffff
            CLRF    = 0b_00000001_10000000,     //0000 0001 1fff ffff
            CLRW    = 0b_00000001_00000000,     //0000 0001 0xxx xxxx
            SUBWF   = 0b_00000010_00000000,     //0000 0010 dfff ffff
            ADDWF   = 0b_00000111_00000000,     //0000 0111 dfff ffff
            DECFSZ  = 0b_00001011_00000000,     //0000 1011 dfff ffff
            INCFSZ  = 0b_00001111_00000000,     //0000 1111 dfff ffff
            RLF     = 0b_00001101_00000000,     //0000 1100 dfff ffff
            RRF     = 0b_00001100_00000000,     //0000 1100 dfff ffff
            BSF     = 0b_00010100_00000000,     //0001 01bb bfff ffff
            BCF     = 0b_00010000_00000000,     //0001 00bb bfff ffff
            BTFSC   = 0b_00011000_00000000,     //0001 10bb bfff ffff
            BTFSS   = 0b_00011100_00000000,     //0001 11bb bfff ffff
            XORWF   = 0b_00000110_00000000,     //0000 0110 dfff ffff
            XORLW   = 0b_00111010_00000000,     //0011 1010 kkkk kkkk
            ANDLW   = 0b_00111001_00000000,     //0011 1001 kkkk kkkk
            ANDWF   = 0b_00000101_00000000,     //0000 0101 dfff ffff
            IORLW   = 0b_00111000_00000000,     //0011 1000 kkkk kkkk
            IORWF   = 0b_00000100_00000000,     //0000 0100 dfff ffff
            INCF    = 0b_00001010_00000000,     //0000 1010 dfff ffff
            DECF    = 0b_00000011_00000000,     //0000 0011 dfff ffff
            RETURN  = 0b_00000000_00001000,     //0000 0000 0000 1000
            COMF    = 0b_00001001_00000000,     //0000 1001 dfff ffff
            SWAPF   = 0b_00001110_00000000,     //0000 1110 dfff ffff
            CLRWDT  = 0b_00000000_01100100,     //0000 0000 0110 0100
            SLEEP   = 0b_00000000_01100011,     //0000 0000 0110 0011
            RETFIE  = 0b_00000000_00001001,     //0000 0000 0000 1001
        }

        public enum InstructionMask
        {
            XORWF   = 0b_11111111_00000000,     //0000 0110 dfff ffff
            XORLW   = 0b_11111111_00000000,     //0011 1010 kkkk kkkk
            ANDLW   = 0b_11111111_00000000,     //0011 1001 kkkk kkkk
            ANDWF   = 0b_11111111_00000000,     //0000 0101 dfff ffff
            IORLW   = 0b_11111111_00000000,     //0011 1000 kkkk kkkk
            IORWF   = 0b_11111111_00000000,     //0000 0100 dfff ffff
            SUBWF   = 0b_11111111_00000000,     //0000 0010 dfff ffff
            ADDWF   = 0b_11111111_00000000,     //0000 0111 dfff ffff
            DECFSZ  = 0b_11111111_00000000,     //0000 1011 dfff ffff
            INCFSZ  = 0b_11111111_00000000,     //0000 1111 dfff ffff
            RLF     = 0b_11111111_00000000,     //0000 1100 dfff ffff
            RRF     = 0b_11111111_00000000,     //0000 1100 dfff ffff
            MOVF    = 0b_11111111_00000000,     //0000 1000 dfff ffff
            INCF    = 0b_11111111_00000000,     //0000 1010 dfff ffff
            DECF    = 0b_11111111_00000000,     //0000 0011 dfff ffff
            COMF    = 0b_11111111_00000000,     //0000 1001 dfff ffff
            SWAPF   = 0b_11111111_00000000,     //0000 1110 dfff ffff

            MOVWF   = 0b_11111111_10000000,     //0000 0000 1fff ffff
            CLRF    = 0b_11111111_10000000,     //0000 0001 1fff ffff
            CLRW    = 0b_11111111_10000000,     //0000 0001 0xxx xxxx

            NOP     = 0b_11111111_10011111,     //0000 0000 0xx0 0000

            ADDLW   = 0b_11111110_00000000,     //0011 111x kkkk kkkk
            MOVLW   = 0b_11111100_00000000,     //0011 00xx kkkk kkkk
            RETLW   = 0b_11111100_00000000,     //0011 01xx kkkk kkkk
            SUBLW   = 0b_11111110_00000000,     //0011 110x kkkk kkkk
            BSF     = 0b_11111100_00000000,     //0001 01bb bfff ffff
            BCF     = 0b_11111100_00000000,     //0001 00bb bfff ffff
            BTFSC   = 0b_11111100_00000000,     //0001 10bb bfff ffff
            BTFSS   = 0b_11111100_00000000,     //0001 11bb bfff ffff
            CALL    = 0b_11111000_00000000,     //0010 0kkk kkkk kkkk
            GOTO    = 0b_11111000_00000000,     //0010 1kkk kkkk kkkk
            RETURN  = 0b_11111111_11111111,     //0000 0000 0000 1000
            CLRWDT  = 0b_11111111_11111111,     //0000 0000 0110 0100
            SLEEP   = 0b_11111111_11111111,     //0000 0000 0110 0011
            RETFIE  = 0b_11111111_11111111,     //0000 0000 0000 1001
        }

        public static Dictionary<Instruction, int> instrClockCycles = new Dictionary<Instruction, int>()
        {
            { Instruction.ADDWF , 1 },
            { Instruction.ANDWF , 1 },
            { Instruction.CLRF  , 1 },
            { Instruction.CLRW  , 1 },
            { Instruction.COMF  , 1 },
            { Instruction.DECF  , 1 },
            { Instruction.DECFSZ, 1 },
            { Instruction.INCF  , 1 },
            { Instruction.INCFSZ, 1 },
            { Instruction.IORWF , 1 },
            { Instruction.MOVF  , 1 },
            { Instruction.MOVWF , 1 },
            { Instruction.NOP   , 1 },
            { Instruction.RLF   , 1 },
            { Instruction.RRF   , 1 },
            { Instruction.SUBWF , 1 },
            { Instruction.SWAPF , 1 },
            { Instruction.XORWF , 1 },
            { Instruction.BCF   , 1 },
            { Instruction.BSF   , 1 },
            { Instruction.BTFSC , 1 },
            { Instruction.BTFSS , 1 },
            { Instruction.ADDLW , 1 },
            { Instruction.ANDLW , 1 },
            { Instruction.CALL  , 2 },
            { Instruction.CLRWDT, 1 },
            { Instruction.GOTO  , 2 },
            { Instruction.IORLW , 1 },
            { Instruction.MOVLW , 1 },
            { Instruction.RETFIE, 2 },
            { Instruction.RETLW , 2 },
            { Instruction.RETURN, 2 },
            { Instruction.SLEEP , 1 },
            { Instruction.SUBLW , 1 },
            { Instruction.XORLW , 1 },
        };

        public static UInt16 Fetch()
        {
            
            (_, UInt16 data) = Program.pic.progMem.GetKeyValuePair(Program.pic.pc);
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

            UInt16 result16;

            bool carryBit;

            int  index;
            int  destinationBitIndex    = 7;
            int  overflowCheck;

            const byte DCMask           = 0b_00001111;
            const UInt16 paramAddressMask = 0b_00000111_11111111;

            //Increment PIC clock
            for (int i = 0; i < instrClockCycles[instruction]; i++) {
                Program.pic.DoClockTicks(false);
            }

            switch (instruction)
            {
                
                case Instruction.ADDLW:
                    operand1 = Program.pic.wReg.GetValue();
                    operand2 = (byte)(data);
                    overflowCheck = operand1 + operand2;

                    result = (byte)(operand1 + operand2);
                    Program.pic.wReg.SetValue(result);

                    if ((operand1 & DCMask) + (operand2 & DCMask) > 15)
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 1); //setting dc-flag
                    }
                    else
                    {
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 1); //clearing dc-flag
                    }

                    if (overflowCheck > 255) 
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 0); //setting c-flag
                    }
                    else
                    {
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 0); //clearing c-flag
                    }

                    if (result > 0) 
                    {
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 2); //clearing z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 2); //setting z-flag
                    }

                    if (operand2 == 0)
                    {
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 1); //clearing dc-flag
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 0); //clearing c-flag
                    }

                    return true;

                case Instruction.ADDWF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);

                    operand1 = Program.pic.wReg.GetValue();
                    operand2 = Program.pic.dataMem.Get(dataMemAddress);
                    overflowCheck = operand1 + operand2;

                    result = (byte)(operand1 + operand2);

                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.Set(dataMemAddress, result);
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(result);
                    }

                    if ((operand1 & DCMask) + (operand2 & DCMask) > 15)
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 1); //setting dc-flag
                    }
                    else
                    {
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 1); //clearing dc-flag
                    }

                    if (overflowCheck > 255)
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 0); //setting c-flag
                    }
                    else
                    {
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 0); //clearing c-flag
                    }

                    if (result > 0)
                    {
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 2); //clearing z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 2); //setting z-flag
                    }

                    if (operand2 == 0)
                    {
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 1); //clearing dc-flag
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 0); //clearing c-flag
                    }

                    //COMPUTED GOTO
                    if(dataMemAddress == (byte)RegisterAddress.PCL)
                    {
                        int PCLATH = Program.pic.dataMem.Get((byte)RegisterAddress.PCLATH) << 8;
                        Program.pic.pc = (UInt16)(result + PCLATH);
                    }

                    return true;

                case Instruction.ANDLW:
                    result = (byte)(Program.pic.wReg.GetValue() & (byte)(data));
                    Program.pic.wReg.SetValue(result);
                    if (result > 0)
                    {
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 2); //clearing z-flag
                    }
                    else 
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 2); //setting z-flag
                    }
                    return true;

                case Instruction.ANDWF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Program.pic.wReg.GetValue() & Program.pic.dataMem.Get(dataMemAddress));
                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.Set(dataMemAddress, result);
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(result);
                    }

                    if (result > 0)
                    {
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 2); //clearing z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 2); //setting z-flag
                    }
                    return true;

                case Instruction.BCF:
                    //bits 9, 8 and 7 are used to define the index of the bit that is to be cleared
                    index = (ConvertThreeBitsToInt(data.GetBit(9), data.GetBit(8), data.GetBit(7)));
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = Program.pic.dataMem.Get(dataMemAddress);

                    result = ClearBitInByte(result, index);
                    Program.pic.dataMem.Set(dataMemAddress, result);
                    return true;

                case Instruction.BSF:
                    //bits 9, 8 and 7 are used to define the index of the bit that is to be set
                    index = (ConvertThreeBitsToInt(data.GetBit(9), data.GetBit(8), data.GetBit(7)));
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = Program.pic.dataMem.Get(dataMemAddress);

                    result = SetBitInByte(result, index);
                    Program.pic.dataMem.Set(dataMemAddress, result);
                    return true;

                case Instruction.BTFSC:
                    //bits 9, 8 and 7 are used to define the index of the bit that is to be evaluated
                    index = (ConvertThreeBitsToInt(data.GetBit(9), data.GetBit(8), data.GetBit(7)));
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    if (Program.pic.dataMem.GetFlag(dataMemAddress, index))
                    {
                        //nothing really happens
                    }
                    else
                    {
                        Program.pic.pc++;
                        //skip and perform nop
                        //do one clock cycle
                        Program.pic.DoClockTicks(false);
                    }
                    return true;
                     
                case Instruction.BTFSS:
                    //bits 9, 8 and 7 are used to define the index of the bit that is to be evaluated
                    index = (ConvertThreeBitsToInt(data.GetBit(9), data.GetBit(8), data.GetBit(7)));
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    if (!Program.pic.dataMem.GetFlag(dataMemAddress, index))
                    {
                        //nothing really happens
                    }
                    else
                    {
                        Program.pic.pc++;
                        //skip and perform nop
                        //do one clock cycle
                        Program.pic.DoClockTicks(false);
                    }
                    return true;

                case Instruction.CALL:
                    result16 = (UInt16)(data & paramAddressMask);
                    Program.pic.stack.Push(Program.pic.pc);
                    Program.pic.pc = result16;
                    //Program.pic.dataMem.UpdatePC();
                    return true;

                case Instruction.CLRF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    Program.pic.dataMem.Set(dataMemAddress, 0);
                    Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 2); //setting z-flag
                    return true;

                case Instruction.CLRW:
                    Program.pic.wReg.SetValue(0);
                    Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 2); //setting z-flag
                    return true;

                case Instruction.COMF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(~Program.pic.dataMem.Get(dataMemAddress));
                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.Set(dataMemAddress, result);
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(result);
                    }

                    if (result > 0)
                    {
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 2); //clearing z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 2); //setting z-flag
                    }
                    return true;

                case Instruction.DECFSZ:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Program.pic.dataMem.Get(dataMemAddress) - 1);
                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.Set(dataMemAddress, result);
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(result);
                    }
                    if (result == 0)
                    {
                        Program.pic.pc++;
                        //do one clock cycle
                        Program.pic.DoClockTicks(false);
                    }
                    return true;
                case Instruction.INCFSZ:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Program.pic.dataMem.Get(dataMemAddress) + 1);
                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.Set(dataMemAddress, result);
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(result);
                    }
                    if (result == 0)
                    {
                        Program.pic.pc++;
                        //do one clock cycle
                        Program.pic.DoClockTicks(false);
                    }
                    return true;

                case Instruction.INCF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Program.pic.dataMem.Get(dataMemAddress) + 1);
                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.Set(dataMemAddress, result);
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(result);
                    }

                    if (result > 0)
                    {
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 2); //clearing z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 2); //setting z-flag
                    }
                    return true;

                case Instruction.DECF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Program.pic.dataMem.Get(dataMemAddress) - 1);
                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.Set(dataMemAddress, result);
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(result);
                    }

                    if (result > 0)
                    {
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 2); //clearing z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 2); //setting z-flag
                    }
                    return true;

                case Instruction.GOTO:
                    result16 = (UInt16)(data & paramAddressMask);
                    Program.pic.pc = result16;
                    //Program.pic.dataMem.UpdatePC();
                    return true;

                case Instruction.IORLW:
                    result = (byte)(Program.pic.wReg.GetValue() | (byte)(data));
                    Program.pic.wReg.SetValue(result);

                    if (result > 0)
                    {
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 2); //clearing z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 2); //setting z-flag
                    }
                    return true;

                case Instruction.IORWF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Program.pic.wReg.GetValue() | Program.pic.dataMem.Get(dataMemAddress));
                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.Set(dataMemAddress, result);
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(result);
                    }

                    if (result > 0)
                    {
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 2); //clearing z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 2); //setting z-flag
                    }
                    return true;

                case Instruction.MOVF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    byte value = Program.pic.dataMem.Get(dataMemAddress);
                    if(data.GetBit(destinationBitIndex))
                    {
                        //its moved back to where it was removed so nothing really happens
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(value);
                    }

                    if (value == 0)
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 2); //setting z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 2); //clearing z-flag
                    }
                    return true;

                case Instruction.MOVLW:
                    Program.pic.wReg.SetValue((byte)(data));
                    return true;

                case Instruction.MOVWF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    Program.pic.dataMem.Set(dataMemAddress, Program.pic.wReg.GetValue());
                    return true;

                case Instruction.NOP:
                    return true;

                case Instruction.RETLW:
                    param = (byte)(data);
                    Program.pic.wReg.SetValue(param);
                    Program.pic.pc = Program.pic.stack.Pop();
                    return true;

                case Instruction.RETURN:
                    Program.pic.pc = Program.pic.stack.Pop();
                    return true;

                case Instruction.RLF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = Program.pic.dataMem.Get(dataMemAddress);
                    carryBit = Program.pic.dataMem.GetFlag((byte)RegisterAddress.STATUS, 0);
                    if (result.GetBit(7))
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 0);
                    }
                    else
                    {
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 0);
                    }
                    result = (byte)(result << 1);
                    if (carryBit)
                    {
                        result = SetBitInByte(result, 0);
                    }
                    else
                    {
                        result = ClearBitInByte(result, 0);
                    }

                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.Set(dataMemAddress, result);
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(result);
                    }
                    return true;

                case Instruction.RRF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = Program.pic.dataMem.Get(dataMemAddress);
                    carryBit = Program.pic.dataMem.GetFlag((byte)RegisterAddress.STATUS, 2);
                    if (result.GetBit(0))
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 0);
                    }
                    else
                    {
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 0);
                    }
                    result = (byte)(result >> 1);
                    if (carryBit)
                    {
                        result = SetBitInByte(result, 7);
                    }
                    else
                    {
                        result = ClearBitInByte(result, 7);
                    }

                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.Set(dataMemAddress, result);
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
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 2); //clearing z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 2); //setting z-flag
                    }

                    if (overflowCheck >= 0)
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 0); //setting c-flag
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 1); //setting dc-flag
                    }
                    else
                    {
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 0); //clearing c-flag
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 1); //clearing dc-flag
                    }

                    if (operand2 == 0)
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 0); //setting c-flag
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 1); //setting dc-flag
                    }

                    return true;

                case Instruction.SUBWF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    operand1 = Program.pic.dataMem.Get(dataMemAddress);
                    operand2 = Program.pic.wReg.GetValue();
                    overflowCheck = operand1 - operand2;

                    result = (byte)(operand1 - operand2);

                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.Set(dataMemAddress, result);
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(result);
                    }

                    if (result > 0)
                    {
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 2); //clearing z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 2); //setting z-flag
                    }

                    if (overflowCheck >= 0)
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 0); //setting c-flag
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 1); //setting dc-flag
                    }
                    else
                    {
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 0); //clearing c-flag
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 1); //clearing dc-flag
                    }

                    if (operand2 == 0)
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 0); //setting c-flag
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 1); //setting dc-flag
                    }

                    return true;

                case Instruction.SWAPF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    operand1 = (byte)(Program.pic.dataMem.Get(dataMemAddress));
                    operand2 = (byte)(operand1 << 4);
                    operand1 = (byte)(operand1 >> 4);
                    result = (byte)(operand1 + operand2);
                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.Set(dataMemAddress, result);
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(result);
                    }
                    return true; 

                case Instruction.XORLW:
                    result = (byte)(Program.pic.wReg.GetValue() ^ (byte)(data));
                    Program.pic.wReg.SetValue(result);

                    if (result > 0)
                    {
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 2); //clearing z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 2); //setting z-flag
                    }
                    return true;

                case Instruction.XORWF:
                    param = (byte)(data);
                    dataMemAddress = (byte)(param & 0b_01111111);
                    result = (byte)(Program.pic.wReg.GetValue() ^ Program.pic.dataMem.Get(dataMemAddress));
                    if (data.GetBit(destinationBitIndex))
                    {
                        Program.pic.dataMem.Set(dataMemAddress, result);
                    }
                    else
                    {
                        Program.pic.wReg.SetValue(result);
                    }

                    if (result > 0)
                    {
                        Program.pic.dataMem.ClearFlag((byte)RegisterAddress.STATUS, 2); //clearing z-flag
                    }
                    else
                    {
                        Program.pic.dataMem.SetFlag((byte)RegisterAddress.STATUS, 2); //setting z-flag
                    }
                    return true;

                case Instruction.CLRWDT:
                    return true;
                case Instruction.RETFIE:
                    Program.pic.pc = Program.pic.stack.Pop();
                    Program.pic.dataMem.SetFlag((byte)RegisterAddress.INTCON, 7);
                    return true;
                case Instruction.SLEEP:
                    return true;
                default:
                    return false;
                    
            }
        }
    }
}