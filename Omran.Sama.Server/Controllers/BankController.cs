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
    [Route(RouteConstants.BankRout)]
    public class BankController
    {

        private BankService  _service = new BankService();
        public BankController()
        {
        }

        [HttpGet("[Action]")]
        public List<Bank> Load()
        {
            return _service.Load();
        }

        [HttpPost("[Action]")]
        public Bank LoadById(int id)
        {
            return _service.LoadById(id);
        }

        [HttpPost("[Action]")]

        public bool Add([FromBody]Bank bank)
        {
            return _service.Add(bank);
        }

        [HttpPost("[Action]")]
        public bool Remove(int id)
        {
            return _service.Remove(id);
        }

        [HttpPost("[Action]")]
        public bool Update([FromBody]Bank bank)
        {
            return _service.Update(bank);
        }

      

    }
}

