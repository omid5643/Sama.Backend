using Omran.Sama.Models;
using Omran.Sama.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Tests
{
   class EmployeeServiceTests
    {

        private EmployeeService service = new EmployeeService();



        public void TestLoad()
        {

            var employees = service.Load();
          
        }
         

        public void TestAdd()
        {
            Employee employee = new Employee { Id = 44, FirstName = "Jack", LastName = "Jason", Age = 44};
            employee.PhoneNumbers = new string[] { "8185555" };
            service.Add(employee);

        }
        public void TestRemove()
        {

            service.Remove(1);
        }

        public void TestUpdate()
        {
            Employee employee = new Employee { Id = 2,FirstName="sam"};
            service.Update(employee);
        }
    }
}
