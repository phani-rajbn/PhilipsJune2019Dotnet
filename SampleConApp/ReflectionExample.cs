using System;
using System.Reflection;

namespace SampleConApp
{
    class ReflectionExample
    {
        const string DLL_PATH = @"B:\Programs\Philips-June-2019\DotnetApps\SampleLibrary\bin\Debug\SampleLibrary.dll";
        static Assembly dllFile;
        static Type ClassName;
        static MethodInfo methodName;
        static object[] parameters;
        static object instance; 

        static void Main(string[] args)
        {
            invakeaSmallmethod();
        }

        private static void invakeaSmallmethod()
        {
            loadDllIntoProcess();
            listAllClasses();
            listAllMethods();
            setValuestoParameters();
        }

        private static void setValuestoParameters()
        {
            if(methodName == null)
            {
                Console.WriteLine("Method is not set");
                return;
            }
            var pmList = methodName.GetParameters();
            parameters = new object[pmList.Length];
            for (int i = 0; i < pmList.Length; i++)
            {
                Console.WriteLine("Enter the value for the parameter {0}, Type: {1}", pmList[i].Name, pmList[i].ParameterType.Name);
                parameters[i] = Convert.ChangeType(Console.ReadLine(), pmList[i].ParameterType);
            }
            Console.WriteLine("All the parameters are set\nlets create an objet and invoke the method");
            instance = Activator.CreateInstance(ClassName);
            if(instance == null)
            {
                Console.WriteLine("Failed to create an Instance");
                return;
            }
            var result = methodName.Invoke(instance, parameters);
            Console.WriteLine("The Result of this function is " + result);
        }

        private static void listAllMethods()
        {
            if(ClassName == null)
            {
                Console.WriteLine("Class details are not found yet");
                return;
            }

            MethodInfo[] allMethods =  ClassName.GetMethods();
            foreach (var method in allMethods)
            {
                Console.WriteLine(method.Name);
                Console.WriteLine("Its return type: " + method.ReturnType.Name);
                foreach(var parameter in method.GetParameters())
                {
                    Console.WriteLine("{0}:{1}, position:{2}", parameter.Name, parameter.ParameterType.Name, parameter.Position);
                }
                Console.WriteLine("-----------End of the Method--------------");
            }
            Console.WriteLine("Enter the method name from the list above");
            methodName =  ClassName.GetMethod(Console.ReadLine());
            if(methodName == null)
            {
                Console.WriteLine("Wrong method selected");
                return;
            }
        }

        private static void listAllClasses()
        {
            if(dllFile == null)
            {
                Console.WriteLine("DLL is not loaded into the process");
                return;
            }

            var types = dllFile.GetTypes();
            foreach (var type in types)
            {
                Console.WriteLine(type.FullName);
                ClassName = type;
            }
        }

        private static void loadDllIntoProcess()
        {
            dllFile = Assembly.LoadFile(DLL_PATH);
            if (dllFile == null)
            {
                Console.WriteLine("No DLL Found at the location, closing....");
                return;
            }
        }
    }
}
