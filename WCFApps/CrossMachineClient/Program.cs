using CrossMachineClient.myCrossServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CrossMachineClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var proxy = new HelloServiceClient();
            string message = proxy.WelcomeMessage();
            Console.WriteLine(message);
        }
    }
}
