using System;
using System.Data.SqlClient;

namespace DatabaseConnectivity
{
    public class Program
    {
        private static SqlConnection connection;
        private static string connectionString = "Server=localhost; Database=db_hr_dts; User Id=sa; Password=Passw@rd; Trusted_Connection=False; MultipleActiveResultSets=true";

        public static void Main(string[] args)
        {
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Connection Open!");
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Connection Failed : " + e);
            }
        }
    }
}