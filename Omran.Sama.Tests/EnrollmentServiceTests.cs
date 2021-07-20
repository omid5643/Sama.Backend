using Omran.Sama.Commen.Enums;
using Omran.Sama.Common;
using Omran.Sama.Models;
using Omran.Sama.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Tests
{
  public  class EnrollmentServiceTests
    {

        EnrollmentService enrollmentService = new EnrollmentService();

        public void TestAdd()
        {
            Enrollment enrollment = new Enrollment { Id=1,InstructorId=1,CourseId=1,};
            enrollment.Grade = Grade.None;
            enrollment.Semester = Semester.Fall;
            enrollmentService.Add(enrollment);

        }
        public void TestLoad()
        {
            List<Enrollment> enrollments = enrollmentService.Load();
        }
        public void TestLoadById()
        {
            Enrollment enrollment = enrollmentService.LoadById(2);
        }
        public void TestRemove()
        {
            bool succeded = enrollmentService.Remove(11);
        }
        public void Testupdate()
        {
            Enrollment enrollment = new Enrollment {Grade=Grade.F};
            enrollmentService.Update(enrollment);
        }
        public void TestEnoll1()
        {
            Student student = new Student { FirstName= "mike", LastName= "jamal" };
            Instructor instructor = new Instructor {FirstName= "Joe", LastName= "Smith" };
            Course course = new Course { Name="chem1"};
            enrollmentService.Enroll(student.FirstName= "mike",
                                     student.LastName= "jamal",
                                     instructor.FirstName= "Joe",
                                     instructor.LastName = "Smith",
                course.Name= "chem1",Semester.Fall);


        }
        public void TestEnoll()

        {
            Student student = new Student {Id=13};
            Instructor instructor = new Instructor {Id=1 };
            Course course = new Course { Id = 4};
           
            enrollmentService.Enroll(student.Id=13,instructor.Id=1,course.Id=4,Semester.Spring);
        }

        public void TestDic()
        {
            Dictionary<string, int> studentCountPerSemester = new Dictionary<string, int>();

            studentCountPerSemester.Add("Fall", 8);
            studentCountPerSemester.Add("Spring", 13);
            if(!studentCountPerSemester.ContainsKey("Spring"))
            studentCountPerSemester.Add("Spring", 14);

        }

        public void TestGetNumberOfEnrollmetsPerStudent()
        {
           var result =enrollmentService.GetNumberOfEnrollmentsPerStudent();
            
        }
    }
}
