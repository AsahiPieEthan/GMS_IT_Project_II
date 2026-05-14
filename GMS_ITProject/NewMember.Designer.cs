namespace GMS_ITProject
{
    partial class NewMember
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewMember));
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            dateTimePickerDOB = new DateTimePicker();
            txtMobile = new TextBox();
            dateTimePickerJoinDate = new DateTimePicker();
            txtEmail = new TextBox();
            txtAddress = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label9 = new Label();
            btnSave = new Button();
            btnReset = new Button();
            label10 = new Label();
            comboBoxMembership = new ComboBox();
            label11 = new Label();
            SuspendLayout();
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(150, 92);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(100, 23);
            txtFirstName.TabIndex = 0;
            txtFirstName.TextChanged += textBox1_TextChanged;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(151, 173);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(100, 23);
            txtLastName.TabIndex = 1;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.BackColor = Color.Transparent;
            radioButton1.ForeColor = Color.White;
            radioButton1.Location = new Point(151, 242);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(51, 19);
            radioButton1.TabIndex = 2;
            radioButton1.TabStop = true;
            radioButton1.Text = "Male";
            radioButton1.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.BackColor = Color.Transparent;
            radioButton2.ForeColor = Color.White;
            radioButton2.Location = new Point(236, 242);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(63, 19);
            radioButton2.TabIndex = 3;
            radioButton2.TabStop = true;
            radioButton2.Text = "Female";
            radioButton2.UseVisualStyleBackColor = false;
            // 
            // dateTimePickerDOB
            // 
            dateTimePickerDOB.Location = new Point(150, 308);
            dateTimePickerDOB.Name = "dateTimePickerDOB";
            dateTimePickerDOB.Size = new Size(200, 23);
            dateTimePickerDOB.TabIndex = 4;
            // 
            // txtMobile
            // 
            txtMobile.Location = new Point(172, 395);
            txtMobile.Name = "txtMobile";
            txtMobile.Size = new Size(100, 23);
            txtMobile.TabIndex = 5;
            // 
            // dateTimePickerJoinDate
            // 
            dateTimePickerJoinDate.Location = new Point(671, 189);
            dateTimePickerJoinDate.Name = "dateTimePickerJoinDate";
            dateTimePickerJoinDate.Size = new Size(192, 23);
            dateTimePickerJoinDate.TabIndex = 6;
            dateTimePickerJoinDate.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(671, 103);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(192, 23);
            txtEmail.TabIndex = 7;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(671, 263);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(192, 96);
            txtAddress.TabIndex = 9;
            txtAddress.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Noto Sans HK", 12F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(34, 92);
            label1.Name = "label1";
            label1.Size = new Size(95, 24);
            label1.TabIndex = 11;
            label1.Text = "First Name";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Noto Sans HK", 12F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(35, 172);
            label2.Name = "label2";
            label2.Size = new Size(92, 24);
            label2.TabIndex = 12;
            label2.Text = "Last Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Noto Sans HK", 12F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(35, 237);
            label3.Name = "label3";
            label3.Size = new Size(66, 24);
            label3.TabIndex = 13;
            label3.Text = "Gender";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Noto Sans HK", 12F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(34, 307);
            label4.Name = "label4";
            label4.Size = new Size(110, 24);
            label4.TabIndex = 14;
            label4.Text = "Date of Birth";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Noto Sans HK", 12F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(35, 391);
            label5.Name = "label5";
            label5.Size = new Size(91, 24);
            label5.TabIndex = 15;
            label5.Text = "Phone No.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Noto Sans HK", 12F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(576, 103);
            label6.Name = "label6";
            label6.Size = new Size(54, 24);
            label6.TabIndex = 16;
            label6.Text = "Email";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Noto Sans HK", 12F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(576, 189);
            label7.Name = "label7";
            label7.Size = new Size(84, 24);
            label7.TabIndex = 17;
            label7.Text = "Join Date";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Noto Sans HK", 12F, FontStyle.Bold);
            label9.ForeColor = Color.Transparent;
            label9.Location = new Point(576, 263);
            label9.Name = "label9";
            label9.Size = new Size(72, 24);
            label9.TabIndex = 19;
            label9.Text = "Address";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(337, 535);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 20;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(512, 535);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 23);
            btnReset.TabIndex = 21;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.ForeColor = SystemColors.ControlLightLight;
            label10.Location = new Point(293, 447);
            label10.Name = "label10";
            label10.Size = new Size(104, 15);
            label10.TabIndex = 22;
            label10.Text = "Membership Time";
            label10.Click += label10_Click;
            // 
            // comboBoxMembership
            // 
            comboBoxMembership.FormattingEnabled = true;
            comboBoxMembership.Items.AddRange(new object[] { "1 Month (Basic)", "1 Month (Pro)", "1 Month (Elite)", "6 Months", "12 Months" });
            comboBoxMembership.Location = new Point(403, 447);
            comboBoxMembership.Name = "comboBoxMembership";
            comboBoxMembership.Size = new Size(121, 23);
            comboBoxMembership.TabIndex = 23;
            comboBoxMembership.SelectedIndexChanged += comboBoxMembership_SelectedIndexChanged_1;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Noto Sans HK", 12F, FontStyle.Bold);
            label11.ForeColor = SystemColors.ControlLightLight;
            label11.Location = new Point(88, 51);
            label11.Name = "label11";
            label11.Size = new Size(0, 24);
            label11.TabIndex = 11;
            label11.Click += label1_Click;
            // 
            // NewMember
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(996, 614);
            Controls.Add(comboBoxMembership);
            Controls.Add(label10);
            Controls.Add(btnReset);
            Controls.Add(btnSave);
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label11);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtAddress);
            Controls.Add(txtEmail);
            Controls.Add(dateTimePickerJoinDate);
            Controls.Add(txtMobile);
            Controls.Add(dateTimePickerDOB);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Name = "NewMember";
            Text = "NewMember";
            Load += NewMember_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private DateTimePicker dateTimePicker1;
        private TextBox txtMobile;
        private DateTimePicker dateTimePickerJoinDate;
        private TextBox txtEmail;
        private RichTextBox txtAddress;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button btnSave;
        private Button btnReset;
        private Label label10;
        private ComboBox comboBoxMembership;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private DateTimePicker dateTimePickerDOB;
        private Label label11;
    }
}