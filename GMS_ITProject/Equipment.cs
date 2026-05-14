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
    public partial class Equipment : Form
    {
        public Equipment()
        {
            InitializeComponent();
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Get text from input fields
            string equipName = txtEquipName.Text.Trim();
            string description = txtDescription.Text.Trim();
            string musclesUsed = txtMusclesUsed.Text.Trim();
            string deliveryDate = dateTimePickerDeliveryDate.Value.ToString("yyyy-MM-dd");
            string costText = txtCost.Text.Trim();

            // Basic validation
            if (string.IsNullOrWhiteSpace(equipName) || string.IsNullOrWhiteSpace(description) ||
                string.IsNullOrWhiteSpace(musclesUsed) || string.IsNullOrWhiteSpace(costText))
            {
                MessageBox.Show("Please fill in all required fields before saving.");
                return;
            }

            // Validate and parse cost
            long cost;
            if (!long.TryParse(costText, out cost))
            {
                MessageBox.Show("Invalid cost format. Please enter a valid number.");
                return;
            }

            // Database connection string (use your same gym database)
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=gym;Integrated Security=True";


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Equipment (Equipment_Name, Equipment_Description, Muscles_Used, Delivery_Date, Cost) " +
                               "VALUES (@Equipment_Name, @Equipment_Description, @Muscles_Used, @Delivery_Date, @Cost)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Equipment_Name", equipName);
                    cmd.Parameters.AddWithValue("@Equipment_Description", description);
                    cmd.Parameters.AddWithValue("@Muscles_Used", musclesUsed);
                    cmd.Parameters.AddWithValue("@Delivery_Date", deliveryDate);
                    cmd.Parameters.AddWithValue("@Cost", cost);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("New equipment added successfully!");
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
            txtEquipName.Clear();
            txtDescription.Clear();
            txtMusclesUsed.Clear();
            txtCost.Clear();
            dateTimePickerDeliveryDate.Value = DateTime.Now;
        }

        private void btnViewEq_Click(object sender, EventArgs e)
        {
            ViewEquipment ve = new ViewEquipment();
            ve.Show();
        }
    }
}
