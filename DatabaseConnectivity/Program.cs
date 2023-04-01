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
            // GetAllRegion();
            // InsertRegion("Region 1");
            // GetRegionById(1);
            // UpdateRegion(5, "Region 2");
        }

        // method untuk menampilkan semua data region
        public static void GetAllRegion()
        {
            // membuka koneksi
            dbConn.OpenConnection();

            try {
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
            } catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message);
            } finally {
                // menutup koneksi
                dbConn.CloseConnection();
            }
        }

        // method untuk menampilkan data region berdasarkan id
        public static void GetRegionById(int id)
        {
            // membuka koneksi
            dbConn.OpenConnection();

            try {
                // membuat sql command
                SqlCommand cmd = new SqlCommand("SELECT * FROM region WHERE id = @id", dbConn.GetConnection());

                // menambahkan parameter
                cmd.Parameters.AddWithValue("@id", id);

                // membuat sql data reader
                SqlDataReader reader = cmd.ExecuteReader();

                // membaca data
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("ID\t: " + reader.GetInt32(0));
                        Console.WriteLine("Name\t: " + reader.GetString(1));
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                // menutup sql data reader
                reader.Close();
            } catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message);
            } finally {
                // menutup koneksi
                dbConn.CloseConnection();
            }
        }


        // method untuk menambahkan data region
        public static void InsertRegion(string name)
        {
            // membuka koneksi
            dbConn.OpenConnection();

            // membuat begin transaction
            SqlTransaction transaction = dbConn.GetConnection().BeginTransaction();
            try {
                // membuat sql command
                SqlCommand cmd = new SqlCommand("INSERT INTO region (name) VALUES (@name)", dbConn.GetConnection(), transaction);

                // menambahkan parameter
                cmd.Parameters.AddWithValue("@name", name);

                // mengeksekusi sql command
                int result = cmd.ExecuteNonQuery();

                // menampilkan hasil eksekusi
                if (result > 0)
                {
                    Console.WriteLine("Data berhasil ditambahkan");
                }
                else
                {
                    Console.WriteLine("Data gagal ditambahkan");
                }

                // commit transaction
                transaction.Commit();
            } catch (Exception ex) {
                // rollback transaction
                transaction.Rollback();
                Console.WriteLine("Error: " + ex.Message);
            } finally {
                // menutup koneksi
                dbConn.CloseConnection();
            }
        }

        // method untuk mengubah data region
        public static void UpdateRegion(int id, string name)
        {
            // membuka koneksi
            dbConn.OpenConnection();

            // membuat begin transaction
            SqlTransaction transaction = dbConn.GetConnection().BeginTransaction();
            try {
                // membuat sql command
                SqlCommand cmd = new SqlCommand("UPDATE region SET name = @name WHERE id = @id", dbConn.GetConnection(), transaction);

                // menambahkan parameter
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);

                // mengeksekusi sql command
                int result = cmd.ExecuteNonQuery();

                // menampilkan hasil eksekusi
                if (result > 0)
                {
                    Console.WriteLine("Data berhasil diubah");
                }
                else
                {
                    Console.WriteLine("Data gagal diubah");
                }

                // commit transaction
                transaction.Commit();
            } catch (Exception ex) {
                // rollback transaction
                transaction.Rollback();
                Console.WriteLine("Error: " + ex.Message);
            } finally {
                // menutup koneksi
                dbConn.CloseConnection();
            }
        }
    }
}
