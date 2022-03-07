using Microsoft.AspNetCore.Mvc;
using Omran.Sama.Commen.Constants;
using Omran.Sama.Commen.DTOs;
using Omran.Sama.Models;
using Omran.Sama.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omran.Sama.Server.Controllers

{
    [Route(RouteConstants.StudentRoute)]
    public class StudentController:Controller
    {
        private StudentService _service = new StudentService();

        public StudentController()
        {
           
        }


        [HttpGet("[Action]")]
       
       public List<Student> Load()
        {
           var students= _service.Load();
            return students;
        }

        [HttpPost("[Action]")]

        public  Student LoadById(int id)
        {
            return _service.LoadById(id);
        }

        [HttpPost("[Action]")]

        public bool Add( [FromBody]Student student)
        {
            return _service.Add(student);
        }
        [HttpPost("[Action]")] 

         public List<Student> GetByName([FromBody]StudentDTO studentDto)
        {

            return _service.GetByName(studentDto.FirstName,studentDto.LastName);
        }
        [HttpPost("[Action]")] 

        public bool Remove(int id)
        {
            return _service.Remove(id);

        }
        [HttpPost("[Action]")]
        public void RemoveMany(List<int> ids)
        {

            _service.RemoveMany( ids);
        }
        [HttpPost("[Action]")] 

        public bool Update( [FromBody]Student student)
        {
            return _service.Update(student);
        }
    }
}
