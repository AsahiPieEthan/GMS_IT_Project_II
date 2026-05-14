namespace GMS_ITProject {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Boolean b = true;
        private void Form1_Load(object sender, EventArgs e) { }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }


        private void newStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewStaff ns = new NewStaff();
            ns.Show();

        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (b == true)
            {
                menuStrip1.Dock = DockStyle.Left; b = false; toolStripMenuItem1.Image = Image.FromFile(@"C:\ImageITProject\arrowRight.jpg");
            }
            else { menuStrip1.Dock = DockStyle.Top; b = true; toolStripMenuItem1.Image = Image.FromFile(@"C:\ImageITProject\arrowTop.jpg"); }
        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void newMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewMember newMemberForm = new NewMember();
            newMemberForm.ShowDialog(); // Use ShowDialog() to open it as a popup (modal)
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void equipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Equipment eq = new Equipment();
            eq.Show();
        }

        private void searchMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchMember sm = new SearchMember();
            sm.Show();
        }

        private void deleteMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteMember dm = new DeleteMember();
            dm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will close your application. Confirm?",
                                "CLOSE",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Error) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Welcome Back",
                                "Welcome",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

      

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure you want to Log Out?", "Log Out", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) ;
            {
                this.Close();
                Login lg = new Login();
                lg.Show();
            }
        }

        private void manageStaffToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ManageStaff ms = new ManageStaff();
            ms.Show();
        }
    }
}