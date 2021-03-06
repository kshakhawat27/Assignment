using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCommon
{
    public static class AppSettings
    {
        public static string Version { get; private set; }
        public static string BaseURL { get; private set; }
        static AppSettings()

        {
            BaseURL = ConfigurationManager.AppSettings["BaseURL"];
            Version = ConfigurationManager.AppSettings["Version"];
        }
    }
}
