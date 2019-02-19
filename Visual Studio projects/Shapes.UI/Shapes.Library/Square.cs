using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Library
{
    public class Rectangle : Shapes
    {
        public Rectangle()
        {
            NumOfSides = 4;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public int NumOfSides { get; }

        public double CalculateArea()
        {
            return Width * Height;
        }
    }
}
