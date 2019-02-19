using System;
using System.Collections.Generic;
using System.Text;

namespace MoreAnimals.Library
{
    public class Eagle : ABird
    {
        //in C# by default overriding inheretied members is not allowed!
        //  only adding new members
        public override void MakeNoise()
        {
            Console.WriteLine("Screech");
        }

        //override is the counterpart to virtual
        //overried goes on the child class
        public override void GoTo(string location)
        {
            Console.WriteLine($"I'm an eagle flying to the {location}");
        }
    }
}
