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
    public class ScheduleService : IScheduleService
    {
        // this is the database path
        private readonly string fullPath = DbConstants.DbPath + DbConstants.ScheduleFile;
        private bool Store(List<Schedule> schedules)
        {
            try
            {

                string serialized = JsonConvert.SerializeObject(schedules);
                File.WriteAllText(this.fullPath, serialized);
                return true;
            }

            catch (Exception e)
            {
                Loger.Log(e.Message);
                return false;

            }



        }

        public List<Schedule> Load()
        {
            if (File.Exists(this.fullPath))
            {

                string content = File.ReadAllText(this.fullPath);
                List<Schedule> schedules = JsonConvert.DeserializeObject<List<Schedule>>(content);

                return schedules;
            }
            return null;

        }
        public Schedule LoadById(int id)
        {
            try
            {
                List<Schedule> schedules = Load();
                var matched = schedules.Single(x => x.Id == id);

                return matched;
            }

            catch (Exception e)
            {
                Loger.Log(e.Message);
                return null;
            }

        }
        public bool Add(Schedule schedule)
        {
            return true;
        }
        public bool Remove(int id)
        {
            return true;

        }
        public bool Update(Schedule schedule)
        {

            return true;

        }


    }
}
