using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Commen
{
   


        public static class Log
        {
            public static string fullpath = @"C:\OmranLog\" + "Log.txt";
            public static void Loger(string message)
            {
                message = DateTime.Now + message + Environment.NewLine;
                File.AppendAllText(fullpath, message);
            }
        }





    }






