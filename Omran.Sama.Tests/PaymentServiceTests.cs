using Omran.Sama.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Tests
{
    public class PaymentServiceTests
    {

        PaymentService _paymentService = new PaymentService();


        public void TestSubmit()
        {

            _paymentService.Submit(150,5);
        }

        public void TestGetSumOfPayments()
        {

            _paymentService.GetSumOfPayments();
        }

        public void TestGetSumOfPaymentsStudent()
        {
            _paymentService.GetSumOfPaymentsForStudent(4);
          
        }

        public void GetStudentPaymentReport()
        {
            _paymentService.GetStudentPaymentReport();
        }


    }
}
