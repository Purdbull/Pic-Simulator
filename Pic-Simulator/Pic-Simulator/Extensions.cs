using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
    public static class Extensions
    {
        private static ushort bitMask = 0b_00000000_00000001;
        public static bool GetBit(this UInt16 data, int index)
        {
            for (int i = 15; i > index; i--)
            {
                bitMask = (ushort)(bitMask << 1);
            }
            data = (ushort)(data & bitMask);

            return data > 0;
        }

        public static int ConvertThreeBitsToInt(bool firstBit, bool secondBit, bool thirdBit)
        {
            int result = 0;
            if (firstBit)  {result += 4;}
            if (secondBit) {result += 2;}
            if (thirdBit)  {result++;}
            return result;
        }

        public static byte SetBitInByte(byte b, int index)
        {
            byte mask = 0b_00000001;
            byte result;
            for (int i = 7; i > index; i--)  //shifting the Mask so that just the right bit is 1
            {
                mask = (byte)(mask << 1);
            }
            result = (byte)(b | mask);
            return result;
        }

        public static byte ClearBitInByte(byte b, int index)
        {
            byte mask = 0b_11111110;
            byte result;
            for (int i = 7; i > index; i--)  //shifting the Mask and incrementing it so that just the right bit is 0 
            {
                mask = (byte)(mask << 1);
                mask++;
            }
            result = (byte)(b & mask);
            return result;
        }
    }
}
