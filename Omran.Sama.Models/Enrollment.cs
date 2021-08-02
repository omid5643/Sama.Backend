using Omran.Sama.Commen.Enums;
using Omran.Sama.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Models
{
   public  class Enrollment:Entity
    {
        public int StudentId {get; set;}
        public int CourseId {get; set;}
        public int InstructorId {get; set;}
        public Semester Semester {get; set;}
        public DateTime CreateDate {get; set;}
        public string CreateBy {get; set;}
        public Grade Grade {get; set;}
    }
}
