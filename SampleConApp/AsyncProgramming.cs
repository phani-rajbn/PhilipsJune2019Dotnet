using System;
using System.Threading;
using System.ComponentModel;
using System.Runtime.Remoting.Messaging;
/*
* When U want 2 or more operations to execute parallely or not wait for one operation to be completed, U can go for Async Programming. Delegates help in invoking a method asynchronously.
* However if U want to have a complete control in the flow of the  multiple such async operations, U could create threads and work on mutli threading Applications.
* For smaller tasks, U could use Async and Await keywords to make a method be invoked asynchronously.
* With async programming, U could divide UR logic into multiple async tasks where U could perform some long running operations like Reading a large binary file, doing an API call, or downloading a resource from an external server without having to block the execution of UR Application on the User interface or Service.
* All Delegates are derived from a class called System.Delegate which has methods called BeginInvoke and EndInvoke, where BeginInvoke is to invoke the method asynchronously and Endinvoke is to get the result after the operation is completed. 
*/
namespace SampleConApp
{
    class AsyncProgramming
    {
        static void SomeBigTask()
        {
            Console.WriteLine("Doing some big Task");
            //Thread.Sleep(5000);//Makes the thread suspend for a period mentioned as arg...
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("The Task is doing some big job");
            }
            Console.WriteLine("Completing the Task");
        }
        static void Main()
        {
            //voidAsyncExample();
            mathAsyncExample();
        }

        private static void mathAsyncExample()
        {
            Func<double> func = () =>
            {
                double res = 1;
                for (int i = 1; i <= 10; i++)
                {
                    Thread.Sleep(1000);
                    res += res * i;
                    Console.WriteLine("Result is getting created...");
                }
                return res;
            };
            var waiter = func.BeginInvoke((waiterCopy)=>
            {
                Console.WriteLine("The result has come now....");
                AsyncResult waitingObj = waiterCopy as AsyncResult;
                var myDelegateobj = waitingObj.AsyncDelegate as Func<double>;
                var returnValue = myDelegateobj.EndInvoke(waiterCopy);
                Console.WriteLine("The Result of the complex task is " + returnValue);
            }, null);
            //BeginInvoke fn returns an object of the IAsyncResult which monitors the async method about its exccution and its  time of termination along with other resources of the method. 
            Console.WriteLine("Main wishes to continue...");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("main is doing some other job");
            }
            Console.WriteLine("Main has completed its job, waiting for its Child Task to complete");
            while (!waiter.IsCompleted)
            {
                //Console.WriteLine("Waiting....!!!!");
                Thread.Sleep(1000);
            }
            //double result = func.EndInvoke(waiter);
            //Console.WriteLine("The Result of the complex task is " + result);
            Console.WriteLine("Finally Main has compeleted all its operations");
        }

        private static void voidAsyncExample()
        {
            Console.WriteLine("Main program is executing...");
            //SomeBigTask();
            Action task = SomeBigTask;
            var res = task.BeginInvoke(null, null);
            //The job of the BeginInvoke is to invoke the method associated with the delegate instance asynchronously.
            Console.WriteLine("Main wishes to continue...");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("main is doing some other job");
            }
            task.EndInvoke(res);//Makes the calling Function to wait till the async method associated with the delegate object has completed. If the function has any result(Return value) it would be obtained thro EndInvoke Method
            Console.WriteLine("Main is terminating");
        }
    }
}
