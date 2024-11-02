using DVLD_Business;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public class clsGlobel
    {

        public static clsUser CurrentUser;

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {

            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD_Project";

            string user = "Username";
            string pasword = "Password";


            try
            {
                // Write the value to the Registry
                Registry.SetValue(keyPath, user, Username, RegistryValueKind.String);
                Registry.SetValue(keyPath, pasword, Password, RegistryValueKind.String);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }


        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD_Project";

            string user = "Username";
            string pasword = "Password";


            try
            {
                // Write the value to the Registry
                Username= Registry.GetValue(keyPath, user, null )as string;
                Password= Registry.GetValue(keyPath, pasword, null) as string;

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }


        }




    }
}
