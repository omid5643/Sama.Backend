using Omran.Sama.Models;
using Omran.Sama.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Tests
{
    class CourseServiceTests
    {
        private CourseService courseService = new CourseService();
        public void TestLoad()
        {
            List<Course> courses = courseService.Load();
        }
        public void TestLoadById()
        {
            Course course = courseService.LoadById(5);
        }
        public void TestRemove()
        {
            courseService.Remove(5);

        }
        public void TestUpdate()
        {
            Course course = new Course { Id = 1, Name = "math2", Credit = 3, PreReqId = 3 };
            bool succeded = courseService.Update(course);
        }
        public void TestAdd()
        {
            Course course2 = new Course { Id = 5, Name = "chem", Credit = 2 };

            courseService.Add(course2);
        }

        public void TestSetCost()
        {
            courseService.SetCost(1, 500);
        }
        public void TestRemoveMany()
        {
            List<int> ids = new List<int> { 5 };
            courseService.RemoveMany(ids);
        }
    }
}

