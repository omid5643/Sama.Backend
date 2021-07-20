using Omran.Sama.Models;
using Omran.Sama.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Tests
{
    public  class RollServiceTests
    {

        RollService Service = new RollService();
        
        public void TestAdd()
        {
            Roll roll = new Roll {RollDiscription=Commen.Enums.Roll.Student.ToString()};

            Service.Add(roll);
        }
        


    }
}
