namespace FoodCourt
{
    partial class Form1
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
            this.Login = new System.Windows.Forms.Button();
            this.Registration = new System.Windows.Forms.Button();
            this.admin = new System.Windows.Forms.Button();
            this.manager = new System.Windows.Forms.Button();
            this.refresh = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.Color.OrangeRed;
            this.Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Login.ForeColor = System.Drawing.Color.White;
            this.Login.Location = new System.Drawing.Point(243, 85);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(173, 63);
            this.Login.TabIndex = 2;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // Registration
            // 
            this.Registration.BackColor = System.Drawing.Color.OrangeRed;
            this.Registration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Registration.ForeColor = System.Drawing.Color.White;
            this.Registration.Location = new System.Drawing.Point(243, 195);
            this.Registration.Name = "Registration";
            this.Registration.Size = new System.Drawing.Size(173, 63);
            this.Registration.TabIndex = 8;
            this.Registration.Text = "Registration";
            this.Registration.UseVisualStyleBackColor = false;
            this.Registration.Click += new System.EventHandler(this.RegistrationBtn);
            // 
            // admin
            // 
            this.admin.BackColor = System.Drawing.Color.DodgerBlue;
            this.admin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.admin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.admin.Location = new System.Drawing.Point(173, 279);
            this.admin.Name = "admin";
            this.admin.Size = new System.Drawing.Size(143, 47);
            this.admin.TabIndex = 9;
            this.admin.Text = "Admin";
            this.admin.UseVisualStyleBackColor = false;
            this.admin.Visible = false;
            this.admin.Click += new System.EventHandler(this.admin_Click);
            // 
            // manager
            // 
            this.manager.BackColor = System.Drawing.Color.DodgerBlue;
            this.manager.Cursor = System.Windows.Forms.Cursors.Hand;
            this.manager.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.manager.Location = new System.Drawing.Point(339, 279);
            this.manager.Name = "manager";
            this.manager.Size = new System.Drawing.Size(143, 47);
            this.manager.TabIndex = 10;
            this.manager.Text = "Manager";
            this.manager.UseVisualStyleBackColor = false;
            this.manager.Visible = false;
            this.manager.Click += new System.EventHandler(this.manager_Click);
            // 
            // refresh
            // 
            this.refresh.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh.Location = new System.Drawing.Point(12, 12);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(64, 30);
            this.refresh.TabIndex = 11;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = false;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.OrangeRed;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(243, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 63);
            this.button1.TabIndex = 12;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 472);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.manager);
            this.Controls.Add(this.admin);
            this.Controls.Add(this.Registration);
            this.Controls.Add(this.Login);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button Registration;
        private System.Windows.Forms.Button admin;
        private System.Windows.Forms.Button manager;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Button button1;
    }
}

