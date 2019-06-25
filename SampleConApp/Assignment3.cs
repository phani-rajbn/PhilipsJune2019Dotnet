using System;

namespace Assignments
{
    class Assignment3
    {
        static void Main(string[] args)
        {
            bool loop = true;
            double val1, val2;
            while (loop)
            {
                int operation = GetInput(out val1, out val2);
                loop = PerformOperation(operation, val1, val2);
            }
        }

        private static bool PerformOperation(int operation, double val1, double val2)
        {
            switch (operation)
            {
                case 0:
                    Console.WriteLine("Enter valid values");
                    return true;
                case 1:
                    Console.WriteLine("Addition");
                    Calculator.Adder(val1, val2);
                    return true;
                case 2:
                    Console.WriteLine("Subtraction");
                    Calculator.Subtractor(val1, val2);
                    return true;
                case 3:
                    Console.WriteLine("Multiplication");
                    Calculator.Multiplier(val1, val2);
                    return true;
                case 4:
                    Console.WriteLine("Division");
                    Calculator.Divider(val1, val2);
                    return true;
                case 5:
                    Console.WriteLine("Exit");
                    return false;
                default:
                    Console.WriteLine("Enter valid values");
                    return true;
            }
        }

        private static int GetInput(out double val1, out double val2)
        {
            Console.WriteLine();
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Exit");
            string input = Console.ReadLine();
            int operation;
            if (int.TryParse(input, out operation))
            {
                if (operation > 0 && operation < 5)
                {
                    Console.WriteLine("Enter first number");
                    input = Console.ReadLine();
                    if (double.TryParse(input, out val1))
                    {
                        Console.WriteLine("Enter second number");
                        input = Console.ReadLine();
                        if (double.TryParse(input, out val2))
                            return operation;
                    }
                }
                else if (operation == 5)
                {
                    val1 = 0;
                    val2 = 0;
                    return 5;
                }
            }
            val1 = 0;
            val2 = 0;
            return 0;
        }
    }
    //A Class should do only one kind of job. It is adding as well as displaying....
    class Calculator
    {
        public static void Adder(double val1, double val2)
        {
            double result = val1 + val2;
            Console.WriteLine($"result is {result}");
        }

        public static void Subtractor(double val1, double val2)
        {
            double result = val1 - val2;
            Console.WriteLine($"result is {result}");
        } 
        public static void Multiplier(double val1, double val2)
        {
            double result = val1* val2;
            Console.WriteLine($"result is {result}");
        }

        public static void Divider(double val1, double val2)
        {
            if (val2 == 0)
                Console.WriteLine($"result is 0");
            else
            {
                double result = val1 / val2;
                Console.WriteLine($"result is {result}");
            }
        }

    }
}
