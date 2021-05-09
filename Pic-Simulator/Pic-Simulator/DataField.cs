﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    public class DataField : Memory<byte>
    {
        public delegate void DataFieldEventHandler(object sender, DataFieldValueChangedEventArgs e);

        public event DataFieldEventHandler ValueChanged;
        protected virtual void OnValueChanged(DataFieldValueChangedEventArgs e)
        {
            DataFieldEventHandler handler = ValueChanged;
            handler?.Invoke(this, e);
        }
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
            OnValueChanged(new DataFieldValueChangedEventArgs(value));
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
