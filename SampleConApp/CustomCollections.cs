using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
/*
 * Collections in .NET are classes whose objects can be used in a foreach statement. Internally they should implement an interface called IEnumerable. 
 * Array is also a collection class, as it is a part of the fundamental concepts of any programming language, it is kept outside the namespace of System.Collections. 
 * Rest of the classes that implement IEnumerable are a part of the Collection Framework of the .NET. 
 * If a class of URs could implement the IEnumerable interface, then it becomes a collection class and its object could be used in a foreach statement. 
 * IEnumerable interface has a function called GetEnumerator which returns an IEnumerator object which can be used to iterate the collection. foreach uses this iterator to move next while it accesses the current value in the collection.  
 * Under generics, there is another version of IEnumerable called IEnumerable<T> and its corresponding IEnumerator<T>. 
 * A Custom Collection is required to customize Ur component to perform simple insertions, deletions, Updations as well as iterations. U could remove many of the unwanted methods to suit Ur business requirements. 
 */
namespace SampleConApp
{
    class Patient
    {
        public int PatientID { get; set; }
        public string Name { get; set; }
        public long ContactNo { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public double TotalBill { get; set; }
        public override bool Equals(object obj)
        {
            if(obj is Patient)
            {
                var temp = obj as Patient;
                return temp.PatientID == PatientID;
            }
            return false;
        }

        public override string ToString()
        {
            return string.Format($"Name:{Name}\nContact:{ContactNo}\nTotal Bill:{TotalBill:C}");
        }
    }


    class InPatientWard : IEnumerable<Patient>
    {
        List<Patient> _allPatients = new List<Patient>();//List with no elements in it. 

        public void AddPatient(Patient patient)
        {
            _allPatients.Add(patient);
        }

        public void UpdatePatient(Patient patient)
        {
           for (int i = 0; i < _allPatients.Count; i++)
            {
                if (_allPatients[i].Equals(patient))//find the patient
                {
                    //set the new details
                    _allPatients[i].Name = patient.Name;
                    _allPatients[i].ContactNo = patient.ContactNo;
                    _allPatients[i].TotalBill = patient.TotalBill;
                    _allPatients[i].DateOfAdmission = patient.DateOfAdmission;
                    return;//exit the function
                }
            }
        }

        public void DeleteEmployee(int id)
        {
            var found = _allPatients.Find(p => p.PatientID == id);
            if (found == null)
                throw new Exception("No Patient found to delete");
            _allPatients.Remove(found);
        }

        public List<Patient> GetAllPatients()
        {
            return _allPatients;
        }
        //New version
        public IEnumerator<Patient> GetEnumerator()
        {
            return _allPatients.GetEnumerator();
        }
        //Older version as the new version is derived from the old. 
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _allPatients.GetEnumerator();
        }

        public int PatientCount { get { return _allPatients.Count; } }

        public Patient this[int index]
        {
            get
            {
                if (index < _allPatients.Count)
                    return _allPatients[index];
                else
                    throw new IndexOutOfRangeException("Patient does not exist at this index");
            }
        }

        public Patient this[string name]
        {
            get
            {
                return _allPatients.Find(p => p.Name == name);
            }
        }
    }
    class CustomCollections
    {
        static void Main(string[] args)
        {
            //arrayAsCollection();
            InPatientWard manipalHospitals = new InPatientWard();
            manipalHospitals.AddPatient(new Patient
            {
                ContactNo = 2343444,
                DateOfAdmission = DateTime.Parse("22/02/1977"),
                Name ="Phaniraj",
                PatientID = 123,
                TotalBill = 1500                
            });

            manipalHospitals.AddPatient(new Patient
            {
                ContactNo = 345534545,
                DateOfAdmission = DateTime.Parse("12/04/1976"),
                Name = "Radha",
                PatientID = 124,
                TotalBill = 2500
            });

            manipalHospitals.AddPatient(new Patient
            {
                ContactNo = 6656169,
                DateOfAdmission = DateTime.Parse("15/10/1957"),
                Name = "Sudhindra",
                PatientID = 125,
                TotalBill = 4500
            });
            Console.WriteLine("---------------Using Foreach----------------------");
            foreach(Patient patient in manipalHospitals)
            {
                Console.WriteLine(patient);
            }
            Console.WriteLine("---------------Using For with indexer----------------------");
            for (int i = 0; i < manipalHospitals.PatientCount; i++)
            {
                Console.WriteLine(manipalHospitals[i]);
            }
            Console.WriteLine("---------------Using overloaded Indexer----------------------");
            Console.WriteLine(manipalHospitals["SomeName"]);
        }

        private static void arrayAsCollection()
        {
           
            string[] array = { "Apple", "Mango", "Orange" };//All arrays are instances of a Class called System.Array.
            //foreach (string item in array) Console.WriteLine(item);
            var iterator = array.GetEnumerator();//This function returns an IEnumerator object thro which we could perform the iteration of the collection. 
                while(iterator.MoveNext())
                Console.WriteLine(iterator.Current);
        }
        //IEnumerable vs IEnumerator: IEnumerable is the interface that gives an ability for a class to iterate, and the iteration happens thro the object called IEnumerator. 
        //IEnumerator has a read only property called Current and a method called MoveNext which returns a bool that will return false if there is no next item in the collection. 
    }
}
