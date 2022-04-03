using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCourt
{
    class Database
    {
        public static SqlConnection ConnectDB()
        {
            string connString = @"Server=RABBY-PC\SQLEXPRESS;Database=FoodCourt;User Id=sa;Password=1234;";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}
