using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * C# language is based on C++.
 * Majorly used to create .NET based Apps.
 * Files are saved with extension .cs. 
 * C# tries to develop the code as pure object oriented programming. 
 * Everything in C# should be within a class or a struct.
 * U cannot have global members. Even Main is a function of a class. 
 * Usually Classname and the filename should be same.(Need not be always, but good for maintainance).
 * Main is the entrypoint of the C# project. 
 * Main function is part of a class. The function should be static which could have either void or int as its return type. 
 * It can however take String Array as arguement or nothing.
 * Main method need not have access specifier. Default access specifier is private in C#. 
 * Static methods are those that can be called by their classname without creating an instance of the class. 
 * Console is a class in .NET to interact with the Console Window. It has only static methods, which means that U can invoke its methods by the Name of the Class, without a need of an object of the Console Class. 
 * WriteLine method is used to write content on the Console Window and ReadLine method is used to read the input provided by the user thro Console.
 * ReadLine method returns the input as a string variable. 
 * Anything U write or read to and from the console are implicitly converted to string and then displayed or returned respectively. 
 * For simple input and display, string would do, but for manipulation U need data types.
 */
namespace SampleConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Name");
            string name = Console.ReadLine();

            //Console.WriteLine("Enter the Date of Birth");
            //string dob = Console.ReadLine();

            Console.WriteLine("Enter the Age");
            string age = Console.ReadLine();

            Console.WriteLine("Enter the Address");
            string address = Console.ReadLine();

            //Console.WriteLine($"The name is {name} from {address}\nThe person's date of birth is {dob}");//New in C# 7.0 called Interpolation Syntax which is used to display a text combined with values of the variables.
            Console.WriteLine($"The name is {name} from {address}\nThe person's age is {age}");
        }
        //Ctrl+ F5 to execute the Application...
    }
}
