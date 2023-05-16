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
    public partial class book : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=***;Initial Catalog=***;uid=***;pwd=***");
        public book()
        {
            InitializeComponent();
        }

        public void List()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "BookList";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void book_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            List();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // SAVE BOOK
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SaveBook";
            cmd.Parameters.AddWithValue("bookTitle", textBox4.Text);
            cmd.Parameters.AddWithValue("page", textBox1.Text);
            cmd.Parameters.AddWithValue("publisher_id", textBox2.Text);
            cmd.Parameters.AddWithValue("isRead", comboBox1.Text);
            cmd.Parameters.AddWithValue("date", textBox3.Text);
            cmd.Parameters.AddWithValue("genre_id", textBox5.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            List();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox4.Tag = row.Cells["bookId"].Value.ToString();
            textBox4.Text = row.Cells["bookTitle"].Value.ToString();
            textBox1.Text = row.Cells["page"].Value.ToString();
            textBox2.Text = row.Cells["publisher_id"].Value.ToString();
            comboBox1.Text = row.Cells["isRead"].Value.ToString();
            textBox3.Text = row.Cells["date"].Value.ToString();
            textBox5.Text = row.Cells["genre_id"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // UPDATE BOOK
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateBook";
            cmd.Parameters.AddWithValue("bookId", textBox4.Tag);
            cmd.Parameters.AddWithValue("bookTitle", textBox4.Text);
            cmd.Parameters.AddWithValue("page", textBox1.Text);
            cmd.Parameters.AddWithValue("publisher_id", textBox2.Text);
            cmd.Parameters.AddWithValue("isRead", comboBox1.Text);
            cmd.Parameters.AddWithValue("date", textBox3.Text);
            cmd.Parameters.AddWithValue("genre_id", textBox5.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            List();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // DELETE BOOK
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteBook";
            cmd.Parameters.AddWithValue("bookId", textBox4.Tag);
            cmd.ExecuteNonQuery();
            conn.Close();
            List();
        }

        private void aUTHORSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            author go = new author();
            go.Show();
            this.Hide();
        }

        private void gENRESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            genre go = new genre();
            go.Show();
            this.Hide();
        }

        private void pUBLISHERSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            publisher go = new publisher();
            go.Show();
            this.Hide();
        }
    }
}
