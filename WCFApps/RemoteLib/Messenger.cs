using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//The class must be derived from MarshalByRefObject which makes this class and its objects accessible remotely.....
namespace RemoteLib
{
    public class Messenger : MarshalByRefObject
    {
        //public Messenger()
        //{
        //    Console.WriteLine("Messenger service has started");
        //}

        public void PostMessage(string User, string message)
        {
            Console.WriteLine($"{User}:{message}");
        }
    }
}
