using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DapperLearnings.Models
{
    public class StudentRepo : IStudentRepo
    {
        private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["Datafi"].ConnectionString);
        public StudentModel GetStudentById(int studentID)
        {
          return  _db.Query<StudentModel>("select [StudentId],[StudentName],[SubjectPassed] from [StudentDetails] where StudentId=@StudentId", new { StudentId = studentID }).SingleOrDefault();
        }

        public List<StudentModel> GetStudents()
        {
           return this._db.Query<StudentModel>("select [StudentId],[StudentName],[SubjectPassed] from[StudentDetails]").ToList();
        }

        public bool InsertStudent(StudentModel student)
        {
            int rowsAffected = _db.Execute(@"Insert [StudentDetails] ([StudentId], [StudentName], [SubjectPassed]) values (@StudId,@StudName,@SubPass)", new { StudId = student.StudentID, StudName = student.StudentName, SubPass = student.SubjectPassed });
            if(rowsAffected > 0 )
            {
                return true;
            }
            return false;
        }

        public bool RemoveStudent(int studentID)
        {
            int rowsAffected = _db.Execute(@"Delete from [StudentDetails] where StudentId=@StudentId", new { StudentId = studentID });
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateStudent(StudentModel student)
        {
            int rowsAffected =this._db.Execute(@"Update [StudentDetails] set [StudentId]=@StudId, [StudentName]=@StudName, [SubjectPassed]=@StubPass where StudentId = " + student.StudentID, student);
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}