using Microsoft.AspNetCore.Mvc;
using Omran.Sama.Commen.Constants;
using Omran.Sama.Commen.DTOs;
using Omran.Sama.Common;
using Omran.Sama.Models;
using Omran.Sama.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omran.Sama.Server.Controllers
{
    [Route(RouteConstants.EnrollmentRoute)]
    public class EnrollmentController
    {
     
        private EnrollmentService _service = new EnrollmentService();
        public EnrollmentController()
        {

        }

        [HttpGet("[Action]")]

        public List<Enrollment> Load()
        {
            return _service.Load();
        }

        [HttpPost("[Action]")]

        public Enrollment LoadById(int id)
        {
            return _service.LoadById(id);
        }

        [HttpPost("[Action]")]

        public bool Add([FromBody]Enrollment enrollment)
        {
            return _service.Add(enrollment);
        }
       
        [HttpPost("[Action]")]

        public bool Remove(int id)
        {
            return _service.Remove(id);
        }
        [HttpPost("[Action]")]

        public bool Update([FromBody]Enrollment enrollment)
        {
            return _service.Update(enrollment);
        }

        [HttpPost("[Action]")]

        public string Enroll([FromBody]EnollmentDTO enrollmentDto)
        {
            return _service.Enroll(enrollmentDto.StudentFirstName,enrollmentDto.StudentLastName,
                                   enrollmentDto.InstructorFirstName,enrollmentDto.InstrutorLastName,
                                   enrollmentDto.CourseName,enrollmentDto.Semester);                         

        }
    }
}
