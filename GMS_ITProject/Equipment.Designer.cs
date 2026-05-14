namespace GMS_ITProject
{
    partial class Equipment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Equipment));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtEquipName = new TextBox();
            txtMusclesUsed = new TextBox();
            txtDescription = new RichTextBox();
            dateTimePickerDeliveryDate = new DateTimePicker();
            txtCost = new TextBox();
            btnSave = new Button();
            btnReset = new Button();
            btnViewEq = new Button();
            label6 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Emoji", 11.25F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(130, 180);
            label1.Name = "label1";
            label1.Size = new Size(139, 20);
            label1.TabIndex = 0;
            label1.Text = "Equipment Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Emoji", 11.25F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(145, 235);
            label2.Name = "label2";
            label2.Size = new Size(96, 20);
            label2.TabIndex = 1;
            label2.Text = "Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Emoji", 11.25F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(145, 316);
            label3.Name = "label3";
            label3.Size = new Size(115, 20);
            label3.TabIndex = 2;
            label3.Text = "Muscle Target";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Emoji", 11.25F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(145, 379);
            label4.Name = "label4";
            label4.Size = new Size(112, 20);
            label4.TabIndex = 3;
            label4.Text = "Delivery Date";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Emoji", 11.25F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(145, 432);
            label5.Name = "label5";
            label5.Size = new Size(42, 20);
            label5.TabIndex = 4;
            label5.Text = "Cost";
            // 
            // txtEquipName
            // 
            txtEquipName.Location = new Point(273, 180);
            txtEquipName.Name = "txtEquipName";
            txtEquipName.Size = new Size(163, 23);
            txtEquipName.TabIndex = 5;
            // 
            // txtMusclesUsed
            // 
            txtMusclesUsed.Location = new Point(273, 317);
            txtMusclesUsed.Name = "txtMusclesUsed";
            txtMusclesUsed.Size = new Size(120, 23);
            txtMusclesUsed.TabIndex = 6;
            txtMusclesUsed.TextChanged += textBox2_TextChanged;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(274, 232);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(182, 71);
            txtDescription.TabIndex = 7;
            txtDescription.Text = "";
            // 
            // dateTimePickerDeliveryDate
            // 
            dateTimePickerDeliveryDate.Format = DateTimePickerFormat.Short;
            dateTimePickerDeliveryDate.Location = new Point(273, 379);
            dateTimePickerDeliveryDate.Name = "dateTimePickerDeliveryDate";
            dateTimePickerDeliveryDate.Size = new Size(140, 23);
            dateTimePickerDeliveryDate.TabIndex = 8;
            dateTimePickerDeliveryDate.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // txtCost
            // 
            txtCost.Location = new Point(273, 433);
            txtCost.Name = "txtCost";
            txtCost.Size = new Size(100, 23);
            txtCost.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(338, 526);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(450, 526);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 23);
            btnReset.TabIndex = 11;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnViewEq
            // 
            btnViewEq.Location = new Point(556, 526);
            btnViewEq.Name = "btnViewEq";
            btnViewEq.Size = new Size(118, 23);
            btnViewEq.TabIndex = 12;
            btnViewEq.Text = "View Equipments";
            btnViewEq.UseVisualStyleBackColor = true;
            btnViewEq.Click += btnViewEq_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ButtonFace;
            label6.Location = new Point(435, 118);
            label6.Name = "label6";
            label6.Size = new Size(141, 20);
            label6.TabIndex = 13;
            label6.Text = "ＧＹＭＦＩＲＳＴ.";
            label6.TextAlign = ContentAlignment.TopCenter;
            label6.Click += label6_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Location = new Point(450, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(106, 78);
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // Equipment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(997, 614);
            Controls.Add(pictureBox1);
            Controls.Add(label6);
            Controls.Add(btnViewEq);
            Controls.Add(btnReset);
            Controls.Add(btnSave);
            Controls.Add(txtCost);
            Controls.Add(dateTimePickerDeliveryDate);
            Controls.Add(txtDescription);
            Controls.Add(txtMusclesUsed);
            Controls.Add(txtEquipName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Equipment";
            Text = "Equipment";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtEquipName;
        private TextBox txtMusclesUsed;
        private RichTextBox txtDescription;
        private DateTimePicker dateTimePickerDeliveryDate;
        private TextBox txtCost;
        private Button btnSave;
        private Button btnReset;
        private Button btnViewEq;
        private Label label6;
        private PictureBox pictureBox1;
    }
}