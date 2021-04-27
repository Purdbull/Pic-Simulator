using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    public class DataField : Memory<byte>
    {
        public DataField(byte content = 0) : base(1)
        {
            this._keys.Add(0);
            this._values.Add(content);
        }

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
