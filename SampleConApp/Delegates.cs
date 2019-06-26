using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Delegates are reference types to create callback functions.
 * Function which takes another function as an arg and the function will invoke it if the logical conditions are met is what is the reason behind callback fns. 
 * Event handling, thread based functions are the examples of callback functions. 
 * In these cases, functions take function as the arg. 
 * If U want to pass a fn as an arg, then U should create a Delegate and the instance of the delegate is used to declare the function. Any function that matches the signature of the delegate could be passed as arg when U invoke the function. 
 */
namespace SampleConApp
{
    delegate void FuncRef(int value);//syntax to create a delegate
    class Delegates
    {
        static void InvokeFunc(FuncRef func)
        {
            if (func == null)
                return;
            Console.WriteLine("Enter a number");
            int data = int.Parse(Console.ReadLine());
            func(data);
        }
        static void Main(string[] args)
        {
            //Anonymous method....
            //InvokeFunc(delegate(int val)
            //{
            //    int value = val + (val * val);
            //    Console.WriteLine("The result is " + value);
            //});

            InvokeFunc(CallThisFunc);
        }

        static void CallThisFunc(int arg)
        {
            int value = arg + (arg * arg);
            Console.WriteLine("The result is " + value);
        }
    }
}
