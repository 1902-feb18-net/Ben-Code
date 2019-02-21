using System;
using System.Collections.Generic;
using System.Text;

namespace ML.Library
{
    public class MemoryList<T>
    {
        protected readonly List<T> _list = new List<T>();

        Dictionary<T, bool> dict = new Dictionary<T, bool>();

        public void Add(T value)
        {
            dict.Add(value, true);
            _list.Add(value);
        }

        public void Remove(T value)
        {
            _list.Remove(value);
        }

        public bool Contains(T value)
        {
            return _list.Contains(value);
        }

        public bool HasEverContained(T value)
        {
            if (dict.ContainsKey(value))
                return true;
            else
                return false;
        }

        //test-driven development
        //1. write tests that fail
        //2. make the tests pass without changing thme (by writing the real code)
    }
}
