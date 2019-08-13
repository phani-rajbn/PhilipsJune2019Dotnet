using System;
using RemoteLib;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace RemoteClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelServices.RegisterChannel(new TcpClientChannel(), false);
            Messenger proxy = Activator.GetObject(typeof(Messenger), "tcp://localhost:1234/MsgServices") as Messenger;//Unbox...
            if (proxy == null)
            {
                Console.WriteLine("Failed to create the service");
                return;
            }
            Console.WriteLine("Please enter the username");
            string user = Console.ReadLine();
            do
            {
                Console.WriteLine("Post UR message here...");
                string msg = Console.ReadLine();
                proxy.PostMessage(user, msg);
            } while (true);
        }
    }
}
//Remoting Limitations:
//Both the client and the server should be .NET Applications in Remoting. Other Protocols like SOAP are not possible in REMOTING. The data will be a .NET Type but not JSON or XML. 
//If a service created in .NET has to be consumed by a Java Program, it cannot be done using .NET Remoting technology.
//Use XML Web services for making the service cross platform.



