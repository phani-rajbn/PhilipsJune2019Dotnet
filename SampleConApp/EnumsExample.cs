using System;

//Enum is a named const to represent integral value by a name. Enums are helpful in setting a value within the limits of the data that the App wishes to set. They are also helpful in providing a clean switch statements. 
namespace SampleConApp
{
    enum AccountType {  SBA , RDA , FDA }
    class EnumsExample
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The selected account type is " + (int)AccountType.SBA);
            Console.WriteLine("Enter the choice of the Account from the list");
            Array values = Enum.GetValues(typeof(AccountType));//Get all the possible values of the enum
            foreach (object value in values) Console.WriteLine(value);
            //Display all the values allowing the user to select one from the list.
            AccountType selected = (AccountType)Enum.Parse(typeof(AccountType), Console.ReadLine());//Example of UNBOXING....
            //Parse method returns an object which will be UNBOXED to the AccountType. 
            //Convert the string to the type of Enum using Enum.Parse. 
            Console.WriteLine("The selected Type: " + selected);
        }
    }
}


