using System;
using System.Collections.Generic;
using System.Text;
using static ExtensionMethods.Extensions;

namespace Pic_Simulator
{
    public class DataMemory : Memory<UInt16>
    {
        public DataMemory() : base(PIC.MAX_DATAMEM_SIZE) 
        {
            for(int i = 0; i < this._keys.Count; i++) if (i <= UInt16.MaxValue)
            {
                _keys[i] = (UInt16)i;
            }
        }
        public byte GetByte(bool bank, byte address)
        {
            UInt16 valueAtAddress = this.GetValue(address);

            if(bank) 
            {
                return (byte)(valueAtAddress);
            }
            else
            {
                return (byte)(valueAtAddress >> 8);
            }
        }

        public void SetByte(bool bank, byte address, byte value)
        {
            UInt16 valueAtAddress = this.GetValue(address);
            if(bank)
            {
                //clear the right byte of the UInt16 value at the address and add the new value onto it
                UInt16 newFullValue = (UInt16)(ClearUInt16RightByte(valueAtAddress) + value);

                this.SetValue(address, newFullValue);
            }
            else
            {
                //clear the left byte of the UInt16 value at the address and add the new value onto it
                UInt16 newFullValue = (UInt16)(ClearUInt16LeftByte(valueAtAddress) + (value << 8));

                this.SetValue(address, newFullValue);
            }
               
            //TODO: UPDATE GUI ON VALUE CHANGE
        }

        public bool GetFlag(bool bank, byte address, int bitIndex)
        {
            byte targetByte = this.GetByte(bank, address);
            return targetByte.GetBit(bitIndex);
        }
        public bool GetFlag(byte address, int bitIndex)
        {
            UInt16 targetValue = this.GetValue(address);
            return targetValue.GetBit(bitIndex);
        }

        public void SetFlag(bool bank, byte address, int bitIndex)
        {
            byte targetByte = this.GetByte(bank, address);
            byte resultByte = SetBitInByte(targetByte, bitIndex);

            this.SetByte(bank, address, resultByte);
            //TODO: UPDATE GUI ON VALUE CHANGE
        }
        public void SetFlag(byte address, int bitIndex)
        {
            UInt16 mask = (UInt16)(1 << bitIndex);
            UInt16 targetValue = this.GetValue(address);
            UInt16 resultValue = (UInt16)(targetValue | mask);
            this.SetValue(address, resultValue);
            //TODO: UPDATE GUI ON VALUE CHANGE
        }
        public void ClearFlag(bool bank, byte address, int bitIndex)
        {
            byte targetByte = this.GetByte(bank, address);
            byte resultByte = ClearBitInByte(targetByte, bitIndex);

            this.SetByte(bank, address, resultByte);
            //TODO: UPDATE GUI ON VALUE CHANGE
        }
        public void ClearFlag(byte address, int bitIndex)
        {
            UInt16 mask = (UInt16)(1 << bitIndex);
            UInt16 targetValue = this.GetValue(address);
            UInt16 resultValue = (UInt16)(targetValue & ~mask);
            this.SetValue(address, resultValue);
            //TODO: UPDATE GUI ON VALUE CHANGE
        }
    }
}
