using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Classes
{
    class Staff
    {
        public String Name;
        public String Department;
        public int Salary;
        String Designation;
        int Experience;

        public void GetStaffDetails()
        {
            Console.Write("Enter Name: ");
            Name = Console.ReadLine();
            Console.WriteLine("-------------------------------------------------");

            Console.Write("Enter Department: ");
            Department = Console.ReadLine().ToUpper();
            Console.WriteLine("-------------------------------------------------");

            Console.Write("Enter Designation: ");
            Designation = Console.ReadLine();
            Console.WriteLine("-------------------------------------------------");

            Console.Write("Enter Experience: ");
            Experience = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("-------------------------------------------------");

            Console.Write("Enter Salary: ");
            Salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("-------------------------------------------------");
        }
        
    }
}
