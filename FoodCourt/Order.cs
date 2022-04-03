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
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
            var orderList = GetAllOrder();
            dataGridView1.DataSource = orderList;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown)
                Application.Exit();
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
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to Exit!", "Are you sure want to exit ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Hide();
                new ManagerPortal().Show();
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
           
            string ProductId = pId.Text.Trim();
            int Quantity = Convert.ToInt32(quantity.Text.Trim());
            string CustomerName = name.Text.Trim();
            int OrderId = Convert.ToInt32(orderNumber.Text);
            if (string.IsNullOrEmpty(pId.Text.Trim()) || string.IsNullOrEmpty(quantity.Text.Trim()) || string.IsNullOrEmpty(name.Text.Trim())||string.IsNullOrEmpty(orderNumber.Text.Trim()))
            {
                MessageBox.Show("Please give all information", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var Insertconn = Database.ConnectDB();
                var Updateconn = Database.ConnectDB();
                var Getconn = Database.ConnectDB();
                try
                {
                    Insertconn.Open();
                    Updateconn.Open();
                    Getconn.Open();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {


                    string getQuery = string.Format("Select * From Product Where Id='{0}'", ProductId);
                    SqlCommand GetCmd = new SqlCommand(getQuery, Getconn);
                    SqlDataReader reader = GetCmd.ExecuteReader();
                    Product p = null;
                    while (reader.Read())
                    {
                        p = new Product();
                        p.Id = reader.GetString(reader.GetOrdinal("Id"));
                        p.Name = reader.GetString(reader.GetOrdinal("Name"));
                        p.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                        p.Price = reader.GetInt32(reader.GetOrdinal("Price"));
                        p.RestId = reader.GetString(reader.GetOrdinal("RestId"));
                    }
                    if (p != null)
                    {
                        Getconn.Close();
                        if ((p.Quantity - Quantity) >= 0)
                        {
                            string insertQuery = string.Format("insert into [Order] values ('{0}','{1}','{2}','{3}')", OrderId,ProductId, Quantity, CustomerName);
                            SqlCommand Insertcmd = new SqlCommand(insertQuery, Insertconn);
                            int insert = Insertcmd.ExecuteNonQuery();
                            if (insert > 0)
                            {
                                MessageBox.Show("Order Confirm Successfully");
                                var orderList = GetAllOrder();
                                dataGridView1.DataSource = orderList;
                                Insertconn.Close();
                                
                                int totalQuantity = p.Quantity - Quantity;
                                string updateQuery = string.Format("Update Product set Quantity = '{0}' Where Id='{1}'",totalQuantity,ProductId);
                                SqlCommand Updatecmd = new SqlCommand(updateQuery, Updateconn);
                                int update = Updatecmd.ExecuteNonQuery();
                                Updateconn.Close();
                        
                            }
                            else
                            {
                                MessageBox.Show("Failed to confirm order");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Not enough food");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Product not found");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
             
               
            }

        }

        private void delete(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(orderNumber.Text.Trim()))
            {
                MessageBox.Show("Please give OrderId", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int OrderId = Convert.ToInt32(orderNumber.Text);
               
            
                var Deleteconn = Database.ConnectDB();
                try
                {
                 
                    Deleteconn.Open();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                string deletequery = String.Format("Delete From [Order] Where OrderId='{0}'", OrderId);
                try
                {
                    SqlCommand cmd = new SqlCommand(deletequery, Deleteconn);
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        MessageBox.Show("Order delivered done");
                        var orderList = GetAllOrder();
                        dataGridView1.DataSource = orderList;
                    }
                    else
                    {
                        MessageBox.Show("Order delivery failed");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void update(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Order_Load(object sender, EventArgs e)
        {

        }
    }
}
