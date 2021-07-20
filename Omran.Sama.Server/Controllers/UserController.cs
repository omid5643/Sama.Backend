using Microsoft.AspNetCore.Mvc;
using Omran.Sama.Commen.Constants;
using Omran.Sama.Commen.DTOs;
using Omran.Sama.Models;
using Omran.Sama.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omran.Sama.Server.Controllers
{
    [Route(RouteConstants.UserRout)]
    public class UserController:Controller
    {

        private UserService _service = new UserService();
        public UserController()
        {
        }

        [HttpGet("[Action]")]
        public List<User> Load()
        {
            return _service.Load();
        }

        [HttpPost("[Action]")]
        public User LoadById(int id)
        {
            return _service.LoadById(id);
        }

        [HttpPost("[Action]")]

        public bool Add([FromBody]User user)
        {
            return _service.Add(user);
        }
        [HttpPost("[Action]")]
        public List<User> GetByName([FromBody]UserDTO userDto)
        {

            return _service.GetByName(userDto.FirstName,userDto.LastName);
        }
        [HttpPost("[Action]")]
        public bool Remove(int id)
        {
            return _service.Remove(id);
        }
        [HttpPost("[Action]")]
        public bool Update([FromBody]User user)
        {
            return _service.Update(user);
        }


    }
}
