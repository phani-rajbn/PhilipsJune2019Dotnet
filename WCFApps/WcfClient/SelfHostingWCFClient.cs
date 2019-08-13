using System;
using System.ServiceModel;
using WcfClient.myHostingServices;

namespace SelfHostingClient
{
    class ClientProgram
    {
        static void Main(string[] args)
        {
            //readRecords();
            addRecord();
            //read Data from other machine using Http.....
            //http://IPAddress:1234/MySelfHostServices/mex use this Address to access the clients....
        }

        private static void addRecord()
        {
            //net.tcp://localhost:4321/myTcpServices/mexTcp/
            var tcpProxy = new WcfClient.myTcpServices.CustomerAddingServiceClient();
            tcpProxy.AddNewCustomer(new WcfClient.myTcpServices.Customer
            {
                CustomerID = 201, CustomerAddress ="Bangalore", CustomerName="Phaniraj", CustomerPhone = 2342423455
            });
        }

        private static void readRecords()
        {
            var proxy = new CustomerServiceClient();
            var data = proxy.GetAllCustomers();
            foreach (var cst in data) Console.WriteLine($"{cst.CustomerName} is from {cst.CustomerAddress}");
        }
    }
}