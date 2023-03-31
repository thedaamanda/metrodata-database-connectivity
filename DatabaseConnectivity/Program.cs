using System;
using System.Data.SqlClient;

namespace DatabaseConnectivity
{
    public class Program
    {
        // membuat objek DatabaseConnection
        private static DatabaseConnection dbConn = new DatabaseConnection("localhost", "db_hr_dts", "sa", "Passw@rd");

        public static void Main(string[] args)
        {
            GetAllRegion();
        }

        // method untuk menampilkan semua data region
        public static void GetAllRegion()
        {
            // membuka koneksi
            dbConn.OpenConnection();

            // membuat sql command
            SqlCommand cmd = new SqlCommand("SELECT * FROM region", dbConn.GetConnection());

            // membuat sql data reader
            SqlDataReader reader = cmd.ExecuteReader();

            // membaca data
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("ID\t: " + reader.GetInt32(0));
                    Console.WriteLine("Name\t: " + reader.GetString(1));
                    Console.WriteLine("=====================================");
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }

            // menutup sql data reader
            reader.Close();

            // menutup koneksi
            dbConn.CloseConnection();
        }
    }
}
