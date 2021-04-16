using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    abstract class Memory<T>
    {
        protected List<T> _keys;
        protected List<T> _values;

        protected Memory(int size){
            this._keys = new List<T>(size);
            this._values = new List<T>(size);
        }

        public T GetValue(T key_value)
        {
            int index = _keys.BinarySearch(key_value);
            return _values[index];
        }
        public (T, T) GetKeyValuePair(int index)
        {
            T key = _keys[index];
            T value = _values[index];

            return (key, value);
        }
    }
}
