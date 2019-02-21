using System;
using System.Collections.Generic;
using System.Text;

namespace ML.Library
{
    public class MemoryList<T> : List<T>
    {
        protected readonly List<T> _list = new List<T>();

        Dictionary<T, bool> _everContained = new Dictionary<T, bool>();

        public MemoryList() : base() { }

        public new void Add(T value)
        {
            _everContained.Add(value, true);
            _list.Add(value);
        }

        public new void Remove(T value)
        {
            _list.Remove(value);
        }

        public new bool Contains(T value)
        {
            return _list.Contains(value);
        }

        public bool HasEverContained(T value)
        {
            if (_everContained.ContainsKey(value))
                return true;
            else
                return false;
        }



        //test-driven development
        //1. write tests that fail
        //2. make the tests pass without changing thme (by writing the real code)
    }
}
