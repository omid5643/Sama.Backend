using Omran.Sama.Models;
using Omran.Sama.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Tests
{
     public class BankServiceTests
    {

        BankService bankService = new BankService();



        public void TestLoad()
        {

            bankService.Load();
        }

        public void TestAdd()
        {
            Bank bank = new Bank {Name="Chase",RoutingNumber=111000614,CreateBy="dv molavi" };

            bankService.Add(bank);

        }

        public void TestRemove()
        {

            bankService.Remove(1);

        }
        public void TestByLoadId()
        {

            bankService.LoadById(4);

        }

        public void TestUpdate()
        {
            Bank bank = new Bank {Id=3,Name="Bank Of America",RoutingNumber=111000025};
            bankService.Update(bank);

        }

    }
}
