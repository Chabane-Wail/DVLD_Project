using System;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics;


namespace DVLD_Access
{
    public class clsCountryData
    {

        public static bool GetCountryInfoByID(int CountryID, ref string CountryName)
        { 

            bool isfound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Countries where CountryID=@CountryID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@CountryID", CountryID);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {


                    isfound = true;

                    CountryName = (string)reader["CountryName"];
                    
                   





                }
                else
                {

                    isfound = false;

                }

                reader.Close();




            }
            catch (Exception ex)
            {
                clsGlobel.EventLogView(ex.Message, EventLogEntryType.Error);
                isfound = false;

            }
            finally
            {


                connection.Close();



            }





            return isfound;
        }







        public static bool GetCountryInfoByCountryName(ref int CountryID, string CountryName)
        {

            bool isfound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Countries where CountryName=@CountryName";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@CountryName", CountryName);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {


                    isfound = true;

                    CountryID = (int)reader["CountryID"];
                    




                }
                else
                {

                    isfound = false;

                }

                reader.Close();




            }
            catch (Exception ex)
            {
                clsGlobel.EventLogView(ex.Message, EventLogEntryType.Error);

            }
            finally
            {


                connection.Close();



            }





            return isfound;
        }




         
         
        public static DataTable GetAllCountries()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT    CountryID, CountryName FROM   Countries";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                clsGlobel.EventLogView(ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }



 


  



    }
}
