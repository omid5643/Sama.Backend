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
    public class AccountService
    {
        private readonly string fullPath = DbConstants.DbPath + DbConstants.AccountFile;
        private StudentService studentService = new StudentService();
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
                Loger.Log(e.Message);
                return false;

            }
        }
          public Account LoadById(int id)
        {
            try
            {
                List<Account> accounts = Load();
                var matched = accounts.Single(x => x.Id == id);
                return matched;
            }
            catch (Exception e)
            {
                Loger.Log(e.Message);
                return null;
            }

        }
        public bool Add(Account account)
        {
            List<Account> accounts = Load();
            if (accounts != null)
            {
                var matched = accounts.SingleOrDefault(x => x.Id == account.Id);
                if (matched != null)
                    return false;
                int greatestId = accounts.OrderByDescending(x => x).Select(x => x.Id).FirstOrDefault();
                account.Id = greatestId + 1;
                account.CreateBy = "System";
                account.CreateDate = System.DateTime.Now;
                accounts.Add(account);
                Store(accounts);
                return true;
            }
            else
            {
                List<Account> newAccounts = new List<Account>();
                account.Id = 1;
                account.CreateBy = "System";
                account.CreateDate = System.DateTime.Now;
                newAccounts.Add(account);
                Store(newAccounts);
                return true;

            }
        }

        public bool Update(Account account)
        {
            try
            {
                List<Account> accounts = Load();
                var matched = accounts.Single(x => x.Id == account.Id);
                matched.Id = account.Id;
                matched.Number = account.Number;
                matched.Balance = account.Balance;
                matched.CreateBy = account.CreateBy;
                matched.CreateDate = account.CreateDate;
                Store(accounts);
                return true;
            }
            catch (Exception e)
            {
                Loger.Log(e.Message);
                return false;
            }
        }
        public bool Remove(int id)
        {
            try
            {
                List<Account> accounts = Load();
                var matched = accounts.Single(x => x.Id == id);
                accounts.Remove(matched);
                Store(accounts);
                return true;
            }
            catch (Exception e)
            {
                Loger.Log(e.Message);
                return false;
            }
        }

        public void CreatStudentAccounts()
        {
            //all=new+existing
            List<Account> existingAccounts = Load();   
            List<Student> students = studentService.Load();
            List<Account> newAccounts = new List<Account>();
            List<Account> allAccounts = new List<Account>();
            int id = 1;
            foreach (Student student in students)
            {
                
                if (existingAccounts == null)
                    {
                        //create an account for the student and add it to the list
                        Account account = new Account();
                        account.Id = id;
                        account.ForeignId = student.Id;
                       account.Number = "000"+student.Id;
                       newAccounts.Add(account);
                       id++;
                    }
                    else
                    {
                        var found = existingAccounts.SingleOrDefault(x => x.ForeignId == student.Id);
                        //if not found
                        if (found == null)
                        {
                            //create an account for the student and add it to the list
                            Account account = new Account();
                        int greatestId =existingAccounts.OrderByDescending(x => x).Select(x => x.Id).FirstOrDefault();
                        account.Id = greatestId + 1;
                        account.ForeignId = student.Id;
                            account.Number = "000"+student.Id;
                            newAccounts.Add(account);
                        }
                    }
     

                }
                    if (existingAccounts != null)
                      allAccounts.AddRange(existingAccounts);
                    if(newAccounts!=null)
                      allAccounts.AddRange(newAccounts);

                    //write your list of new accounts to the database
                       Store(allAccounts);
        }
        public Account GetStudentAccount(Student student)
        {
            try
            {
                List<Account> accounts = Load();
                var foundStudent = accounts.SingleOrDefault(x => x.ForeignId == student.Id);
                return foundStudent;
            }
            catch(Exception e)
            {
                Loger.Log(e.Message);
                return null;
            }

        }
       
       

        }
        }
    


