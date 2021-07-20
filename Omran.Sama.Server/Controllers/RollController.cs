using Microsoft.AspNetCore.Mvc;
using Omran.Sama.Commen.Constants;
using Omran.Sama.Models;
using Omran.Sama.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omran.Sama.Server.Controllers
{
    [Route(RouteConstants.RollRout)]
    public class RollController:Controller
    {
        private RollService _service = new RollService();

        public RollController()
        {
        }


        [HttpGet("[action]")]

        public List<Roll> Load()
        {
            return _service.Load();
        }

        [HttpPost("[Action]")]

        public Roll LoadById(int id)
        {
            return _service.LoadById(id);
        }

        [HttpPost("[Action]")]

        public bool Add([FromBody]Roll roll)
        {
            return _service.Add(roll);
        }
        [HttpPost("[Action]")]

    
        [HttpPost("[Action]")]

        public bool Remove(int id)
        {
            return _service.Remove(id);
        }
        [HttpPost("[Action]")]

        public bool Update([FromBody]Roll roll)
        {
            return _service.Update(roll);
        }
    }
}
