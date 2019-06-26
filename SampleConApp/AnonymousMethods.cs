using System;

/*
 * Anonymous methods are functions that are created adhoc to support callback functions. They are used in conjuction with delegates. 
 * There are 2 delegates created by .NET to support multiple signatures. Action and Func. Action delegate is for void Functions and Func is for non-void Functions. 
 * There are 19 overloads for this delegates. U could use this delegate for any kind of function that can have any kind of args upto 17 in no. 
 */
namespace SampleConApp
{
    class AnonymousMethods
    {
        static void Main(string[] args)
        {
            //anonymousExample();

            //multiCastDelegate();

            Func<double, double> SpOperation =  (no) => no * no;
            //Square operation....
            Console.WriteLine("The result:" + SpOperation(12));
        }

        private static void multiCastDelegate()
        {
            Func<double, double, double> operation = new Func<double, double, double>(addFunc);
            operation += subFunc;//Multicast delegate....
            double result = operation(123, 23);
            Console.WriteLine(result);
        }

        public static double addFunc(double v1, double v2)
        {
            Console.WriteLine("Add Func is called");
            return v1 + v2;
        }

        public static double subFunc(double v1, double v2)
        {
            Console.WriteLine("Sub Func is called");
            return v1 - v2;
        }

        private static void anonymousExample()
        {
            Func<double, double, double> operation = delegate (double first, double second)
            {
                return first + second;
            };

            Console.WriteLine(operation(123, 234));

            Action action = delegate ()
            {
                Console.WriteLine("Test Func");
            };//A method with no name associated with the delegate object is called as Anonymous method introduced in .NET 2.0
            action();
        }

        //static void TestFunc()
        //{
        //    Console.WriteLine("Test Func");
        //}
    }
}
