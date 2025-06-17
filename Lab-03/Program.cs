using System;
using Lab3.Classes;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Q-1
            //int a = 7, b = 0;
            //try
            //{
            //    a = 7 / b;
            //}
            //catch (DivideByZeroException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //Q-2
            //int[] arr = new int[5];

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write("Enter number at index " + i + ": ");
            //    arr[i] = Convert.ToInt32(Console.ReadLine());
            //}
            //try
            //{
            //    for (int i = 0; i <= arr.Length; i++)
            //    {
            //        Console.WriteLine("Number at index " + i + ": " + arr[i]);
            //    }
            //}
            //catch (IndexOutOfRangeException e)
            //{
            //    Console.WriteLine("Error: " + e);
            //}

            //Q-3
            //Calculate calculate = new Calculate();
            //System.Console.WriteLine("3 + 4 = "+calculate.SumOfTwo(3,4));
            //System.Console.WriteLine("1 + 2 + 4 = "+calculate.SumOfThree(3,2,2));

            //Q-4
            //CalculateInterface calculateInterface = new CalculateInterface();
            //System.Console.WriteLine("3 + 4 = " + calculateInterface.Addtion(3 , 4));
            //System.Console.WriteLine("10 - 3  = " + calculateInterface.Substraction(10 , 3));

            //Q-5
            //string str = "Yash Kakadiya, World     ";
            //Console.WriteLine($"Original string: '{str}'");

            //string trimmed = str.Trim();
            //Console.WriteLine($"Trimmed: '{trimmed}'");

            //Console.WriteLine($"ToUpper: {trimmed.ToUpper()}");
            //Console.WriteLine($"ToLower: {trimmed.ToLower()}");

            //Console.WriteLine($"Substring (start at 7): {trimmed.Substring(7)}");

            //Console.WriteLine($"Replace 'World' with 'C#': {trimmed.Replace("World", "C#") }");

            //Console.WriteLine($"Contains 'Hello': {trimmed.Contains("Hello")}");

            //Console.WriteLine($"IndexOf ',': {trimmed.IndexOf(',') }");

            //string[] parts = trimmed.Split(',');
            //Console.WriteLine("Split by ',' :");
            //foreach (var part in parts)
            //{
            //    Console.WriteLine(part);
            //}

            //Q-6
            //string input = Console.ReadLine();
            //char[] swapped = new char[input.Length];

            //for (int i = 0; i < input.Length; i++)
            //{
            //    char c = input[i];
            //    if (char.IsLower(c))
            //        swapped[i] = char.ToUpper(c);
            //    else if (char.IsUpper(c))
            //        swapped[i] = char.ToLower(c);
            //    else
            //        swapped[i] = c;
            //}

            //string result = new string(swapped);
            //Console.WriteLine($"Swapped case: {result}");

            //Q-7
            InterfaceShape.AreaCalculator areaCalculator = new InterfaceShape.AreaCalculator();
            Console.WriteLine("Circle area with r = 2 is " + areaCalculator.Circle(2));
            Console.WriteLine("Triangle area with base = 1, height = 3 is " + areaCalculator.Triangle(1, 3));
            Console.WriteLine("Square area with lenght = 2 is " + areaCalculator.Square(2));

        }
    }
}
