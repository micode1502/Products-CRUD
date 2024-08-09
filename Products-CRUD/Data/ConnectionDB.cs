using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products_CRUD.Data
{
    public class ConnectionDB
    {
        private string server = "localhost";
        private string database = "testdb";
        private string user = "root";
        private string password = "";

        private string chainConnection;
        private MySqlConnection connect;

        public ConnectionDB() 
        {
            chainConnection = "Database=" + database +
                "; DataSource=" + server +
                "; User Id=" + user +
                "; Password=" + password;
        }

        public MySqlConnection getConnect() 
        {
            try
            {
                if (connect == null)
                {
                    connect = new MySqlConnection(chainConnection);
                    connect.Open();
                }
                return connect;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in connection: " + e.Message);
                throw;
            }
        }
   

    }
}
