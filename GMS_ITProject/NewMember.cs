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

namespace GMS_ITProject
{
    public partial class NewMember : Form
    {
        private bool isSaved = false;
        public NewMember()
        {
            InitializeComponent();
        }

        private void NewMember_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // ADD THESE 5 LINES AT THE TOP:
            if (isSaved)
            {
                MessageBox.Show("This member has already been saved in the database.", "Already Saved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Get text from textboxes
            string fname = txtFirstName.Text.Trim();
            string lname = txtLastName.Text.Trim();

            // Determine gender based on selected radio button
            string gender = radioButton1.Checked ? radioButton1.Text : radioButton2.Text;

            // Get other details from controls
            string dob = dateTimePickerDOB.Value.ToString("yyyy-MM-dd");
            string mobileText = txtMobile.Text.Trim();
            string email = txtEmail.Text.Trim();
            string joindate = dateTimePickerJoinDate.Value.ToString("yyyy-MM-dd");
            string address = txtAddress.Text.Trim();
            string membership = comboBoxMembership.Text.Trim();

            // Basic input validation
            if (string.IsNullOrWhiteSpace(fname) || string.IsNullOrWhiteSpace(lname) || string.IsNullOrWhiteSpace(gender) ||
                string.IsNullOrWhiteSpace(mobileText) ||
                string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(membership))
            {
                MessageBox.Show("Please fill in all required fields before saving.");
                return;
            }

            // Validate and parse mobile number
            long mobile;
            if (!long.TryParse(mobileText, out mobile))
            {
                MessageBox.Show("Invalid mobile number format.");
                return;
            }

            // Database connection
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=gym;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
INSERT INTO NewMember
(Fname, Lname, Gender, Dob, Mobile, Email, JoinDate, Maddress, MembershipTime)
VALUES
(@Fname, @Lname, @Gender, @Dob, @Mobile, @Email, @JoinDate, @Maddress, @MembershipTime)";


                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Fname", fname);
                    cmd.Parameters.AddWithValue("@Lname", lname);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Dob", dob);
                    cmd.Parameters.AddWithValue("@Mobile", mobile);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@JoinDate", joindate);
                    cmd.Parameters.AddWithValue("@Maddress", address);
                    cmd.Parameters.AddWithValue("@MembershipTime", membership);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        isSaved = true; // <-- ADD THIS LINE
                        MessageBox.Show("New member added successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            isSaved = false; // <-- ADD THIS LINE
            txtFirstName.Clear();
            txtLastName.Clear();

            radioButton1.Checked = false;
            radioButton2.Checked = false;

            txtMobile.Clear();
            txtEmail.Clear();

            comboBoxMembership.ResetText();
            txtAddress.Clear();

            dateTimePickerDOB.Value = DateTime.Now;
            dateTimePickerJoinDate.Value = DateTime.Now;
        }

        private void comboBoxMembership_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxMembership_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
