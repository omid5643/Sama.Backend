using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Omran.Sama.Server.Global;

namespace Omran.Sama.Server
{
    public class Program
    {
        public static IConfiguration Config { get; } = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile("proc.json")
            .AddEnvironmentVariables()
            .Build();
        public static void Main(string[] args)
        {
            Settings settings = Settings.GetInstance();
            settings.ApplicationName="Omran";
            Settings settings1 = Settings.GetInstance();
          
            
         
          

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseConfiguration(Config)
                .UseStartup<Startup>()
                .Build();
    }
}
