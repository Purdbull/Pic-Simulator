using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    public class DataFieldValueChangedEventArgs : EventArgs
    {
        public DataFieldValueChangedEventArgs(int newValue)
        {
            NewValue = newValue;
        }
        public int NewValue { get; set; }
    }
}
