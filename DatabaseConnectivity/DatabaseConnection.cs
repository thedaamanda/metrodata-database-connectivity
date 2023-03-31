using System.Data.SqlClient;

namespace DatabaseConnectivity
{
    public class DatabaseConnection
    {
        private SqlConnection connection;
        private string connectionString;

        public DatabaseConnection(string serverName, string databaseName, string userName, string password)
        {
            // Memasukkan data koneksi ke dalam string
            connectionString = "Server=" + serverName + ";Database=" + databaseName + ";User Id=" + userName + ";Password=" + password + "; Trusted_Connection=False; MultipleActiveResultSets=true";

            // Menginisialisasi SqlConnection object
            connection = new SqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                // Membuka koneksi ke database
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                // Melakukan penanganan error jika gagal membuka koneksi
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public void CloseConnection()
        {
            // Menutup koneksi ke database
            connection.Close();
        }

        public SqlConnection GetConnection()
        {
            // Mengembalikan SqlConnection object
            return connection;
        }
    }
}
