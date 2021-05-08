using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    public class Stack<T>
    {
        private int stacksize;
        private T[] stack;
        private int index = -1;

        public Stack(int stacksize)
        {
            this.stacksize = stacksize;
            this.stack = new T [this.stacksize];
        }

        public void Push(T value)
        {
            index++;
            if (index == this.stacksize)
            {
                index = 0;
            }
            this.stack[index] = value;
        }

        public T Pop()
        {
            T value = this.stack[index];
            this.stack[index] = default(T);
            index--;
            if(index < 0)
            {
                index = this.stacksize - 1;
            }
            return value;
        }
    }
}
