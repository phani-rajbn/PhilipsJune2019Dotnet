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
    using System.Runtime.Serialization;

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
            //basicExceptionHandling();
            try
            {
                throw ExceptionHolder.CreateInsertionException();
            }
            catch(InsertionFailedException ex)
            {
                Console.WriteLine(ex.Message);
                if(!String.IsNullOrEmpty(ex.Reason))
                    Console.WriteLine(ex.Reason);
            }
            finally
            {
                Console.WriteLine("Cleaning the App");
            }
        }

        private static void basicExceptionHandling()
        {

        RETRY:
            try
            {
                Logger.LogInfoMessage("Application has begun");
                Console.WriteLine("Enter a numer");
                int no = int.Parse(Console.ReadLine());
            }
            catch (FormatException format)
            {
                Console.WriteLine("The System generated the following message: {0}", format.Message);
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
            catch (Exception genEx)
            {
                Console.WriteLine(genEx.Message);
                Logger.LogErrorMessage(genEx.Message);
            }
        }
    }

    /*Custom Exceptions: 
     * Custom Exceptions are created by deriving it from System.ApplicationException. 
     * It will be created by overloading the constructors and calling its respective base class versions.
     * U can throw the exeception using throw keyword. 
     */

    class InsertionFailedException : ApplicationException
    {
        //base keyword in C# is used to refer the immediate base class and this is used to refer the object of the class. 
        public InsertionFailedException()
        {

        }

        public InsertionFailedException(string message) : base(message)
        {
        }

        public InsertionFailedException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public string Reason
        {
            get
            {
                return "The UserID might be already present in our database or the data entered is mismatching with the database";
            }
        }
    }

    static class ExceptionHolder
    {
        public static InsertionFailedException CreateInsertionException()
        {
            return new InsertionFailedException("Failed to insert the record");
        }
    }
}

/*
 * Points to remember:
 * Use try/catch only on that code that could potentially raise an exception. As a programmer, U should anticipate the Exception and provide handling to that instead of blindly covering the code with a common try...catch. 
 * Handle the common conditions without throwing Exceptions. Throwing Exceptions frequently will reduce the performance of the App even if U handle it efficiently.  
 * design the classes in such a way that exceptions can be utmost avoided.
 * Dont try to use or set null in UR code as much as possible as Null would be the frequent Exception raiser for any program.
 * Exception class should be last catch for a given try...catch block. Exception class is the super base class for all the Exceptions, then if the first catch is for the Exception class, the other Catch blocks are unreachable, The compiler will throw an Error. 
 * It is good to raise System Exceptions for common errors instead of throwing CustomExceptions. 
 * Don't put any jump statements inside Finally block. goto, return, break, throw are not allowed in finally block as this block is more like a clean up which is executed after the return statement.
 * Provide atleast 3 Constructors for UR custom Exception and ensure that each constructor calls its base version using base. U could however provide additional properties to provide additional info to the caller who handles the Exception. 
 * If a certain exception is raised frequently across the Application, U could create a Exception Builder class or method to avoid code repeating. 
 * Provide a restoring state within UR function when UR methods dont complete due to any Exception. 
 */