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
    public partial class ViewEquipment : Form
    {
        public ViewEquipment()
        {
            InitializeComponent();




        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ViewEquipment_Load(object sender, EventArgs e)
        {
            try
            {
                // Connection string (use your own server name)
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=gym;Integrated Security=True";


                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // SQL query to select all records
                    string query = "SELECT * FROM Equipment";

                    // Create data adapter and fill dataset
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    // Bind dataset to DataGridView
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
