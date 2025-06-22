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

namespace afterservice
{
    public partial class loginForm : Form
    {
        GuestClass guest = new GuestClass();
        public loginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Red;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Transparent;
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_username.Text) || string.IsNullOrEmpty(textBox_password.Text))
        {
            MessageBox.Show("Need login data", "Wrong Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        string uname = textBox_username.Text;
        string pass = textBox_password.Text;

        // Use parameterized query to prevent SQL injection
        MySqlCommand cmd = new MySqlCommand("SELECT * FROM `user` WHERE `username` = @username AND `password` = @password");
        cmd.Parameters.AddWithValue("@username", uname);
        cmd.Parameters.AddWithValue("@password", pass);

        DataTable table = guest.getList(cmd);

        if (table.Rows.Count > 0)
        {
            // Get the permission from the query result
            string permission = table.Rows[0]["permission"].ToString();

            // Navigate to the appropriate menu based on permission
            Form targetMenu = null;
            switch (permission)
            {
                case "Manager":
                    targetMenu = new menu();
                    break;
                case "inventory staff":
                    targetMenu = new inventoryStaffMenu();
                    break;
                case "delivery staff":
                    targetMenu = new deliveryStaffMenu();
                    break;
                case "product controller staff":
                    targetMenu = new productStaffMenu();
                    break;
                default:
                    MessageBox.Show("Invalid permission.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
                loginUser.Username = uname;
                this.Hide();
            targetMenu.Show();
        }
        else
        {
            MessageBox.Show("Your username and password do not exist", "Wrong Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            


        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            textBox_password.UseSystemPasswordChar = true;
        }

        private void checkBox_showpassword_CheckedChanged(object sender, EventArgs e)
        {
            textBox_password.UseSystemPasswordChar = !checkBox_showpassword.Checked;
        }
    }
}
