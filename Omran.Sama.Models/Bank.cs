using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Models
{
    public class Bank : Entity
    {
        public string Name {get; set;}
        public int RoutingNumber {get; set;}
        public DateTime CreateDate {get; set;}
        public string CreateBy {get; set;}

       
    }
}
