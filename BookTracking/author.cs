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
    public partial class author : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=***;Initial Catalog=***;uid=***;pwd=***");
        public author()
        {
            InitializeComponent();
        }

        public void List()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AuthorList";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void author_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            List();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // SAVE AUTHOR
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SaveAuthor";
            cmd.Parameters.AddWithValue("authorName", textBox4.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            List();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // UPDATE AUTHOR
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateAuthor";
            cmd.Parameters.AddWithValue("authorId", textBox4.Tag);
            cmd.Parameters.AddWithValue("authorName", textBox4.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            List();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // DELETE AUTHOR
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteAuthor";
            cmd.Parameters.AddWithValue("authorId", textBox4.Tag);
            cmd.ExecuteNonQuery();
            conn.Close();
            List();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox4.Tag = row.Cells["authorId"].Value.ToString();
            textBox4.Text = row.Cells["authorName"].Value.ToString();
        }

        private void aUTHORSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            book go = new book();
            go.Show();
            this.Hide();
        }

        private void gENRESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            genre go = new genre();
            go.Show();
            this.Hide();
        }
    }
}
