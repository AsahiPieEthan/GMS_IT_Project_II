using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GMS_ITProject
{
    public partial class DeleteMember : Form
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=gym;Integrated Security=True";

        public DeleteMember()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // ── Form ──
            this.BackColor = Color.FromArgb(176, 196, 222);
            this.Text = "Delete Member";
            this.MinimumSize = new Size(720, 540);

            // ── Title ──
            Label lblTitle = new Label
            {
                Text = "Delete Member",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 50, 80),
                AutoSize = true,
                Location = new Point(20, 15)
            };
            this.Controls.Add(lblTitle);

            // ── White filter card panel ──
            Panel pnlTop = new Panel
            {
                BackColor = Color.White,
                Size = new Size(this.ClientSize.Width - 40, 70),
                Location = new Point(20, 55),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            pnlTop.Paint += (s, e) =>
            {
                e.Graphics.DrawRectangle(
                    new Pen(Color.FromArgb(180, 200, 220), 1),
                    0, 0, pnlTop.Width - 1, pnlTop.Height - 1);
            };

            // Member ID label
            Label lblID = new Label
            {
                Text = "Member ID",
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.FromArgb(100, 120, 140),
                Location = new Point(16, 10),
                AutoSize = true
            };

            // Restyle textBox1 and move it into the panel
            textBox1.Location = new Point(16, 28);
            textBox1.Width = 160;
            textBox1.Font = new Font("Segoe UI", 10);
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Remove(textBox1);

            // Restyle btnDelete and move it into the panel
            btnDelete.Location = new Point(190, 24);
            btnDelete.Size = new Size(90, 32);
            btnDelete.Text = "Delete";
            btnDelete.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnDelete.BackColor = Color.FromArgb(192, 57, 43);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.UseVisualStyleBackColor = false;
            this.Controls.Remove(btnDelete);

            pnlTop.Controls.AddRange(new Control[] { lblID, textBox1, btnDelete });
            this.Controls.Add(pnlTop);

            // Remove old label1 (the "Enter ID:" label)
            this.Controls.Remove(label1);

            // ── DataGridView styling ──
            dataGridView1.Location = new Point(20, 140);
            dataGridView1.Size = new Size(this.ClientSize.Width - 40, this.ClientSize.Height - 155);
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Font = new Font("Segoe UI", 9);
            dataGridView1.GridColor = Color.FromArgb(220, 230, 240);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 95, 165);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            dataGridView1.ColumnHeadersHeight = 36;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 210, 240);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 40, 80);
            dataGridView1.DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 246, 252);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DeleteMember_Load(object sender, EventArgs e)
        {
            LoadMemberData();
        }

        private void LoadMemberData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM NewMember", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int memberID;

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a Member ID to delete.",
                    "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBox1.Text, out memberID))
            {
                MessageBox.Show("Member ID must be a number.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Clear();
                textBox1.Focus();
                return;
            }

            if (MessageBox.Show("This will permanently delete the member. Confirm?",
                "Delete Member", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM NewMember WHERE MID = @MID", con);
                    cmd.Parameters.AddWithValue("@MID", memberID);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        MessageBox.Show("Member deleted successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("No member found with that ID.",
                            "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadMemberData();
                textBox1.Clear();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}