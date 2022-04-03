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
    public partial class RestaurantManagement : Form
    {
        public RestaurantManagement()
        {
            InitializeComponent();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown)
                Application.Exit();
        }
        List<Restaurant> GetAllRestaurant()
        {
            var conn = Database.ConnectDB();
            List<Restaurant> restaurants = new List<Restaurant>();
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string query = String.Format("SELECT * FROM Restaurant");
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Restaurant r = new Restaurant();
                    r.Id = reader.GetString(reader.GetOrdinal("Id"));
                    r.Name = reader.GetString(reader.GetOrdinal("Name"));
                    r.Location = reader.GetString(reader.GetOrdinal("Location"));
                    r.MainDish = reader.GetString(reader.GetOrdinal("MainDish"));
                    restaurants.Add(r);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
            return restaurants;
        }
        private void RestaurantManagement_Load(object sender, EventArgs e)
        {
            var restaurants = GetAllRestaurant();
            dgView.DataSource = restaurants;
        
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void add(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(id.Text.Trim()) || string.IsNullOrEmpty(name.Text.Trim()) || string.IsNullOrEmpty(location.Text.Trim()) || string.IsNullOrEmpty(dish.Text.Trim()))
            {
                MessageBox.Show("Please give all information", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {


                string Id = id.Text.Trim();
                string Name = name.Text.Trim();
                string Location = location.Text.Trim();
                string MainDish = dish.Text.Trim();
                var conn = Database.ConnectDB();
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                string query = string.Format("INSERT INTO Restaurant VALUES('{0}','{1}','{2}','{3}')", Id, Name, Location, MainDish);
          
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        MessageBox.Show("Restaurant Inserted");
                        var restaurants = GetAllRestaurant();
                        dgView.DataSource = restaurants;
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert Restaurant");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conn.Close();
            }
        }

        private void Delete(object sender, EventArgs e)
        {
            string Id = id.Text.Trim();
            var conn = Database.ConnectDB();
            try
            {
                conn.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string query = String.Format("Delete From Restaurant where Id='{0}'", Id);
                SqlCommand cmd = new SqlCommand(query, conn);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    MessageBox.Show("Restaurant Delete Done");
                    var restaurants = GetAllRestaurant();
                    dgView.DataSource = restaurants;
                }
                else
                {
                    MessageBox.Show("Failed to delete restaurant");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        private void Update(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(id.Text.Trim()) || string.IsNullOrEmpty(name.Text.Trim()) ||string.IsNullOrEmpty(location.Text.Trim())||string.IsNullOrEmpty(dish.Text.Trim()))
            {
                MessageBox.Show("Please give all information", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string Id = id.Text.Trim();
                string Name = name.Text.Trim();
                string Location = location.Text.Trim();
                string MainDish = dish.Text.Trim();
                var conn = Database.ConnectDB();
                try
                {
                    conn.Open();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                string query = String.Format("Update Restaurant set Name='{0}',Location='{1}',MainDish='{2}' Where Id='{3}'",  Name, Location, MainDish,Id);
                try
                {

                    SqlCommand cmd = new SqlCommand(query, conn);
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        MessageBox.Show("Information Updated");
                        var restaurants = GetAllRestaurant();
                        dgView.DataSource = restaurants;
                    }
                    else
                    {
                        MessageBox.Show("Information Updated failed");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminPortal().Show();
        }

        private void dgView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
