using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace SampleWpfApp.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Marks { get; set; }

        public Student(int id, string name, int marks)
        {
            StudentID = id;
            StudentName = name;
            Marks = marks;
        }
    }

    public class StudentDatabase
    {
        private List<Student> _students = new List<Student>();

        public StudentDatabase()
        {
            _students.Add(new Student(123, "Phaniraj", 540));
            _students.Add(new Student(124, "Anjan", 340));
            _students.Add(new Student(125, "Komal", 340));
            _students.Add(new Student(126, "Ram", 500));
            _students.Add(new Student(127, "Andrew", 500));
            _students.Add(new Student(128, "Tom", 426));

        }
        public List<Student> AllStudents => _students;    
    }

    [ValueConversion(typeof(int), typeof(Brush))]
    public class MarksConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int current = (int)value;//value is of the type int(Marks)...
            if (current <= 300)
                return Brushes.Red;
            else if ((current > 300) && (current < 500))
                return Brushes.Blue;
            else
                return Brushes.Green;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
