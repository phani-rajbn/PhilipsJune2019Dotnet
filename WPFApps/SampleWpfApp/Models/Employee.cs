using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWpfApp.Models
{
    public class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public long EmpContact { get; set; }
        public int EmpSalary { get; set; }
       
    }

    public class EmpRepository
    {
        private List<Employee> _employees = new List<Employee>();
        public EmpRepository()
        {
            _employees.Add(new Employee
            {
                EmpID = 111, EmpAddress="Mysore", EmpContact=2343245, EmpName="Banu Prakash", EmpSalary= 45000
            });
            _employees.Add(new Employee
            {
                EmpID = 112,
                EmpAddress = "Bangalore",
                EmpContact = 2346553,
                EmpName = "Phaniraj",
                EmpSalary = 35000
            });
            _employees.Add(new Employee
            {
                EmpID = 113,
                EmpAddress = "Mysore",
                EmpContact = 43553245,
                EmpName = "Vinod Kumar",
                EmpSalary = 40000
            });
            _employees.Add(new Employee
            {
                EmpID = 114,
                EmpAddress = "Shimoga",
                EmpContact = 4455656,
                EmpName = "Somnath",
                EmpSalary = 35000
            });
            _employees.Add(new Employee
            {
                EmpID = 115,
                EmpAddress = "Chennai",
                EmpContact = 5453466,
                EmpName = "Senthil",
                EmpSalary = 45000
            });
            _employees.Add(new Employee
            {
                EmpID = 116,
                EmpAddress = "Vizag",
                EmpContact = 65474577,
                EmpName = "Mohan Kumar",
                EmpSalary = 37000
            });
            _employees.Add(new Employee
            {
                EmpID = 117,
                EmpAddress = "Bangalore",
                EmpContact = 23409876,
                EmpName = "JoyDip Mondal",
                EmpSalary = 28000
            });
        }

        public void AddNewEmployee(Employee emp)
        {
            _employees.Add(emp);
        }

        public void RemoveEmployee(int id)
        {
            var emp = _employees.Find(e => e.EmpID == id);
            _employees.Remove(emp);
        }

        public Employee Find(int id)
        {
            var emp = _employees.Find(e => e.EmpID == id);
            return emp;
        }

        public List<Employee> GetAll()
        {
            return _employees;
        }

        public void UpdateEmployee(Employee emp)
        {
            throw new Exception("Do it URself");
            //Find the Emp matching the id of the emp arg.
            //Update the details
            //Exit the func....
        }
        //Create a property called AllEmployees...
        public List<Employee> AllEmployees => _employees;
    }
}
