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
    public class RollService
    {
        private readonly string fullPath = DbConstants.DbPath + DbConstants.RollFile;
        public List<Roll> Load()
        {
            if (File.Exists(fullPath))
            {
                string content = File.ReadAllText(fullPath);
                List<Roll> rolls = JsonConvert.DeserializeObject<List<Roll>>(content);
                return rolls;
            }
            return null;
        }
        private bool Store(List<Roll> rolls)
        {
            try
            {
                string serilizad = JsonConvert.SerializeObject(rolls);
                File.WriteAllText(fullPath, serilizad);
                return true;
            }
            catch (Exception e)
            {
                Loger.Log(e.Message);
                return false;
            }

        }

        public Roll LoadById(int id)
        {
            try
            {
                List<Roll> rolls= Load();
                var matched = rolls.Single(x => x.Id == id);
                return matched;
            }

            catch (Exception e)
            {
                Loger.Log(e.Message);
                return null;
            }
        }

        public bool Add(Roll roll)

        {
            List<Roll> rolls = Load();
            if (rolls != null)
            {
                var matched = rolls.SingleOrDefault(x => x.Id == roll.Id);
                if (matched != null)
                    return false;

                int greatestId = rolls.OrderByDescending(x => x.Id).Select(x => x.Id).First();
                roll.Id = greatestId + 1;
                roll.CreateBy = "System";
                roll.CreateDate = System.DateTime.Now;
                rolls.Add(roll);
                Store(rolls);
                return true;
            }
            else
            {
                List<Roll> newRolls = new List<Roll>();
                roll.Id = 1;
                roll.CreateBy = "System";
                roll.CreateDate = System.DateTime.Now;
                newRolls.Add(roll);
                Store(newRolls);
                return true;

            }
        }  
        
        public bool Remove(int id)
        {
            try
            {
                List<Roll> rolls = Load();
                var matched = rolls.Single(x => x.Id == id);
                return true;
            }

            catch (Exception e)
            {
                Loger.Log(e.Message);
                return false;


            }

        }
        public bool Update(Roll roll)
        {
            try
            {
                List<Roll> rolls = Load();
                var userToUpdate = rolls.Single(x => x.Id == roll.Id);
                userToUpdate.Id = roll.Id;
                userToUpdate.RollDiscription= roll.RollDiscription;
                userToUpdate.CreateBy= roll.CreateBy;
                userToUpdate.CreateDate = roll.CreateDate;
               
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
