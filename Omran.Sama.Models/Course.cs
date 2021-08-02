using Omran.Sama.Commen.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Models
{
   public class Course:Entity
    {
      
        public string Name {get; set;}
        public int Credit {get; set;}
        public int? PreReqId {get; set;}
        public decimal Cost {get; set;}
        public DateTime CreatDate {get; set; }
        public string CreatedBy {get; set;}
    }
}
