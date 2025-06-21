using Lab03.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03.Classes
{
    class Calculate : Sum
    {
        public override int SumOfTwo(int a, int b)
        {
            return a + b;
        }

        public override int SumOfThree(int a, int b, int c)
        {
            return a + b+c;
        }
    }
}
