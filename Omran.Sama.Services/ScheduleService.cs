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
            List<Schedule> schedules = Load();
            if(schedules!=null)
            {
                var matched = schedules.SingleOrDefault(x=>x.Id==schedule.Id);
                if (matched != null)
                    return false;
                int greatestId = schedules.OrderByDescending(x => x.Id).Select(x => x.Id).First();
                schedule.Id = greatestId + 1;
                schedule.StartTime = System.TimeSpan.Zero;
                schedule.EndTime = System.TimeSpan.Zero;
                schedules.Add(schedule);
                Store(schedules);

                return true;
            }

            else
            {
                List<Schedule> newSchudles = new List<Schedule>();
                schedule.Id = 1;
                schedule.StartTime = System.TimeSpan.Zero;
                schedule.EndTime = System.TimeSpan.Zero;

                newSchudles.Add(schedule);
                Store(newSchudles);
                return true;
            }

          
        }
        public bool Remove(int id)
        {
            try
            {
                List<Schedule> schedules = new List<Schedule>();
                var matched = schedules.Single(x=>x.Id==id);
                schedules.Remove(matched);
                Store(schedules);

                return true;
            }
            catch(Exception e)
            {
                Loger.Log(e.Message);

                return false;
            }
            
        }
        public bool Update(Schedule schedule)
        {
            try
            {
                List<Schedule> schedules = new List<Schedule>();
                var foundSchedule = schedules.Single(x=>x.Id==schedule.Id);
                foundSchedule.Id = schedule.Id;
                foundSchedule.StartTime = schedule.StartTime;
                foundSchedule.EndTime = schedule.EndTime;

                return true;
            }

            catch(Exception e)
            {
                Loger.Log(e.Message);

                return false;
            }
        }


    }
}
