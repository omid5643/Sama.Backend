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
    public class CourseService : ICourseService
    {
        private readonly string fullPath = DbConstants.DbPath + DbConstants.CourseFile;

        private bool Store(List<Course> courses)
        {
            try
            {
                string serilizad = JsonConvert.SerializeObject(courses);
                File.WriteAllText(fullPath, serilizad);
                return true;
            }
            catch (Exception e)
            {
                Loger.Log(e.Message);
                return false;
            }
        }

         public List<Course> Load()
        {

            if (File.Exists(fullPath))
            {
                string content = File.ReadAllText(fullPath);
                List<Course> courses = JsonConvert.DeserializeObject<List<Course>>(content);

                return courses;
            }
            return null;

        }
        public Course LoadById(int id)
        {
            try
            {
                List<Course> courses = Load();
                Course mathed = courses.Single(x => x.Id == id);

                return mathed;
            }
            catch (Exception e)
            {
                Loger.Log(e.Message);
                return null;
            }
        }
        public bool Add(Course course)
        {
            List<Course> courses = Load();
            if (courses!= null && courses.Count()>0)
            {
                var matched =courses.SingleOrDefault(x =>x.Id == course.Id);
                if (matched!= null)
                    return false;
                //Find Greatest Id In DB
                int greatestId = courses.OrderByDescending(x => x.Id).Select(x => x.Id).First();
                course.Id = greatestId + 1;
                course.CreatedBy = "System";
                course.CreatDate = System.DateTime.Now;

                courses.Add(course);
                Store(courses);
                return true;
            }
            else
            {
                List<Course> newCourses = new List<Course>();
                course.Id = 1;
                course.CreatedBy = "System";
                course.CreatDate = System.DateTime.Now;
                newCourses.Add(course);
                Store(newCourses);
                return true;

            }
        }
        public List<Course> GetByName(string name)
        {
            List<Course> courses = Load();
            if (courses != null)
            {
                var matched = courses.Where(x => x.Name != null && x.Name.ToLower().Trim() == name.ToLower().Trim()).ToList();
                return matched;
            }
            return null;
        }


        public bool Remove(int id)
        {
            try
            {
                List<Course> courses = Load();
                var foundCourse = courses.Single(x => x.Id == id);
                courses.Remove(foundCourse);
                Store(courses);
                return true;
            }
            catch (Exception e)
            {
                Loger.Log(e.Message);
                return false;

            }
        }

        public  void RemoveMany(List<int>ids)
        {
            List<Course> courses = Load();
            {
                var coursesToRemove = courses.Where(x => ids.Contains(x.Id)).ToList();
                if (coursesToRemove!= null && coursesToRemove.Count() > 0)
                {
                    courses.RemoveAll(x => courses.Select(y => y.Id).Contains(x.Id));
                }
                Store(courses);

            }
        }


        public bool Update(Course course)
        {
            try
            {
                List<Course> courses = Load();
                var updatecourse = courses.Single(x => x.Id == course.Id);
                updatecourse.Id = course.Id;
                updatecourse.Name = course.Name;
                updatecourse.PreReqId = course.PreReqId;
                updatecourse.Cost=course.Cost;
                updatecourse.Credit = course.Credit;
                updatecourse.CreatDate = course.CreatDate;
                updatecourse.CreatedBy = course.CreatedBy;
                Store(courses);
                return true;
            }
            catch (Exception e)
            {
                Loger.Log(e.Message);
                return false;
            }
           }

        public void SetCost(int coursId, decimal cost)
        {
            List<Course> courses = Load();
            if (courses != null)
            {
                var foundCourse = courses.SingleOrDefault(x => x.Id == coursId);
                if (foundCourse != null)
                {
                    foundCourse.Cost = cost;
                }
                Store(courses);

            }
            
        }

        
      
    }
}


