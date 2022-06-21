using Newtonsoft.Json;
using Omran.Sama.Commen;
using Omran.Sama.Commen.Constants;
using Omran.Sama.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Omran.Sama.Database
{
 public class AccountDbProvider
    {

        private readonly string fullPath = DbConstants.DbPath + DbConstants.AccountFile;
     
        public List<Account> Load()
        {
            if (File.Exists(fullPath))
            {
                string Content = File.ReadAllText(fullPath);
                List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(Content);
                return accounts;
            }
            return null;
        }
        private bool Store(List<Account> accounts)
        {
            try
            {

                string serialized = JsonConvert.SerializeObject(accounts);
                File.WriteAllText(this.fullPath, serialized);
                return true;
            }



            catch (Exception e)
            {
                Log.Loger(e.Message);
                return false;

            }
        }





    }



}
