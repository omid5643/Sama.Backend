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
      public class EmployeeDbProvider
    {


        private readonly string fullPath = DbConstants.DbPath + DbConstants.EmployeeFile;





        public List<Employee> Load()
        {
            if (File.Exists(this.fullPath))
            {
                string content = File.ReadAllText(this.fullPath);
                List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(content);
                return employees;

            }


            return null;
        }


        public bool Store(List<Employee> employees)
        {
            try
            {
                string serialized = JsonConvert.SerializeObject(employees);
                File.WriteAllText(this.fullPath, serialized);

                return true;
            }
            catch (Exception e)
            {

                Log.Loger(e.Message);
                return false;

            }
        }

    }
}
