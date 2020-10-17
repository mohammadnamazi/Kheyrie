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
    public partial class Form2 : Form
    {
       
        public Form2()
        {
           
            InitializeComponent();
        }
        // connect to DB

        function cs = new function();

        

        bool enter = true;
        private void Form2_Load(object sender, EventArgs e)
        {
            
            Class_DB.dt.Columns.Clear();
            Class_DB.refresh("mddjo");
            dataGridView1.DataSource = Class_DB.dt;

            dataGridView1.Columns["dates"].HeaderText = "تاریخ";
            dataGridView1.Columns["namefname"].HeaderText = "نام ونام خانوادگی";
            dataGridView1.Columns["fathername"].HeaderText = "نام پدر";
            dataGridView1.Columns["melicode"].HeaderText = "کد ملی";
            dataGridView1.Columns["mablagh"].HeaderText = "مبلغ";
            dataGridView1.Columns["frome"].HeaderText = "از محل";
            dataGridView1.Columns["nokomak"].HeaderText = "نوع کمک";
            dataGridView1.Columns["id"].HeaderText = "شماره";


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)||char.IsControl(e.KeyChar)))
                e.Handled =true ;
        }

        private void button3_Click(object sender, EventArgs e)
      {
            string datte = comboBox1.SelectedItem.ToString() + comboBox3.SelectedItem.ToString() + comboBox2.SelectedItem.ToString();
            SqlCommand query = new SqlCommand();
            int date = Convert.ToInt32(datte);
            if (enter == true)
            {
                try
                {
                    //insert data to table in DB

                    query.CommandText = "insert into [dbo].[mddjo]([namefname],[fathername],[melicode],[mablagh],[date],[frome],[nokomak],[dates])VALUES(@namefname,@fathername,@melicode,@mablagh,@date,@from,@nokomak,@dates)";

                     datte = comboBox1.SelectedItem.ToString() + comboBox3.SelectedItem.ToString() + comboBox2.SelectedItem.ToString();

                     date = Convert.ToInt32(datte);
                    query.Parameters.Add("@namefname", SqlDbType.NVarChar).Value = textBox1.Text.Trim();
                    query.Parameters.Add("@fathername", SqlDbType.NVarChar).Value = textBox3.Text.Trim();
                    query.Parameters.Add("@melicode", SqlDbType.Int).Value = Convert.ToInt32(textBox4.Text.Trim());
                    query.Parameters.Add("@mablagh", SqlDbType.Int).Value = Convert.ToInt32(textBox5.Text.Trim());
                    query.Parameters.Add("@date", SqlDbType.Int).Value = date;
                    query.Parameters.Add("@from", SqlDbType.NVarChar).Value = Convert.ToString(comboBox5.SelectedItem);
                    query.Parameters.Add("@nokomak", SqlDbType.NVarChar).Value = Convert.ToString(comboBox4.SelectedItem);
                    query.Parameters.Add("@dates", SqlDbType.NVarChar).Value = Convert.ToString(comboBox1.SelectedItem + "/" + comboBox3.SelectedItem + "/" + comboBox2.SelectedItem);



                    query.Connection =Class_DB.connection;
                    Class_DB.connection.Open();
                    query.ExecuteNonQuery();
                    Class_DB.connection.Close();
                }
                catch { MessageBox.Show("لطفا مقادیر را صحیح وارد کنید"); }
            }
            enter = false;
            cs.tableupdatee("select * from [dbo].[mddjo]");
            //dataGridView1.DataSource = dt_show;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // displays table data in textboxs for edit
            button6.Visible = true;
            button3.Visible = false;
            

            textBox5.Text = dataGridView1.CurrentRow.Cells["namefname"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["mablagh"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["nopardakht"].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells["nokomak"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand query = new SqlCommand();
            //delet a row in table
            int id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());

            query.CommandText = "DELETE FROM[dbo].[mddjo] where id=@id";
            query.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;

            query.Connection = Class_DB.connection;
            Class_DB.connection.Open();
            query.ExecuteNonQuery();
            Class_DB.connection.Close();

            cs.tableupdatee("select * from [dbo].[mddjo]");
            dataGridView1.DataSource = Class_DB.dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            button6.Visible = false;

            textBox1.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = "";
            comboBox5.Text = "";
            comboBox1.Text = ""; comboBox2.Text = ""; comboBox3.Text = ""; comboBox4.Text = "";
            enter = true;
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //updates table row
            string datte = comboBox1.SelectedItem.ToString() + comboBox3.SelectedItem.ToString() + comboBox2.SelectedItem.ToString();

           int date = Convert.ToInt32(datte);

            SqlCommand query = new SqlCommand();

            query.CommandText = "update [dbo].[mddjo] set namefname=@namefname,fathername=@fathername,melicode=@melicode,mablagh=@mablagh,date=@date,frome=@from,nokomak=@nokomak,dates=@dates where id=@id)";

             datte = comboBox1.SelectedItem.ToString() + comboBox3.SelectedItem.ToString() + comboBox2.SelectedItem.ToString();

             date = Convert.ToInt32(datte);

            int id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            query.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
            query.Parameters.Add("@namefname", SqlDbType.NVarChar).Value = textBox1.Text.Trim();
            query.Parameters.Add("@fathername", SqlDbType.NVarChar).Value = textBox3.Text.Trim();
            query.Parameters.Add("@melicode", SqlDbType.Int).Value = Convert.ToInt32(textBox4.Text.Trim());
            query.Parameters.Add("@mablagh", SqlDbType.Int).Value = Convert.ToInt32(textBox5.Text.Trim());
            query.Parameters.Add("@date", SqlDbType.Int).Value = date;
            query.Parameters.Add("@from", SqlDbType.NVarChar).Value = Convert.ToString(comboBox5.SelectedItem);
            query.Parameters.Add("@nokomak", SqlDbType.NVarChar).Value = Convert.ToString(comboBox4.SelectedItem);
            query.Parameters.Add("@dates", SqlDbType.NVarChar).Value = Convert.ToString(comboBox1.SelectedItem + "/" + comboBox3.SelectedItem + "/" + comboBox2.SelectedItem);



            query.Connection = Class_DB.connection;
            Class_DB.connection.Open();
            query.ExecuteNonQuery();
            Class_DB.connection.Close();
        }
    }
}
