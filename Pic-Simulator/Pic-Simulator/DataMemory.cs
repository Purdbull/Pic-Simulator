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
            for(int i = 0; i < this._keys.Count; i++) if (i <= byte.MaxValue)
            {
                _keys[i] = (byte)i;
            }
        }
        public void Set(byte address, byte value)
        {
            byte STATUS = this._values[(byte)(InstructionAddress.STATUS)];
            bool RP0 = STATUS.GetBit(5);

            this.Set(address, RP0, value);
        }

        public void Set(byte address, bool bank, byte value)
        {
            byte fullAddress = (byte)(((address << 1) >> 1) + (Convert.ToByte(bank) << 8));

            this.SetValue(fullAddress, value);
            //TODO: UPDATE GUI
        }

        public byte Get(byte address)
        {
            byte STATUS = this._values[(byte)(InstructionAddress.STATUS)];
            bool RP0 = STATUS.GetBit(5);

            byte fullAddress = (byte)(((address << 1) >> 1) + (Convert.ToByte(RP0) << 8));

            return this.Get(fullAddress);
        }

        public byte Get(byte address, bool bank)
        {
            byte fullAddress = (byte)(((address << 1) >> 1) + (Convert.ToByte(bank) << 8));

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
    }
}
