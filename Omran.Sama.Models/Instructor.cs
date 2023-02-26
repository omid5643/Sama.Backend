using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Models
{
    public class Instructor : Entity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public string[] PhoneNumber { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
       

    }
}
