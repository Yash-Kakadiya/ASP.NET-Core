using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Classes
{
    class Area
    {
        public void CalculateArea(double length, double breadth)
        {
            double area = length * breadth;
            Console.WriteLine($"Area of the rectangle: {area} square units");
        }
        public void CalculateArea(double side)
        {
            double area = side * side;
            Console.WriteLine($"Area of the square: {area} square units");
        }
        public void CalculateArea(double radius, bool isCircle)
        {
            if (isCircle)
            {
                double area = Math.PI * radius * radius;
                Console.WriteLine($"Area of the circle: {area} square units");
            }
            else
            {
                Console.WriteLine("Invalid parameters for circle area calculation.");
            }
        }
    }
}
