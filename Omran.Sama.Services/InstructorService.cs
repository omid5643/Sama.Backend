using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Omran.Sama.Commen.Constants;
using Omran.Sama.Models;

namespace Omran.Sama.Services
{
    public class InstructorService : IInstructorService

    {
        private readonly string fullPath = DbConstants.DbPath + DbConstants.InstrucrtorFile;
   
        private bool Store(List<Instructor> instructors)
        {
            try
            {

                string serialized = JsonConvert.SerializeObject(instructors);
                File.WriteAllText(this.fullPath, serialized);
                return true;
            }

            catch (Exception e)
            {
                Loger.Log(e.Message);
                return false;

            }
        }
        public List<Instructor> Load()
        {
            if (File.Exists(fullPath))
            {
                string content = File.ReadAllText(fullPath);
                List<Instructor> instructors = JsonConvert.DeserializeObject<List<Instructor>>(content);
                return instructors;

            }
            return null;
        }

        public Instructor LoadById(int id)
        {
            try
            {
                List<Instructor> instructors = Load();
                var instructor = instructors.Single(x=> x.Id == id);
                return instructor;
            }
            catch (Exception e)
            {
                Loger.Log(e.Message);
                return null;
            }
        }
        public bool Add(Instructor instructor)
        {
            List<Instructor> instructors = Load();
            if (instructors != null && instructors.Count()>0)
            {
                var matched = instructors.SingleOrDefault(x => x.Id == instructor.Id);
                if (matched != null)
                    return false;
                //Find Greatest Id In DB
                int greatestId = instructors.OrderByDescending(x => x.Id).Select(x => x.Id).First();
                instructor.Id = greatestId + 1;
                instructor.CreateBy = "System";
                instructor.CreateDate = System.DateTime.Now;

                instructors.Add(instructor);
                Store(instructors);
                return true;
            }
            else
            {
                List<Instructor> newInstructors = new List<Instructor>();
                instructor.Id = 1;
                instructor.CreateBy = "System";
                instructor.CreateDate = System.DateTime.Now;
                newInstructors.Add(instructor);
                Store(newInstructors);
                return true;
                
            }
          
        }

        public List<Instructor> GetByName(string firstName,string lastName)
        {
            List<Instructor> instructors = Load();
            if (instructors != null)
            {
              var matched = instructors.Where(x => x.FirstName != null &&
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
                List<Instructor> instructors = Load();
                var instructor = instructors.Single(x => x.Id == id);
                instructors.Remove(instructor);
                Store(instructors);
                return true;
            }
            catch(Exception e)
            {
                Loger.Log(e.Message);
                return false;
            }
        }

        public void RemoveMany(List<int> ids)
        {
            {
                List<Instructor> instructors = Load();
                var instructorsToRemove = instructors.Where(x => ids.Contains(x.Id)).ToList();
                if (instructorsToRemove != null && instructorsToRemove.Count() > 0)
                {
                    instructors.RemoveAll(x => instructorsToRemove.Select(y => y.Id).Contains(x.Id));
                }
                Store(instructors);

            }

        }

        public bool Update(Instructor instructor)
        {
            try
            {
                List<Instructor> instructors = Load();
                var instructorToUpdate = instructors.Single(x => x.Id == instructor.Id);
                instructorToUpdate.Id = instructor.Id;
                instructorToUpdate.FirstName = instructor.FirstName;
                instructorToUpdate.LastName = instructor.LastName;
                instructorToUpdate.PhoneNumber = instructor.PhoneNumber;
                instructorToUpdate.Address = instructor.Address;
                instructorToUpdate.Email = instructor.Email;
                instructorToUpdate.CreateBy = instructor.CreateBy;
                instructorToUpdate.CreateDate = instructor.CreateDate;
                Store(instructors);
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
