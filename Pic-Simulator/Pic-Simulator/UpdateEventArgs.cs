using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    public class UpdateEventArgs<T>
    {
        public T Address;
        public T Value;
        public UpdateEventArgs(T address = default(T), T value = default(T))
        {
            this.Address = address;
            this.Value = value;
        }
    }
}
