using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
//This App will consume the Web APIs using System.Net.WebClient Class.  
namespace WebApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new WebClient();
            var data = client.DownloadString("http://localhost:55304/api/Student");
            Console.WriteLine(data);
            //DownloadString API will download the data as JSON object(basically a String) which can be used to read the data....

        }
    }
}
