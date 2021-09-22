using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SalesForce.Models
{
  
      public class DBConnection
        {
            public static string GetConnection()
            {
                try
                {
                    return ConfigurationManager.ConnectionStrings["sql"].ToString();

                }
                catch (Exception ce)
                {

                    throw new ApplicationException("Unable to get DB Connection string from Config File. Contact Administrator" + ce);
                }
            }
        }
}