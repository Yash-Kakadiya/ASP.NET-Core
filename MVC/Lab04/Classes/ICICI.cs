using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04.Classes
{
    class ICICI : RBI
    {
        public override double calculateInterest(double amount, double time, double rate = 4)
        {
            Console.WriteLine("Welcome to ICICI");
            Console.Write("Interest with amount of " + amount + " at the rate of " + rate + "% for " + time + " years is: Rs.");
            return amount * time * rate / 100;
        }
    }
}
