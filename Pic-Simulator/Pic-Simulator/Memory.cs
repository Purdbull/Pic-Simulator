using System;
using System.Collections.Generic;
using System.Text;

namespace Pic_Simulator
{
    abstract public class Memory<T>
    {
        protected List<T> _keys;
        protected List<T> _values;

        protected Memory(int size){
            this._keys = new List<T>(new T[size]);
            this._values = new List<T>(new T[size]);
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

        public void SetKey(int index, T key)
        {
            this._keys[index] = key;
        }

        public void SetValue(int index, T value)
        {
            this._values[index] = value;
        }

        public void SetLine(int index, T key, T value)
        {
            SetKey(index, key);
            SetValue(index, value);
        }
    }
}
