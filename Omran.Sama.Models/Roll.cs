using Omran.Sama.Commen.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Models
{
     public class Roll:Entity
    {
        public string RollDiscription { get; set;}
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
    }
}
