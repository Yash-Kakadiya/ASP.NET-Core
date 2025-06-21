using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04.Classes
{
    class HDFC : RBI
    {
        public override double calculateInterest(double amount, double time, double rate = 5)
        {
            Console.WriteLine("Welcome to HDFC");
            Console.Write("Interest with amount of " + amount + " at the rate of " + rate + "% for " + time + " years is: Rs.");
            return amount * time * rate / 100;
        }
    }
}
