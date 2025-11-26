namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Write a program to print your name, address, contact number & city.
            Console.WriteLine("Name: John Doe");
            Console.WriteLine("Address: 123 Main Street");
            Console.WriteLine("Contact Number: 123-456-7890");
            Console.WriteLine("City: New York");
            Console.WriteLine();

            // 2. Write a program to get two numbers from user and print those two numbers.
            Console.Write("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"You entered: {num1} and {num2}");
            Console.WriteLine();

            // 3. Write program to prompt a user to input his/her name and country name and then output as: Hello <yourname> from country <countryname>
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your country: ");
            string country = Console.ReadLine();
            Console.WriteLine($"Hello {name} from country {country}");
            Console.WriteLine();

            // 4. Write a program to calculate the size of the area in square-feet based on Specified length and width.
            Console.Write("Enter length in feet: ");
            double length = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter width in feet: ");
            double width = Convert.ToDouble(Console.ReadLine());
            double area = length * width;
            Console.WriteLine($"Area is: {area} square feet");
            Console.WriteLine();

            // 5. Write a program to calculate area of Square, Rectangle and Circle.
            Console.Write("Enter side of square: ");
            double side = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Area of square: {side * side}");

            Console.Write("Enter length of rectangle: ");
            double rectLength = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter width of rectangle: ");
            double rectWidth = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Area of rectangle: {rectLength * rectWidth}");

            Console.Write("Enter radius of circle: ");
            double radius = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Area of circle: {Math.PI * radius * radius}");
            Console.WriteLine();

            // 6. Write a program to calculate Celsius to Fahrenheit and vice-versa using function.
            static double CelsiusToFahrenheit(double celsius) => celsius * 9 / 5 + 32;
            static double FahrenheitToCelsius(double fahrenheit) => (fahrenheit - 32) * 5 / 9;

            Console.Write("Enter temperature in Celsius: ");
            double celsius = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Fahrenheit: {CelsiusToFahrenheit(celsius)}");

            Console.Write("Enter temperature in Fahrenheit: ");
            double fahrenheit = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Celsius: {FahrenheitToCelsius(fahrenheit)}");
            Console.WriteLine();

            // 7. Write a program to find out Simple Interest using function. (I = PRN/100)
            static double SimpleInterest(double principal, double rate, double time)
            {
                return principal * rate * time / 100;
            }

            Console.Write("Enter Principal: ");
            double principal = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Rate: ");
            double rate = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Time: ");
            double time = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Simple Interest: {SimpleInterest(principal, rate, time)}");
            Console.WriteLine();

            // 8. Write a program to create a Simple Calculator for two numbers (Addition, Multiplication, Subtraction, Division) [Also using if…else & Switch Case]
            Console.Write("Enter first number: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Choose operation: + - * /");
            string operation = Console.ReadLine();
            Console.Write("Enter second number: ");
            double b = Convert.ToDouble(Console.ReadLine());

            // Using if...else
            if (operation == "+")
                Console.WriteLine($"Addition: {a + b}");
            else if (operation == "-")
                Console.WriteLine($"Subtraction: {a - b}");
            else if (operation == "*")
                Console.WriteLine($"Multiplication: {a * b}");
            else if (operation == "/")
                Console.WriteLine(b != 0 ? $"Division: {a / b}" : "Cannot divide by zero");
            else
                Console.WriteLine("Invalid operation");

            // Using switch
            switch (operation)
            {
                case "+":
                    Console.WriteLine($"Addition: {a + b}");
                    break;
                case "-":
                    Console.WriteLine($"Subtraction: {a - b}");
                    break;
                case "*":
                    Console.WriteLine($"Multiplication: {a * b}");
                    break;
                case "/":
                    if (b != 0)
                        Console.WriteLine($"Division: {a / b}");
                    else
                        Console.WriteLine("Cannot divide by zero");
                    break;
                default:
                    Console.WriteLine("Invalid operation");
                    break;
            }
            Console.WriteLine();

            // 9. Write a program to Swapping without using third variable.
            Console.Write("Enter first number for swap: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second number for swap: ");
            int y = Convert.ToInt32(Console.ReadLine());
            x = x + y;
            y = x - y;
            x = x - y;
            Console.WriteLine($"After swapping: x = {x}, y = {y}");
            Console.WriteLine();

            // 10. Write a program to find maximum numbers from given 3 numbers using ternary operator.
            Console.Write("Enter first number: ");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second number: ");
            int n2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter third number: ");
            int n3 = Convert.ToInt32(Console.ReadLine());
            int max = n1 > n2 ? n1 > n3 ? n1 : n3 : n2 > n3 ? n2 : n3;
            Console.WriteLine($"Maximum number is: {max}");
        }
    }

}