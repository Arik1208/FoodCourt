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
    public partial class PendingOrder : Form
    {
        public PendingOrder()
        {
            InitializeComponent();
            var order = GetAllOrder();
            dataGridView1.DataSource = order;
            
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown)
                Application.Exit();
        }
        private void PendingOrder_Load(object sender, EventArgs e)
        {

        }
        List<orderInfo> GetAllOrder()
        {
            var conn = Database.ConnectDB();
            List<orderInfo> orders = new List<orderInfo>();
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string query = String.Format("SELECT * FROM [Order]");
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    orderInfo o = new orderInfo();
                    o.OrderId = reader.GetInt32(reader.GetOrdinal("OrderId"));
                    o.ProductId = reader.GetString(reader.GetOrdinal("ProductId"));
                    o.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                    o.CustomerName = reader.GetString(reader.GetOrdinal("CustomerName"));

                    orders.Add(o);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
            return orders;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminPortal().Show();
        }
    }
}
