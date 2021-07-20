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
    [Route(RouteConstants.CourseRoute)]
    public class CourseController:Controller
    {
        private CourseService _service = new CourseService();
        public CourseController()
        {
        }

        [HttpGet("[Action]")]
        public List<Course> Load()
        {
            return _service.Load();
        }

        [HttpPost("[Action]")]
        public Course LoadById(int id)
        {
            return _service.LoadById(id);
        }

        [HttpPost("[Action]")]

        public  bool Add( [FromBody]Course course)
        {
            return _service.Add(course);
        }
        [HttpPost("[Action]")]
        public List<Course> GetByName([FromBody]CourseDTO courseDto)
        {

            return _service.GetByName(courseDto.name);
        }
        [HttpPost("[Action]")]
         public bool Remove(int id)
        {
            return _service.Remove(id);
        }
        [HttpPost("[Action]")]
        public bool Update([FromBody]Course course)
        {
            return _service.Update(course);
        }
    }
}
