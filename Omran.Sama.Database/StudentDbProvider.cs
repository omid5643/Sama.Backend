using Newtonsoft.Json;
using Omran.Sama.Commen;
using Omran.Sama.Commen.Constants;
using Omran.Sama.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Omran.Sama.Database
{
    public class StudentDbProvider
    {
        private readonly string fullPath = DbConstants.DbPath + DbConstants.StudentFile;
        public bool Store(List<Student> students)
        {
            try
            {

                string serialized = JsonConvert.SerializeObject(students);
                File.WriteAllText(this.fullPath, serialized);
                return true;
            }

            catch (Exception e)
            {
                Log.Loger(e.Message);
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


    }
}
