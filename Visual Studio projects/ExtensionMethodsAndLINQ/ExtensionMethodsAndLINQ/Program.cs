using ExtensionMethodsAndLINQ.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethodsAndLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 3.Pow(3);
            Console.WriteLine(result);
            var list = new List<string>();
            list.Empty();
            var str = list.ToString();

            //extension methods don't allow us to truly modify the original type
            //they are only visible when we have a using directive
            //  for the namespace where my static methods is defined

            //extension methods don't let us see any private/protected members
            //we can't cheat the access modifiers

            //LINQ: language-integrated-query
            //LINQ is a buch of extension methods on IEnumerable<T> and 
            //  IQueryable<T>, and they all come from System.Linq namespace

            list.ToList();
            list.AddRange(new string[] { "a", "b", "c", "d", "asdfasdfasdf" });

            var sum = 0;
            foreach (var s in list)
            {
                sum += str.Length;
            }
            double averageStringLength = sum / list.Count;
            Console.WriteLine(averageStringLength);

            //with LINQ...
            averageStringLength = list.Average(s => s.Length);

            Console.WriteLine(averageStringLength);

            //a "lambda" is kind of like a methods that's anonymous and
            //  can be treated like an ordinary value/object

            Func<string, int> numberOfAs = X => X.Count(c => c == 'a');
            var numOfAllAs = list.Sum(numberOfAs); //getting function from Func variable
            var numOfAllBs = list.Sum(NumberOfBs); //getting function from a method

            //functional programming is a paradigm like
            //  OOP, like procedural programming

            //we treat functions/methods as if they were just another piece of data

            //C# is not a purely functional language but it does have plenty
            //  of support for programming in that style especially with LINQ
            //C# does have some immutale classes in the library

            //LINQ has two syntaxes... "method syntax" and "query syntax" (SQL wannabe)

            var allEmptyStrings = from x in list
                                  where x == ""
                                  select x.Count();

            //method syntax way
            var allEmptyStrings2 = list.Where(x => x == "");

            //LINQ methods we shoudl know...

            //Any (a big OR on a condition over all the elements)
            var anyStringsLongerThanFive = list.Any(s => s.Length > 5);

            //All (a bit AND on a condition over all the elements)
            bool allStringsLongerThanFix = list.All(s => s.Length > 5);

            //Contains (checks for a given value)

            //Count() or Count(value) (checks for number of elements, or a specific value)

            //DefaultIfEmpty

            //OrderBy

            //Distinct (will remove duplicate in collection)
            //The second characters of all the unique strings that start with 'a'
            var asdf = list.Distinct().Where(x => x[0] == 'a').Select(x => x[1]);

            //Select and Where are the most common ones
            //Select applies a mapping to the collection
            //Where filters a collection on some condition

            var allWithLengthThree = list.Where(s => s.Length == 3);

            //Usually use var with LINQ, types can be complicated
            //Deferred execution
            Console.WriteLine("This prints before the exception");

            //Many all these LINQ methods return IEnumerable, not whatever the original
            //  collection type is
            //In such cases, the processing defined by the method calls doesn't
            //  happen until you start trying to pull values out of that IEnumerable

            foreach (var item in asdf)
            {
                //HERE in this loop we are actually executing the logica from line 86
                Console.WriteLine(item);
            }

            //when we DON'T want deferred exectuion, we want all the values right now...
            //  we often use .ToList()

            asdf.Last();
            asdf.Last();
            asdf.Last();
            asdf.Last();
            //we sometimes want to avoid running the operations repetitively

        }

        static int NumberOfBs(string x)
        {
            var count = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == 'b')
                {
                    count++;
                }
            }
            return count;
        }
    }
}
