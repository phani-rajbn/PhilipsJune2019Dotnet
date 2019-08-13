using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
/*
 * Windows Service is a kind of App that is started at the bootup  of the Windows OS.
* It is provided with an Installer thro which a Windows Component called SCM(Service Control Manager) creates, registers and consumes our WCF services.  
* Every Service App will have a Main Function that registers the Service to the Windows OS. The Program.cs contain the code that is required to register the service and run it. 
* When the service runs, events like OnStart gets executed and when it stops, events like OnStop will be executed. Other than these, U could have events like Run to ensure what needs to be done while the service is executing. 
* Windows services are designed to work on Windows OS only. However, U can still host the service as Windows service and thro REST U can configure to use the services in other platforms. 
* Steps: Create the WCF Component along with its interfaces. 
* Override the OnStart method to create the WCF service.
* OnStop will contain the code to stop the WCF service.
 */
namespace WcfWinService
{
    public partial class hr : ServiceBase
    {
        private ServiceHost host = null;
        public hr()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:2222/MathServices");
            host = new ServiceHost(typeof(MathComponent), baseAddress);
            var contract = typeof(IMathService);
            host.AddServiceEndpoint(contract, new WSHttpBinding(), "");
//            host.AddServiceEndpoint(typeof(IMetadataExchange), new Mex, "mex");
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);
            host.Open();
        }

        protected override void OnStop()
        {
            host.Close();
        }
    }
}
