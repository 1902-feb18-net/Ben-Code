using System;

//For each number from 1 to 1000 in order,
//* print "Fizz" for the ones divisible by 3 (& not 5)
//* print "Buzz" for the ones divisible by 5 (& not 3)
//* print "Fizzbuzz" for the ones divisible by both 3 and 5
//* print the number itself, for all the rest of the numbers
//Also, I want to know, at the end, how many Fizz, how many Buzz, how many Fizzbuzz.

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            int fizzNum = 0;
            int buzzNum = 0;
            int fizzBuzzNum = 0;

            for (int i = 1; i <= 1000; i++)
            {
                if (i % 15 == 0)
                {
                    Console.WriteLine("Fizzbuzz");
                    fizzBuzzNum++;
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                    fizzNum++;
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                    buzzNum++;
                }
                else
                    Console.WriteLine(i);
            }

            Console.WriteLine($"Fizz: {fizzNum}, Buzz: {buzzNum}, FizzBuzz: {fizzBuzzNum}");

            return;
        }
    }
}