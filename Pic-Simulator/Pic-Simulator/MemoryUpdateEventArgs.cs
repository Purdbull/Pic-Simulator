using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    public class MemoryUpdateEventArgs<T>
    {
        public T Arg;
        public MemoryUpdateEventArgs(T arg)
        {
            this.Arg = arg;
        }
    }
}
