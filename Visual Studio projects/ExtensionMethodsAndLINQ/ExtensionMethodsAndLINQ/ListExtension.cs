using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethodsAndLINQ.Extensions
{
    public static class ListExtension
    {
        //C# supports adding methods onto any class using static 
        //  methods whose first parameter is declared with "this"
        //  the class/struct which type
        public static bool Empty<T>(this List<T> list)
        {
            return list.Count == 0;
        }

        public static int Pow(this int a, int b)
        {
            if (b < 0)
            {
                throw new ArgumentException("exponent must be non-negative", nameof(b));
            }
            if (b == 0) { return 1; }

            int result;
            for (result = a; b > 1; b--)
            {
                result *= a;
            }
            return result;
        }
    }
}
