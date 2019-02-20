using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionTesting.Library
{
    public class MyGenericCollection<T>
    {
        protected readonly List<T> _list = new List<T>();

        public void Add(T value)
        {
            _list.Add(value);
        }

        public bool Contains(T value)
        {
            return _list.Contains(value);
        }
    }
}
