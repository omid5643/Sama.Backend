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
   public class InstructorDbProvider
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
                Log.Loger(e.Message);
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


    }
}
