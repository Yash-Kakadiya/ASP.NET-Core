using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Classes
{
    class Bank_Account
    {
        String Account_No;
        string Email;
        String User_Name;
        String Account_Type;
        float Account_Balance;
        public void GetAccountDetails()
        {
            Console.Write("Enter account number: ");
            Account_No = Console.ReadLine();
            Console.Write("Enter account holder name: ");
            User_Name = Console.ReadLine();
            Console.Write("Enter account holder email: ");
            Email = Console.ReadLine();
            Console.Write("Enter account holder account type: ");
            Account_Type = Console.ReadLine();
            Console.Write("Enter initial balance: ");
            Account_Balance = float.Parse(Console.ReadLine());
        }
        public void DisplayAccountDetails()
        {
            Console.WriteLine($"\n--------Account details---------\n Account Number: {Account_No}\n Account Holder Name: {User_Name}\n Account Holder Email: {Email}\n Account type: {Account_Type}\n Balance: {Account_Balance}");
        }
    }
}