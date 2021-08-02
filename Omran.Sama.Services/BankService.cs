using Newtonsoft.Json;
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
    public class BankService:IBank
    {
        private readonly string fullPath = DbConstants.DbPath + DbConstants.BankFile;

        private bool Store(List<Bank> banks)
        {
            try
            {
                string serialized = JsonConvert.SerializeObject(banks);
                File.WriteAllText(fullPath, serialized);
                return true;
            }
            catch (Exception e)
            {
                Loger.Log(e.Message);
            }
            return false;
        }

        public List<Bank> Load()
        {
            if (File.Exists(fullPath))
            {
                string content = File.ReadAllText(fullPath);
                List<Bank> banks = JsonConvert.DeserializeObject<List<Bank>>(content);
                return banks;
            }
            return null;
        }

        public Bank LoadById(int id)
        {
            try
            {
                List<Bank> banks = Load();
                var matched = banks.Single(x => x.Id == id);
                return matched;
            }

            catch (Exception e)
            {
                Loger.Log(e.Message);
                return null;
            }

        }

        public bool Add(Bank bank)
        {
            List<Bank> banks = Load();
            if (banks != null && banks.Count()>0)
            {

                var matched = banks.SingleOrDefault(x => x.Id == bank.Id);
                if (matched != null)
                    return false;
                int greatestId = banks.OrderByDescending(x => x.Id).Select(x => x.Id).First();
                bank.Id = greatestId + 1;
                bank.CreateBy = "System";
                bank.CreateDate = System.DateTime.Now;
                banks.Add(bank);
                Store(banks);
                return true;
            }

            else

            {
                List<Bank> newBanks = new List<Bank>();
                bank.Id = 1;
                bank.CreateBy = "System";
                bank.CreateDate = System.DateTime.Now;
                newBanks.Add(bank);
                Store(newBanks);
                return true;
            }

        }

        public bool Remove(int id)
        {
            try
            {
                List<Bank> banks = Load();
                var bankToRemove = banks.Single(x=>x.Id==id);
                banks.Remove(bankToRemove);
                Store(banks);
                return true;

            }
            catch (Exception e)
            {

                Loger.Log(e.Message);
                return false;
            }


        }
        public bool Update(Bank bank)
        {

            try
            {
                List<Bank> banks = Load();
                var foundStudent = banks.Single(x => x.Id == bank.Id);

                foundStudent.Id = bank.Id;
                foundStudent.Name = bank.Name;
                foundStudent.RoutingNumber = bank.RoutingNumber;
                foundStudent.CreateDate = bank.CreateDate;
                foundStudent.CreateBy = bank.CreateBy;
                Store(banks);

                return true;
            }
            catch (Exception e)
            {
                Loger.Log(e.Message);
                return false;
            }
        }


    












}
}
