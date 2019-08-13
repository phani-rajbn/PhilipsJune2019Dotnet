using SampleWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//All Web APIs are derived from System.Web.Http.ApiController which internally implements an interface called IController which is the foundation for all MVC based Apps in ASP.NET.
//Web APIS are improvized versions of Service based Architecture, future of WCF. 
//Some Applications which are migrating to Web API from WCF, will create ApiControllers which internally refer to the WCF components....

namespace SampleWebApi.Controllers
{
    public class FirstExampleController : ApiController
    {
        public string GetWelcomeMessage()
        {
            return "Hello World from Web API";
        }
        //GET passing an arguement within the URL(QueryString)....
        public string GetEmployee(int id)
        {
            return "Employee by " + id + " is  found";
        }

        [Route("api/Customers/{id}")]//Introduced in Web API 2.0(2015)...
        public string GetCustomer(int id)
        {
            return "Customer by " + id + " was found";
        }

        [Route("api/Student")]
        public Student GetStudent()
        {
            return new Student
            {
                StudentNo = 111, CurrentClass = 7, StudentName="Akshay", TotalMarks=400
            };
        }//Data is always transfered either as XML or JSON depending on the Parser used by the browser that consumes it....
    }
}
