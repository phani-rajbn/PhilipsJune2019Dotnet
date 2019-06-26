using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    interface ISimple
    {
        void Create();
    }

    interface IExample
    {
        void Create();
    }

    class SimpleExample : ISimple, IExample
    {
        public void Create()
        {
            Console.WriteLine("Object is created as SimpleExample");
        }
        //Explicit Interface implementation..
        void ISimple.Create()
        {
            Console.WriteLine("Object is created as Simple");
        }

        void IExample.Create()
        {
            Console.WriteLine("Object is created as Example");
        }
    }
    class ExplicitImplementation
    {
        static void Main(string[] args)
        {
            IExample ex = new SimpleExample();
            ex.Create();

            ISimple sim = new SimpleExample();
            sim.Create();

            SimpleExample simEx = new SimpleExample();
            simEx.Create();
        }
    }
}
