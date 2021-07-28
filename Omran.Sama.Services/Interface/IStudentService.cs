using Omran.Sama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Services
{
   public interface IStudentService
    {
  
        List<Student> Load();
        Student LoadById(int id);
        bool Add(Student student);
        List<Student> GetByName(string firstName,string lastName);
        bool Remove(int id);
        bool Update(Student student);
       
        
       
    }
}
