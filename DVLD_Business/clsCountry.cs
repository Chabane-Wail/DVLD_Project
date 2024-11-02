using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using DVLD_Access;

namespace DVLD_Business
{
    public class clsCountry
    {



        public int CountryID { get; set; }
        public string CountryName { get; set; }
         



        public clsCountry()
        {

            this.CountryID = -1;

            this.CountryName = "";
 


        }





        public clsCountry(int CountryID, string CountryName)
        {


            this.CountryID = CountryID;

            this.CountryName = CountryName;

           

        }




        public static clsCountry Find(int CountryID)
        {

            string CountryName = "";


            bool isfouund = clsCountryData.GetCountryInfoByID(CountryID, ref CountryName);


            if (isfouund)
            {

                return new clsCountry(CountryID,  CountryName);
            }
            else
            {
                return null;
            }





        }




        public static clsCountry Find(string CountryName)
        {

            int CountryID = -1;


            bool isfouund = clsCountryData.GetCountryInfoByCountryName(ref CountryID,   CountryName);


            if (isfouund)
            {

                return new clsCountry(CountryID, CountryName);
            }
            else
            {
                return null;
            }





        }


        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
            
        }



    }
}
