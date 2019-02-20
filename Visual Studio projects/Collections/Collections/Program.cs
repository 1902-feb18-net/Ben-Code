using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            Arrays();
            Lists();
            Sets();
            Maps();
            StringEquality();
        }

        static void Arrays()
        {
            //we can make fixed-length lists of things, arrays
            int[] ints = new int[5];
            //we can also use array initializer syntax
            int[] ints2 = new int[] { 1, 2, 3, 4, 5 };

            //we can go through arrays with for loop, or foreach loop
            //  if we have no need of the index

            //we can have ararys of any time, even other arrays
            int[][] twodArray = new int[9][];
            twodArray[0] = new int[4];
            twodArray[1] = new int[4];
            // etc.
            //a 9 by 4 2d array
            //this is called a jagged array
            //each row could have different lengths if we wanted

            //C# has multidimensional arrays
            int[,] multiDarray = new int[5,5];
            //5x5 multi-d arrray
            multiDarray[0, 0] = 8;
            //comma instead of extra brackets

            int[,][] crazyThing = new int[2, 2][];

            //we rarely have any use for arrays
            //for performance is the only reason

            //in practice we use other objects
        }

        static void Lists()
        {
            var list = new ArrayList {5, 8, 1 };
            list.AddRange(new int[] { 4, 5, 6, 7, 8 });
            list.Remove(8);
            
            for(int i = 0; i < list.Count; i++)
            {
                //in C# we can index into the list just as if it were an array
                //Console.WriteLine(list[i]);
                list[i] = 4;
            }

            //early in C#'s history, we got generics and stopped using ArrayList as well

            var genericList = new List<int> { 1, 2, 3 };
            //this list doesn't upcast everything to object, it only allows ints
            //genericList.Add("abc"); //not allowed, this list instance is tied to int type

            foreach (var item in genericList)
            {
                Console.WriteLine(item * 2); //works because we know this is an int
            }

        }

        static void Sets()
        {
            var set = new HashSet<string>();
            set.Add("abc");
            set.Add("abc"); //this line does effectively nothing
            set.Add("ghijkl");
            //we take our idea of sets from mathematics
            //a set has no concept of duplicates, something is either in it or not
            //a set also have no concept of order

            Console.WriteLine(set.Count); //going to return 2

            //sets are useful when we aren't interested in storing any order
            //the main thing we want to do is later on check if some thing
            //  is or is not inside the set

            //checking membership in the set is very fast
            var list = new List<int> { 1, 2, 2, 2, 3 };
            var withoutDupes = new List<int>(new HashSet<int>(list));
            //set iteration is a little slower than list iteration

        }

        static void Maps()
        {
            //the point of a dictionary is to store a key/value relationship
            var dictionary = new Dictionary<string, string>();
            dictionary["classroom"] = "room where classses are held.";

            //we also have an initializer syntax for dictionaries
            var grades = new Dictionary<string, double>
            {
                ["Ben"] = 93
            };
            //helpful members: Keys, Values, ContainsKey, ContainsValue, TryGetValue

            foreach (var item in grades)
            {
                //item.Key;
                //item.Value;
            }

            //dictionary objects let you use any type you want to index into it
            //  and any type to use for the value stored for that key

            //sometimes a class/struct is a better choice paired values


        }

        static void StringEquality()
        {
            string a = "asdf";
            string b = "asdf";
            Console.WriteLine(a == b); //returns true

            //value types and reference types:
            //  value type variables store their values directly
            //  reference type variables store a reference to their value

            //in C#, many of our basic types are value types
            //  int, double, float, bool, long,  etc.

            int n1 = 5;
            int n2 = n1; //int is value type, so n2 is a copy of n1
            n1 = 6; //n2 stays at 5 because it's a value type

            var dummy1 = new Dummy();
            var dummy2 = dummy1;

            dummy1.data = 10;
            if (dummy2.data == 10)
            {
                Console.WriteLine("reference type");
            }
            else
            {
                Console.WriteLine("value type");
            }
            //Dummy is a reference type so dummy2 is a copy of the reference,
            //  i.e. a reference to the same object; changes to dummy1 will
            //  also change dummy2

            var dummy3 = new ValueDummy();
            var dummy4 = dummy3;

            dummy3.data = 10;
            if (dummy4.data == 10)
            {
                Console.WriteLine("reference type");
            }
            else
            {
                Console.WriteLine("value type");
            }
            //structs are copie entirely every time we pass it to a new method
            //  or assign it to a new variable
            //value types are deleted from memory as soon as the one variable
            //  that contains them passes out of scope

            //reference types we get a new copy of a reference but to the same
            //  underlying object
            //reference types need to be "garbage collected" because we don't 
            //  know right away when the LAST variable pointing to it passed
            //  out of scope.

            //objects made from classes are always reference types
            //objects made from structs are value types
            //all the built-in value types are "structs" in C#

            //in C# we hav ethe idea of "managed" vs "unmanaged" code
            //in unmanaged code you have to manually write the code to
            //  delete reference from memory

            //in managed code, there is garbage collection that runs periodically
            //  to search for objects that are unreachable by any running part of the code

            //our tradeoff is, the computer should work harder so the deeloper can solve 
            //  real problems

            //back to strings......

            //NORMALLY "==" compares value types by value and reference types by reference
            Console.WriteLine(new Dummy() == new Dummy()); //false... reference types

            //For value types like struct, they don't need to be the same object, only
            //  the same value

            //BUT we make an exception for strings because it's awkward to have to 
            //  do string.Equals() for comparing strings.

            //In C# all value types do derive ultimately from object so we can always
            //  upcast them to object variables

            int i1 = 5;
            object o1 = i1; //implicit upcasting going on
            //this is caleld "boxing" - the int is wrapped inside a reference type
            //  to give that value reference type semantics

            //Java has awkward Integer vs int distinctions
            //we have this as boxing and unboxing with object
            //"Unboxing" the reverse, with downcasting

            int i2 = (int)02; //extract that value from inside the object wrapper

            //sometimes we want to see if two objects have ethe same values in them
            //  for that we make use of a .Equals method
        }

        class Dummy
        {
            public int data { get; set; }
        }
        struct ValueDummy
        {
            public int data { get; set; }
        }
    }
}
