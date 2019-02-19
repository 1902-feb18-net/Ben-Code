using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Library
{
    public class Circle : Shapes
    {
        public Circle()
        {
            NumOfSides = 1;
        }

        double m_Radius;
        public double Width
        {
            get => m_Radius;
            set
            {
                m_Radius = value / 2;
            }
        }

        public double Height
        {
            get => m_Radius;
            set
            {
                m_Radius = value / 2;
            }
        }

        public int NumOfSides { get; }

        public double CalculateArea()
        {
            return (3.14 * (m_Radius * m_Radius));
        }
    }
}
