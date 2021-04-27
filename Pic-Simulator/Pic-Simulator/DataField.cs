using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    public class DataField : Memory<byte>
    {
        public DataField() : base(1){}

        public byte GetValue()
        {
            return this._values[0];
        }

        public void SetValue(byte value)
        {
            this._values[0] = value;
        }
    }
}
