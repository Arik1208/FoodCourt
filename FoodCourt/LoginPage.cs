using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodCourt
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown)
                Application.Exit();
        }
        private void LoginPage_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0); // Transparent Panel
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void passcheck_CheckedChanged(object sender, EventArgs e)
        {
            if (passcheck.Checked)
            {
                password.UseSystemPasswordChar = false;
            }
            else
            {
                password.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string User = user.Text.Trim();
            string Password = password.Text.Trim();
            var conn = Database.ConnectDB();
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string Adminquery = string.Format("select * from Admin where (Username= '{0}' OR Email='{1}') and Password= '{2}'",User,User,Password);
            string Managerquery = string.Format("select * from Manager where (Username= '{0}' OR Email='{1}') and Password= '{2}'",User,User,Password);
            if (admin.Checked == true)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(Adminquery, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        this.Hide();
                        new AdminPortal().Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid user","Invalid Information",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (manager.Checked == true)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(Managerquery, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        this.Hide();
                        new ManagerPortal().Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid user", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
