using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using MySql.Data.MySqlClient;


namespace afterservice
{
    public partial class createreq : Form
    {
        public createreq()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.Load += new EventHandler(Create_Requirement_Load);
            comboBox1.Items.Add("Inventory staff");
            comboBox1.Items.Add("Delivery staff");
            comboBox1.Items.Add("Product controller staff");
            comboBox1.Items.Add("Manager");

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }
        public delegate void DataSubmittedHandler();
        public event DataSubmittedHandler dataSubmitted;
        private void Create_Requirement_Load(object sender, EventArgs e)
        {
            Guid guid = Guid.NewGuid();
            string fullid = guid.ToString("N");
            using (System.Security.Cryptography.SHA1 sha1 = System.Security.Cryptography.SHA1.Create())
            {
                byte[] hash = sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(fullid));
                string shortHash = BitConverter.ToString(hash).Replace("-", "").Substring(0, 8);
                this.textBox4.Text = shortHash;
                this.textBox4.ReadOnly = true;
            }
            LoadAllUser();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string reqID = this.textBox4.Text.Trim();
            string createBy = this.comboBox1.SelectedItem.ToString().Trim();
            string remark = this.richTextBox1.Text.Trim();
            string productType = this.textBox3.Text.Trim();
            string cusName = this.textBox5.Text.Trim();
            string cusPhone = this.textBox1.Text.Trim();
            string cusAddress = this.textBox6.Text.Trim();
            string cusEmail = this.textBox2.Text.Trim();
            DateTime receivingTime = this.dateTimePicker1.Value.Date;

            if (string.IsNullOrEmpty(reqID) || string.IsNullOrEmpty(createBy) || string.IsNullOrEmpty(productType))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string connectionString = "server=localhost;database=afterservice;uid=root;password=;";

            string query = "INSERT INTO Requirements (ReqID, CreatedBy, remark, productType, ReceivingTime, cusName, cusPhone, cusAddress) " +
                "VALUES (@reqID, @createdBy, @remark, @productType, @receivingTime,@cusName,@cusPhone,@cusAddress)";

            string infoQuery = "INSERT INTO info(RequestID,Name,Email,Phone,Address,State) " +
                "VALUES(@reqID,@cusName,@cusEmail,@cusPhone,@cusAddress,'Pending Approval')";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using(MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@reqID", reqID);
                                cmd.Parameters.AddWithValue("@createdBy", createBy);
                                cmd.Parameters.AddWithValue("@remark", remark);
                                cmd.Parameters.AddWithValue("@productType", productType);
                                cmd.Parameters.AddWithValue("@cusName", cusName);
                                cmd.Parameters.AddWithValue("@cusPhone", cusPhone);
                                cmd.Parameters.AddWithValue("@cusAddress", cusAddress);
                                cmd.Parameters.AddWithValue("@receivingTime", receivingTime);

                                cmd.ExecuteNonQuery();
                            }
                            using (MySqlCommand infoCmd = new MySqlCommand(infoQuery, conn, transaction))
                            {
                                infoCmd.Parameters.AddWithValue("@reqID", reqID);
                                infoCmd.Parameters.AddWithValue("@cusName",cusName);
                                infoCmd.Parameters.AddWithValue("@cusPhone", cusPhone);
                                infoCmd.Parameters.AddWithValue("@cusEmail", cusEmail);
                                infoCmd.Parameters.AddWithValue("@cusAddress", cusAddress);
                                
                                infoCmd.ExecuteNonQuery();
                            }
                            transaction.Commit();
                            MessageBox.Show("Data has been saved successfully!");
                            dataSubmitted?.Invoke();
                            this.Close();
                        }
                        catch(Exception ex) 
                        {
                            transaction.Rollback();
                            MessageBox.Show("Save failed：" + ex.Message);
                        }
                        
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedDept = comboBox1.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(selectedDept))
            {
                LoadUserByDept(selectedDept);
            }
        }
        private void LoadUserByDept(string dept)
        {
            string query = "select username from user where permission = @dept";
            DBconnect connect = new DBconnect();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connect.getconnection))
                {
                    cmd.Parameters.AddWithValue("@dept", dept);
                    connect.openConnect();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        comboBox2.Items.Clear();
                        while (reader.Read())
                        {

                            string name = reader["username"].ToString();
                            comboBox2.Items.Add(name);
                        }
                        if (comboBox2.Items.Count > 0)
                        {
                            comboBox2.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error to load users: " + ex.Message);
            }
        }
        private void LoadAllUser()
        {
            string query = "select username from user ";
            DBconnect conn = new DBconnect();

            using (MySqlCommand cmd = new MySqlCommand(query, conn.getconnection))
            {
                conn.openConnect();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    comboBox2.Items.Clear();
                    while (reader.Read())
                    {
                        string name = reader["username"].ToString();
                        comboBox2.Items.Add(name);
                    }
                    if (comboBox2.Items.Count > 0)
                    {
                        comboBox2.SelectedIndex = 0;
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reqProductSelection selectResult = new reqProductSelection(textBox3);
            selectResult.ShowDialog();
        }
       
    }
}
