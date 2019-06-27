using System;
using System.Threading;
namespace SampleConApp
{
    /*
     * If U want perform Async operations with more control over its flow and its operations, then U could create a Thread and use it. All Threads are objects of a Class called System.Threading.Thread.
     * Thread object takes Delegate as arg called ThreadStart. It is a  void delegate with no args. 
     * ThreadStart Delegate contains the reference of the method that has to be invoked when the thread starts. The thread begins its execution by a method called Start. 
     * The Thead has other methods like Suspend, Resume to control how the thread executes. 
     * But it is recommended to use Synchronization techniques instead of using Suspend and Resume methods
     * Dont assume that multi threading is performance oriented. Use threading only for tasks where U want to control the work that is done by multiple users who interact with the function simultaneously and U wish to maintain data consistancy. These things cannot be done with BeginInvoke kind of Async Functions. 
     * Threads are by default created as Foreground Threads. The Calling thread will wait till the worker thread complete its operation. 
     */
    class MultiThreading
    {
        static int sharedData = 1;
        public void ThreadFunc(object arg)
        {
            //lock is the keyword in C# for a .NET Synchronization object called Monitor. Monitor is the .NET 's Implementation of CRITICAL_SECTION of the Windows OS...
            lock (this)
            {
                Console.WriteLine("{0} has started", arg);
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Thread Beep#{0} for {1}", i, arg);
                    Thread.Sleep(1000);
                    sharedData += i;
                }
                Console.WriteLine("{0} has Ended", arg);
                Console.WriteLine("The Current value for the shared data is " + sharedData);
            }
        }
        static void Main()
        {
            MultiThreading ex = new MultiThreading();
            Thread the = new Thread(ex.ThreadFunc);
            Thread the2 = new Thread(ex.ThreadFunc);
            Thread th3 = new Thread(new MultiThreading().ThreadFunc);
            //the.IsBackground = true;//Making the background thread is similar to Deamon Threads in Java. 
            the.Start("Thread 1");//This  will the thread while the Main continues its operation. Main is also running on a thread which is the Main thread or the UI Thread of the Application. If the Main Thread completes, the Application terminates. 
            the2.Start("Thread 2");
            th3.Start("Thread 3");
            Console.WriteLine("Main has ended");
        }
    }
}
/*
 * A Process is an instance of an Application program that is executing. 
 * Each process has its own address space where UR Code, UR Classes, Objects and members are created and executed. 
 * Every Process will have a path of Execution which progresses the flow of the App. This is called a Thread. 
 * Thread is a path of execution within a process. 
 * OS supports multiple paths of Execution to be made available within a process. 
 * Main Thread or the UI Thread is the one that makes UR App execute and finally when it completes its tasks, the thread gets terminated and the process gets killed.
 * Most of the Apps should be OK with one Thread(Main Thread) but for some complex operations where U dont want to block the User interface, U could split the Thread functionality into another to make it run as an other task. Eventually U will have 2 paths of execution. 
 * Threads that are created to perform some work are called as Worker Threads. They are associated with some task represented by a function, once the thread starts, the function will execute and finally when the function is completed, the thread gets killed. 
 * Meanwhile U could make the Calling thread(Main Thread) do some other operations while the worker thread is completing the task given to it.
 * Programmatically, A process is represented by a class called Process and the Thread is represented by a class called Thread. Process is available under the namespace System.Diagnostics and Thread is available under System.Threading. 
 */
