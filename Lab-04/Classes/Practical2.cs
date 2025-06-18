using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Classes
{
    class Practical2
    {
        public double area(double l)
        {
            Console.Write("Area of square with side " + l + ": ");
            return l * l;
        }
        public double area(double l, double b)
        {
            Console.Write("Area of rectangle with lenght " + l + " and breadth " + b + " is: ");
            return l * b;
        }
    }
}
