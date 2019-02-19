using System;

namespace Animals.Library
{
    public class Dog
    {
        //fields
        internal string Noise = "Woof";

        //getter
        public string getNoise()
        {
            return $"{Noise}!";
        }

        //setter
        public void setNoise(string newValue)
        {
            if (newValue == null || newValue.Length <= 0)
            {
                throw new ArgumentException("value must not be null or empty");
            }
            Noise = newValue;
        }

        //instead of using getters and setters,
        //  in C# we have properties where other languages
        //  would just use fields on their own



        //methods
        public void GoTo(string location)
        {
            // simple way to put a string together
            // Console.WriteLine("Walking to " + location);

            //string interpolation syntax
            //$ in front turns braces into "switch back to C#" code
            Console.WriteLine($"Walking to {location}");
        }

        public void MakeNoise()
        {
            Console.WriteLine(Noise);
        }

        //access modifiers
        //in C#, every class/interface/etc has some access modifier
        //      and every class/etc _member_ also has some access modifier

        //public: everyone can access this member
        //private/(nothing): only the current class can access this member
        //internal: anything in the same assembly (project) can access,
        //      but nothing from outside the assembly

        //there's no such thing as a private class
        //  On classes, interface, etc we have public and internal
        //  Default is internal
    }
}