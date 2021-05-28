using System;
using System.Collections.Generic;
using System.Text;
using static ExtensionMethods.Extensions;

namespace Pic_Simulator
{
    public class ProgramCounter : Memory<ushort>
    {
        public ProgramCounter(ushort content = 0) : base(1)
        {
            this.SetValue(content);
        }

        public ushort GetValue()
        {
            return this._values[0];
        }

        public void SetValue(ushort value)
        {
            this._values[0] = value;
            Program.pic?.dataMem.Set((byte)RegisterAddress.PCL, (byte)value);
        }

        public void Increment()
        {
            ushort newValue = ++this._values[0];
            Program.pic.dataMem.Set((byte)RegisterAddress.PCL, (byte)newValue);
        }

        public void Decrement()
        {
            ushort newValue = --this._values[0];
            Program.pic.dataMem.Set((byte)RegisterAddress.PCL, (byte)newValue);
        }

        public string GetAsBinaryValue()
        {
            string binValue = Convert.ToString(GetValue(), 2);
            return binValue.PadLeft((16), '0');
        }
    }
}
