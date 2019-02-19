using System;
using MoreAnimals.Library;

namespace MoreAnimals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Dog fido1 = new Dog();
            fido1.Id = 1;
            fido1.Name = "Fido";
            fido1.Breed = "Doberman";

            //C# has property initializer syntax.
            Dog fido2 = new Dog
            {
                Id = 1,
                Name = "Fido",
                Breed = "Doberman"
            };

            fido1.GoTo("park");
            fido1.MakeNoise();

            //IAnimal is a parent type of Dog
            //Dog is a subtype of IAnimal

            IAnimal animal = fido1;
            //Conveting from Dog variable to IAnimal variable is "upcasting"
            //Upcasting is guarenteed to succeed, so it's implicit

            //converting the OTHER way, from IAnimal down to Dog, is "downcasting"
            //NOT guaranteed to succeed, so it must explicit with () casting
            //Bird bird = (Bird)animal; : Error

            //when the Dog object is contained in an IAnimal variable, we can't
            //  see the Dog specific stuff anymore
            //  animal.Breed = ""; //error

            Dog dog3 = (Dog)animal; // : Works

            //not all casting is upcasting or downcasting, e.g. int to double and back
            int integer = (int)3.4;
            double num = integer;

            var animals = new IAnimal[2];
            animals[0] = fido1;
            animals[1] = new Eagle()
            {
                Id = 3,
                Name = "Bill"
            };

            //this code doesn't care how the members are implmented,
            //  only that thye can do the job specified by the interface
            foreach (var item in animals)
            {
                Console.WriteLine(item.Name);
                item.MakeNoise();
                item.GoTo("park"); //here when we weren't using virtual/override
                                    //here we can't see Eagle.GoTo, whinc only hides
                                    //ABird.GoTo without truly overriding it

            //once we use virtual/override, it really does replace the method implementation
            //on the object itself
            }

            Eagle eagle1 = (Eagle)animals[1];
            eagle1.GoTo("park");

            //MakeNoise(dog3);
            //we use camelCase for local variables and private fields
            //TitleCase for everything else

            //static void MakeNoise(IAnimal anm)
            //{
            //    anm.MakeNoise();
            //}
        }
    }
}
