using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GMS_ITProject
{
    public partial class ManageStaff : Form
    {
        string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=gym;Integrated Security=True";

        private Panel pnlFilter;
        private Label lblTitle;
        private Label lblSearch;
        private TextBox txtSearch;
        private Label lblGender;
        private ComboBox cmbGender;
        private Button btnSearch;
        private Button btnClear;
        private Button btnEdit;
        private Button btnDelete;

        public ManageStaff()
        {
            InitializeComponent();
            SetupUI();
            LoadAllStaff();
        }

        private void SetupUI()
        {
            // ── Form ──
            this.BackColor = Color.FromArgb(176, 196, 222);
            this.Text = "Manage Staff";
            this.MinimumSize = new Size(920, 600);

            // ── Title ──
            lblTitle = new Label
            {
                Text = "Manage Staff",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 50, 80),
                AutoSize = true,
                Location = new Point(20, 15)
            };
            this.Controls.Add(lblTitle);

            // ── Filter panel ──
            pnlFilter = new Panel
            {
                BackColor = Color.White,
                Size = new Size(this.ClientSize.Width - 40, 70),
                Location = new Point(20, 55),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            pnlFilter.Paint += (s, e) => e.Graphics.DrawRectangle(
                new Pen(Color.FromArgb(180, 200, 220), 1), 0, 0,
                pnlFilter.Width - 1, pnlFilter.Height - 1);

            // Search by name/ID
            lblSearch = new Label
            {
                Text = "Search (Name or ID)",
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.FromArgb(100, 120, 140),
                Location = new Point(16, 10),
                AutoSize = true
            };
            txtSearch = new TextBox
            {
                Location = new Point(16, 28),
                Width = 180,
                Font = new Font("Segoe UI", 10),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Gender filter
            lblGender = new Label
            {
                Text = "Gender",
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.FromArgb(100, 120, 140),
                Location = new Point(212, 10),
                AutoSize = true
            };
            cmbGender = new ComboBox
            {
                Location = new Point(212, 28),
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
                Location = new Point(338, 24),
                Size = new Size(90, 32),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(30, 95, 165),
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
                Location = new Point(438, 24),
                Size = new Size(75, 32),
                Font = new Font("Segoe UI", 10),
                BackColor = Color.FromArgb(220, 220, 220),
                ForeColor = Color.FromArgb(60, 60, 60),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Click += btnClear_Click;

            // Edit button
            btnEdit = new Button
            {
                Text = "Edit Selected",
                Location = new Point(540, 24),
                Size = new Size(110, 32),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(39, 174, 96),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Enabled = false
            };
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Click += btnEdit_Click;

            // Delete button
            btnDelete = new Button
            {
                Text = "Delete Selected",
                Location = new Point(660, 24),
                Size = new Size(120, 32),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(192, 57, 43),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Enabled = false
            };
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Click += btnDelete_Click;

            pnlFilter.Controls.AddRange(new Control[]
            {
                lblSearch, txtSearch,
                lblGender, cmbGender,
                btnSearch, btnClear,
                btnEdit,   btnDelete
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
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
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

            // Enable Edit/Delete buttons only when a row is selected
            dataGridView1.SelectionChanged += (s, e) =>
            {
                bool hasSelection = dataGridView1.SelectedRows.Count > 0;
                btnEdit.Enabled = hasSelection;
                btnDelete.Enabled = hasSelection;
            };
        }

        private void ManageStaff_Load(object sender, EventArgs e) { }

        private void LoadAllStaff()
        {
            SearchWithFilters("", "All");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchWithFilters(txtSearch.Text.Trim(),
                              cmbGender.SelectedItem?.ToString() ?? "All");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbGender.SelectedIndex = 0;
            LoadAllStaff();
        }

        private void SearchWithFilters(string search, string gender)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT * FROM NewStaff WHERE 1=1";

                    if (!string.IsNullOrEmpty(search))
                        query += " AND (CAST(SID AS NVARCHAR) LIKE @Search OR Fname LIKE @Search OR Lname LIKE @Search)";
                    if (gender != "All")
                        query += " AND Gender = @Gender";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(search))
                            cmd.Parameters.AddWithValue("@Search", "%" + search + "%");
                        if (gender != "All")
                            cmd.Parameters.AddWithValue("@Gender", gender);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;

                        if (dt.Rows.Count == 0)
                            MessageBox.Show("No staff found matching your search.",
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

        // ── DELETE ────────────────────────────────────────────────────────────
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var row = dataGridView1.SelectedRows[0];
            int sid = Convert.ToInt32(row.Cells["SID"].Value);
            string name = $"{row.Cells["Fname"].Value} {row.Cells["Lname"].Value}";

            if (MessageBox.Show($"Delete staff member {name}? This cannot be undone.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    var cmd = new SqlCommand("DELETE FROM NewStaff WHERE SID = @SID", conn);
                    cmd.Parameters.AddWithValue("@SID", sid);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Staff member deleted successfully.",
                        "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadAllStaff();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── EDIT ──────────────────────────────────────────────────────────────
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var row = dataGridView1.SelectedRows[0];
            int sid = Convert.ToInt32(row.Cells["SID"].Value);

            // Open edit dialog
            using (var editForm = new EditStaffDialog(sid, connStr))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                    LoadAllStaff(); // Refresh after edit
            }
        }
    }

    // ── EDIT STAFF DIALOG ─────────────────────────────────────────────────────
    public class EditStaffDialog : Form
    {
        private string _connStr;
        private int _sid;

        private TextBox txtFname, txtLname, txtMobile, txtEmail, txtState, txtCity;
        private ComboBox cmbGender;
        private DateTimePicker dtpDob, dtpJoinDate;
        private Button btnSave, btnCancel;

        public EditStaffDialog(int sid, string connStr)
        {
            _sid = sid;
            _connStr = connStr;
            BuildUI();
            LoadStaffData();
        }

        private void BuildUI()
        {
            this.Text = "Edit Staff";
            this.Size = new Size(480, 520);
            this.BackColor = Color.FromArgb(176, 196, 222);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;

            // White card panel
            Panel card = new Panel
            {
                BackColor = Color.White,
                Location = new Point(20, 20),
                Size = new Size(this.ClientSize.Width - 40, this.ClientSize.Height - 80),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
            };
            this.Controls.Add(card);

            int y = 20, lx = 20, fx = 160, fw = 260;

            Label title = new Label
            {
                Text = "Edit Staff Details",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 50, 80),
                Location = new Point(lx, y),
                AutoSize = true
            };
            card.Controls.Add(title);
            y += 40;

            // Helper to add a row
            Control AddRow(string labelText, Control input)
            {
                var lbl = new Label
                {
                    Text = labelText,
                    Font = new Font("Segoe UI", 9),
                    ForeColor = Color.FromArgb(80, 100, 120),
                    Location = new Point(lx, y + 3),
                    AutoSize = true
                };
                input.Location = new Point(fx, y);
                if (input is TextBox tb) { tb.Width = fw; tb.Font = new Font("Segoe UI", 10); tb.BorderStyle = BorderStyle.FixedSingle; }
                if (input is ComboBox cb) { cb.Width = fw; cb.Font = new Font("Segoe UI", 10); cb.FlatStyle = FlatStyle.Flat; }
                if (input is DateTimePicker dtp) { dtp.Width = fw; dtp.Font = new Font("Segoe UI", 10); }
                card.Controls.Add(lbl);
                card.Controls.Add(input);
                y += 38;
                return input;
            }

            txtFname = (TextBox)AddRow("First Name", new TextBox());
            txtLname = (TextBox)AddRow("Last Name", new TextBox());

            cmbGender = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            cmbGender.Items.AddRange(new object[] { "Male", "Female" });
            AddRow("Gender", cmbGender);

            dtpDob = new DateTimePicker { Format = DateTimePickerFormat.Short };
            AddRow("Date of Birth", dtpDob);

            txtMobile = (TextBox)AddRow("Mobile", new TextBox());
            txtEmail = (TextBox)AddRow("Email", new TextBox());

            dtpJoinDate = new DateTimePicker { Format = DateTimePickerFormat.Short };
            AddRow("Join Date", dtpJoinDate);

            txtState = (TextBox)AddRow("State", new TextBox());
            txtCity = (TextBox)AddRow("City", new TextBox());

            // Buttons
            btnSave = new Button
            {
                Text = "Save Changes",
                Location = new Point(fx, y + 10),
                Size = new Size(120, 34),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(30, 95, 165),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += btnSave_Click;
            card.Controls.Add(btnSave);

            btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(fx + 130, y + 10),
                Size = new Size(90, 34),
                Font = new Font("Segoe UI", 10),
                BackColor = Color.FromArgb(220, 220, 220),
                ForeColor = Color.FromArgb(60, 60, 60),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            card.Controls.Add(btnCancel);
        }

        private void LoadStaffData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    conn.Open();
                    var cmd = new SqlCommand("SELECT * FROM NewStaff WHERE SID = @SID", conn);
                    cmd.Parameters.AddWithValue("@SID", _sid);
                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtFname.Text = reader["Fname"].ToString();
                        txtLname.Text = reader["Lname"].ToString();
                        cmbGender.Text = reader["Gender"].ToString();
                        dtpDob.Value = Convert.ToDateTime(reader["Dob"]);
                        txtMobile.Text = reader["Mobile"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        dtpJoinDate.Value = Convert.ToDateTime(reader["JoinDate"]);
                        txtState.Text = reader["Statee"].ToString();
                        txtCity.Text = reader["City"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading staff: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFname.Text) ||
                string.IsNullOrWhiteSpace(txtLname.Text) ||
                string.IsNullOrWhiteSpace(txtMobile.Text) ||
                string.IsNullOrWhiteSpace(txtState.Text) ||
                string.IsNullOrWhiteSpace(txtCity.Text))
            {
                MessageBox.Show("Please fill in all required fields.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
                        UPDATE NewStaff SET
                            Fname    = @Fname,
                            Lname    = @Lname,
                            Gender   = @Gender,
                            Dob      = @Dob,
                            Mobile   = @Mobile,
                            Email    = @Email,
                            JoinDate = @JoinDate,
                            Statee   = @Statee,
                            City     = @City
                        WHERE SID = @SID", conn);

                    cmd.Parameters.AddWithValue("@Fname", txtFname.Text.Trim());
                    cmd.Parameters.AddWithValue("@Lname", txtLname.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gender", cmbGender.Text);
                    cmd.Parameters.AddWithValue("@Dob", dtpDob.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@JoinDate", dtpJoinDate.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Statee", txtState.Text.Trim());
                    cmd.Parameters.AddWithValue("@City", txtCity.Text.Trim());
                    cmd.Parameters.AddWithValue("@SID", _sid);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Staff updated successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}