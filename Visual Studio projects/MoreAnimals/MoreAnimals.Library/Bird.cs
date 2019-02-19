using System;
using System.Collections.Generic;
using System.Text;

namespace MoreAnimals.Library
{
    //an abstract class is like a mix of class and interface
    //we can provide some iplmentation while leaving other things unimplemented
    public abstract class ABird : IAnimal
    {
        //exercisee: implement class Bird for interface IAnimal
        //"expression body" methods/properties
        //in cocntrast to 'block body"
        //string GetNoise() => "noise"
        //string GetNoise() => 


        public int Id { get; set; }
        public string Name { get; set; }
        
        //is filled out by child class
        public abstract void MakeNoise();

        //virtual is an extended modifier meaning 
        //  "opt-in to derived classes being allowed to override it"
        public virtual void GoTo(string location)
        {
            Console.WriteLine($"Flying to {location}");
        }



        //because we don't have all implementation, it's impossible
        //  to construct an object from an abstract class
    }
}
