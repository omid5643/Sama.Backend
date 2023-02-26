using Newtonsoft.Json;
using Omran.Sama.Commen;
using Omran.Sama.Commen.Constants;
using Omran.Sama.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Services
{
    public class PaymentService : IDisposable
    {

        private readonly string fullPath = DbConstants.DbPath + DbConstants.PaymentFile;
        private StudentService studentService = new StudentService();
        private AccountService accountService = new AccountService();
        //private SQLConnection _mySQLConnection = new SQLConnection();

        //public void GetDataFromSQL()
        //{ // this is unmanagaed code, CLR cant use garbage collector to free this memeory
        //    var sqlConnection=_mySQLConnection.Open("myserver://");
        //  var data= sqlConnection.ExecuteCommand("Select * from Students");


        //}

        private bool Store(List<Payment> payments)
        {
            try
            {
                string serialized = JsonConvert.SerializeObject(payments);
                File.WriteAllText(fullPath, serialized);
                return true;

            }
            catch (Exception e)
            {
                Log.Loger(e.Message);
                return false;
            }
        }

        public List<Payment> Load()
        {
            if (File.Exists(fullPath))
            {

                string content = File.ReadAllText(fullPath);
                List<Payment> payments = JsonConvert.DeserializeObject<List<Payment>>(content);
                return payments;
            }
            return null;

        }
        public Payment LoadById(int id)
        {
            try
            {
                List<Payment> payments = Load();
                var matched = payments.Single(x => x.Id == id);
                return matched;
            }
            catch (Exception e)
            {
                Log.Loger(e.Message);
                return null;
            }
        }
        public bool Remove(int id)
        {
            try
            {
                List<Payment> payments = Load();
                var matched = payments.Single(x => x.Id == id);
                payments.Remove(matched);
                Store(payments);
                return true;

            }
            catch (Exception e)
            {
                Log.Loger(e.Message);
                return false;
            }

        }
        public bool Add(Payment payment)
        {
            List<Payment> payments = Load();
            if (payments != null)
            {
                var matched = payments.SingleOrDefault(x => x.Id == payment.Id);
                if (matched != null)
                    return false;
                int greatestId = payments.OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();
                payment.Id = greatestId + 1;
                payment.CreatedBy = "System";
                payment.CreatDate = System.DateTime.Now;
                payments.Add(payment);
                Store(payments);
                return true;
            }

            else
            {
                List<Payment> newPayments = new List<Payment>();
                payment.Id = 1;
                payment.CreatedBy = "System";
                payment.CreatDate = System.DateTime.Now;
                newPayments.Add(payment);
                Store(newPayments);
                return true;
            }

        }
        public bool Update(Payment payment)
        {
            try
            {
                List<Payment> payments = Load();
                var foundPaymentToUpdate = payments.Single(x => x.ForgenId == payment.Id);
                foundPaymentToUpdate.ForgenId = payment.Id;
                foundPaymentToUpdate.Amount = payment.Id;
                foundPaymentToUpdate.CreatedBy = payment.CreatedBy;
                foundPaymentToUpdate.CreatDate = payment.CreatDate;
                return true;
            }
            catch (Exception e)
            {
                Log.Loger(e.Message);
            }
            return false;

        }
        //public int GetSumOfPayments()
        //{
        //    List<Payment> payments = Load();
        //    //int sum=0;

        //    //foreach (Payment payment in payments)
        //    //{
        //    //    sum =  sum+ payment.Amount;

        //    //}

        //    //return sum;
        //    return payments.Sum(x => x.Amount);
        //}

        //        {
        //            Dictionary<int, int> reportList = new Dictionary<int, int>();
        //    var students = studentService.Load();
        //    var payments = Load();
        //            foreach (Student student in students)
        //            {
        //                var count = payments.Count(x => x.Id == student.Id);
        //    reportList.Add(student.Id, count);
        //            }




        //return reportList;
        //        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }

    




   


}










