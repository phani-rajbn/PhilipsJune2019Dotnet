using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceClient.myWebServices;//use the namespace...
namespace WebServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the instance of the service object
            EmpDataService empData = new EmpDataService();
            var data = empData.GetAllEmployees();//Call the method
            foreach (var name in data) Console.WriteLine(name.ToUpper());
            //Iterate thro the collection...
        }
    }
}
