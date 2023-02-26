using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Models
{
    public class Student :Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
        public string[] PhoneNumbers { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }



    }
}
