using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace CGCommon
{
  
        public class DBConnection
        {
            public static string GetConnection()
            {
                try
                {
                    return ConfigurationManager.ConnectionStrings["DBCnnString"].ToString();

                }
                catch (Exception ce)
                {

                    throw new ApplicationException("Unable to get DB Connection string from Config File. Contact Administrator" + ce);
                }
            }
        }
    }



