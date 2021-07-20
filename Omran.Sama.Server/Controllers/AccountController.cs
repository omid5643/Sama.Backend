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
    [Route(RouteConstants.AccountRout)]
    public class AccountController : Controller
    {

        private AccountService _service = new AccountService();
        public AccountController()
        {
        }

        [HttpGet("[Action]")]
        public List<Account> Load()
        {
            return _service.Load();
        }

        [HttpPost("[Action]")]
        public Account LoadById(int id)
        {
            return _service.LoadById(id);
        }

        [HttpPost("[Action]")]

        public bool Add([FromBody]Account account)
        {
            return _service.Add(account);
        }

        [HttpPost("[Action]")]
        public bool Remove(int id)
        {
            return _service.Remove(id);
        }

        [HttpPost("[Action]")]
        public bool Update([FromBody]Account account)
        {
            return _service.Update(account);
        }

        [HttpPost("[Action]")]
        public Account GetStudentAccount([FromBody]Student student)
        {
            return _service.GetStudentAccount(student);
        }

    }
}

