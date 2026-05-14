namespace GMS_ITProject
{
    partial class SearchMember
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Location = new Point(12, 124);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(760, 400);
            dataGridView1.TabIndex = 0;
            // 
            // SearchMember
            // 
            ClientSize = new Size(800, 550);
            Controls.Add(dataGridView1);
            Name = "SearchMember";
            Text = "SearchMember";
            Load += SearchMember_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dataGridView1;
    }
}