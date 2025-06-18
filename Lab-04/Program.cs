using Lab4.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Q-1
            //Practical1 practical1 = new Practical1();
            //Console.WriteLine(practical1.addition(3,4));
            //Console.WriteLine(practical1.addition(3.3, 4.4));

            ////Q-2
            //Practical2 practical2 = new Practical2();
            //Console.WriteLine(practical2.area(7));
            //Console.WriteLine(practical2.area(4,5));

            ////Q-3
            //HDFC hdfc = new HDFC();
            //Console.WriteLine(hdfc.calculateInterest(10000, 2));
            //Console.WriteLine("---------------------------------------------------------------------------------------------");

            //SBI sbi = new SBI();
            //Console.WriteLine(sbi.calculateInterest(10000, 2));
            //Console.WriteLine("---------------------------------------------------------------------------------------------");


            //ICICI icici = new ICICI();
            //Console.WriteLine(icici.calculateInterest(10000, 2));
            //Console.WriteLine("---------------------------------------------------------------------------------------------");

            //Q-4
            //Apollo apolo = new Apollo();
            //apolo.HospitalDetails();

            //Wockhardt wockhardt = new Wockhardt();
            //wockhardt.HospitalDetails();

            //GokulSuperspeciality gokul = new GokulSuperspeciality();
            //gokul.HospitalDetails();

            //Q-5
            Area area = new Area();
            area.CalculateArea(5);
            area.CalculateArea(5, 10);
            area.CalculateArea(7, true);
        }
    }
}
