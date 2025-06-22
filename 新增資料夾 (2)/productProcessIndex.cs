using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace afterservice.ProductPorcess
{

    public partial class productProcessIndex : Form
    {
        public string connectionString = "server=localhost;database=afterservice;uid=root;password=;";
        public productProcessIndex()
        {
            InitializeComponent();
            LoadData();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void LoadData()
        {

            string query = "Select i.RequestID ,p.planStart,p.planEnd,p.productType,p.Quantity,i.state from productprocess p inner join info i on p.ReqId = i.RequestID where i.state = 'Processing' or i.state ='Pending Approval'";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    
                    dataGridView1.DataSource = dt;

                    if (!ColumnExists(dataGridView1, "EditButton"))
                    {
                        DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                        btnColumn.Name = "EditButton";
                        btnColumn.HeaderText = "Edit";
                        btnColumn.Text = "Edit";
                        btnColumn.UseColumnTextForButtonValue = true;
                        dataGridView1.Columns.Insert(0, btnColumn);

                        dataGridView1.Columns["EditButton"].Width = 30;

                       
                        dataGridView1.RowTemplate.Height = 20;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load data: " + ex.Message);
                }
            }
        }
        private void dataGridView_editClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "EditButton")
            {
                int rowIndex = e.RowIndex;
                if(rowIndex >= 0)
                {
                    string reqId = dataGridView1.Rows[rowIndex].Cells["RequsetID"].Value.ToString();
                    processEdit edit = new processEdit(reqId);
                    edit.Show();
                }
            }
        }
        private bool ColumnExists(DataGridView dgv, string columnName)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Name == columnName)
                    return true;
            }
            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            menu mn = new menu();
            mn.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to process.");
                return;
            }
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            object reqIDObj = selectedRow.Cells["RequestID"].Value;

            string reqID = reqIDObj.ToString();
            if (string.IsNullOrEmpty(reqID))
            {
                MessageBox.Show("Unable to obtain RequestID");
                return;
            }

            string updateQuery = "UPDATE info SET state = 'Processing' WHERE RequestID = @reqID";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {

                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                {

                    cmd.Parameters.AddWithValue("@reqID", reqID);


                    int rowsAffected = cmd.ExecuteNonQuery();


                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Status updated to Processing！");


                        LoadData();
                    }
                    else
                    {

                        MessageBox.Show("No corresponding records found");
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to process.");
                return;
            }
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            object reqIDObj = selectedRow.Cells["RequestID"].Value;

            string reqID = reqIDObj.ToString();
            if (string.IsNullOrEmpty(reqID))
            {
                MessageBox.Show("Unable to obtain RequestID");
                return;
            }

            string updateQuery = "UPDATE info SET state = 'Disapprove' WHERE RequestID = @reqID";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {

                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                {

                    cmd.Parameters.AddWithValue("@reqID", reqID);


                    int rowsAffected = cmd.ExecuteNonQuery();


                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Status updated to Processing！");


                        LoadData();
                    }
                    else
                    {

                        MessageBox.Show("No corresponding records found");
                    }
                }
            }
        }
    }
}
