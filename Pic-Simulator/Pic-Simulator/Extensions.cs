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
    }
}
