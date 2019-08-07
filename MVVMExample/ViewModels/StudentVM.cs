using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMExample.Models;
namespace MVVMExample.ViewModels
{
    //VM class should have Notification of Properties, Command Binding for Events. 
    public class CustomCommand : ICommand
    {
        private Action<object> action;

        public CustomCommand(Action<object> invoker)
        {
            action = invoker;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //Logic to define whether the event should occur or not...
            return true;
        }

        public void Execute(object parameter)
        {
            //Code on which method to execute....
            action(parameter);
        }
    }

    public class StudentVM : INotifyPropertyChanged
    {

        private static StudentDatabase _db = new StudentDatabase();
        public event PropertyChangedEventHandler PropertyChanged;
        private Student newStudent = new Student();

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public Student NewStudent
        {
            get { return newStudent; }
            set
            {
                newStudent = value;
                OnPropertyChanged("NewStudent");
            }
        }
        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public StudentVM()
        {
            AddCommand = new CustomCommand(addFunc);
            DeleteCommand = new CustomCommand(delFunc);
            UpdateCommand = new CustomCommand(updateFunc);
        }

        public ObservableCollection<Student> AllStudents => new ObservableCollection<Student>(_db.GetAllStudents()); 

        private void addFunc(object student)
        {
            if(student is Student)
            {
                var temp = new Student();
                var copy = student as Student;
                temp.StudentID = copy.StudentID;
                temp.StudentName = copy.StudentName;
                temp.StudentCourse = copy.StudentCourse;
                temp.Fees = copy.Fees;
                _db.AddNewStudent(temp);
                NewStudent = new Student();
            }
            OnPropertyChanged("AllStudents");
        }

        private void delFunc(object id)
        {
            _db.DeleteStudent(int.Parse(id.ToString()));
        }

        private void updateFunc(object student)
        {
            if (student is Student)
            {
                _db.UpdateStudent(student as Student);
            }
        }
    }
}
