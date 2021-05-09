using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    public class DataField : Memory<byte>
    {
        private Action onValueChanged;
        public DataField(Action onValueChanged = null, byte content = 0) : base(1)
        {
            this.SetValue(content);
            this.onValueChanged = onValueChanged;
        }

        public byte GetValue()
        {
            return this._values[0];
        }

        public void SetValue(byte value)
        {
            this._values[0] = value;
            if (!(this.onValueChanged is null)) onValueChanged();
        }

        public void Increment()
        {
            this.SetValue((byte)(GetValue() + 1));
        }

        public void Decrement()
        {
            this.SetValue((byte)(GetValue() - 1));
        }
    }
}
