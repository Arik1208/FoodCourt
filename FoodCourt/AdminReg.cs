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
    public partial class AdminReg : Form
    {
        string Gender;
        public AdminReg()
        {
            InitializeComponent();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown)
                Application.Exit();
        }
       
        private void AdminReg_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new LoginPage().Show();
        }

        private void register(object sender, EventArgs e)
        {
            string Name = string.Concat(fname.Text.Trim(), " ", lname.Text.Trim());
            string Dob = dob.Text.Trim();
           
            if (male.Checked == true)
            {
                Gender = male.Text;
            }
            else if(female.Checked == true)
            {
                Gender = female.Text;
            }
            string Address = address.Text.Trim();
            int MobileNo = Convert.ToInt32(number.Text);
            string UserName = user.Text.Trim();
            string Email = email.Text.Trim();
            string Password = password.Text.Trim();
            var conn = Database.ConnectDB();
          
                conn.Open();
      
            string query = string.Format("INSERT INTO Admin VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",Name,Dob,Gender,Address,MobileNo,UserName,Email,Password);
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    MessageBox.Show("Admin Inserted");
                  
                }
                else
                {
                    MessageBox.Show("Failed to insert Admin");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }
    }
}
