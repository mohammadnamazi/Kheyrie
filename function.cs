using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kheyrie
{
    class function
    {
        public static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\kheyri.mdf;Integrated Security=True;Connect Timeout=30");
        public static SqlDataAdapter adaptor = new SqlDataAdapter();
        public static DataTable dt_show = new DataTable();
        public void tableupdatee( string input)
        {
            //updates
            SqlCommand query = new SqlCommand();
            query.CommandText = input;
            dt_show.Clear();
            query.Connection = connection;
            connection.Open();
            adaptor.SelectCommand = query;
            adaptor.SelectCommand.Connection = connection;
            adaptor.Fill(dt_show);
            connection.Close();
        }
    }
}
