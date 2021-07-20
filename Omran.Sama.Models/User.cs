using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Models
{
   public class User:Entity
    {

        public string FirstName { get;set;}
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public DateTime CreateDate { get; set;}
        public string CreateBy { get; set;}
        public int RollId { get; set;}
    }
}
