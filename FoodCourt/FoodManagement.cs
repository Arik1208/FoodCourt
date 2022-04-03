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
    public partial class FoodManagement : Form
    {
        
        public FoodManagement()
        {
            InitializeComponent();
            var result = GetAllProduct();
            dataGridView1.DataSource = result;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown)
                Application.Exit();
        }
        List<Product> GetAllProduct()
        {
            var conn = Database.ConnectDB();
            List<Product> products = new List<Product>();
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string query = String.Format("SELECT * FROM Product");
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.Id = reader.GetString(reader.GetOrdinal("Id"));
                    p.Name = reader.GetString(reader.GetOrdinal("Name"));
                    p.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                    p.Price = reader.GetInt32(reader.GetOrdinal("Price"));
                    p.RestId = reader.GetString(reader.GetOrdinal("RestId"));
                    products.Add(p);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
            return products;
        }
       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ProductManagement_Load(object sender, EventArgs e)
        {

        }

        private void Add(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(id.Text.Trim()) || string.IsNullOrEmpty(name.Text.Trim()) || string.IsNullOrEmpty(quantity.Text.Trim()) || string.IsNullOrEmpty(price.Text.Trim()) || string.IsNullOrEmpty(restId.Text.Trim()))
            {
                MessageBox.Show("Please give all information", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string Id = id.Text.Trim();
                string Name = name.Text.Trim();
                int Quantity = Convert.ToInt32(quantity.Text);
                int Price = Convert.ToInt32(price.Text);
                string RestId = restId.Text.Trim();
                var conn = Database.ConnectDB();
                var conn1 = Database.ConnectDB();
                try
                {
                    conn.Open();
                    conn1.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                string Insertquery = string.Format("INSERT INTO Product VALUES('{0}','{1}','{2}','{3}','{4}')", Id, Name, Quantity, Price,RestId);
                string query = String.Format("Select * From Restaurant Where Id='{0}'", RestId);
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn1);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Restaurant restaurant = null;
                    while (reader.Read())
                    {
                        restaurant = new Restaurant();
                        restaurant.Id = reader.GetString(reader.GetOrdinal("Id"));
                        restaurant.Name = reader.GetString(reader.GetOrdinal("Name"));
                        restaurant.Location = reader.GetString(reader.GetOrdinal("Location"));
                        restaurant.MainDish = reader.GetString(reader.GetOrdinal("MainDish"));
                    }
                    if (restaurant != null)
                    {
                        
                        conn1.Close();
                        SqlCommand cmd1 = new SqlCommand(Insertquery, conn);
                        int r1 = cmd1.ExecuteNonQuery();
                        if (r1 > 0)
                        {
                            MessageBox.Show("Product Inserted");
                            var result = GetAllProduct();
                            dataGridView1.DataSource = result;
                        }
                        else
                        {
                            MessageBox.Show("Failed to insert the product");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Restaurant Not Found");
                    }
                  
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ManagerPortal().Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Delete(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(id.Text.Trim()))
            {
                MessageBox.Show("Please give all information", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string Id = id.Text.Trim();
                var conn = Database.ConnectDB();
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    string query = String.Format("Delete From Product where Id='{0}'", Id);
                    SqlCommand cmd = new SqlCommand(query, conn);
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        MessageBox.Show("Product Remove");
                      
                        var result = GetAllProduct();
                        dataGridView1.DataSource = result;
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete Product");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conn.Close();
            }
        }

        private void Update(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(id.Text.Trim()) ||  string.IsNullOrEmpty(quantity.Text.Trim()) || string.IsNullOrEmpty(price.Text.Trim()))
            {
                MessageBox.Show("Please give all information", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string Id = id.Text.Trim();
                int Quantity = Convert.ToInt32(quantity.Text);
                int Price = Convert.ToInt32(price.Text);
                var conn = Database.ConnectDB();
                try
                {
                    conn.Open();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                string query = String.Format("Update Product set Quantity='{0}',Price='{1}' Where Id ='{2}'",Quantity,Price,Id);
                try
                {


                    SqlCommand cmd = new SqlCommand(query, conn);
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        MessageBox.Show("Information Updated");
                        var result = GetAllProduct();
                        dataGridView1.DataSource = result;
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
                conn.Close();
            }
        }
    }
}
