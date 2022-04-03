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
    public partial class ManagerPortal : Form
    {
        public ManagerPortal()
        {
            InitializeComponent();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown)
                Application.Exit();
        }
        private void ManagerPortal_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FoodManagement().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Order().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginPage().Show();
        }
    }
}
