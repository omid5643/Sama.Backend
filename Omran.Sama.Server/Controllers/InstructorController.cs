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
    [Route(RouteConstants.InstructorRoute)]
    public class InstructorController:Controller
    {
        private InstructorService _service = new InstructorService();
        public InstructorController()
        {
        }


        [HttpGet("[Action]")]
        public List<Instructor> Load()
        {
            return _service.Load();
        }

        [HttpPost("[Action]")]
        public Instructor LoadById(int id)
        {
            return _service.LoadById(id);
        }

        [HttpPost("[Action]")]
        public bool Add( [FromBody]Instructor instructor)
        {
            return _service.Add(instructor);
        }
        [HttpPost("[Action]")]
        public List<Instructor> GetByName([FromBody]InstructorDTO instructorDto)
        {

            return _service.GetByName(instructorDto.FirstName,instructorDto.LastName);
        }
        [HttpPost("[Action]")]
        public bool Remove(int id)
        {
            return _service.Remove(id);
        }
        [HttpPost("[Action]")]
        public bool Update( [FromBody]Instructor instructor)
        {
            return _service.Update(instructor);
        }
    }
}
