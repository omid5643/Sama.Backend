using Omran.Sama.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Commen.DTOs
{
   public class EnollmentDTO
    {
       public string StudentFirstName { get; set; }
       public string StudentLastName { get; set; }
       public string InstructorFirstName { get; set; }
       public string InstrutorLastName { get; set; }
       public string CourseName { get; set; }
       public Semester Semester { get; set; }
    }
}
