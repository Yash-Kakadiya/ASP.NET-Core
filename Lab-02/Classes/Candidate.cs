using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Classes
{
    class Candidate
    {
        int ID;
        String Name;
        int Age;
        int Weight;
        int Height;


        public void GetCandidateDetails()
        {
            Console.Write("Enter ID: ");
            ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("-------------------------------------------------");

            Console.Write("Enter Name: ");
            Name = Console.ReadLine();
            Console.WriteLine("-------------------------------------------------");


            Console.Write("Enter Age: ");
            Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("-------------------------------------------------");

            Console.Write("Enter Weight: ");
            Weight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("-------------------------------------------------");

            Console.Write("Enter Height: ");
            Height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("-------------------------------------------------");
        }

        public void DisplayCandidateDetails()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("ID: " + ID);
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Weight: " + Weight);
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Height: " + Height);
            Console.WriteLine("-------------------------------------------------");

        }

    }

}
