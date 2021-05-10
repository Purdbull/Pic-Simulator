using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    public class MemoryUpdateEventArgs<T>
    {
        public T NewValue;
        public MemoryUpdateEventArgs(T newValue)
        {
            this.NewValue = newValue;
        }
    }
}
