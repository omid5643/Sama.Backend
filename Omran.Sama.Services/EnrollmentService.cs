using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Omran.Sama.Commen.Constants;
using Omran.Sama.Commen.Enums;
using Omran.Sama.Common;
using Omran.Sama.Models;

namespace Omran.Sama.Services
{
    public class EnrollmentService 
    {
       private readonly string fullPath = DbConstants.DbPath + DbConstants.EnrollmentFile;
        private StudentService studentService = new StudentService();
        private InstructorService instructorService = new InstructorService();
        private CourseService courseService = new CourseService();
        private AccountService accountService = new AccountService();

        private bool Store(List<Enrollment> enrollments)
        {
            try
            {

                string serialized = JsonConvert.SerializeObject(enrollments);
                File.WriteAllText(fullPath, serialized);
                return true;
            }

            catch (Exception e)
            {
                Loger.Log(e.Message);
                return false;

            }
        }

        public List<Enrollment>Load()
        {
            if (File.Exists(fullPath))
            {
                string content = File.ReadAllText(fullPath);
                List<Enrollment> enrollments = JsonConvert.DeserializeObject<List<Enrollment>>(content);
                return enrollments;
            }
            return null;
        }

           public Enrollment LoadById(int id)
        {
            try
            {
                List<Enrollment> enrollments = Load();
                var matched = enrollments.Single(x => x.Id == id);
                return matched;
            }
            catch (Exception e)
            {
                Loger.Log(e.Message);
                return null;
            }
        }
        public bool Add(Enrollment enrollment)
        {

            List<Enrollment> enrollments = Load();
            if (enrollments != null)
            {
                var matched = enrollments.SingleOrDefault(x => x.Id == enrollment.Id);
                if (matched != null)
                    return false;
                int greatestId = enrollments.OrderBy(x => x.Id).Select(x => x.Id).First();
                enrollment.Id = greatestId + 1;
                enrollment.CreateBy = "System";
                enrollment.CreateDate = System.DateTime.Now;
                enrollments.Add(enrollment);
                Store(enrollments);
                return true;

            }
            else

            {
                List<Enrollment> newEnrollments = new List<Enrollment>();
                enrollment.Id = 1;
                enrollment.CreateBy = "System";
                enrollment.CreateDate = System.DateTime.Now;
                newEnrollments.Add(enrollment);
                Store(newEnrollments);
                return true;


            }
        }
      
        public  bool Remove(int id)
        {
            try
            {
                List<Enrollment> enrollments = Load();
                var matched = enrollments.Single(x => x.Id == id);
                enrollments.Remove(matched);
                return true;
            }
            catch (Exception e)
            {
                Loger.Log(e.Message);
                return false;

            }
        }

        public bool Update(Enrollment enrollment)
        {
            try
            {
                List<Enrollment> enrollments = Load();
                var matched = enrollments.Single(x => x.Id == enrollment.Id);
                matched.Id = enrollment.Id;
                matched.Id = enrollment.Id;
                matched.InstructorId = enrollment.InstructorId;
                matched.Semester = Semester.Fall;
                matched.CourseId = enrollment.CourseId;
                matched.CreateBy = enrollment.CreateBy;
                matched.CreateDate = enrollment.CreateDate;
                matched.Grade = Grade.None;
                Store(enrollments);
                return true;
            }
            catch (Exception e)
            {

                Loger.Log(e.Message);
                return false;
            }
        }
        public string Enroll(string studentFirstName,string studentLastName,
                            string instructorFirstName,string instrutorLastName,string courseName, Semester semester)
        {
            Enrollment enrollment = new Enrollment();
         
           List<Student> foundStudents= studentService.GetByName(studentFirstName,studentLastName);
            if(foundStudents == null|| foundStudents.Count==0)
            {
                return "Student not found!";
            }
            if (foundStudents.Count > 1)
            {
                return "found multiple students!";
            }
           
                enrollment.StudentId=foundStudents.Select(x=>x.Id).First();

            List<Instructor> foundInstructors = instructorService.GetByName(instructorFirstName,instrutorLastName);
            if (foundInstructors == null)
            {
                return "Instructor not found";
            }
            if (foundInstructors.Count>1)
            {
                return "found multiple instructors";
            }
            enrollment.InstructorId = foundInstructors.Select(x=>x.Id).First();
       
            List<Course> foundCourses = courseService.GetByName(courseName);

            if (foundCourses == null)
            {
                return "course not found";
            }
            if (foundCourses.Count>1)
            {
                return "found multiple courses";
            }
            enrollment.CourseId = foundCourses.Select(x=>x.Id).First();
            enrollment.Semester = semester;

            this.Add(enrollment);
            return "enrollment succeeded";                

        }

        public Dictionary<int, int> GetNumberOfEnrollmentsPerStudent()
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            var students = studentService.Load();
            var enrollments = Load();
            foreach (Student student in students)
            {
                var count = enrollments.Count(x => x.StudentId == student.Id);
                result.Add(student.Id, count);
            }

            return result;
        }

         public string Enroll(int studentId,int instructorId,int courseId,Semester semester)
       {
           Enrollment enrollment = new Enrollment();

            Student student = studentService.LoadById(studentId);
            if (student == null)
                return "Student not found!";
            
            enrollment.StudentId = student.Id;

            Instructor instructor = instructorService.LoadById(instructorId);
            if (instructor == null)
                return "Instructor not found!";
            
            enrollment.InstructorId = instructor.Id;

            Course course = courseService.LoadById(courseId);
            if (course == null)
                return "Course not found";
            if (course.PreReqId.HasValue)
            {
                //if student hasnt passed the course with that prereq id return a message
               var previousEnr=Load()
                                .FirstOrDefault(x=>x.StudentId==studentId && 
                                 x.CourseId==course.PreReqId.GetValueOrDefault() &&
                                (x.Grade==Grade.A|| x.Grade == Grade.B|| x.Grade == Grade.C));
                if (previousEnr == null)
                {
                    //find the course that its id equls the prereqid of the course being enrolled
                  var preReqCourse = courseService.LoadById(course.PreReqId.GetValueOrDefault());
                    if(preReqCourse!=null)

                  //  return "You need to take"+preReqCourse.Name;
                    return $"You need to take {preReqCourse.Name}";
                }
               
            }
            
            enrollment.CourseId = course.Id;

            enrollment.Semester = semester;

            this.Add(enrollment);

            // check the student has an account if the student does not have an account creat it.
            var existingAccount = accountService.GetStudentAccount( student);
            if (existingAccount == null)
            {
                Account account = new Account();
                account.Balance = (int)course.Cost;
                accountService.Add(account);
                      
            }
            else
            {
             // existingAccount.Balance =existingAccount.Balance+(int)course.Cost;
                existingAccount.Balance += (int)course.Cost;
                accountService.Update(existingAccount);
            }
            return "Succeeded!";
            }




        

    }
}
