using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    public class DataField : Memory<byte>
    {
        public DataField(byte content = 0) : base(1)
        {
            this.SetValue(content);
        }

        public byte GetValue()
        {
            return this._values[0];
        }

        public void SetValue(byte value)
        {
            this._values[0] = value;
            OnRegisterUpdated(new UpdateEventArgs<byte>(value: value));
        }

        public void Increment()
        {
            this.SetValue((byte)(GetValue() + 1));
        }

        public void Decrement()
        {
            this.SetValue((byte)(GetValue() - 1));
        }

        public string GetAsBinaryValue()
        {
            string binValue = Convert.ToString(GetValue(), 2);
            return binValue.PadLeft((8), '0');
        }
    }
}
