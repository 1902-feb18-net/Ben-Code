using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Library
{
    public interface Shapes
    {
        double Width { get; set; }

        double Height { get; set; }


        int NumOfSides { get; }

        double CalculateArea();
    }
}
