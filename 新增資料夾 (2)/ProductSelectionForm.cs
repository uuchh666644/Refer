using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace afterservice
{
    public partial class ProductSelectionForm : Form
    {
        private string connStr = "server=localhost;database=afterservice;uid=root;password=;";
        public DeliveryOrderData OrderData = new DeliveryOrderData();

        public ProductSelectionForm()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "SELECT prodID, prodname, Quantity, price FROM productinventry";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (!dt.Columns.Contains("OrderQuantity"))
                        dt.Columns.Add("OrderQuantity", typeof(int));

                    foreach (DataRow row in dt.Rows)
                        row["OrderQuantity"] = 0;

                    dataGridViewProducts.DataSource = dt;
                    dataGridViewProducts.ReadOnly = false;
                    dataGridViewProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewProducts.MultiSelect = true;
                    dataGridViewProducts.Columns["OrderQuantity"].ReadOnly = false;
                    dataGridViewProducts.Columns["prodID"].ReadOnly = true;
                    dataGridViewProducts.Columns["prodname"].ReadOnly = true;
                    dataGridViewProducts.Columns["Quantity"].ReadOnly = true;
                    dataGridViewProducts.Columns["price"].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load product: " + ex.Message);
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridViewProducts.DataSource;
            OrderData.Items = new List<OrderItem>();

            foreach (DataRow row in dt.Rows)
            {
                int orderQty = 0;
                int.TryParse(row["OrderQuantity"].ToString(), out orderQty);
                int invenQty = 0;
                int.TryParse(row["Quantity"].ToString(), out invenQty);

                if (orderQty > 0)
                {
                    if (orderQty > invenQty)
                    {
                        MessageBox.Show($"Not enough stock for {row["prodname"]}. Only {invenQty} left.");
                        return;
                    }
                    string prodName = row["prodname"].ToString();
                    decimal price = 0;
                    decimal.TryParse(row["price"].ToString(), out price);

                    OrderData.Items.Add(new OrderItem
                    {
                        ProductName = prodName,
                        Quantity = orderQty,
                        Price = price
                    });
                }
            }

            if (OrderData.Items.Count == 0)
            {
                MessageBox.Show("Please select at least one product, and quantity must be at least 1.");
                return;
            }

            CustomerInfoForm infoForm = new CustomerInfoForm(OrderData);
            this.Hide();
            var result = infoForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                this.Show();
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            deliveryStaffMenu form = new deliveryStaffMenu();
            this.Hide();
            form.Show();
        }

        private void dataGridViewProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ProductSelectionForm_Load(object sender, EventArgs e)
        {

        }
    }
}