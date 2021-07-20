using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Models
{
   public class Account:Entity
    { 
       public int ForeignId { get; set; }
       public  string Number { get; set; }
       public int Balance { get; set; }
       public DateTime BalaceDueDate { get; set; }
       public DateTime CreateDate { get; set; }
       public string CreateBy { get; set; }
    }
}

