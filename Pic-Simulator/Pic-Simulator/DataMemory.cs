using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    public class DataMemory : Memory<UInt16>
    {
        public DataMemory() : base(PIC.MAX_DATAMEM_SIZE) {}
        public byte GetBankByte(int bank, byte adress)
        {
            ushort bothBankBytes = this.GetValue(adress);

            if (bank == 1) 
            {
                bothBankBytes = (ushort)(bothBankBytes >> 8);
                return (byte)(bothBankBytes);
            }
            else if (bank == 2)
            {
                return (byte)(bothBankBytes);
            }
            else
            {
                //TODO: Exception?
                return 0;
            }
        }
    }
}
