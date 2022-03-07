using Microsoft.AspNetCore.Mvc;
using Omran.Sama.Commen.Constants;
using Omran.Sama.Models;
using Omran.Sama.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omran.Sama.Server.Controllers
{ [Route(RouteConstants.EmployeeRout)]
    public class EmployeeController:Controller
    {
        private EmployeeService _service = new EmployeeService();

        public EmployeeController()
        {

        }

        [HttpGet("[Action]")]

        public List<Employee> Load()
        {
            var employees = _service.Load();
            return Load();

        }
        [HttpPost("[Action]")]
        public Employee LoadById( int id)
        {
            return _service.LoadById(id);
           
        }
        [HttpPost("[Action]")]
        public bool Add([FromBody] Employee employee)
        {

          return _service.Add(employee);
        }

        [HttpPost("[Action]")]
        public  List<Employee> GetEmployeeByname([FromBody] Employee employee)
        {
            return _service.GetEmployeeByName(employee.FirstName, employee.LastName);
        }

        [HttpPost("[Action]")]
        public bool Remove(int id)
        {
            return _service.Remove(id);

        }

        [HttpPost("[Action]")]
        public bool Update([FromBody] Employee employee)
        {

            return _service.Update(employee);
        }











    }
}
