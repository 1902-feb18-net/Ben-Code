using System;

namespace Animals.Library
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var dog = new Dog();
            dog.GoTo("door");
            dog.MakeNoise();
        }
    }
}
