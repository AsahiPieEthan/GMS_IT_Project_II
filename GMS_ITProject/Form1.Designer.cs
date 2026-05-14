namespace GMS_ITProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            newMemberToolStripMenuItem = new ToolStripMenuItem();
            newStaffToolStripMenuItem = new ToolStripMenuItem();
            manageStaffToolStripMenuItem = new ToolStripMenuItem();
            searchMemberToolStripMenuItem = new ToolStripMenuItem();
            deleteMemberToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            membershipToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ButtonHighlight;
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, newMemberToolStripMenuItem, newStaffToolStripMenuItem, manageStaffToolStripMenuItem, searchMemberToolStripMenuItem, deleteMemberToolStripMenuItem, logOutToolStripMenuItem, exitToolStripMenuItem, toolStripMenuItem2 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1450, 128);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked_1;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem4 });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(12, 124);
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(82, 22);
            toolStripMenuItem4.Text = ">";
            // 
            // newMemberToolStripMenuItem
            // 
            newMemberToolStripMenuItem.BackColor = SystemColors.ButtonHighlight;
            newMemberToolStripMenuItem.Image = (Image)resources.GetObject("newMemberToolStripMenuItem.Image");
            newMemberToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            newMemberToolStripMenuItem.Name = "newMemberToolStripMenuItem";
            newMemberToolStripMenuItem.Size = new Size(191, 124);
            newMemberToolStripMenuItem.Text = "New Member";
            newMemberToolStripMenuItem.Click += newMemberToolStripMenuItem_Click;
            // 
            // newStaffToolStripMenuItem
            // 
            newStaffToolStripMenuItem.Image = (Image)resources.GetObject("newStaffToolStripMenuItem.Image");
            newStaffToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            newStaffToolStripMenuItem.Name = "newStaffToolStripMenuItem";
            newStaffToolStripMenuItem.Size = new Size(170, 124);
            newStaffToolStripMenuItem.Text = "New Staff";
            newStaffToolStripMenuItem.Click += newStaffToolStripMenuItem_Click;
            // 
            // manageStaffToolStripMenuItem
            // 
            manageStaffToolStripMenuItem.Image = (Image)resources.GetObject("manageStaffToolStripMenuItem.Image");
            manageStaffToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            manageStaffToolStripMenuItem.Name = "manageStaffToolStripMenuItem";
            manageStaffToolStripMenuItem.Size = new Size(209, 124);
            manageStaffToolStripMenuItem.Text = "Manage Staff";
            manageStaffToolStripMenuItem.Click += manageStaffToolStripMenuItem_Click_1;
            // 
            // searchMemberToolStripMenuItem
            // 
            searchMemberToolStripMenuItem.Image = (Image)resources.GetObject("searchMemberToolStripMenuItem.Image");
            searchMemberToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            searchMemberToolStripMenuItem.Name = "searchMemberToolStripMenuItem";
            searchMemberToolStripMenuItem.Size = new Size(202, 124);
            searchMemberToolStripMenuItem.Text = "Search Member";
            searchMemberToolStripMenuItem.Click += searchMemberToolStripMenuItem_Click;
            // 
            // deleteMemberToolStripMenuItem
            // 
            deleteMemberToolStripMenuItem.Image = (Image)resources.GetObject("deleteMemberToolStripMenuItem.Image");
            deleteMemberToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            deleteMemberToolStripMenuItem.Name = "deleteMemberToolStripMenuItem";
            deleteMemberToolStripMenuItem.Size = new Size(200, 124);
            deleteMemberToolStripMenuItem.Text = "Delete Member";
            deleteMemberToolStripMenuItem.Click += deleteMemberToolStripMenuItem_Click;
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.BackColor = SystemColors.ButtonHighlight;
            logOutToolStripMenuItem.ForeColor = SystemColors.ActiveCaptionText;
            logOutToolStripMenuItem.Image = (Image)resources.GetObject("logOutToolStripMenuItem.Image");
            logOutToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(162, 124);
            logOutToolStripMenuItem.Text = "Log Out";
            logOutToolStripMenuItem.Click += logOutToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Image = (Image)resources.GetObject("exitToolStripMenuItem.Image");
            exitToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(117, 124);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { membershipToolStripMenuItem });
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(12, 124);
            // 
            // membershipToolStripMenuItem
            // 
            membershipToolStripMenuItem.Name = "membershipToolStripMenuItem";
            membershipToolStripMenuItem.Size = new Size(141, 22);
            membershipToolStripMenuItem.Text = "Membership";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1450, 898);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem newMemberToolStripMenuItem;
        private ToolStripMenuItem newStaffToolStripMenuItem;
        private ToolStripMenuItem searchMemberToolStripMenuItem;
        private ToolStripMenuItem deleteMemberToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem membershipToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem manageStaffToolStripMenuItem;
    }
}
