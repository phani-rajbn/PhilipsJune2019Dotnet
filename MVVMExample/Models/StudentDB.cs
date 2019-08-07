using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMExample.Models
{
    public class Student : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _id, _fees;
        private string _name, _course;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public int StudentID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("StudentID");
            }
        }

        public string StudentName
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("StudentName");
            }
        }
        public string StudentCourse
        {
            get { return _course; }
            set
            {
                _course = value;
                OnPropertyChanged("StudentCourse");
            }
        }

        public int Fees
        {
            get { return _fees; }
            set
            {
                _fees = value;
                OnPropertyChanged("Fees");
            }
        }
    }

    public class StudentDatabase
    {
        private List<Student> _students = new List<Student>();
        public void AddNewStudent(Student student)
        {
            _students.Add(student);
        }

        public void DeleteStudent(int id)
        {
            var student = _students.Find(s => s.StudentID == id);
            if (student == null)
                throw new Exception("Student not found to delete");
            _students.Remove(student);
        }

        public void UpdateStudent(Student modifiedStudent)
        {
            var student = _students.Find(s => s.StudentID == modifiedStudent.StudentID);
            if (student == null)
                throw new Exception("Student not found to Update");
            student.StudentCourse = modifiedStudent.StudentCourse;
            student.StudentName = modifiedStudent.StudentName;
            student.Fees = modifiedStudent.Fees;
        }

        public List<Student> GetAllStudents() => _students;
    }
}
