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
            bool RP0 = GetFlag((byte)InstructionAddress.STATUS, 5);

            this.Set(address, RP0, value);

        }

        public void Set(byte address, bool bank, byte value)
        {
            //Indirect addressing
            if (address << 1 == 0)
            {
                //Write to the address in FSR instead
                address = this.Get((byte)InstructionAddress.FSR);
                bank = GetFlag((byte)InstructionAddress.STATUS, 7);
                
                if(address == 0)
                {
                    return; //Indirect write to INDF results in no-op
                }
            }

            byte fullAddress = (byte)(((address << 1) >> 1) + (Convert.ToByte(bank) << 7));

            this.SetValue(fullAddress, value);

            //map value to the opposite bank at specific addresses
            switch (address)
            {
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
            byte STATUS = this._values[(byte)(InstructionAddress.STATUS)]; //DO NOT USE GETFLAG()
            bool RP0 = STATUS.GetBit(5);
            return this.Get(address, RP0);
        }

        public byte Get(byte address, bool bank)
        {
            //Indirect addressing
            if (address << 1 == 0)
            {
                //Write to the address in FSR instead
                address = this.Get((byte)InstructionAddress.FSR);
                bank = GetFlag((byte)InstructionAddress.STATUS, 7);

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
            return _keys[index].ToString("X4");
        }

        public string GetHexValueAtIndex(int index)
        {
            return _values[index].ToString("X4");
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

        public UInt16 GetPC()
        {
            UInt16 PC       = this.Get((byte)InstructionAddress.PCL);
            UInt16 PCLATH   = this.Get((byte)InstructionAddress.PCLATH);

            return (UInt16)(PC + (PCLATH << 8));
        }

        public void SetPC(UInt16 value)
        {
            byte PCL = (byte)value;
            byte PCLATH = (byte)(value >> 8);


            this.Set((byte)InstructionAddress.PCL, PCL);
            this.Set((byte)InstructionAddress.PCLATH, PCLATH);
        }
    }
}
