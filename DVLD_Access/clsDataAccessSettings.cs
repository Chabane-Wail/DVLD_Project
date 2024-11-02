using System;
using System.Configuration; 

namespace DVLD_Access
{
    internal class clsDataAccessSettings
    {
       public static string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

      
    }
}
