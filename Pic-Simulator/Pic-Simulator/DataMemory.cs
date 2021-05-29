using System;
using System.Collections.Generic;
using System.Text;
using static ExtensionMethods.Extensions;

namespace Pic_Simulator
{
    public class DataMemory : Memory<byte>
    {
        public DataMemory() : base(PIC.MAX_DATAMEM_SIZE) 
        {
            for(int i = 0; i < this._keys.Count; i++) if (i <= PIC.MAX_DATAMEM_SIZE)
            {
                _keys[i] = (byte)i;
            }
        }
        public void Set(byte address, byte value)
        {
            bool RP0 = GetFlag((byte)RegisterAddress.STATUS, 5);

            this.Set(address, RP0, value);

        }

        public void Set(byte address, bool bank, byte value)
        {
            //Indirect addressing
            if (address == 0)
            {
                //Write to the address in FSR instead
                address = this.Get((byte)RegisterAddress.FSR);
                bank = GetFlag((byte)RegisterAddress.STATUS, 7);
                
                if(address == 0)
                {
                    return; //Indirect write to INDF results in no-op
                }
            }
            //If INTCON
            //else if(address == 11)
            //{
            //    bool currentGIE = GetFlag((byte)RegisterAddress.INTCON, 7);
            //    bool newGIE = value.GetBit(7);

            //    //reset INTCON if GIE is cleared
            //    if(currentGIE && !newGIE)
            //    {
            //        SetValue((byte)RegisterAddress.INTCON, 0);
            //    }
            //}

            byte fullAddress = (byte)(((address << 1) >> 1) + (Convert.ToByte(bank) << 7));

            this.SetValue(fullAddress, value);

            //map value to the opposite bank at specific addresses
            switch (address)
            {
                case 1:
                    if (!bank)
                    {
                        Program.pic.tmr0Inhibit = 2;
                        Program.pic.timerClock = 0;
                    }
                    break;
                case 2:
                case 3:
                case 10:
                case 11:
                case byte n when (n > 11 && n < 48):
                    fullAddress = (byte)(((address << 1) >> 1) + (Convert.ToByte(!bank) << 7));
                    this.SetValue(fullAddress, value);
                    break;
                default:
                    break;
            }
        }

        public byte Get(byte address)
        {
            byte STATUS = this._values[(byte)(RegisterAddress.STATUS)]; //DO NOT USE GETFLAG()
            bool RP0 = STATUS.GetBit(5);
            return this.Get(address, RP0);
        }

        public byte Get(byte address, bool bank)
        {
            //Indirect addressing
            if (address << 1 == 0)
            {
                //Write to the address in FSR instead
                address = this.Get((byte)RegisterAddress.FSR);
                bank = GetFlag((byte)RegisterAddress.STATUS, 7);

                if (address == 0)
                {
                    return 0; //Indirect read from INDF returns 0
                }
            }

            byte fullAddress = (byte)(((address << 1) >> 1) + (Convert.ToByte(bank) << 7));

            return this.GetValue(fullAddress);
        }

        public bool GetFlag(byte address, int bitIndex)
        {
            byte targetByte = this.Get(address);
            return targetByte.GetBit(bitIndex);
        }

        public bool GetFlag(byte address, bool bank, int bitIndex)
        {
            byte targetByte = this.Get(address, bank);
            return targetByte.GetBit(bitIndex);
        }

        public string GetHexKeyAtIndex(int index)
        {
            return _keys[index].ToString("X2");
        }

        public string GetHexValueAtIndex(int index)
        {
            return _values[index].ToString("X2");
        }

        public string GetBinaryValueAtIndex(int index)
        {
            string binString = Convert.ToString(_values[index], 2);
            return binString.PadLeft((8), '0');
        }

        public void SetFlag(byte address, int bitIndex)
        {
            byte targetByte = this.Get(address);
            byte resultByte = SetBitInByte(targetByte, bitIndex);

            this.Set(address, resultByte);
        }

        public void SetFlag(byte address, bool bank, int bitIndex)
        {
            byte targetByte = this.Get(address, bank);
            byte resultByte = SetBitInByte(targetByte, bitIndex);

            this.Set(address, bank, resultByte);
        }

        public void ClearFlag(byte address, int bitIndex)
        {
            byte targetByte = this.Get(address);
            byte resultByte = ClearBitInByte(targetByte, bitIndex);

            this.Set(address, resultByte);
        }

        public void ClearFlag(byte address, bool bank, int bitIndex)
        {
            byte targetByte = this.Get(address, bank);
            byte resultByte = ClearBitInByte(targetByte, bitIndex);

            this.Set(address, bank, resultByte);
        }

        //public UInt16 EvaluatePC()
        //{
        //    UInt16 PC       = this.Get((byte)RegisterAddress.PCL);
        //    UInt16 PCLATH   = this.Get((byte)RegisterAddress.PCLATH);

        //    return (UInt16)(PC + (PCLATH << 8));
        //}

        //public void UpdatePC()
        //{
        //    UInt16 PCL = this.Get((byte)RegisterAddress.PCL);
        //    UInt16 PCLATH = (UInt16)(this.Get((byte)RegisterAddress.PCLATH) << 8);

        //    Program.pic.pc= (UInt16)(PCL + PCLATH);
        //}

        public int GetPrescaler(bool prescalerAssignment)
        {
            int value = ConvertThreeBitsToInt(GetFlag((byte)RegisterAddress.OPTION, true, 2), GetFlag((byte)RegisterAddress.OPTION, true, 1), GetFlag((byte)RegisterAddress.OPTION, true, 0));


            if (prescalerAssignment)
            {
                return (int)Math.Pow(2, value);
            }
            else
            {
                return (int)Math.Pow(2, (value + 1));
            }
        }
    }
}
