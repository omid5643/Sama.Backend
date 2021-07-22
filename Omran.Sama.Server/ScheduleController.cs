using Microsoft.AspNetCore.Mvc;
using Omran.Sama.Commen.Constants;
using Omran.Sama.Models;
using Omran.Sama.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omran.Sama.Server
{
    [Route(RouteConstants.ScheduleRout)]
    public class ScheduleController:Controller
    {
       

      private ScheduleService _service  = new ScheduleService();


        public ScheduleController()
        {


        }
        [HttpGet("[Action]")]

        public List<Schedule> Load()
        {

            return _service.Load();

        }

        [HttpPost("[Action]")]
        public Schedule LoadById(int id)
        {
            return _service.LoadById(id);
        }
        [HttpPost("[Action]")]

        public bool Add([FromBody] Schedule schedule)
        {
            return _service.Add(schedule);
        }
        [HttpPost("[Action]")]
        public bool Remove([FromBody]int id)
        {

            return _service.Remove(id);
        }
        [HttpPost("[Action]")]

        public bool Update([FromBody] Schedule schedule)
        {

            return _service.Update(schedule);

        }

    }
}
