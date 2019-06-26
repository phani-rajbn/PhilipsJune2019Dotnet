/*
 * Arrays
 * Enums
 * Classes, Interfaces, Abstract Classes. 
 * Method overriding.
 */
using System;
using System.IO;
namespace CommonLayer
{
    //Entities of Ur Application are classes that represent the data of UR App...
    class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public double EmpSalary { get; set; }
    }

    class Prompt
    {
        public static string GetString(string statement)
        {
            Console.WriteLine(statement);
            return Console.ReadLine();
        }

        public static double GetNumber(string statement)
        {
            return double.Parse(GetString(statement));
        }

        public static int GetInteger(string statement)
        {
            return int.Parse(GetString(statement));
        }
    }
}

namespace DataLayer
{
    using CommonLayer;
    interface IDataLayer
    {
        void AddNewEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(int id);
        Employee[] FindEmployee(string name);
        Employee FindEmployee(int id);
    }
    //Repository pattern is where U develop a class that contain the CRUD operations on the data it will hold
    class ArrayComponent : IDataLayer
    {
        /* Fixed in size, cannot be dynamic and will not resize....
         * Array of reference objects will default create an array of null objects.
         */
        private Employee[] employees = new Employee[10];
        public void AddNewEmployee(Employee emp)
        {
            for(int i =0; i <employees.Length; i++)
            {
                if(employees[i] == null)
                {
                    employees[i] = new Employee();
                    employees[i].EmpID = emp.EmpID;
                    employees[i].EmpName = emp.EmpName;
                    employees[i].EmpAddress = emp.EmpAddress ;
                    employees[i].EmpSalary = emp.EmpSalary;
                    return;
                }
            }
            throw new Exception("No more employees to be added");
        }

        public void DeleteEmployee(int id)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                if((employees[i] != null) && (employees[i].EmpID == id))
                {
                    employees[i] = null;
                    return;
                }
            }
            throw new Exception("Employee not found to delete");
        }

        public Employee[] FindEmployee(string name)
        {
            Employee[] tempList = new Employee[0];
            //create a blank array
            //search thro the master array
            foreach(Employee emp in employees)
            {
                //find the matching record.
                if((emp != null) && (emp.EmpName.Contains(name)))
                {
                    Array copy = tempList.Clone() as Array;//Replicates the array as it is...
                    tempList = new Employee[copy.Length + 1];
                    copy.CopyTo(tempList, 0);
                    tempList[tempList.Length - 1] = emp;
                }
            }
            return tempList;
            
            //Clone the tempList to a temp Array...
            //resize teh tempList incrementing by 1. 
            //Copy all the contents of the tempArray into the tempList. 
            //last one is the new element to be added.....
        }

        public Employee FindEmployee(int id)
        {
            foreach(Employee emp in employees)
            {
                if(emp != null)
                {
                    if (emp.EmpID == id)
                        return emp;
                }
            }
            throw new Exception(string.Format("Employee by the ID {0} not found", id));
        }

        public void UpdateEmployee(Employee emp)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                if ((employees[i] != null) && (employees[i].EmpID == emp.EmpID))
                {
                    //employees[i] = new Employee();
                    //employees[i].EmpID = emp.EmpID;
                    employees[i].EmpName = emp.EmpName;
                    employees[i].EmpAddress = emp.EmpAddress;
                    employees[i].EmpSalary = emp.EmpSalary;
                    return;
                }
            }
            throw new Exception("Employee not found to update");
        }
    }
}

namespace UILayer
{
    using DataLayer;
    using CommonLayer;
    using SampleConApp;

    class UserInterface
    {
        static IDataLayer component = new CSVComponent();
        static string getMenu(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            string menu = reader.ReadToEnd();//reads the whole txt file and returns the data of the file as a string..
            return menu;//this is our menu....
        }
        static void Main(string[] args)
        {
            string menu = getMenu(args[0]);
            bool loop = true;
            do
            {
                string answer = Prompt.GetString(menu);
                loop = processMenu(answer);
                waitForAnswer();
            } while (loop);
        }

        private static void waitForAnswer()
        {
            Console.WriteLine("Press any key to clear the sceen");
            Console.ReadKey();
            Console.Clear();
        }

        private static bool processMenu(string answer)
        {
            switch (answer.ToUpper())//makes it case insensitive...
            {
                case "A":
                    addingRecord();
                    return true;
                case "D":
                    deletingRecord();
                    return true;
                case "U":
                    updatingRecord();
                    return true;
                case "F":
                    findingRecords();
                    return true;
                case "I":
                    return true;
                default:
                    return false;
            }
        }

        private static void findingRecords()
        {
            string name = Prompt.GetString("Enter the name or a part of the Name to search the Employees");
            Employee[] employees = component.FindEmployee(name);
            if(employees.Length == 0)
            {
                Console.WriteLine("No Employee by that name is found");
                return;//exit the function
            }
            foreach(Employee emp in employees)
                Console.WriteLine($"{emp.EmpName}\n{emp.EmpAddress}\n{emp.EmpSalary}\n");
        }

        private static void deletingRecord()
        {
            int id = Prompt.GetInteger("Enter the ID of the Employee to delete");
            component.DeleteEmployee(id);
            Console.WriteLine("Employee deleted successfully");
        }

        private static void updatingRecord()
        {
            Employee emp = createEmployee();
            component.UpdateEmployee(emp);
            Console.WriteLine("Employee updated to the database");
        }

        private static Employee createEmployee()
        {
            //Factory method design pattern....
            //Take all the inputs from the user
            int id = Prompt.GetInteger("Enter the Id of the Employee");
            string name = Prompt.GetString("Enter the Name");
            string address = Prompt.GetString("Enter the Address");
            double salary = Prompt.GetNumber("Enter the Salary");
            //Create the Employee object
            Employee emp = new Employee {
                EmpID = id,
                EmpName = name,
                EmpAddress = address,
                EmpSalary = salary
            };//New Object initialization syntax from C# 4.0....
            return emp;
        }

        private static void addingRecord()
        {
            Employee emp = createEmployee();
            //Pass the object to the AddNewEmployee function of the interface object.
            component.AddNewEmployee(emp);
            Console.WriteLine("Employee is added successfully");
        }
    }
}