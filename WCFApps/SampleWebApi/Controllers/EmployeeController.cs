using SampleWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleWebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public List<Employee> AllEmployees()
        {
            var context = new MyDBEntities();//Classname that interacts with the DB
            var records = context.EmpTables.ToList();
            var employees = new List<Employee>();
            foreach (var emp in records)
            {
                var temp = new Employee();
                temp.Convert(emp);
                employees.Add(temp);
            }

            //var employees = context.EmpTables.ToList().Select((e)=>new Employee {
            //ID = e.EmpID,
            //Address = e.EmpAddress, Name =e.EmpName, Salary = e.EmpSalary
            // }).ToList();

            return employees;
        }        

        [HttpGet]
        public Employee Find(int id)
        {
            var context = new MyDBEntities();
            var selected = context.EmpTables.FirstOrDefault((e) => e.EmpID == id);
            if (selected == null) throw new Exception("Employee not found");
            var emp = new Employee();
            emp.Convert(selected);
            return emp;
        }

        [HttpPost]//Adding 
        public bool AddNewEmployee(Employee emp)
        {
            var context = new MyDBEntities();
            var empTable = emp.Convert();
            context.EmpTables.Add(empTable);
            context.SaveChanges();//Commit the transaction and save to the DB...
            return true;
        }

        [HttpPut]
        public bool UpdateEmployee(Employee emp)
        {
            if(emp == null)
            {
                throw new Exception("Emp Details are not set");
            }
            var context = new MyDBEntities();
            var selected = context.EmpTables.FirstOrDefault(e => e.EmpID == emp.ID);
            if (selected == null) throw new Exception("Not found to update");
            selected.EmpName = emp.Name;
            selected.EmpAddress = emp.Address;
            selected.EmpSalary = emp.Salary;
            context.SaveChanges();
            return true;
        }
    }
}
