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
    public partial class Form4 : Form
    {
        
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand query = new SqlCommand();
            int date , date2;
            string datte1 , datte2;
            datte1 = comboBox6.SelectedItem.ToString() + comboBox4.SelectedItem.ToString() + comboBox5.SelectedItem.ToString();
            datte2 = comboBox1.SelectedItem.ToString() + comboBox3.SelectedItem.ToString() + comboBox2.SelectedItem.ToString();
            date = Convert.ToInt32(datte1);
            date2 = Convert.ToInt32(datte2);
            try
            {
                

                Class_DB.dt.Clear();
                query.CommandText = "select * from mddjo where [namefname]=@namefname and date>@date1 and date<@date2 ";

                 datte1 = comboBox6.SelectedItem.ToString() + comboBox4.SelectedItem.ToString() + comboBox5.SelectedItem.ToString();
                 datte2 = comboBox1.SelectedItem.ToString() + comboBox3.SelectedItem.ToString() + comboBox2.SelectedItem.ToString();

                 date = Convert.ToInt32(datte1);
                date2 = Convert.ToInt32(datte2);

                query.Parameters.Add("@namefname", SqlDbType.NVarChar).Value = textBox1.Text.Trim();
                query.Parameters.Add("@date1", SqlDbType.Int).Value = date;
                query.Parameters.Add("@date2", SqlDbType.Int).Value = date2;

                Class_DB.dt.Clear();
                query.Connection = Class_DB.connection;
                Class_DB.connection.Open();
                Class_DB.adaptor.SelectCommand = query;
                Class_DB.adaptor.SelectCommand.Connection = Class_DB.connection;
                Class_DB.adaptor.Fill(Class_DB.dt);
                query.ExecuteNonQuery();
                Class_DB.connection.Close();
                //dataGridView1.DataSource = dataTable1;
            }
            catch { MessageBox.Show("لطفا مقادیر را صحیح وارد کنید"); }

            dataGridView1.Columns["date"].Visible = false;
            dataGridView1.Columns["dates"].HeaderText = "تاریخ";
            dataGridView1.Columns["namefname"].HeaderText = "نام ونام خانوادگی";
            dataGridView1.Columns["mablagh"].HeaderText = "مبلغ";
            dataGridView1.Columns["nopardakht"].HeaderText = "نوع پرداخت";
            dataGridView1.Columns["nokomak"].HeaderText = "نوع کمک";
            dataGridView1.Columns["id"].HeaderText = "شماره";

            
            SqlCommand query1 = new SqlCommand();
            DataTable dt = new DataTable();
            query1.CommandText = "select sum([mablagh]) as جمع from [dbo].[mddjo] where namefname=@namefname and date>@date1 and date<@date2 group by namefname ";
            query1.Parameters.Add("@namefname", SqlDbType.NVarChar).Value = textBox1.Text.Trim();

            dt.Clear();
            query1.Connection = Class_DB.connection;
            Class_DB.connection.Open();
            Class_DB.adaptor.SelectCommand = query1;
            Class_DB.adaptor.SelectCommand.Connection = Class_DB.connection;
            Class_DB.adaptor.Fill(dt);
            query.ExecuteNonQuery();
            Class_DB.connection.Close();
            dataGridView2.DataSource = dt;
        }
    }
}
