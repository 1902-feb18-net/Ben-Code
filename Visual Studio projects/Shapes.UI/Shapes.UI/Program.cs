using Shapes.Library;
using System;

namespace Shapes.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Circle circle1 = new Circle()
            {
                Width = 1
            };

            Console.WriteLine($"The total area is {circle1.CalculateArea()}");
            Console.WriteLine($"Number of sides is {circle1.NumOfSides}");

            Rectangle rect1 = new Rectangle()
            {
                Width = 4,
                Height = 4
            };

            Console.WriteLine(rect1.CalculateArea());

        }
    }
}
