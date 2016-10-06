using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLearnings.Models
{
    interface IStudentRepo
    {
        List<StudentModel> GetStudents();
        StudentModel GetStudentById(int studentID);
        bool RemoveStudent(int studentID);
        bool InsertStudent(StudentModel student);
        bool UpdateStudent(StudentModel student);

    }
}
