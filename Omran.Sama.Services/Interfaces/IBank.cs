using Omran.Sama.Models;
using System.Collections.Generic;

namespace Omran.Sama.Services
{
    public interface IBank
    {
        List<Bank> Load();
        Bank LoadById(int id);
        bool Add(Bank bank);
        bool Remove(int id);
        bool Update(Bank bank);
    }
}