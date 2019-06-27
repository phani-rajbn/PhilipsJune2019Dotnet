using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * try is that block of code that could raise an Exception which is followed by either catch or finally or both. 
 * catch block contains the Exception Type that U want to handle. U can have multiple Catch blocks for a given try. 
 * finally block is one that is executed on all conditions(with or without exception). This could be optional when a catch block is present.  
 * All Exceptions raised by the .NET CLR are represented as objects of the class derived from System.Exception. There are 2 types of Exceptions: SystemException and ApplicationException. ApplicationException is the class to represent custom Exceptions that are relative to the Application U R using. All Custom Exceptions created are derived from System.ApplicationException.
 * It is advised to provide Exception handling code at all levels of UR Application. U must handle each kind of Exception in a different manner. 
 * Exceptions are raised in the program using throw statement. C# does not have throws keyword.
 * 
 */
namespace SampleConApp
{
    using System.Diagnostics;
    static class Logger
    {
        public static void LogErrorMessage(string message)
        {
            EventLog log = new EventLog("SampleApp", Environment.MachineName, "PhilipsApp");
            log.WriteEntry(message, EventLogEntryType.Error);
            log.Close();
        }
        public static void LogInfoMessage(string message)
        {
            EventLog log = new EventLog("SampleApp", Environment.MachineName, "PhilipsApp");
            log.WriteEntry(message, EventLogEntryType.Information);
            log.Close();
        }
    }
    class ExceptionHandling
    {
        static void Main(string[] args)
        {
            
            RETRY:
            try
            {
                Logger.LogInfoMessage("Application has begun");
                Console.WriteLine("Enter a numer");
                int no = int.Parse(Console.ReadLine());
            }
            catch(FormatException format)
            {
                Console.WriteLine("The System generated the following message: {0}" ,format.Message);
                Console.WriteLine("Should enter a valid whole number");
                Logger.LogErrorMessage(format.Message);
                goto RETRY;
            }
            catch (OverflowException)
            {
                string strMessage = string.Format("Value should be within the range of a number\nThe Range should be b/w {0} and {1}", int.MinValue, int.MaxValue);
                Console.WriteLine("strMessage");
                Logger.LogErrorMessage(strMessage);
                goto RETRY;
            }
            catch(Exception genEx)
            {
                Console.WriteLine(genEx.Message);
                Logger.LogErrorMessage(genEx.Message);
            }
        }
    }
}
