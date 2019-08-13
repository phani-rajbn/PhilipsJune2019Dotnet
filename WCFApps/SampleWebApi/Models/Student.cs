using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebApi.Models
{
    public class Student
    {
        public int StudentNo { get; set; }
        public string StudentName { get; set; }
        public int TotalMarks { get; set; }
        public int CurrentClass { get; set; }
    }
}