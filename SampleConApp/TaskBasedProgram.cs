using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleConApp
{
    class TaskBasedProgram
    {
        //C# 5.0's version of Async Programming without using Begin....End...
        static void Main(string[] args)
        { 
            Task<double> someJob = AddFuncAsync(123, 234);
            //someJob.Wait();//This will make the program wait till we get the result...
            Console.WriteLine("The Result:" + someJob.Result);
           
        }
        //async says that this function is invoked asynchronously..
        static async Task<double> AddFuncAsync(double v1, double v2)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1500);
            }
            return await Task.Run(()=>  v1 + v2);
        }
    }

}
