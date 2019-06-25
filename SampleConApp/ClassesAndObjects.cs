using System;
//What is a Class? Its a User defined type that has data and functions to manipulate the data. Along with it, comes a host of features of OOP like Encapsulation, Inheritance and polyhmorphism. 
//In .NET all Classes are reference types. Their memory is created in an area called heap that is managed by the CLR's Garbage Collector. The reference of the memory is what is stored in the variable that is created. Hense the name reference types.
//Variables of the class is called as Object. They are instantiated/created using an operator new. However there are indirect ways of creating objects, but new is the most convinient and traditional way of creating objects in .NET.
//Only instantiated objects can be used. 


namespace SampleConApp
{
    //Declaration of a class is more like a blue print of the User defined type which contain info about what it stores, what it does and how to get the data created within it. Declaration has no memory allocation. It is just a prototype of what UR class does when used thro an object.  
    class Employee
    {
        //members of a class are private to the class unless U provide access specifier. internal means that the members of this class can be used anywhere within this project(Assembly). 
        internal int age;
        internal string name;
        internal double salary;
    }
    class ClassesAndObjects
    {
        static void Main(string[] args)
        {
            //This is the only way of creating an object in a direct way. The new operator is the one which actually creates the object in the managed heap and gives a reference of the memory where it is created. Using the reference we will access the members of the class. Uninstantiated objects when accessed will throw a null reference Exception. 
            Employee emp = new Employee();
            
            Console.WriteLine("Enter the name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the Age");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Salary");
            double salary = double.Parse(Console.ReadLine());

            //The members of the class(data and its methods) will be accessed thro an object using .operator. 
            emp.name = name;
            emp.age = age;
            emp.salary = salary;

            Console.WriteLine($"The Name:{emp.name}\nAge:{emp.age}\nSalary{ emp.salary:C}");
            //Create another object and see if it affects the first object U created. Display both the objects in Console.Writeline. 

            //How reference copies are creaeted without creating a new object. 
            Employee copy = emp;//In this case, U have created an alias to the emp, but not a new Employee. There are 2 variables to the same employee object..
            copy.name = "TempName";
            Console.WriteLine($"The Name:{emp.name}\nAge:{emp.age}\nSalary{ emp.salary:C}");
        }
    }
}
/*
 * Points to remember:
 * All classes are derived from System.Object, everything is an object.
 * Data is unique to the object and the data is owned by the object. 
 * If U want to share the data among the objects, U should make it as static and use it across the objects by the classname. However, U could call the static members inside the instance members. 
 * Objects that are created will be eventually destroyed by Garbage Collector in the means of a time tested algorithm. 
 * Classes will have both data and manipulators to that data. Data is called as fields and manipulators are called as Functions/Methods. 
 * Usually data fields will be private and we have either accessors or functions to manipulate them.
 * This feature of Hiding the data is called as Encapsulation.
 * U could create accessors like properties to access those hidden members. 
 */
