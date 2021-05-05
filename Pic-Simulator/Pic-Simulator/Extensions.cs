using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
    public static class Extensions
    {
        public static bool GetBit(this UInt16 data, int index)
        {
            ushort bitMask = 0b_00000000_00000001;
            bitMask = (ushort)(bitMask << index);
            data = (ushort)(data & bitMask);

            return data > 0;
        }

        public static bool GetBit(this byte data, int index)
        {
            ushort bitMask = 0b_00000001;
            bitMask = (byte)(bitMask << index);
            data = (byte)(data & bitMask);

            return data > 0;
        }

        public static int ConvertThreeBitsToInt(bool thirdBit, bool secondBit, bool firstBit)
        {
            return Convert.ToInt32(thirdBit) * 4 + Convert.ToInt32(secondBit) * 2 + Convert.ToInt32(firstBit);
        }

        public static byte SetBitInByte(byte b, int index)
        {
            byte mask = (byte)(0b_00000001 << index);
            return (byte)(b | mask);
        }

        public static byte ClearBitInByte(byte b, int index)
        {
            byte mask = 0b_00000001;
            mask = (byte)(mask << index);
            return (byte)(b & ~mask);
        }

        public static UInt16 ClearUInt16LeftByte(UInt16 fullValue)
        {
            return (UInt16)((fullValue << 8) >> 8);
        }

        public static UInt16 ClearUInt16RightByte(UInt16 fullValue)
        {
            return (UInt16)((fullValue >> 8) << 8);
        }
    }
}
