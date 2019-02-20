using System;
using System.Collections.Generic;
using System.Text;

namespace MoreAnimals.Library
{
    //this means Dog implements IAnimal interface
    //  which means every member specified by IAnimal is guarenteed to be present in this class
    public class Dog : IAnimal
    {

        //normally we stick to simple properties when we don't need any special checks
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Noise;
        public void MakeNoise()
        {
            Console.WriteLine("Woof!");
        }

        public void SetNoise(string newValue)
        {
            if (newValue == null)
            {
                throw new ArgumentNullException("newValue");
            }
            if (newValue.Length <= 0)
            {
                throw new ArgumentException("argument is empty", "newValue");
            }
            Noise = newValue;
        }

        public string GetNoise()
        {
            return Noise;
        }

        public void GoTo(string location)
        {
            Console.WriteLine($"Walking to {location}");
        }

    }
}
