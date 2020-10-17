using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kheyrie
{
    public class Class_DB
    {
        public static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\kheyri.mdf;Integrated Security=True;Connect Timeout=30");
        public static SqlDataAdapter adaptor = new SqlDataAdapter();
        public static DataTable dt = new DataTable();
        public static SqlCommand query = new SqlCommand();

        public static string user = " ";
        public static void refresh(string Sselect)
        {
            Class_DB.query.CommandText = "SELECT * FROM " + Sselect;
            Class_DB.dt.Clear();
            Class_DB.query.Connection = connection;
            Class_DB.connection.Open();
            Class_DB.adaptor.SelectCommand = query;
            Class_DB.adaptor.SelectCommand.Connection = connection;
            Class_DB.adaptor.Fill(dt);
            Class_DB.connection.Close();
        }
    }
}
