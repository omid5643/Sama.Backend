using Omran.Sama.Models;
using Omran.Sama.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Tests
{
   public class AccountServiceTests
    {
     private AccountService accountService = new AccountService();

        public void TestCreatAccount()
        {
            accountService.CreatStudentAccounts();
        }
        public void TestGetStudentByAccount()
        {
            Student student = new Student { Id=4};
         Account account =accountService.GetStudentAccount(student);
        }
        public void TestUpdate()
        {
            Account account = new Account {Id=5,Balance=1000 };
            accountService.Update(account);
        }

        public void TestUsing()
        {
            using (var paymentService=new PaymentService())
            {
                paymentService.Load();
            }
            //clr automatically calls dispose

            //var paymentService1 = new PaymentService();
            //try
            //{
            //    paymentService1.Load();
            //}

            //finally
            //{
            //    paymentService1.Dispose();
            //}
        }
    }
}
