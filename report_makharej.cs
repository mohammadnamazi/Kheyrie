using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Data.OleDb;
namespace kheyrie
{
    public partial class Form7 : Form
    {
        
        public Form7()
        {
           InitializeComponent();
        }
        public static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\kheyri.mdf;Integrated Security=True;Connect Timeout=30");
        public static SqlDataAdapter adaptor = new SqlDataAdapter();
        public static DataTable dt_show = new DataTable();
        function cs = new function();
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            int date , date2;
            string datte1, datte2;
            try
            {
                
                SqlCommand query = new SqlCommand();
                dt_show.Clear();
                query.CommandText = "select * from makharej where  date>@date1 and date<@date2 ";

                datte1 = comboBox6.SelectedItem.ToString() + comboBox4.SelectedItem.ToString() + comboBox5.SelectedItem.ToString();
                datte2 = comboBox1.SelectedItem.ToString() + comboBox3.SelectedItem.ToString() + comboBox2.SelectedItem.ToString();

                date = Convert.ToInt32(datte1);
                date2 = Convert.ToInt32(datte2);

                query.Parameters.Add("@date1", SqlDbType.Int).Value = date;
                query.Parameters.Add("@date2", SqlDbType.Int).Value = date2;

                dt_show.Clear();
                query.Connection = connection;
                connection.Open();
                adaptor.SelectCommand = query;
                adaptor.SelectCommand.Connection = connection;
                adaptor.Fill(dt_show);
                query.ExecuteNonQuery();
                connection.Close();
                dataGridView1.DataSource = dt_show;
            }
            catch { MessageBox.Show("لطفا مقادیر را صحیح وارد کنید"); }

            
            SqlCommand query1 = new SqlCommand();
            DataTable dt = new DataTable();
            query1.CommandText = "select sum([cost]) as جمع from [dbo].[makharej] where  date>@date1 and date<@date2  ";

            datte1 = comboBox6.SelectedItem.ToString() + comboBox4.SelectedItem.ToString() + comboBox5.SelectedItem.ToString();
            datte2 = comboBox1.SelectedItem.ToString() + comboBox3.SelectedItem.ToString() + comboBox2.SelectedItem.ToString();

            date = Convert.ToInt32(datte1);
            date2 = Convert.ToInt32(datte2);

            query1.Parameters.Add("@date1", SqlDbType.Int).Value = date;
            query1.Parameters.Add("@date2", SqlDbType.Int).Value = date2;

            dt.Clear();
            query1.Connection = connection;
            connection.Open();
            adaptor.SelectCommand = query1;
            adaptor.SelectCommand.Connection = connection;
            adaptor.Fill(dt);
            query1.ExecuteNonQuery();
            connection.Close();
            dataGridView2.DataSource = dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
