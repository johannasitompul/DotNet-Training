using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpDALLibrary
{
    class MyConnection
    {
        SqlConnection conn;
        static MyConnection connection;
        private MyConnection()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        }
        public static SqlConnection GetConnection()
        {
            if (connection == null)
                connection = new MyConnection();
            return connection.conn;
        }
    }
}
