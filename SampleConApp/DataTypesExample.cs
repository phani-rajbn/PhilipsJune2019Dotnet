//Code File in C# will create a blank C# file which U can use to add any kind of code. When U select a class file, a std boiler plate code for a class would be auto generated. 
/*
 * Data Types in C# are designed by the .NET Framework to achieve language interoperability. 
 * The data types are common among all the .NET Languages. .NET uses CTS(Common Type System) data types which have keywords in the respective languages. C# independently does not have any data types of its own, rather it uses the data types defined by the Common Type System. This is applicable to all the .NET Enabled Languages. 
 * C# has a keyword called string which infers to the CTS type called String.
 * C# has a keyword called int which infers to a CTS type called Int32. 
 * .NET has 2 broad classifications of their data types: Value Types and Reference types.
 * Value types are structs and Reference types are classes. 
 * Among value types:
 * Integral Types: byte(Byte), short(Int16), int(Int32), long(Int64)
 * Floating Types: float(Single), double(Double), decimal(128 Bit decimalvalue)
 * Other types: char(Char), bool(Boolean).
 * UDTs: struct, enum, DateTime. 
 * .NET Framework has many structs created for developing Apps like TimeSpan which are also structs but are not considered as std data types of .NET. 
 * Reference types are classes and their objects. String, Array, Delegates, Classes are the examples of Reference types.
 * All the types in .NET are derived from one common type called object which is defined under the namespace System. 
 * System is the common namespace for all the data type and its definitions along with its Conversion classes. 
 * Data Conversion rules:
 * Longer Range types must be explicitly converted to shorter range types thro Type casting. 
 * U could also use the Static Convert class to convert from any type to another. 
 * Smaller range types will be implicitly converted to the Larger Range types. 
 * As long as there is no loss of data, conversions are possible implicitly in C#.
 * Casting is not safe all the time. Instead its recommended to use the Convert Class for data type conversion.  
 * Every type in C# has an equivalent CTS Type which could be either a class or a struct. All value types are structs. 
 * .NET provides CTS types with consts, methods to perform common conversion and equality operations.
 * MinValue and MaxValue are consts defined by the Value type to get the Max and Min value allowed for that type. 
 * To ensure typesafe conversions, its recommended to create a checked block within UR Code so that any Arthematic overflows are checked and thrown as an Exception instead of returning abnormal values. checked is a keyword in C# that is used to check for arithematic overflows that arise when U typecast it.  
 * However, if U want to enforce automatic checking of the Arithematic Overflow U could do so by setting a project property in the Properties Window, Build tab and click for Advanced Button which opens a Dialog box to check for Arithematic OverFlows.
 * object is the base type for all the data types of .NET, even for the one U create. Everything is object in .NET. It means that every data type will be implicitly convertible to object. object is a reference type, converting UR variable to an object is called as BOXING. The reconversion back to its type is called UNBOXING. object is more like void* of C++.
 */

using System;//U intend to use the classes defined in this namespace
namespace SampleConApp
{
    class DataTypes
    {
        static void DateExample()
        {
            Console.WriteLine("Enter the Salary");
            int salary = int.Parse(Console.ReadLine());//Convert a string to an integer. 

            Console.WriteLine("Enter the date of birth");
            DateTime dt = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("The Salary is " + salary);//Old style...

            TimeSpan totalDiff = DateTime.Now - dt;
            double yrs = totalDiff.Days / 365.25;
            Console.WriteLine("Current Age: " + (int)yrs);
            //double is explicitly converted to int so that decimal values are removed while I print the age. 
        }
        static void DisplayRangeOfInteger()
        {
            Console.WriteLine("The Min Value for int is :" + int.MinValue);
            Console.WriteLine("The Max Value for int is :" + int.MaxValue);
        }
        static void Main(string[] args)
        {
            //Functions that are created within the same class can be called in the Main function without object or classname...
            //            DateExample();
            //            DisplayRangeOfInteger();
            //simpleDataConversion();  
            //castingIssueExample();
            //usingCheckedExample();

        }

        private static void usingCheckedExample()
        {
            long no = 123;
            //checked
            //{
                int maxVal = int.MaxValue;
                int value = (int)no + maxVal;//Compile Error when U try to put a larger range value into the int, so type cast it...
                Console.WriteLine("The value: "+ value);
            //}
            //NOTE: U also have unchecked block if U want to override the typesafety

        }

        private static void castingIssueExample()
        {
            try
            {
                long value = 234453455566 + 2345;
                //int shortValue = (int)value;//casting is not safe. U might get unexpected results if the value is not within the range of the variable that U R storing it. 
                int shortValue = Convert.ToInt32(value);
                Console.WriteLine("The Short value is " + shortValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void simpleDataConversion()
        {
            int no = 123;
            long longno = no;//Smaller range values can implicitly convert to larger range...
            no = (int)++longno;//Larger Range value cannot be stored in the shorter range variables. Here we should cast it using Casting operation.  
            Console.WriteLine("The Long value:{0}\nThe Short value:{1}", longno, no);
        }
    }
}