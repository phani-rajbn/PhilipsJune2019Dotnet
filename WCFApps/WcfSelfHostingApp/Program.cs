using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

//The important libraries of WCF are: System.ServiceModel and System.Runtime.Serialization. U must reference these libraries before U develop any WCF Components inside a .NET App.
//self hosting apps are created for developing WCF components that are to be consumed by other .NET Apps within the Intranet Network. In other words, U will develop the Code for hosting a WCF component inside UR .NET App like the way we used to do in .NET Remoting kind of Apps. 
//Add the references of the above libraries into UR project as this is a console App 
namespace WcfSelfHostingApp
{
   //Like any other WCF components, U need to develop the service contracts and its implementation in the form a WCF components. 
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        List<Customer> GetAllCustomers();
    }
    [DataContract]//This performs the serialization for UR data components....
    public class Customer
    {
        [DataMember] public int CustomerID { get; set; }
        [DataMember] public string CustomerName { get; set; }
        [DataMember] public string CustomerAddress { get; set; }
        [DataMember] public long CustomerPhone { get; set; }
    }
    [ServiceContract]
    public interface ICustomerAddingService
    {
        [OperationContract]
        void AddNewCustomer(Customer cst);
    }

    public class WCFComponent : ICustomerService, ICustomerAddingService
    {
        public void AddNewCustomer(Customer cst)
        {
            var list = GetAllCustomers();
            list.Add(cst);
            var content = JsonConvert.SerializeObject(list);
            using(StreamWriter writer = new StreamWriter("Customers.json"))
            {
                writer.WriteLine(content);
            }
        }

        public List<Customer> GetAllCustomers()
        {
            var reader = new StreamReader("Customers.json");
            string content = reader.ReadToEnd();
            reader.Close();
                var data = JsonConvert.DeserializeObject(content, typeof(List<Customer>));
                if (data is List<Customer>)
                    return data as List<Customer>;
                else
                    throw new FaultException("Failed to load the Json file");
        }
    }
    class Program
    {

        //This function will read the JSON file and convert the data to a List<Customer>
        static List<Customer> getRecords()
        {
            var reader = new StreamReader("Customers.json");
            string content = reader.ReadToEnd();
            var data = JsonConvert.DeserializeObject(content, typeof(List<Customer>));
            if (data is List<Customer>)
                return data as List<Customer>;
            else
                return null;
        }
        static void Main(string[] args)
        {
            //writeToJson();
            //readRecords();
            //Code to Host the service....
            string url = "http://localhost:1234/MySelfHostServices/";
            try
            {
                ServiceHost hostApp = new ServiceHost(typeof(WCFComponent), new Uri(url));
                WSHttpBinding binding = new WSHttpBinding();
                Type contract = typeof(ICustomerService);
                hostApp.AddServiceEndpoint(contract, binding, "");  
                hostApp.Open();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                hostApp.Close();
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception genEx)
            {
                Console.WriteLine(genEx.Message);
            }
        }

        private static void writeToJson()
        {
            Customer cst = new Customer
            {
                CustomerID = 123,
                CustomerName = "Phaniraj",
                CustomerAddress = "Bangalore",
                CustomerPhone = 9879879876
            };

            Customer[] customers = new Customer[]
            {
                    new Customer
                    {
                        CustomerID = 123,
                        CustomerName = "Gopal",
                        CustomerAddress = "Bangalore",
                        CustomerPhone = 9879879876
                    },
                    new Customer
                    {
                        CustomerID = 124,
                        CustomerName = "Mahesh",
                        CustomerAddress = "Tumkur",
                        CustomerPhone = 9879879876
                    },
                    new Customer
                    {
                        CustomerID = 125,
                        CustomerName = "Venkatesh",
                        CustomerAddress = "Hassan",
                        CustomerPhone = 9879879876
                    }
        };

            string data = JsonConvert.SerializeObject(customers);
            Console.WriteLine(data);
            //In JSON, an array is simply a subscript operator[].Inside lies the data of the Array, if its an object, it will be provided with { } seperated by ,  

            //Use StreamWriter to save this file as Json...
            using (StreamWriter writer = new StreamWriter("data.json"))
            {
                writer.WriteLine(data);
            }
        }

        private static void readRecords()
        {
            var data = getRecords();
            foreach (var c in data) Console.WriteLine(c.CustomerName);
        }
    }
}
