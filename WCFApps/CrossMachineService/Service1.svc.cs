using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CrossMachineService
{
   
    public class HelloService : IHelloService
    {
        //In Real Time, this could be a function that returns data from its source....
        public string WelcomeMessage()
        {
            return "Hello user";
        }
    }
}
