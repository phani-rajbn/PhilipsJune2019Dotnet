using System;
using RemoteLib;//Our Component that will created remotely...
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;//Our example uses Tcp Channel. 
//U add the reference of the System.Runtime.Remoting Dll to get the namespaces and the classes required for .NET Remoting Application. 

//Add the reference of the RemoteLib that was created earlier. The instances of the messenger will be created in this server application. 
namespace RemoteServer
{
    //.NET Remoting allows the Services accessible thro 2 protocols: TCP and HTTP. TCP Channel is used for Intranet kind of Apps and HTTP is used for Internet kind of Applications. 
   //Every Service based Application needs the following things:
   //An Address thro which Clients can access UR service. 
   //A Protocol which contains info on how the service is available. 
   //A PortNo thro which the service is accessible. 
    class ServiceMain
    {
        static void Main(string[] args)
        {
            //U should create the TcpServer object.
            TcpServerChannel server = new TcpServerChannel(1234);
            //Register the Tcp Channel to the Windows SErvices.
            ChannelServices.RegisterChannel(server, `);
            //Register the service into the Windows OS...
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Messenger), "MsgServices", WellKnownObjectMode.Singleton);//only one instance of the Object will be made available for the clients.....
            //Expose the service to client(Run the Application)
            Console.WriteLine("server is ready at http://localhost:1234/MsgServices");
            Console.WriteLine("Press any key to Terminate the service");
            Console.ReadKey();
        }
    }
}
