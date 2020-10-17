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
    public partial class Form1 : Form
    {
       
        
        public Form1()
        {
            
            InitializeComponent();
        }



      
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(); 
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            // oleDbDataAdapter1.SelectCommand = new OleDbCommand("SELECT * FROM [vaziat]", oleDbConnection1);
            // DataTable dt = new DataTable();

            // oleDbDataAdapter1.Fill(this.dataTable1);
            //dataGridView1.DataSource = dataTable1;
            // oleDbDataAdapter1.Update(dataTable1);

            //dtt.Clear();
            //query.Connection = connection;
            //connection.Open();
            //adaptor.SelectCommand = query;
            //adaptor.SelectCommand.Connection = connection;
            //adaptor.Fill(dtt);
            //query.ExecuteNonQuery();
            //connection.Close();
            //dataGridView1.DataSource = dtt;

            SqlCommand query = new SqlCommand();
            query.CommandText = "select * from [dbo].[vaziat]";
            Class_DB.dt.Clear();
            query.Connection = Class_DB.connection;
            Class_DB.connection.Open();
            Class_DB.adaptor.SelectCommand = query;
            Class_DB.adaptor.SelectCommand.Connection = Class_DB.connection;
            Class_DB.adaptor.Fill(Class_DB.dt);
            Class_DB.connection.Close();
            dataGridView1.DataSource = Class_DB.dt;



        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form7 frm = new Form7();
            frm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
