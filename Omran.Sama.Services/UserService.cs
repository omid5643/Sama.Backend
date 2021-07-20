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
   public class UserService
    {
        private readonly string fullPath = DbConstants.DbPath + DbConstants.UserFile;
        public List<User> Load()
        {
            if (File.Exists(fullPath))
            {
                string content = File.ReadAllText(fullPath);
                List<User> users = JsonConvert.DeserializeObject<List<User>>(content);
                return users;
            }
            return null;
        }
          private bool Store(List<User> users)
        {
            try
            {
                string serilizad = JsonConvert.SerializeObject(users);
                File.WriteAllText(fullPath, serilizad);
                return true;
            }
            catch (Exception e)
            {
                Loger.Log(e.Message);
                return false;
            }

        }
        
        public  User LoadById(int id)
        {
            try
            {
                List<User> users = Load();
                var matched = users.Single(x => x.Id == id);
                return matched;
            }

            catch (Exception e)
            {
                Loger.Log(e.Message);
                return null;
            }
       }

       public bool Add(User user)

        {   List<User> users = Load();
            if (users != null)
            {
                var matched = users.SingleOrDefault(x => x.Id == user.Id);
                if (matched != null)
                    return false;
            
            int greatestId = users.OrderByDescending(x => x.Id).Select(x => x.Id).First();
            user.Id = greatestId + 1;
            user.CreateBy = "System";
            user.CreateDate = System.DateTime.Now;

            users.Add(user);
             Store(users);
            return true; }
            else
            {
                List<User> newusers = new List<User>();
                user.Id= 1;
                user.CreateBy = "System";
                user.CreateDate = System.DateTime.Now;
                newusers.Add(user);
               Store(newusers);
                return true;

            }
       }
               
       public List<User> GetByName(string firstName, string lastName)
       {
            List<User> users = Load();
            var matched = users.Where(x => x.FirstName != null && x.LastName != null &&
                                      x.FirstName.ToLower().Trim() == firstName.ToLower().Trim()&&
                                      x.LastName.ToLower().Trim() == lastName.ToLower().Trim()).ToList();
            return matched;
       }
       public bool Remove(int id)
        {
            try
            {
                List<User> users = Load();
                var matched = users.Single(x => x.Id == id);
                return true;
            }

            catch(Exception e)
            {
                Loger.Log(e.Message);
                return false;
            }

        }
        public bool Update(User user)
        {
            try
            {
                List<User> users = Load();
                var userToUpdate = users.Single(x => x.Id == user.Id);
                userToUpdate.Id = user.Id;
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.LastName = user.LastName;
                userToUpdate.UserName = user.UserName;
                userToUpdate.PassWord = user.PassWord;
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
