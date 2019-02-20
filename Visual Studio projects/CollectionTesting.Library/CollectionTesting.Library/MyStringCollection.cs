using System;
using System.Collections.Generic;

namespace CollectionTesting.Library
{
    public class MyStringCollection : MyGenericCollection<string>
    {
        //use a private or protected field
        //  to store a List<string> to handle all the list operations

        //implement some collection methods like Add, Contains, Remove,
        //  and some others that are not already on the List.
        //ex: remove all empty strings, or take all strings and append

        //at least 5 methods

        //private List<string> _list = new List<string>();

        //public void Add(string addition)
        //{
        //    _list.Add(addition);
        //}

        //public bool Contains(string check)
        //{
        //    return _list.Contains(check);
        //}

        public bool Remove(string toRemove)
        {
            return _list.Remove(toRemove);
        }

        public void RemoveEmpty()
        {
            for (int i = 0; i < _list.Count; i++) 
            {
                if (_list[i] == "")
                    _list.Remove("");
            }
            // or...
            _list.RemoveAll(x => x == " ");
        }

        /// <summary>
        /// Replace all contained strings with lowercased versions
        /// </summary>

        public void MakeLowerCase()
        {
            for (int i = 0; i < _list.Count; i++)
            {
                _list[i] = _list[i].ToLower();
            }
        }

        public string GetFirst()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("list is empty");
            }
            return _list[0];
        }
    }
}
