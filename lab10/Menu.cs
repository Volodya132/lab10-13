using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab10
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lab10 lab10 = new Lab10();
            this.Hide();
            lab10.ShowDialog();
            this.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lab11 lab11 = new Lab11();
            this.Hide();
            lab11.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Lab12 lab12 = new Lab12();
            this.Hide();
            lab12.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Lab13 lab13 = new Lab13();
            this.Hide();
            lab13.ShowDialog();
            this.Show();

        }
    }
}
