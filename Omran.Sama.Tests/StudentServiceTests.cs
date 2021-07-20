using Omran.Sama.Models;
using Omran.Sama.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Tests
{
    class StudentServiceTests
    {
        private StudentService service = new StudentService();

        public void TestUpdate()
        {
            Student student = new Student { Id = 12,
                FirstName = "sam",
                LastName = "Abaei",
                Age = 36, Address = new Address { Addr1 = "76544" } };

            bool done = this.service.Update(student);
        }
        public void TestLoad()
        {
            Student loadStudent = this.service.LoadById(1);
        }
        public void TestAdd()
        {
            Student student = new Student();
            student.Id = 23;
            student.FirstName = "Titi";
            student.LastName = "soal";
            student.Age = 24;
            student.PhoneNumbers = new string[] { "999" };
           student.Address = new Address { Addr1 = "221" };
           bool done = this.service.Add(student);

       }
        public void TestRemove()
        {
            bool succeded = service.Remove(11);
        }
        public void TestRemoveMany()
        {
            List<int> ids = new List<int> { 14,15,16,17};
            service.RemoveMany(ids);
        }
        public void TestName()
        {
          List<Student>st =service.GetByName("SAhar"," ghoresi"); 
        }

    }
   
}
