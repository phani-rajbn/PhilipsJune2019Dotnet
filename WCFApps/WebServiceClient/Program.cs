using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WebServiceClient.myWebServices;//use the namespace...
namespace WebServiceClient
{
    //Set this Project as StartUp Project before U execute the Application...
    class Program
    {
        static void Main(string[] args)
        {
            //Create the instance of the service object
            EmpDataService empData = new EmpDataService();
            var data = empData.GetAllRecords();//Call the method
            var table = data.Tables[0];
            foreach(DataRow row in table.Rows)
                Console.WriteLine(row["EmpName"]);
        }
    }
    //Advantages of  Web Services:
    /*
     * Accessible across multiple platforms. 
     * A .NET Web service can be consumed by a Java App and a JSP Web service can be consumed by .NET App. 
     * True Platform independent technology as data is transfered internally as XML.
     */
    /*
     * Disadvantages of Web services:
     * Only SOAP and HTTP, not usable for TCP 
     * Only XML, or any data representable as XML can be used in Web services. 
     * Later improvisations in Web technology could not be upgraded in Web services. 
     * Multi Service Oriented Technologies like Web Services and .NET Remoting needed a common Framework for all kinds of Service based Applications leading to a new Framework called Windows Communication Foundation...
     */
}
