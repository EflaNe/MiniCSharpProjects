using System;
using System.Threading;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to the calculator program!");

            while (true) 
            {
                float num1 = ReadFloat("Please enter your first number: ");
                float num2 = ReadFloat("Please enter your second number: ");

                Console.WriteLine("What type of operation would you like to do?");
                Console.WriteLine("Enter: a=addition, s=subtraction, m=multiplication, d=division");
                Console.Write("Choice: ");
                string answer = (Console.ReadLine() ?? "").Trim().ToLower();

                float result = 0f;
                bool valid = true;

                switch (answer)
                {
                    case "a":
                        Console.WriteLine("Waiting...");
                        Thread.Sleep(500);
                        result = num1 + num2;
                        break;

                    case "s":
                        Console.WriteLine("Waiting...");
                        Thread.Sleep(500);
                        result = num1 - num2;
                        break;

                    case "m":
                        Console.WriteLine("Waiting...");
                        Thread.Sleep(500);
                        result = num1 * num2;
                        break;

                    case "d":
                        Console.WriteLine("Waiting...");
                        Thread.Sleep(500);

                        if (num2 == 0f)
                        {
                            Console.WriteLine("Error: You cannot divide by 0.");
                            valid = false;
                        }
                        else
                        {
                            result = num1 / num2;
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid operation choice.");
                        valid = false;
                        break;
                }

                if (valid)
                {
                    Console.WriteLine("The result is: " + result);
                }

                Console.Write("Do you want to calculate again? (y/n): ");
                string again = (Console.ReadLine() ?? "").Trim().ToLower();
                if (again != "y")
                {
                    Console.WriteLine("Thank you for using the calculator program!");
                    break;
                }

                Console.WriteLine(); 
            }
        }

        static float ReadFloat(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (float.TryParse(input, out float value))
                    return value;

                Console.WriteLine("Invalid input! Please enter a valid number (e.g., 12, 3.14, -0.5).");
            }
        }
    }
}