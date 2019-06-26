using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DataLayer;
using CommonLayer;
//All file related classes are available under the namespace System.IO. 
namespace SampleConApp
{
    class CSVComponent : IDataLayer
    {
        const string FILE_NAME = "Employees.csv";
        private List<Employee> _tempList = new List<Employee>();
        public CSVComponent()
        {
            //To ensure that the file Exists, if not create a new file....
            if (!File.Exists(FILE_NAME))
            {
                var fs = File.Create(FILE_NAME);
                fs.Close();
            }
        }
        public void AddNewEmployee(Employee emp)
        {
            //StreamWriter writer = new StreamWriter(FILE_NAME, true);
            //var line = string.Format($"{emp.EmpID},{emp.EmpName},{emp.EmpAddress},{emp.EmpSalary}");
            //writer.WriteLine(line);
            //writer.Close();
            using (StreamWriter writer = new StreamWriter(FILE_NAME, true))
            {
                var line = string.Format($"{emp.EmpID},{emp.EmpName},{emp.EmpAddress},{emp.EmpSalary}");
                writer.WriteLine(line);
            }//It will call the resource's destructor kind of function called Dispose. 
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Employee[] FindEmployee(string name)
        {
            throw new NotImplementedException();
        }

        public Employee FindEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee emp)
        {
            //CSV file cannot be updated as U dont have any APIs to seek a line and make changes to it. 
            readAllRecords();
            var rec = _tempList.Find(e => e.EmpID == emp.EmpID);
            rec.EmpName = emp.EmpName;
            rec.EmpAddress = emp.EmpAddress;
            rec.EmpSalary = emp.EmpSalary;
            updateAllRecords();
        }

        private void updateAllRecords()
        {
            using (StreamWriter writer = new StreamWriter(FILE_NAME))
            {
                foreach(var emp in _tempList)
                {
                    var line = string.Format($"{emp.EmpID},{emp.EmpName},{emp.EmpAddress},{emp.EmpSalary}");
                    writer.WriteLine(line);
                }
            }
        }

        private void readAllRecords()
        {
            _tempList.Clear();//All the records will be truncated....
            using(StreamReader reader = new StreamReader(FILE_NAME))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    string[] words = line.Split(',');
                    var emp = new Employee
                    {
                        EmpID = int.Parse(words[0]),
                        EmpName = words[1],
                        EmpAddress = words[2],
                        EmpSalary = double.Parse(words[3])
                    };
                    _tempList.Add(emp);
                }
            }
        }
    }
    class FileIO
    {
        static void Main(string[] args)
        {
            //readAllAtOnce();
            //readLines();
            writeCSVFile();

        }

        private static void writeCSVFile()
        {
            string value = "123,Phaniraj,Bangalore";
            //File.WriteAllText("Sample.csv", value);//writes to the file as CSV...
            StreamWriter writer = new StreamWriter("Sample.csv", true);
            writer.WriteLine(value);
            writer.Flush();//Clear the buffer before closing
            writer.Close();//Closes the Stream from writing...
        }

        private static void readLines()
        {
            var lines = File.ReadAllLines(@"B:\Programs\Philips-June-2019\DotnetApps\SampleConApp\FileIO.cs");
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine($"{(i + 1)}:{lines[i]}");
            }
        }

        private static void readAllAtOnce()
        {
            var content = File.ReadAllText(@"B:\Programs\Philips-June-2019\DotnetApps\SampleConApp\FileIO.cs");
            Console.WriteLine(content);
        }
    }
}
