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
    public partial class Form3 : Form
    {
        //public DataTable dataTable1 = new DataTable();
        //public OleDbConnection oleDbConnection1 = new OleDbConnection();
        //public OleDbDataAdapter oleDbDataAdapter1 = new OleDbDataAdapter();
        //public OleDbDataAdapter oleDbDataAdapter2 = new OleDbDataAdapter();
        //public DataTable dataTable2 = new DataTable();
        public Form3()
        {
            InitializeComponent();
        }

        public static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\kheyri.mdf;Integrated Security=True;Connect Timeout=30");
        public static SqlDataAdapter adaptor = new SqlDataAdapter();
        public static DataTable dt_show = new DataTable();


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand query = new SqlCommand();
            string datte1 = comboBox6.SelectedItem.ToString() + comboBox4.SelectedItem.ToString() + comboBox5.SelectedItem.ToString();
            string datte2 = comboBox1.SelectedItem.ToString() + comboBox3.SelectedItem.ToString() + comboBox2.SelectedItem.ToString();

            int date = Convert.ToInt32(datte1);
            int date2 = Convert.ToInt32(datte2);

            try
            {
                //dataTable1.Clear();
                //this.oleDbDataAdapter1.SelectCommand = new OleDbCommand("SELECT * FROM khayer WHERE namefname=@namefname AND date>@date1 AND date<@date2", this.oleDbConnection1);
                //this.oleDbDataAdapter1.Fill(this.dataTable1);
                //this.dataGridView1.DataSource = dataTable1;

                //this.oleDbDataAdapter1.SelectCommand.Parameters.AddWithValue("@date1", typeof(int)).Value = date;
                //this.oleDbDataAdapter1.SelectCommand.Parameters.AddWithValue("@date2", typeof(int)).Value = date2;
                //this.oleDbDataAdapter1.SelectCommand.Parameters.AddWithValue("@namefname", typeof(string)).Value = textBox1.Text.Trim();
               

                dt_show.Clear();
                query.CommandText = "select * from khayer where [namefname]=@namefname and date>@date1 and date<@date2 ";

                 datte1 = comboBox6.SelectedItem.ToString() + comboBox4.SelectedItem.ToString() + comboBox5.SelectedItem.ToString();
                 datte2 = comboBox1.SelectedItem.ToString() + comboBox3.SelectedItem.ToString() + comboBox2.SelectedItem.ToString();

               date = Convert.ToInt32(datte1);
                date2 = Convert.ToInt32(datte2);

                query.Parameters.Add("@namefname", SqlDbType.NVarChar).Value = textBox1.Text.Trim();
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


                dataGridView1.Columns["date"].Visible = false;
                dataGridView1.Columns["dates"].HeaderText = "تاریخ";
                dataGridView1.Columns["namefname"].HeaderText = "نام ونام خانوادگی";
                dataGridView1.Columns["mablagh"].HeaderText = "مبلغ";
                dataGridView1.Columns["nopardakht"].HeaderText = "نوع پرداخت";
                dataGridView1.Columns["nokomak"].HeaderText = "نوع کمک";
                dataGridView1.Columns["id"].HeaderText = "شماره";
            }
            catch { MessageBox.Show("لطفا مقادیر را صحیح وارد کنید"); }

           

           


            //dataTable2.Clear();
            //this.oleDbDataAdapter2.SelectCommand = new OleDbCommand("SELECT SUM([mablagh]) as جمع FROM khayer WHERE namefname=@namefname AND date>@date1 AND date<@date2 group by namefname", this.oleDbConnection1);
            //this.oleDbDataAdapter2.Fill(this.dataTable2);
            //this.dataGridView2.DataSource = dataTable2;

            //this.oleDbDataAdapter2.SelectCommand.Parameters.AddWithValue("@date1", typeof(int)).Value = date;
            //this.oleDbDataAdapter2.SelectCommand.Parameters.AddWithValue("@date2", typeof(int)).Value = date2;
            //this.oleDbDataAdapter2.SelectCommand.Parameters.AddWithValue("@namefname", typeof(string)).Value = textBox1.Text.Trim();

            SqlCommand query1 = new SqlCommand();
            DataTable dt = new DataTable();
            query1.CommandText = "select sum([mablagh]) as جمع from [dbo].[khayer] where namefname=@namefname and date>@date1 and date<@date2 group by namefname ";
            query1.Parameters.Add("@namefname", SqlDbType.NVarChar).Value = textBox1.Text.Trim();
            query1.Parameters.Add("@date1", SqlDbType.Int).Value = date;
            query1.Parameters.Add("@date2", SqlDbType.Int).Value = date2;
            dt.Clear();
            query1.Connection = connection;
            connection.Open();
            adaptor.SelectCommand = query1;
            adaptor.SelectCommand.Connection = connection;
            adaptor.Fill(dt);
            query.ExecuteNonQuery();
            connection.Close();
            dataGridView2.DataSource = dt;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
