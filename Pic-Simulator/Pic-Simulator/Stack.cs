using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    public class Stack
    {
        private int stacksize;
        private int[] stack = new int[8];
        private int index = -1;

        public Stack(int stacksize)
        {
            this.stacksize = stacksize;
            this.stack = new int[this.stacksize];
        }

        public void push(int value)
        {
            index++;
            if (index == this.stacksize)
            {
                index = 0;
            }
            this.stack[index] = value;
        }

        public int pull()
        {
            int value = stack[index];
            index--;
            if(index < 0)
            {
                index = this.stacksize - 1;
            }
            return value;
        }
    }
}
