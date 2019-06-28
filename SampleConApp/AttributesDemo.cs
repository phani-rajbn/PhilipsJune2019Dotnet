using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/*
 * Attributes: Attributes are optional properties that are injected into the system and is evaluated at runtime. This contains declarative information of some kind of metadata about UR code. This additional logic can be added into the Application only if U provide this attribute.
 * It is different from properties which is added to the object even if U dont set it. Attributes are injected into the code only if U set the attribute to the class or the object. 
 * Serializable, OperationContract, Obselete are some of the attributes provided by .NET for development. 
 * Attributes are placed using [ ] above the unit that U want to set the attribute. Unit means Class, method, object, anything take makes ur Application. 
 * 2 Types of attributes: predefined Attributes and Custom Attributes. 
 * Custom Attributes are classes U create that is derived from System.Attribute Class. All Attribute classes have a suffix called Attribute. 
 * Values that are set to the attributes are evaluated in code only thro Reflection as attributes add the logic to the metadata of the Code, so it has to be accessed only thro Reflection. 
 * 
 * if a class has to be used on all .NET languages, then its should be made as CLS Compliant Class. A Class which abides to the rules and regulations of the CLS(Common Language Specification) is said to be CLS Compliant. It means that class can be used in any .NET Language so that no naming conflicts, syntax differences can occur that could stop the class from using it. 
 * obselete is an attribute provided by .NET that can be used on those classes that U dont want new Developers to use it but wish to retain the Class in the project to support backward compatibility.  
 */
namespace SampleConApp
{
    [Obsolete("This class is no longer recommende, please use the newer PhilipsEmployee class")]
    public class Employee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
    }
    
    
    public class PhilipsEmployee
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmpAddress1 { get; set; }
        public string EmpAddress2 { get; set; }
        public string EmpCity { get; set; }
    }
    
    public static class AttributeReader
    {

        public static string GetAttributeValue(Type classDetails)
        {
            var details = classDetails.GetCustomAttribute(typeof(InformationAttribute));
            if (details != null)
            {
                var info = details as InformationAttribute;
                return info.InformationString;
            }
            return string.Empty;
        }
        public static string GetAttributeValue(MethodInfo method)
        {
            var allAttributes = method.GetCustomAttributes();
            foreach(var item in allAttributes)
            {
                if(item is InformationAttribute)
                {
                    var info = item as InformationAttribute;
                    return info.InformationString;
                }
            }
            return "No Attribute is set";
            //throw new Exception("Invalid attribute");
        }
    }
    [Information("This class is used for storing Philips' Employee")]
    public class EmpDatabase
    {
        [Information("Philips")]
        public void AddEmployee(PhilipsEmployee emp)
        {
            Console.WriteLine("Code is injected to add the Employee");
        }
    }
    class AttributesDemo
    {

        static void Main(string[] args)
        {

            //Employee emp = new Employee { EmpName = "OPhaniraj", EmpAddress = "Bangalore", EmpNo = 123 };
            //Console.WriteLine("The Name is " + emp.EmpName);

            //////////////////Use a Custom Attribute/////////////////////////////
            EmpDatabase db = new EmpDatabase();
            var info = AttributeReader.GetAttributeValue(typeof(EmpDatabase));
            Console.WriteLine(info);
            var method = db.GetType().GetMethod("AddEmployee");
            string value = AttributeReader.GetAttributeValue(method);
            Console.WriteLine(value);
            if(value == "Philips")
                Console.WriteLine("Database selected is Philips to add the Employee to the Philips DB");
            else
                Console.WriteLine("Database selected is  Common to add the Employee to a Common database");
            db.AddEmployee(new PhilipsEmployee());
        }
    }
    /*
     * Custom Attributes are optional logic that U want to add to ur classes, methods, or any units of UR Application by creating a class derived from System.Attribute. 
     * AttributeUsage attribute is a predefined attribute that can be set on Custom Attributes to tell where this attribute be used. All means that U can use this attribute on all units of UR App: Class, Event, Property, Method, Struct, Enum, Interface, Delegate, Assembly, Namespace 
     */

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    sealed class InformationAttribute : Attribute//sealed means Non Inheritable Class.....
    {
        readonly string positionalString;
        // This is a positional argument
        public InformationAttribute(string positionalString)
        {
            this.positionalString = positionalString;
        }

        public string InformationString
        {
            get { return positionalString; }
        }
    }
}
