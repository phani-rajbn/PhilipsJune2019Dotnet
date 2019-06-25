using System;
namespace MiddleLayer
{
    //A Class is designed for reusability. It should be modular in nature. One class to do only one job
    //Business Layerf
    class MathComponent

    {
        public static double Add(double val1, double val2)
        {
            return val1 + val2;
        }

        public static double Subtract(double val1, double val2)
        {
            return val1 - val2;
            
        }
        public static double Multiply(double val1, double val2)
        {
            return val1 * val2;
            
        }

        public static double Divider(double val1, double val2)
        {
            return val1 / val2;
        }
    }

    //Common Layer...
    class Prompt
    {
        public static string GetString(string statement)
        {
            Console.WriteLine(statement);
            return Console.ReadLine();
        }

        public static double GetNumber(string statement)
        {
            return double.Parse(GetString(statement));
        }
    }

    //UI Layer
    class CalcProgram
    {
        static string getMenu()
        {
            string menu = string.Format("1. Addition\n2. Subtraction\n3. Multiplication\n4. Division\n5. Exit\n");
            return menu;
        }
        static void Main(string[] args)
        {
            string menu = getMenu();
            bool loop = true;
            do
            {
                string answer = Prompt.GetString(menu);
                loop = processMenu(answer);
                waitForAnswer();
            } while (loop);
        }

        private static void waitForAnswer()
        {
            Console.WriteLine("Press any key to clear");
            Console.ReadKey();
            Console.Clear();
        }

        private static bool processMenu(string answer)
        {
            switch (answer)
            {
                case "1":
                    addingOperation();
                    return true;
                case "2":
                    subtractingOperation();
                    return true;
                case "3":
                    multiplyOperation();
                    return true;
                case "4":
                    dividingOperation();
                    return true;
                default:
                    return false;
            }
        }

        private static void dividingOperation()
        {
            double firstValue = Prompt.GetNumber("Enter the first value");
            double secondValue = Prompt.GetNumber("Enter the second value");
            double res = MathComponent.Divider(firstValue, secondValue);
            Console.WriteLine("The Result: " + res);
        }

        private static void multiplyOperation()
        {
            double firstValue = Prompt.GetNumber("Enter the first value");
            double secondValue = Prompt.GetNumber("Enter the second value");
            double res = MathComponent.Multiply(firstValue, secondValue);
            Console.WriteLine("The Result: " + res);
        }

        private static void subtractingOperation()
        {
            double firstValue = Prompt.GetNumber("Enter the first value");
            double secondValue = Prompt.GetNumber("Enter the second value");
            double res = MathComponent.Subtract(firstValue, secondValue);
            Console.WriteLine("The Result: " + res);
        }

        private static void addingOperation()
        {
            double firstValue = Prompt.GetNumber("Enter the first value");
            double secondValue = Prompt.GetNumber("Enter the second value");
            double res = MathComponent.Add(firstValue, secondValue);
            Console.WriteLine("The Result: " + res);
        }
    }
}