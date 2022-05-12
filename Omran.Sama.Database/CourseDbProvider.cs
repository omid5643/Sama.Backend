using Newtonsoft.Json;
using Omran.Sama.Commen;
using Omran.Sama.Commen.Constants;
using Omran.Sama.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Omran.Sama.Database
{
     public class CourseDbProvider
    {

        public readonly string fullPath = DbConstants.DbPath + DbConstants.CourseFile;

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
                Log.Loger(e.Message);
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
    }
}
