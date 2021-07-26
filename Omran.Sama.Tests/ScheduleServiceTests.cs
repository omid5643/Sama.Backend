using Omran.Sama.Models;
using Omran.Sama.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Tests
{
   public class ScheduleServiceTests
    {
        private const string V = "";
        private ScheduleService scheduleService = new ScheduleService();

        public void Testload()
        {


            scheduleService.Load();

        }
         public void TestAdd()
        {
            Schedule schedule = new Schedule { StartTime = TimeSpan.MaxValue };
            

            scheduleService.Add(schedule);
       

        }

        public void TestRemove()
        {


            scheduleService.Remove(1);

        }

        public void TestUpdate()
        {
            Schedule schedule = new Schedule { Id=2,StartTime=TimeSpan.MaxValue,EndTime=TimeSpan.MaxValue };
            scheduleService.Update(schedule);
        }
    }
}
