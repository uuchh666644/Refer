using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;


namespace afterservice
{
    public partial class registerForm : Form
    {
        public registerForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            comboBox1.Items.Add("inventory staff");
            comboBox1.Items.Add("delivery staff");
            comboBox1.Items.Add("product controller staff");
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0; 
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRole = comboBox1.SelectedItem.ToString();  
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            string username = username1.Text.Trim();
            string password = password1.Text.Trim();
            string confirmPassword = textBox_confirmPassword.Text.Trim();
            string permission = comboBox1.SelectedItem.ToString().Trim();

            if (verify(username, password, confirmPassword))
            {
                DBconnect connect = new DBconnect();
                string query = "Insert into user(username, password, permission) values (@username, @password, @permission)";
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connect.getconnection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@permission", permission);
                        connect.openConnect();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            label6.Text = "Password confirmed, registration successful!";
                            label6.ForeColor = Color.Green;
                            MessageBox.Show("Registration successful!");
                            this.Close();
                        }
                        else
                        {
                            label6.Text = "Insert failed, please check your input.";
                            label6.ForeColor = Color.Red;
                            MessageBox.Show("Insert failed, please check your input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    label6.Text = "Save failed: " + ex.Message;
                    label6.ForeColor = Color.Red;
                    MessageBox.Show("Save failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool verify(string username, string password, string confirmPassword)
        {
            if (username == "" || password == "" || confirmPassword == "")
            {
                label6.Text = "Please fill in all fields.";
                label6.ForeColor = Color.Red;
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (password != confirmPassword)
            {
                label6.Text = "Passwords do not match.";
                label6.ForeColor = Color.Red;
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        private void registerForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string password = password1.Text.Trim();
            string confirmPassword = textBox_confirmPassword.Text.Trim();

            if (confirmPassword == "")
            {
                label6.Text = "Please enter a confirmation password.";
                label6.ForeColor = Color.Red;
            }
            else if (password == confirmPassword)
            {
                label6.Text = "Passwords match";
                label6.ForeColor = Color.Green;
            }
            else
            {
                label6.Text = "Passwords do not match";
                label6.ForeColor = Color.Red;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
