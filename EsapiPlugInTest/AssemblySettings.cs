using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EsapiPlugInTest
{
    class AssemblySettings
    {
        public static string ServerName => GetAppSetting("ServerName");

        private static string GetAppSetting(string key)
        {
            try
            {
                var asmPath = Assembly.GetExecutingAssembly().Location;
                var config = ConfigurationManager.OpenExeConfiguration(asmPath);
                var setting = config.AppSettings.Settings[key];
                return setting.Value;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Error reading configuration setting", e);
            }
        }
    }
}
