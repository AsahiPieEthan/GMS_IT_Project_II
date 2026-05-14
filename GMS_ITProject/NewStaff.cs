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
    public partial class NewStaff : Form
    {
        private bool isSaved = false;
        public NewStaff()
        {
            InitializeComponent();
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

        }

        private void NewStaff_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // ADD THESE 5 LINES AT THE TOP:
            if (isSaved)
            {
                MessageBox.Show("This staff has already been saved in the database.", "Already Saved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get text from textboxes
            string fname = txtFname.Text.Trim();
            string lname = txtLname.Text.Trim();

            // Determine gender based on selected radio button
            string gender = radioButton1.Checked ? radioButton1.Text : radioButton2.Text;

            // Get other details from controls
            string dob = dateTimePickerDOB.Value.ToString("yyyy-MM-dd");
            string mobileText = txtMobile.Text.Trim();
            string email = txtEmail.Text.Trim();
            string joindate = dateTimePickerJOINDate.Value.ToString("yyyy-MM-dd");
            string state = txtState.Text.Trim();
            string city = txtCity.Text.Trim();

            // Basic input validation
            if (string.IsNullOrWhiteSpace(fname) || string.IsNullOrWhiteSpace(lname) || string.IsNullOrWhiteSpace(gender) ||
                string.IsNullOrWhiteSpace(mobileText) || string.IsNullOrWhiteSpace(state) || string.IsNullOrWhiteSpace(city))
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

            // Database connection (adjust connection string if needed)
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=gym;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO NewStaff (Fname, Lname, Gender, Dob, Mobile, Email, JoinDate, Statee, City) " +
                               "VALUES (@Fname, @Lname, @Gender, @Dob, @Mobile, @Email, @JoinDate, @Statee, @City)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Fname", fname);
                    cmd.Parameters.AddWithValue("@Lname", lname);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Dob", dob);
                    cmd.Parameters.AddWithValue("@Mobile", mobile);
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(email) ? DBNull.Value : (object)email);
                    cmd.Parameters.AddWithValue("@JoinDate", joindate);
                    cmd.Parameters.AddWithValue("@Statee", state);
                    cmd.Parameters.AddWithValue("@City", city);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        isSaved = true; // <-- ADD THIS LINE
                        MessageBox.Show("New staff added successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            isSaved = false; // <-- ADD THIS LINE
            txtFname.Clear();
            txtLname.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtMobile.Clear();
            txtCity.Clear();
            txtState.Clear();
            txtEmail.Clear();

            dateTimePickerDOB.Value = DateTime.Now;
            dateTimePickerJOINDate.Value = DateTime.Now;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
