using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GMS_ITProject
{
    public partial class SearchMember : Form
    {
        string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=gym;Integrated Security=True";

        private Panel pnlFilter;
        private Label lblTitle;
        private Label lblID;
        private TextBox txtSearchID;
        private Label lblSubscription;
        private ComboBox cmbSubscription;
        private Label lblGender;
        private ComboBox cmbGender;
        private Button btnSearch;
        private Button btnClear;

        public SearchMember()
        {
            InitializeComponent();
            SetupUI();
            LoadAllMembers();
        }

        private void SetupUI()
        {
            // ── Form background (same blue as your original) ──
            this.BackColor = Color.FromArgb(176, 196, 222);
            this.Text = "Search Member";
            this.MinimumSize = new Size(820, 550);

            // ── Title label ──
            lblTitle = new Label
            {
                Text = "Search Member",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 50, 80),
                AutoSize = true,
                Location = new Point(20, 15)
            };
            this.Controls.Add(lblTitle);

            // ── White filter card panel ──
            pnlFilter = new Panel
            {
                BackColor = Color.White,
                Size = new Size(this.ClientSize.Width - 40, 70),
                Location = new Point(20, 55),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            pnlFilter.Paint += (s, e) =>
            {
                e.Graphics.DrawRectangle(
                    new Pen(Color.FromArgb(180, 200, 220), 1),
                    0, 0, pnlFilter.Width - 1, pnlFilter.Height - 1);
            };

            // Member ID
            lblID = new Label
            {
                Text = "Member ID",
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.FromArgb(100, 120, 140),
                Location = new Point(16, 10),
                AutoSize = true
            };
            txtSearchID = new TextBox
            {
                Location = new Point(16, 28),
                Width = 130,
                Font = new Font("Segoe UI", 10),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Subscription
            lblSubscription = new Label
            {
                Text = "Subscription",
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.FromArgb(100, 120, 140),
                Location = new Point(165, 10),
                AutoSize = true
            };
            cmbSubscription = new ComboBox
            {
                Location = new Point(165, 28),
                Width = 130,
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat
            };
            cmbSubscription.Items.AddRange(new object[] { "All", "1 Month", "6 Months", "12 Months" });
            cmbSubscription.SelectedIndex = 0;

            // Gender
            lblGender = new Label
            {
                Text = "Gender",
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.FromArgb(100, 120, 140),
                Location = new Point(314, 10),
                AutoSize = true
            };
            cmbGender = new ComboBox
            {
                Location = new Point(314, 28),
                Width = 110,
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat
            };
            cmbGender.Items.AddRange(new object[] { "All", "Male", "Female" });
            cmbGender.SelectedIndex = 0;

            // Search button
            btnSearch = new Button
            {
                Text = "Search",
                Location = new Point(445, 24),
                Size = new Size(90, 32),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(192, 57, 43),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Click += btnSearch_Click;

            // Clear button
            btnClear = new Button
            {
                Text = "Clear",
                Location = new Point(545, 24),
                Size = new Size(80, 32),
                Font = new Font("Segoe UI", 10),
                BackColor = Color.FromArgb(230, 230, 230),
                ForeColor = Color.FromArgb(60, 60, 60),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Click += btnClear_Click;

            pnlFilter.Controls.AddRange(new Control[]
            {
                lblID, txtSearchID,
                lblSubscription, cmbSubscription,
                lblGender, cmbGender,
                btnSearch, btnClear
            });
            this.Controls.Add(pnlFilter);

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
        }

        private void LoadAllMembers()
        {
            SearchWithFilters(null, "All", "All");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string id = txtSearchID.Text.Trim();
            string subscription = cmbSubscription.SelectedItem?.ToString() ?? "All";
            string gender = cmbGender.SelectedItem?.ToString() ?? "All";
            SearchWithFilters(id, subscription, gender);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchID.Clear();
            cmbSubscription.SelectedIndex = 0;
            cmbGender.SelectedIndex = 0;
            LoadAllMembers();
        }

        private void SearchWithFilters(string id, string subscription, string gender)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT * FROM NewMember WHERE 1=1";

                    if (!string.IsNullOrEmpty(id))
                        query += " AND MID = @MID";
                    if (subscription != "All")
                        query += " AND MembershipTime = @Subscription";
                    if (gender != "All")
                        query += " AND Gender = @Gender";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(id))
                            cmd.Parameters.AddWithValue("@MID", id);
                        if (subscription != "All")
                            cmd.Parameters.AddWithValue("@Subscription", subscription);
                        if (gender != "All")
                            cmd.Parameters.AddWithValue("@Gender", gender);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;

                        if (dt.Rows.Count == 0)
                            MessageBox.Show("No members found matching your filters.",
                                "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchMember_Load(object sender, EventArgs e) { }
    }
}