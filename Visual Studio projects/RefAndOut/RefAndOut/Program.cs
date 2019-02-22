using NLog;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RefAndOut
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number: ");
            
            //gets a string from user
            var input = Console.ReadLine();

            //converts int to string representation

            //try
            //{
            //    int number = int.Parse(input);
            //    Console.WriteLine($"Number entered: {number}");

            //}
            //catch (FormatException ex)
            //{
            //    Console.WriteLine("Invalid input");
            //}

            //out parameters are declared outside the method call
            //  and then the method fills in that value (it's
            //  normally not possible for a method to directly 
            //  change a variable outside of it)
            //This enables methods to effectively return several things at once

            int number;
            if (int.TryParse(input, out number))
            {
                Console.WriteLine($"Number entered: {number}");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }

            //We can also just declare the out parameter in the call
            int.TryParse(input, out int num);

            var dict = new Dictionary<string, int>();
            if (dict.TryGetValue("Ben", out var value))
            {
                //work with value
            }

            //We also have "ref" parameters
            //If youv'e used pointers before, out is a little bit like
            //  passing a pointer, ref is even more like passing a pointer

            int x = 40;
            ChangeMyIntDoesntWork(x); //passes the variable's value only
            ChangeMyInt(ref x); //passing the variable itself
            Console.WriteLine(x);

            //Ref parameters let us pass a whole variable to a function
            //  and have it change the contents of that variable freely
            //Ref has a greater performance penalty than out

            unsafe
            {
                //declare int
                int x2 = 22;

                //get hte memory address of that int as a pointer to the int
                int* pointer = &x2;
                Console.WriteLine((int)pointer);

                //pass  it to a function to change the value a t that address
                ChangeMyIntTwo(pointer);
                Console.WriteLine(*pointer);
            }
            //We need unsafe code sometimes, when we are calling unmanaged
            //  APIs (like Windows API) that requires pointers as arguments
            //  to their methods.  Otherwise avoid it

            ILogger logger = LogManager.GetCurrentClassLogger();
            logger.Debug("logger created succeessfully");

            //try
            //{
            //    int.Parse("abc");
            //}
            //catch (FormatException ex)
            //{
            //    logger.Error(ex);
            //    throw;
            //}

            var logLine = "2019-02-22 10:31:00.3678 DEBUG logger created succeessfully";
            var match = Regex.Match(logLine, @"[\d-]+ [\d:.]+ (\w+)");
            //Regex syntax:
            //"Character classes": 
            //\d for all digits, 
            //\w for all word characters, letters, numbers, and _
            //\s for all whitespace, most of these have an opposite version with uppercase
            //\S for all non-whitespace
            //[abcd] means, one character, EITHER a, b, c, or d

            //a* means 0 to many 'a' chars
            //a+ mean 1 to many 'a' chars

            //() are for surrounding groups of chararcters that you 
            //  want to extract later

            //third capture
            string logLevel = match.Groups[3].Value;
            string dateStr = match.Groups[1] + " " + match.Groups[2];
            if (DateTime.TryParse(dateStr, out var date))
            {
                Console.WriteLine(date);
            }
            else
            {
                Console.WriteLine($"couldn't parse date {dateStr}");
            }

            

            Console.WriteLine(logLevel);

            Console.ReadLine(); //wait until finished
        }

        public static void ChangeMyIntDoesntWork(int number)
        {
            number = 10;
        }

        public static void ChangeMyInt(ref int number)
        {
            number = 20;
        }
        
        //to compile unsafe code, right click on the project name
        //  (not the project solution), go to build, check "allow
        //  unsafe code"
        public static unsafe void ChangeMyIntTwo(int *number)
        {
            //points are like ref variables but less abstracted,
            //  we can see the exact memory location of the value
            //In fact, a pointer is a memory location
            *number = 5;
        }

    }
}
