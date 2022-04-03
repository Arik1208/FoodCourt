using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodCourt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown)
                Application.Exit();
        }
        private void RegistrationBtn(object sender, EventArgs e)
        {
            admin.Visible = true;
            manager.Visible = true;
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            admin.Visible = false;
            manager.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginPage().Show();
        }

        private void admin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminReg().Show();

        }

        private void manager_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ManagerReg().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to Exit!", "Are you sure want to exit ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
