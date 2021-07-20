using Omran.Sama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Services
{
    public interface IInstructorService
    {
       
        List<Instructor> Load();
        Instructor LoadById(int id);
        bool Add(Instructor instructor);
        List<Instructor> GetByName(string firstName,string lastName);
        bool Remove(int id);
        bool Update(Instructor instructor);
        
        
       
    }
}

