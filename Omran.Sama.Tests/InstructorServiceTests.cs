using Omran.Sama.Models;
using Omran.Sama.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Tests
{
    class InstructorServiceTests
    {
        private InstructorService instructorService = new InstructorService();

        public void TestLoad()
        {
           List<Instructor> instructors =instructorService.Load();
        }
        public void TestAdd()
        {
            Instructor instructor = new Instructor();
            instructor.Id = 2;
            instructor.FirstName = "Walter";
            instructor.LastName = "white";
            instructorService.Add(instructor);
        }
        public void TestUpdate()
        {
            Instructor instructor = new Instructor();
            instructor.Id = 10;
            instructor.Age = 32;
            instructorService.Update(instructor);
        }
    
        public void TestGetInstructorsNameByName()
        {

            List<Instructor> mathedInstructors = instructorService.GetByName("walter4", " white4");
        }
        public void TestRemove()
        {
            bool succeeded = instructorService.Remove(11);
        }
        public void TestLoadById()
        {

           Instructor instructor =instructorService.LoadById(3);
        }
    }
}
