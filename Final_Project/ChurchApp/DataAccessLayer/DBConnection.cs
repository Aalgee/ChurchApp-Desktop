using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal static class DBConnection
    {
        // This is the connection string that is used to connect to the database
        private static string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=ChurchDB;Integrated Security=True";

        // This constructs a connection using the connection string and returns it to the class that called it.
        public static SqlConnection GetConnection()
        {
            var conn = new SqlConnection(connectionString);
            return conn;
        }
    }
}
