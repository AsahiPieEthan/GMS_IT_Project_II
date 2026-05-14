namespace GMS_ITProject
{
    partial class ManageStaff
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.TabIndex = 0;

            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ManageStaff";
            this.Text = "Manage Staff";
            this.Load += new System.EventHandler(this.ManageStaff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dataGridView1;
    }
}