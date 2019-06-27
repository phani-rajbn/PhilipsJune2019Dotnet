using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleLibrary;//use the namespace

/*
 * 1. Add the reference of the DLL:If the DLL is a part of the same soln, U could add project reference else U could browse to the location of the DLL and add the reference. 
 * 2. Use the namespace associated with the dll.
 * 3. Create the object and call its methods....
 * 
 * Using Reflection, a framework for identifying the type info at runtime U could load the dll into the process thro code and access its classes, members of the classes and invoke the methods. This is also called as LATE BINDING feature. Here there will no reference made to the dll, rather it would be loaded from the location of the DLL thro code. 
 * Reflection namespace helps in identifying the Class information at runtime and get its details thro metadata of the Dll. 
 */
namespace SampleConApp
{
    class ConsumingDll
    {
        static void Main(string[] args)
        {
            MathClass cls = new MathClass();
            var res = cls.AddFunc(123, 234);
            Console.WriteLine(res);
        }
    }
}
