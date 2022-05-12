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
   public  class EmployeeService
    {
        private readonly string fullPath = DbConstants.DbPath + DbConstants.EmployeeFile;





        public List<Employee> Load() 
        {
            if (File.Exists(this.fullPath))
            {
                string content = File.ReadAllText(this.fullPath);
                List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(content);
                return employees;

            }


            return null;
        }


        public bool Store(List<Employee> employees)
        {
            try
            {
                string serialized = JsonConvert.SerializeObject(employees);
                File.WriteAllText(this.fullPath, serialized);

                return true;
            }
            catch (Exception e)
            {

                Loger.Log(e.Message);
                return false;

            }
        }

        public Employee LoadById(int id)
        {
            try
            {

                List<Employee> employees = Load();
                var foundEmployee = employees.Single(x => x.Id == id);

                return foundEmployee;
            }
            catch (Exception e)
            {

                Loger.Log(e.Message);

                return null;

            }

        }





        public bool Add(Employee employee)
        {
            List<Employee> employees = Load();

            if(employees!=null&& employees.Count>0)
            {
                var matched = employees.SingleOrDefault(x => x.Id == employee.Id);
                if (matched != null)
                    return false;
                int greatestId = employees.OrderByDescending(x => x.Id).Select(x => x.Id).First();
                employee.Id = greatestId + 1;
                employee.CreateDate = System.DateTime.Now;
                employee.CreateBy = "System";
                employees.Add(employee);
                Store(employees);
                return true;

            }
            else{

                List<Employee> newEmployees = new List<Employee>();
                employee.Id=1;
                employee.CreateDate = System.DateTime.Now;
                employee.CreateBy = "System";
                newEmployees.Add(employee);
                Store(newEmployees);

                return true;
            }




            
        }
        public  List<Employee> GetEmployeeByName(string firstName,string lastName)
        {

            List<Employee> employees = Load();
            if (employees != null)
            {
               var matched =employees.Where(x =>  x.FirstName!=null&& 
                                                  x.LastName!=null&&
                                                  x.FirstName.ToLower().Trim()==firstName.ToLower().Trim()&&
                                                  x.LastName.ToLower().Trim()==lastName.ToLower().Trim()).ToList();

                return matched;
            }

            return null;
        }
        public bool Remove(int id)
        {
            try
            {
                List<Employee> employees = Load();
                var matched = employees.Single(x => x.Id == id);
                employees.Remove(matched);
                Store(employees);

                return true;
            }


            catch(Exception e)
            {

                Loger.Log(e.Message);
                return false;

            }

        }
        public bool Update(Employee employee)
        {
            try
            {
                List<Employee> employees = Load();
                var employeeToUpdate = employees.Single(x => x.Id == employee.Id);
                 employeeToUpdate.Id =employee.Id;
                 employeeToUpdate.FirstName = employee.FirstName;
                 employeeToUpdate.LastName = employee.LastName;
                 employeeToUpdate.Age = employee.Age;
                 employeeToUpdate.UserId = employee.UserId;
                 employeeToUpdate.Email = employee.Email;
                 employeeToUpdate.PhoneNumbers = employee.PhoneNumbers;
                 employeeToUpdate.Address = employee.Address;
                 employeeToUpdate.CreateDate = employee.CreateDate;
                 employeeToUpdate.CreateBy = employee.CreateBy;
                Store(employees);
                



                return true;
            }
            catch (Exception e)
            {
                Loger.Log(e.Message);

                return false;
            }



        }
       
      














    }
}
