using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionTesting.Library
{
    public class MyGenericCollection<T>
    {
        protected readonly List<T> _list = new List<T>();
        //giving fields or properties default values is really just for convenience
        //  in reality, those assignments are copied to every constructor

        private int id;

        //When you make a new class inheriting from another, all
        //  fields, methods, and properties are inherited.
        //  However, constructors are nnot inherited.

        //every non-abstract has at least one constructor;
        //  if you don't write it in the '.cs' file,  you get 
        //  a default constructor with zero paramters that
        //  does nothing.

        public MyGenericCollection() : this(null)
        {
            //we don't put a return statement in the constructor
            //all we do it set up fields, properties, etc.
            //any setup code
        }

        //given array of T initial values, insert them into the list
        public MyGenericCollection(T[] initial)
        {
            id = new Random().Next();
            _list.AddRange(initial);
        }

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
