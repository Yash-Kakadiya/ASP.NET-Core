using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Classes
{
    interface CalculateLab4
    {
        int Addtion(int a, int b);
        int Substraction(int a, int b);
    }
    class CalculateInterface : CalculateLab4
    {
        public int Addtion(int a, int b)
        {
            return a + b;
        }
        public int Substraction(int a, int b)
        {
            return a - b;
        }
    }
}
