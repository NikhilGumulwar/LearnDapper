using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DapperLearnings.Models
{
    public class StudentModel
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string SubjectPassed { get; set; }
    }
}