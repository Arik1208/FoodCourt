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
    public partial class ManagersList : Form
    {
        public ManagersList()
        {
            InitializeComponent();
            var managers = GetAllManagers();
            dataGridView1.DataSource = managers;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown)
                Application.Exit();
        }
        List<Manager> GetAllManagers()
        {
            var conn = Database.ConnectDB();
            List<Manager> managers = new List<Manager>();
            try
            {
                conn.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string query = String.Format("Select * From Manager");
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Manager m = new Manager();
                    m.Name = reader.GetString(reader.GetOrdinal("Name"));
                    m.Dob = reader.GetString(reader.GetOrdinal("Dob"));
                    m.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                    m.Address = reader.GetString(reader.GetOrdinal("Address"));
                    m.MobileNo = reader.GetInt32(reader.GetOrdinal("MobileNo"));
                    m.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                    m.Email = reader.GetString(reader.GetOrdinal("Email"));
                    m.Password = reader.GetString(reader.GetOrdinal("Password"));
                    managers.Add(m);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
            return managers;
        }
        private void EmployeeList_Load(object sender, EventArgs e)
        {
          
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminPortal().Show();
        }
    }
}
