using Omran.Sama.Common;
using Omran.Sama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Services
{
  public  interface IEnrollmentService
    {
        List<Enrollment> Load();
        Enrollment LoadById(int id);
        bool Add(Enrollment enrollment);
        bool Remove(int id);
        bool Update(Enrollment enrollment);
        string Enroll(string studentFirstName,string studentLastName,
                      string instructorFirstName,string instrutorLastName,string courseName,Semester semester);

    }
}
