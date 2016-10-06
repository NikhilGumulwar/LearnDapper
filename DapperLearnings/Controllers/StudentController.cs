using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DapperLearnings.Models;
using System.Collections.Generic;

namespace DapperLearnings.Controllers
{
   
    public class StudentController : ApiController
    {
        private StudentRepo repo = new StudentRepo(); 
         
        [Route("api/Student")]
        [HttpGet]
        public List<StudentModel> GetAllStudents()
        {
            return repo.GetStudents();
        }

        [Route("api/Student/{id}")]
        [HttpGet]
        public StudentModel GetSingleStudent(int id)
        {
            return repo.GetStudentById(id);
        }

        [Route("api/Student")]
        [HttpPost]
        public bool PostStudent([FromBody]StudentModel student)
        {
            return repo.InsertStudent(student);
        }

        [Route("api/Student")]
        [HttpDelete]
        public bool DeleteStudent(int id)
        {
            return repo.RemoveStudent(id);   
        }

        [Route("api/Student")]
        [HttpPut]
        public bool PutStudent([FromBody]StudentModel student)
        {
            return repo.UpdateStudent(student);
        }


    }
}
