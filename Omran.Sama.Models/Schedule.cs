using Omran.Sama.Commen.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Models
{
    public class Schedule:Entity
    {

        public TimeSpan StartTime {get; set;}
        public TimeSpan EndTime {get; set;}
        public WeekDays[] Day {get; set;}
        public DateTime CreatDate  {get; set;} 
        public string CreatedBy {get; set;}


    }
}
