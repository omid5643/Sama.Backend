using Newtonsoft.Json;
using Omran.Sama.Commen.Constants;
using Omran.Sama.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Omran.Sama.Services
{
   public class StudentService:IStudentService
    {
        private readonly string fullPath = DbConstants.DbPath + DbConstants.StudentFile;
      
        private bool Store(List<Student> students)
        {
            try
            {

               string serialized = JsonConvert.SerializeObject(students);
                File.WriteAllText(this.fullPath, serialized);
                return true;
            }

            catch (Exception e)
            {
                Loger.Log(e.Message);
                return false;

            }
        }
        public List<Student> Load()
        {
            if (File.Exists(this.fullPath))
            {

                string content = File.ReadAllText(this.fullPath);
                List<Student> students = JsonConvert.DeserializeObject<List<Student>>(content);

                return students;
            }
            return null;
        }

            public Student LoadById(int id)
        {
            try
            {
                List<Student> students = Load();
                var matched = students.Single(x => x.Id == id);
                return matched;
            }
            catch(Exception e)
            {
                Loger.Log(e.Message);
                return null;
            }
        }
    
        public bool Add(Student student)
        {
            List<Student> students = Load();
            if (students != null && students.Count()>0)
            {
                var matched = students.SingleOrDefault(x => x.Id== student.Id);
                if (matched != null)
                    return false;
                //Find Greatest Id In DB
                int greatestId = students.OrderByDescending(x => x.Id).Select(x => x.Id).First();
                student.Id = greatestId + 1;
                student.CreateBy = "System";
                student.CreateDate = System.DateTime.Now;
                students.Add(student);
                Store(students);
                return true;
            }
            else
            {
                List<Student> newStudents = new List<Student>();
               student.Id = 1;
               student.CreateBy = "System";
               student.CreateDate = System.DateTime.Now;
               newStudents.Add(student);
                Store(newStudents);
                return true;

            }
        }
        public List<Student> GetByName(string firstName,string lastName)
        {
            
                List<Student> students = Load();
            if (students != null)
            {
                var matched = students.Where(x => x.FirstName != null &&
                                                  x.LastName != null &&
                                                  x.FirstName.ToLower().Trim() == firstName.ToLower().Trim() &&
                                                  x.LastName.ToLower().Trim() == lastName.ToLower().Trim()).ToList();

                return matched;
            }
            return null;
        }


        public bool Remove(int id)
        {
            try
            {
                List<Student> students = Load();
                Student studentRemove = students.Single(x => x.Id == id);
                students.Remove(studentRemove);
                Store(students);
                return true;
            }
            catch (Exception e)
            {
                Loger.Log(e.Message);
               // throw;
               return false;
            }
        }

        public void RemoveMany(List<int> ids)
        {
            List<Student> students = Load();
            var studentsToRemove = students.Where(x => ids.Contains(x.Id)).ToList();
            if (studentsToRemove != null && studentsToRemove.Count() > 0)
            {
                students.RemoveAll(x => studentsToRemove.Select(y => y.Id).Contains(x.Id));
            }
            Store(students);
           
        }
        public bool Update(Student student)
        {
            try {
                List<Student> students = Load();
                var foundStudent = students.Single(x => x.Id == student.Id);

                foundStudent.Id = student.Id;
                foundStudent.FirstName = student.FirstName;
                foundStudent.LastName = student.LastName;
                foundStudent.Age = student.Age;
                foundStudent.PhoneNumbers = student.PhoneNumbers;
                foundStudent.Address= student.Address;
                foundStudent.Email = student.Email;
                foundStudent.CreateDate = student.CreateDate;
                foundStudent.CreateBy = student.CreateBy;
                Store(students);

                return true;
            }
            catch (Exception e)
            {
                Loger.Log(e.Message);
                return false;
            }
        }
      
      
        
         

    }

    
}
