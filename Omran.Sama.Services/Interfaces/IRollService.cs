using Omran.Sama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Services.Interfaces
{
   public interface  IRollService
    {
        List<Roll> Load();
        Roll LoadById(int id);
        bool Add(Roll roll);
        bool Remove(int id);
        bool Update(Roll roll);


    }
}
