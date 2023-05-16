using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BookTracking
{
    public partial class publisher : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=***;Initial Catalog=***;uid=***;pwd=***");
        public publisher()
        {
            InitializeComponent();
        }
        public void List()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PublisherList";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void aUTHORSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            book go = new book();
            go.Show();
            this.Hide();
        }

        private void gENRESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            author go = new author();
            go.Show();
            this.Hide();
        }

        private void pUBLISHERSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            genre go = new genre();
            go.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox4.Tag = row.Cells["publisherId"].Value.ToString();
            textBox4.Text = row.Cells["publisherName"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeletePublisher";
            cmd.Parameters.AddWithValue("authorId", textBox4.Tag);
            cmd.ExecuteNonQuery();
            conn.Close();
            List();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SavePublisher";
            cmd.Parameters.AddWithValue("publisherName", textBox4.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            List();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdatePublisher";
            cmd.Parameters.AddWithValue("publisherId", textBox4.Tag);
            cmd.Parameters.AddWithValue("publisherName", textBox4.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            List();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List();
        }
    }
}
