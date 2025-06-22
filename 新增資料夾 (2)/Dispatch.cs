using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DGVPrinterHelper;
using MySql.Data.MySqlClient;

namespace afterservice
{
    public partial class Dispatch : Form
    {
        private decimal totalAmount = 0; // Declare totalAmount as a class-level variable
        private string connectionString = "server=localhost;database=afterservice;uid=root;password=;";
        public Dispatch()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void InitializeCustomComponents()
        {
            // Initialize DataGridView columns
            dataGridView_shoppingcart.Columns.Add("Sr#", "Sr#");
            dataGridView_shoppingcart.Columns.Add("Name", "Name");
            dataGridView_shoppingcart.Columns.Add("Qty", "Qty");
            dataGridView_shoppingcart.Columns.Add("Price", "Price");
            dataGridView_shoppingcart.Columns.Add("Amount", "Amount");
        }

        private void LoadProducts()
        {
            InitializeCustomComponents();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ReqId, productName, price FROM requirements";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string productName = reader["productName"].ToString();
                        decimal price = reader["price"] != DBNull.Value ? Convert.ToDecimal(reader["price"]) : 0m;

                        // Create a button for each product
                        Button btn = new Button
                        {
                            Text = $"{productName}\n${price:F2}", // Display name and price on button
                            Tag = price, // Store price in Tag
                            Size = new System.Drawing.Size(150, 50)
                        };
                        btn.Click += Btn_Click;
                        flowLayoutPanel_product.Controls.Add(btn);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading products: " + ex.Message);
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string productName = btn.Text.Split('\n')[0]; // Extract name from button text
            decimal price = (decimal)btn.Tag;
            int rowCount = dataGridView_shoppingcart.Rows.Count;

            // Add new row to DataGridView
            dataGridView_shoppingcart.Rows.Add(rowCount + 1, productName, 1, price.ToString("C"), price.ToString("C"));
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            totalAmount = 0;
            foreach (DataGridViewRow row in dataGridView_shoppingcart.Rows)
            {
                if (row.Cells["Amount"].Value != null && row.Cells["Amount"].Value.ToString() != "")
                {
                    if (decimal.TryParse(row.Cells["Amount"].Value.ToString().Replace("$", ""), out decimal amount))
                    {
                        totalAmount += amount;
                    }
                }
            }
            label1.Text = $"Total: ${totalAmount:F2}";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void showTable()
        {

        }
        private void Dispatch_Load(object sender, EventArgs e)
        {
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            
        }
        

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            
        }

        private void button_print_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox_product_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_back_Click_1(object sender, EventArgs e)
        {
            menu mu = new menu();
            this.Hide();
            mu.Show();
        }

        private void button_clear_Click_1(object sender, EventArgs e)
        {

        }

        private void button_add_Click_1(object sender, EventArgs e)
        {

        }
    }
}
