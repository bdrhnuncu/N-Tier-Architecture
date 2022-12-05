using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.DataAccess.Configuration
{
    public static class ConfigureConnString
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Kirala.com.WebAPI"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("MSSQLDb");
            }
        }
    }
}
