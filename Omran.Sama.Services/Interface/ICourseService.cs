using Omran.Sama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Services
{
  public  interface ICourseService
    {
        List<Course> Load();
        Course LoadById(int id);
        bool Add(Course course);
        List<Course> GetByName(string name);
        bool Update(Course course);
        bool Remove(int id);
       
    }
}

