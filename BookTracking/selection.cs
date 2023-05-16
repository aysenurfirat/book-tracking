using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookTracking
{
    public partial class selection : Form
    {
        public selection()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            book go = new book();
            go.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            author go = new author();
            go.Show(); 
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            genre go = new genre();
            go.Show();
            this.Hide();
        }

        private void selection_Load(object sender, EventArgs e)
        {

        }
    }
}
