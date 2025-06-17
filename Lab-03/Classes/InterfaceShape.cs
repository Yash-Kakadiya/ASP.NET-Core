using System;

namespace Lab3.Classes
{
    class InterfaceShape
    {
        public interface Shape
        {
            double Circle(double radius);
            double Triangle(double @base, double height);
            double Square(double side);
        }

        public class AreaCalculator : Shape
        {
            public double Circle(double radius)
            {
                return Math.PI * radius * radius;
            }

            public double Triangle(double @base, double height)
            {
                return 0.5 * @base * height;
            }

            public double Square(double side)
            {
                return side * side;
            }
        }
    }
}
