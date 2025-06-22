using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace afterservice
{
    public partial class CreaterequirementMenu : Form
    {
        private DataTable dataTable;
        private MySqlDataAdapter dataAdapter;
        private MySqlConnection conn;
        private Form _parentMenu;
        public CreaterequirementMenu(Form parentMenu)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            
            _parentMenu = parentMenu;
            LoadData();
        }

        private void CreaterequirementMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            createreq re = new createreq();
            re.dataSubmitted += LoadData;
            re.ShowDialog();
        }
        private void form2_dataSubmitted()
        {
            throw new NotImplementedException();
        }

        private void LoadData()
        {
            string connectionString = "server=localhost;database=afterservice;uid=root;password=;";
            string query = "SELECT ReqId, CreatedBy, productType,cusName,cusPhone,cusAddress, remark, ReceivingTime, CreateTime FROM Requirements";

            try
            {
                conn = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(query, conn);

                dataGridView1.AllowUserToAddRows = false;
                conn.Open();

                dataAdapter = new MySqlDataAdapter(cmd);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(dataAdapter);

                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataAdapter == null || dataGridView1.DataSource == null)
            {
                MessageBox.Show("Cannot save changes: Data adapter or data source is null.");
                return;
            }

            DataTable changesTable = ((DataTable)dataGridView1.DataSource).GetChanges();

            if (changesTable != null)
            {
                try
                {
                    // Ensure the connection is open
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    dataAdapter.Update(changesTable);
                    ((DataTable)dataGridView1.DataSource).AcceptChanges();
                    MessageBox.Show("Changes saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Save failed: {ex.Message}");
                    Console.WriteLine(ex.StackTrace); // Add debug info
                }
            }
            else
            {
                MessageBox.Show("No changes to save.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row first.");
                return;
            }

            var selectedRow = dataGridView1.SelectedRows[0];

            if (selectedRow.IsNewRow)
            {
                MessageBox.Show("New row does not need to be deleted.");
                return;
            }

            DataRowView dataRowView = selectedRow.DataBoundItem as DataRowView;
            if (dataRowView == null)
            {
                MessageBox.Show("Unable to retrieve corresponding DataRow.");
                return;
            }

            DataRow rowToDelete = dataRowView.Row;

            DialogResult result = MessageBox.Show("Are you sure you want to delete this row?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            try
            {
                rowToDelete.Delete();
                dataAdapter.Update(dataTable);
                MessageBox.Show("Deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete failed: " + ex.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            _parentMenu.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string reqId = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(reqId))
            {
                MessageBox.Show("Please enter a Requirement ID to search.");
                return;
            }
            string query = "SELECT * FROM requirements WHERE ReqId = @ReqId";
            DBconnect connect = new DBconnect();
            using (MySqlCommand cmd = new MySqlCommand(query, connect.getconnection))
            {
                cmd.Parameters.AddWithValue("@ReqId", reqId);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No data found for the given Requirement ID.");

                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
