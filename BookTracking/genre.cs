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
    public partial class genre : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=***;Initial Catalog=***;uid=***;pwd=***");
        public genre()
        {
            InitializeComponent();
        }
        public void List()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GenreList";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void genre_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            List();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // SAVE GENRE
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SaveGenre";
            cmd.Parameters.AddWithValue("genreName", textBox4.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            List();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // UPDATE GENRE
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateGenre";
            cmd.Parameters.AddWithValue("genreId", textBox4.Tag);
            cmd.Parameters.AddWithValue("genreName", textBox4.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            List();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // DELETE GENRE
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteGenre";
            cmd.Parameters.AddWithValue("genreId", textBox4.Tag);
            cmd.ExecuteNonQuery();
            conn.Close();
            List();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox4.Tag = row.Cells["genreId"].Value.ToString();
            textBox4.Text = row.Cells["genreName"].Value.ToString();
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
            publisher go = new publisher();
            go.Show();
            this.Hide();
        }
    }
}
