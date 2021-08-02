using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Models
{
    public class Payment:Entity
    { public int ForgenId { get; set; }
        public int Amount { get; set;}
        public DateTime CreatDate {get; set;}
        public string CreatedBy {get;set;}
    }
}
