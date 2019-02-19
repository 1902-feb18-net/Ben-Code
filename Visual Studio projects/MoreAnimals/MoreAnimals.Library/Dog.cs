using System;
using System.Collections.Generic;
using System.Text;

namespace MoreAnimals.Library
{
    public class Dog
    {

        //normally we stick to simple properties when we don't need any special checks
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }

        public void MakeNoisee()
        {
            Console.WriteLine("Woof!");
        }

        public void GoTo(string location)
        {
            Console.WriteLine($"Walking to {location}");
        }

    }
}
