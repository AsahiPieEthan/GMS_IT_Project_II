namespace GMS_ITProject
{
    partial class Login
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            btnLogin = new Button();
            txtBoxPassword = new TextBox();
            txtBoxUsername = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            bindingSource1 = new BindingSource(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Center;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(txtBoxPassword);
            panel1.Controls.Add(txtBoxUsername);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(500, 150);
            panel1.Name = "panel1";
            panel1.Size = new Size(514, 388);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(113, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(69, 69);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.ActiveBorder;
            btnLogin.Location = new Point(135, 284);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(206, 48);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += button1_Click;
            // 
            // txtBoxPassword
            // 
            txtBoxPassword.BackColor = Color.FromArgb(128, 255, 128);
            txtBoxPassword.Cursor = Cursors.Hand;
            txtBoxPassword.Location = new Point(135, 211);
            txtBoxPassword.Name = "txtBoxPassword";
            txtBoxPassword.PasswordChar = '*';
            txtBoxPassword.Size = new Size(206, 23);
            txtBoxPassword.TabIndex = 4;
            txtBoxPassword.TextChanged += txtBoxPassword_TextChanged;
            // 
            // txtBoxUsername
            // 
            txtBoxUsername.BackColor = Color.FromArgb(128, 255, 128);
            txtBoxUsername.Cursor = Cursors.Hand;
            txtBoxUsername.Location = new Point(135, 116);
            txtBoxUsername.Name = "txtBoxUsername";
            txtBoxUsername.Size = new Size(206, 23);
            txtBoxUsername.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(135, 183);
            label3.Name = "label3";
            label3.Size = new Size(91, 25);
            label3.TabIndex = 2;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(135, 88);
            label2.Name = "label2";
            label2.Size = new Size(98, 25);
            label2.TabIndex = 1;
            label2.Text = "Username";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Bahnschrift Condensed", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(188, 26);
            label1.Name = "label1";
            label1.Size = new Size(107, 39);
            label1.TabIndex = 0;
            label1.Text = "L O G I N ";
            label1.Click += label1_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1339, 786);
            Controls.Add(panel1);
            Name = "Login";
            Text = "Login";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox txtBoxPassword;
        private TextBox txtBoxUsername;
        private Label label3;
        private Label label2;
        private Button btnLogin;
        private BindingSource bindingSource1;
        private PictureBox pictureBox1;
    }
}