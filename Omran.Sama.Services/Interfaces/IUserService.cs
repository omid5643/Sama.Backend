using Omran.Sama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Services.Interfaces
{
   public interface IUserService
    {
        List<User> Load();
        User LoadById(int id);
        bool Add(User user);
        List<User> GetByName(string firstName, string lastName);
        bool Remove(int id);
        bool Update(User user);


    }
}
