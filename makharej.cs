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
    public partial class Form5 : Form
    {
        
        public Form5()
        {
            InitializeComponent();

        }

        function cs = new function();

        

        bool enter = true;
        private void Form5_Load(object sender, EventArgs e)
        {
            
            Class_DB.dt.Columns.Clear();
            Class_DB.refresh("makharej");
            dataGridView1.DataSource = Class_DB.dt;

            dataGridView1.Columns["date"].Visible = false;
            dataGridView1.Columns["dates"].HeaderText = "تاریخ";
            dataGridView1.Columns["description"].HeaderText = "شرح";
            dataGridView1.Columns["from"].HeaderText = "منبع";
            dataGridView1.Columns["cost"].HeaderText = "مبلغ";
            dataGridView1.Columns["id"].HeaderText = "شماره";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string datte = comboBox1.SelectedItem.ToString() + comboBox2.SelectedItem.ToString() + comboBox3.SelectedItem.ToString();

            int date = Convert.ToInt32(datte);
            if (enter)
            {
                try
               {

                    SqlCommand query = new SqlCommand();
                    query.CommandText = "insert into [dbo].[makharej]([description],[cost],[date],[dates],[from])VALUES(@description,@cost,@date,@dates,@from)";

                    datte = comboBox1.SelectedItem.ToString() + comboBox2.SelectedItem.ToString() + comboBox3.SelectedItem.ToString();

                     date = Convert.ToInt32(datte);
                    query.Parameters.Add("@description", SqlDbType.NVarChar).Value = textBox1.Text.Trim();
                    query.Parameters.Add("@cost", SqlDbType.Int).Value = textBox2.Text.Trim();
                    query.Parameters.Add("@date", SqlDbType.Int).Value = date;
                    query.Parameters.Add("@dates", SqlDbType.NVarChar).Value = Convert.ToString(comboBox1.SelectedItem + "/" + comboBox2.SelectedItem + "/" + comboBox3.SelectedItem);
                    query.Parameters.Add("@from", SqlDbType.NVarChar).Value = Convert.ToString(comboBox4.SelectedItem);

                    query.Connection = Class_DB.connection;
                    Class_DB.connection.Open();
                    query.ExecuteNonQuery();
                    Class_DB.connection.Close();
                    enter = false;
                 }
                  catch { MessageBox.Show("لطفا مقادیر را صحیح وارد کنید"); }
            }
            
            cs.tableupdatee("select * from [dbo].[makharej]");
            dataGridView1.DataSource = Class_DB.dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            //this.oleDbDataAdapter1.DeleteCommand = new OleDbCommand("DELETE FROM makharej WHERE id = @id", this.oleDbConnection1);
            //this.oleDbDataAdapter1.DeleteCommand.Parameters.AddWithValue("@id", typeof(int)).Value = id;
            SqlCommand query = new SqlCommand();

            query.CommandText = "DELETE FROM[dbo].[makharej] where id=@id";
            query.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;

            query.Connection = Class_DB.connection;
            Class_DB.connection.Open();
            query.ExecuteNonQuery();
            Class_DB.connection.Close();

            cs.tableupdatee("select * from [dbo].[makharej]");
            dataGridView1.DataSource = Class_DB.dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button6.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            enter = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["description"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["cost"].Value.ToString();
            comboBox4.Text= dataGridView1.CurrentRow.Cells["from"].Value.ToString();
            button1.Visible = false;
            button6.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (enter)
            {
                string datte = comboBox1.SelectedItem.ToString() + comboBox2.SelectedItem.ToString() + comboBox3.SelectedItem.ToString();
                int id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
                int date = Convert.ToInt32(datte);

                id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());

                SqlCommand query = new SqlCommand();
                query.CommandText = "update [dbo].[makharej] set description=@description,cost=@cost,date=@date,dates=@dates,[from]=@from  where id=@id ";
                query.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
                query.Parameters.Add("@description", SqlDbType.NVarChar).Value = textBox1.Text.Trim();
                query.Parameters.Add("@cost", SqlDbType.Int).Value = Convert.ToInt32(textBox2.Text.Trim());
                query.Parameters.Add("@date", SqlDbType.Int).Value = date;
                query.Parameters.Add("@dates", SqlDbType.NVarChar).Value = Convert.ToString(comboBox1.SelectedItem + "/" + comboBox2.SelectedItem + "/" + comboBox3.SelectedItem);
                query.Parameters.Add("@from", SqlDbType.NVarChar).Value = Convert.ToString(comboBox4.SelectedItem);

                query.Connection = Class_DB.connection;
                Class_DB.connection.Open();
                query.ExecuteNonQuery();
                Class_DB.connection.Close();
                enter = false;
            }

            cs.tableupdatee("select * from [dbo].[makharej]");
            dataGridView1.DataSource = Class_DB.dt;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }
    }
}
