using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BookTracking
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=***;Initial Catalog=***;uid=***;pwd=***");
        public Form1()
        {
            InitializeComponent();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // SAVE USER 
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SaveUser";
            cmd.Parameters.AddWithValue("userName", textBox4.Text);
            cmd.Parameters.AddWithValue("email", textBox3.Text);
            cmd.Parameters.AddWithValue("password", textBox5.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            groupBox2.Visible = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            selection go = new selection();
            go.Show();
            this.Hide();
            */
            // GİRİŞ YAP KONTROLÜ

            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from UserTbl where userName=@userName and password=@password", conn);
            cmd.Parameters.AddWithValue("@userName", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Successful !");
                selection go = new selection();
                go.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Try again.");
                textBox1.Clear();
                textBox2.Clear();
            }
            conn.Close();

        }

        
    }
}
