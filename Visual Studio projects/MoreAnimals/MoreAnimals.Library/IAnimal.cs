using System;
using System.Collections.Generic;
using System.Text;

namespace MoreAnimals.Library
{
    public interface IAnimal
    {
        //in an interface, the emmbers must have the same access level
        //  as the whole interface, so we don't not say it explicitly
        void MakeNoise();
        void GoTo(string location);
    }
}
