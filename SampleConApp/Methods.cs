using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Methods are functions that are used to manipulate the data. When to use property and a function.
//A Function is something U could pass info to it thro parameters and get something out of it thro return values. Functions are manipulators. Propertis are data holders. I use a method if I have some logic that is doing more than just accessing the memory and returning a value which is why properties are used. 
//Methods are of 2 types: Static vs. Non Static. Non static or Instance methods are created and used on object instances where the scope is unique to the instance of the object. The Static methods  are singleton members which means that all the objects share the same scope and the data. They are accessible without an object instance outside the class by their Classname and within the class directly without the classname.
//Static members cannot call instance members even within the same class, but the instance members can call static members
//C# does not support global functions, which can be indirectly achieved thro static methods. 
namespace SampleConApp
{
    class Account
    {
        public int AccountNo { get; set; }
        public string Name { get; set; }
        public double Balance { get; private set; }//new in C# 5.0 where U could have only get or set.
        public void Credit(double amount)
        {
            Balance += amount;
        }

        public void Debit(double amount)
        {
            if (Balance >= amount)
                Balance -= amount;
            else
                throw new Exception("Insufficient Funds");//Rejecting the value provided by the User....
        }
    }
    class Methods
    {

        static void Main(string[] args)
        {
            double totalSum = MultipleMethodsExample.Sum(123, 234);
            totalSum = MultipleMethodsExample.Sum(123, 234, 567);
            totalSum = MultipleMethodsExample.Sum(123, 234,234,234,234,234,234);
            string fullName = MultipleMethodsExample.GetFullName("Nagendra", "Phaniraj", "Bommathanahalli");
            Console.WriteLine(fullName);
            //Account account = new Account { AccountNo = 111, Name = "Phaniraj" };
            //account.Credit(5000);
            //Console.WriteLine("The current balance: {0:C}", account.Balance);
            //account.Debit(5000);

            //StaticExample.TestFunction();//Static method invocation....
            //StaticExample instance = new StaticExample();
            //instance.InstanceFunction();//Thro the instance, U cannot call the static method. In C# static methods and Instance methods are cleanly seperated. 

            //If U want to have a global scope for a function, U could mark that function as static. if U R calling a function very frequently within UR program, its good to make it static as the burden of creating the object instance is not required. For Frequently calling functions, its good to make it static and invoke it thro the classname instead of the object. 
            //Static members are initialized at the begining of the Application Execution and will be destroyed only during the termination of the Application. 

            //double value = 2;
            //MultipleMethodsExample.SimpleFunc(ref value);
            //Console.WriteLine("The current value:" + value);
            double added = 0, subtracted = 0, multiplied =0, divided;
            MathClass.AllOperations(123, 23, ref added, ref subtracted, ref multiplied, out divided);
            Console.WriteLine($"The Added value:{added}");
            Console.WriteLine($"The Subtracted value:{subtracted}");
            Console.WriteLine($"The multiplied value:{multiplied}");
            Console.WriteLine($"The Divided value:{divided}");
        }
    }

    class StaticExample
    {
        string objectData;
        static int incrementingNo;//All members will be initialized to their Default values. Value types to 0 and reference types to null.
        public static void TestFunction()
        {
            StaticExample ex = new StaticExample();
            ex.objectData = "Sample Data";//Compile error to call instance members within a static function without an object instance.
            //ObjectData is scoped to the instance of the class, in this case the ex object. Once ex goes out of scope the objectData is automatically destroyed. 
            ++incrementingNo;
            Console.WriteLine("Static method without instance");
        }

        public void InstanceFunction()
        {
            Console.WriteLine("The incremented no " + incrementingNo);//Static members are accessible by instance members within the same class with or without the classname. 
            Console.WriteLine("Instance method needs objects");
        }
    }
}
/*Points to Remember:
 * Create Static methods if U R using the methods very frequently
 * Static methods can also be created to provide the global scope for UR members. 
 * Static methods cannot call Instance methods and Instance members. 
 * Instance methods can call Static methods and members even without the classname. 
 * If UR Class is having only static methods, then there is no need for an object creation, in that case, U could mark the class as static so that even accidentally UR Users cannot create an object instance.
 * Static classes contain only static methods.
 * Methods can have in parameters, out parameters, ref parameters and params parameter. 
 * in parameter is the default parameter of a function where the parameter is passed by value. 
 * out and ref parameters are passed by reference. If UR function wants to return more than one value at a time, U could create ref and out parameters as they are retained even after the function call, they behave like return values. 
 * ref parameters will be initialized by the caller of the method and out parameters need not be initialized by the caller, however the outparameter must be set with a value inside the function before it returns to the caller.  
 * params is variable no of parameters. There can be only params within the parameter list. It should be the last of the parameter list. params are always passed by value. params must always be a single dimensional array..   
 */

namespace SampleConApp
{
    static class MathClass
    {
        public static void AllOperations(double v1, double v2, ref double res1, ref double res2, ref double res3, out double res4)
        {
            res1 = v1 + v2;
            res2 = v1 - v2;
            res3 = v1 * v2;
            if (v2 != 0)
                res4 = v1 / v2;
            else res4 = 0;
        }
        public static double AddFunc(double v1, double v2)
        {
            return v1 + v2;
        }
        //Lambda methods are new in C# 7.0
        public static double SubFunc(double v1, double v2) => v1 - v2;//Lambda Expressions......

        public static double MultiplyFunc(double v1, double v2) => v1 * v2;

        public static double DivideFunc(double v1, double v2) => v1 / v2;

        public static double SquareFunc(double v1) => MultiplyFunc(v1, v1);

        public static double SquareRoot(double v1) => Math.Sqrt(v1);
    }

    static class MultipleMethodsExample
    {

        public static double Sum(params double [] values)
        {
            double final = 0;
            foreach (double value in values)
                final += value;
            return final;
        }
        //The value with ref will be retaining the content even after the function is returned to the caller. ref keyword ensures that the original variable is passed not a copy. Any changes made to the original will obviously be reflected.....
        public static void SimpleFunc(ref double v1)
        {
            Console.WriteLine("The value before computing:" + v1);
            v1 += (v1 * v1);
            Console.WriteLine("The value after computing:" + v1);
        }

        /*
         * params is variable no of args within a function. 
         * If U dont know the no of args to pass to a function, U could mark the parameter as params. More like ... parameter in C++
         * 
         */
        public static string GetFullName(params string[] names)
        {
            string fullName = string.Empty;
            foreach (string name in names)
                fullName += name + " ";//StringBuilder for manipulated String....
            return fullName;    
        }
    }
}