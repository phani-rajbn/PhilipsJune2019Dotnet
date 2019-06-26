using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    //delegate void OnAction(string msg);
    class CSVEXample
    {

        public Action<string> OnAdded = null;
        public void AddEmployee(int id, string name)
        {
            if (id < 5)
            {
                OnAdded("Insertion has failed");
            }
            else
            {
                Console.WriteLine("The ID {0} with Name{1} is added to the CSV file", id, name);
                //Should add the employee to the CSV file...
                //Invoke a function if the insertion is successfull...
                if (OnAdded != null)
                    OnAdded("Insertion has been successfull");
            }
        }
    }

    class ClientMainProgram
    {
        static void Main(string[] args)
        {
            CSVEXample ex = new CSVEXample();
            ex.OnAdded = new Action<string>(Acknowledgement);//Call this function i
            ex.AddEmployee(2, "Phaniraj");
        }

        static void Acknowledgement(string msg)
        {
            Console.WriteLine(msg);
        } 
    }
}
