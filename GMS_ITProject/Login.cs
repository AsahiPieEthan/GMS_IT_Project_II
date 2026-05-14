using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMS_ITProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBoxUsername.Text == "admin" && txtBoxPassword.Text == "1234")
            {
                Form1 fm = new Form1();
                fm.Show();
                this.Hide();
                MessageBox.Show("Login Successful! Welcome!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Incorrect username or password! Pls try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}