using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omran.Sama.Server.Global
{// Singleton
    public class Settings
    { 
        public string ApplicationName { get; set;}
        public int ApplicationVersion { get; set;}
        private static Settings _settings;
        private  Settings()
        {
           
        }
        public static Settings GetInstance()
        {
            if (_settings == null)
             _settings = new Settings();
            return _settings;
        }
    }
}
