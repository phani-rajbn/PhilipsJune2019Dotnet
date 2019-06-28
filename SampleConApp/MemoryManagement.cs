using System;
using System.IO;
using System.Threading;
/*
* memory management in .NET is based on Garbage collection algorithm. 
* GC is a internal component within the CLR to clean up unused memory while the Application is executing.
* It is invoked when an object is created so that it would check for the required memory, if not found runs thro the heap area to clean up unused references and allow the new object to be created. 
* GC releases all the unused objects memory instead of one or two. Either it releases all or nothing.
* GC is programmatically invokable using GC,a Static class.
* During the course of Execution, GC will be be invoked in a time based manner to clean unused object references. 
* Any object created in .NET will be making an entry of its reference in FinalizationQueue, a table of memory holders. Whenever GC runs, it finds all the reference objects in this Queue, runs thro the QUeue to remove unused memory. If an object survives the cleaning, then it is moved to next level called Generation 1. Generation 0, 1 and 2 are the 3 generations followed by GC to understand the strength of the object. Objects that are recently created are weak references or Gen 0 order references and so forth continued. Static members are 2nd Generation members as they are created once and will retain till the Application is terminated. 
* Automatic Memory Management thro Garbage collection: Part1 and Part2. Jeffery Ricther.
* 
* Developers have no control on the Destructor code to be invoked thro a program. If U want to explicitly run a code that needs any clean up of memory that is not controlled by the GC(Unmanaged code) or Unsafe code, then U must have a function that will be called once the work with the object is done and the object is intended to be destroyed. In such case, UR Class could implement IDisposable interface and implement a function called Dispose which contain the code of the clean up statements. 
* If a Class implements IDisposable, the user of this class must call the Dispose method after the work with the class(object) is completed. 
*/
namespace SampleConApp
{
    class SimpleClass : IDisposable
    {
        private string name;
        public SimpleClass(string name)
        {
            this.name = name;
            Console.WriteLine("Object by name {0} is created", name);
        }

        /*
         * Function that is invoked when the object is destroyed. 
         * It has the same name of the class with a ~.
         * It does not have access specifier and no args to it. 
         * Destructors cannot be called by the programmer. It is implicitly invoked at appropriate time by the GC when the object is being destroyed. 
         */
        ~SimpleClass()
        {
            Console.WriteLine("Object by name {0} is destroyed", name);
        }

        public void Dispose()
        {
            Console.WriteLine("Object by name {0} is destroyed", name);
            GC.SuppressFinalize(this);//Finalize is the acronym for Destructor in C#. SuppressFinalize method is like telling the GC not to call the destructor. 
        }
    }
    class MemoryManagement
    {
        static void createAndDestoryObjects()
        {
            for (int i = 0; i < 100000; i++)
            {
                using (SimpleClass cls = new SimpleClass("Class" + i))
                {
                    Thread.Sleep(100);
                };
                //GC.Collect();//Forces the GC to collect all Unused memory, not specific to 1 or 2...
                //GC.WaitForPendingFinalizers();//Makes the Main thread wait till all the Finalizing objects are released...
                //Thread.Sleep(100);
                //cls.Dispose();
            }
        }

        static void Main(string[] args)
        {
            createAndDestoryObjects();
            Console.WriteLine("Main has ended");
        }
    }
}
/*
 * Programmers cannot call Destructor, U cannot explicitly destroy an object in .NET.
 * U can force the GC to clean the memory using static fn GC.Collect(Not Recommended). 
 * If U want a section of memory releasing code(Unmanaged code: Code that is not managed by the CLR that is usually created thro COM and C++ Win32 API Code) be called, then U could implement IDisposable interface and write the code in the Dispose method of the interface. 
 * This makes the caller of the object to call its Dispose method once the work with that object is done.
 * Users of the class that implement IDisposable must call the Dispose method for unmanaged memory clean up.
 * using block should be used to ensure that the CLR will call the Dispose method automatically once the object goes out of scope of the using block.(SAFE CODING).
 * 
 * .NET allows traditional Win32 API Code and COM Code to be used inside .NET Apps. This is called as Interoperability. In this case, there will be some legacy code developed in Win32 Environment that will be used in .NET. 
 * These APIs will have methods like Release() which must be called once the work with the component is finished. U must implement IDisposable and in the Dispose method, U should call the component's Release method. 
 * COM stands for Component Object Model, a legacy Framework of MS to provide language independency in traditional C++. This was the world before .NET came. COM was the pioneer in language independency in those days(1998 till 2005).
 */