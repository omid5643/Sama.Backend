using Omran.Sama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Services
{
   public interface IAccountService
    {

        List<Account> Load();
        Account LoadById(int id);
        bool Add(Account account);
        bool Update(Account account);
        bool Remove(int id);
        void CreatStudentAccounts();
        Account GetStudentAccount(Student student);
        
          
        }


    }

