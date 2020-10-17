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
    public partial class Form6 : Form
    {
        
        public Form6()
        {
            InitializeComponent();
        }

        // crate DB conenctio
        function cs = new function();
        bool enter = true;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            Class_DB.dt.Columns.Clear();
            Class_DB.refresh("khayer");
            dataGridView1.DataSource = Class_DB.dt;

            dataGridView1.Columns["date"].Visible = false;
            dataGridView1.Columns["dates"].HeaderText = "تاریخ";
            dataGridView1.Columns["namefname"].HeaderText = "نام ونام خانوادگی";
            dataGridView1.Columns["mablagh"].HeaderText = "مبلغ";
            dataGridView1.Columns["nopardakht"].HeaderText = "نوع پرداخت";
            dataGridView1.Columns["nokomak"].HeaderText = "نوع کمک";
            dataGridView1.Columns["id"].HeaderText = "شماره";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand query = new SqlCommand();
            if (enter)
            {
                try
                {
                    query.CommandText = "insert into [dbo].[khayer]([namefname],[mablagh],[nopardakht],[date],[nokomak],[dates])VALUES(@name,@mablagh,@nopardakht,@date,@nokomak,@dates)";

                    string datte = comboBox3.SelectedItem.ToString() + comboBox5.SelectedItem.ToString() + comboBox4.SelectedItem.ToString();

                    int date = Convert.ToInt32(datte);

                    query.Parameters.Add("@name", SqlDbType.NVarChar).Value = textBox5.Text.Trim();
                    query.Parameters.Add("@mablagh", SqlDbType.Int).Value = Convert.ToInt32(textBox4.Text.Trim());
                    query.Parameters.Add("@nopardakht", SqlDbType.NVarChar).Value = Convert.ToString(comboBox1.SelectedItem);
                    query.Parameters.Add("@nokomak", SqlDbType.NVarChar).Value = Convert.ToString(comboBox2.SelectedItem);
                    query.Parameters.Add("@date", SqlDbType.Int).Value = date;
                    query.Parameters.Add("@dates", SqlDbType.NVarChar).Value = comboBox3.SelectedItem + "/" + comboBox5.SelectedItem + "/" + comboBox4.SelectedItem;

                    query.Connection = Class_DB.connection;
                    Class_DB.connection.Open();
                    query.ExecuteNonQuery();
                    Class_DB.connection.Close();
                    //this.oleDbDataAdapter1.Update(dataTable1);
                }
                catch { MessageBox.Show("لطفا مقادیر را صحیح وارد کنید"); }
            }

           
            cs.tableupdatee("select * from [dbo].[khayer]");
            //dataGridView1.DataSource = dt_show;
            enter = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button6.Visible = true;

            textBox5.Text = dataGridView1.CurrentRow.Cells["namefname"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["mablagh"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["nopardakht"].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells["nokomak"].Value.ToString();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            SqlCommand query = new SqlCommand();
            query.CommandText = "DELETE FROM[dbo].[khayer] where id=@id";
            query.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;

            query.Connection = Class_DB.connection;
            Class_DB.connection.Open();
            query.ExecuteNonQuery();
            Class_DB.connection.Close();

            cs.tableupdatee("select * from [dbo].[khayer]");
            dataGridView1.DataSource = Class_DB.dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button6.Visible = false;
            textBox4.Text = "";
            textBox5.Text = "";
            enter = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string datte = comboBox3.SelectedItem.ToString() + comboBox5.SelectedItem.ToString() + comboBox4.SelectedItem.ToString();
            SqlCommand query = new SqlCommand();
            int date = Convert.ToInt32(datte);
            if (enter)
            {
                query.CommandText = "update [dbo].[khayer] set namefname=@name,mablagh=@mablagh,nopardakht=@nopardakht,date=@date,nokomak=@nokomak,dates=@dates where id=@id";

                datte = comboBox3.SelectedItem.ToString() + comboBox5.SelectedItem.ToString() + comboBox4.SelectedItem.ToString();

                date = Convert.ToInt32(datte);

                int id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
                query.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
                query.Parameters.Add("@name", SqlDbType.NVarChar).Value = textBox5.Text.Trim();
                query.Parameters.Add("@mablagh", SqlDbType.Int).Value = Convert.ToInt32(textBox4.Text.Trim());
                query.Parameters.Add("@nopardakht", SqlDbType.NVarChar).Value = Convert.ToString(comboBox1.SelectedItem);
                query.Parameters.Add("@nokomak", SqlDbType.NVarChar).Value = Convert.ToString(comboBox2.SelectedItem);
                query.Parameters.Add("@date", SqlDbType.Int).Value = date;
                query.Parameters.Add("@dates", SqlDbType.NVarChar).Value = comboBox3.SelectedItem + "/" + comboBox5.SelectedItem + "/" + comboBox4.SelectedItem;

                query.Connection = Class_DB.connection;
                Class_DB.connection.Open();
                query.ExecuteNonQuery();
                Class_DB.connection.Close();
                enter = false;
            }

            cs.tableupdatee("select * from [dbo].[khayer]");
            dataGridView1.DataSource = Class_DB.dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
