using Omran.Sama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Services
{
   public interface IScheduleService
    {
        List<Schedule> Load();
        Schedule LoadById(int id);
        bool Add(Schedule schedule);
        bool Remove(int id);
        bool Update(Schedule schedule);



    }
}
