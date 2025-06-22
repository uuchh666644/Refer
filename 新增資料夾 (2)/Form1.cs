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

namespace afterservice
{
    public partial class Form1 : Form
    {
        GuestClass guest = new GuestClass();
        private Form _parentMenu;
        public Form1(Form parentMenu)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _parentMenu = parentMenu;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showTable();
        }

        public void showTable()
        {
            dataGridView1.DataSource = guest.getGuestlist();
            
            }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            string oid = textBox_orderid.Text;
            DateTime oDate = dateTimePicker1.Value;
            string name = textBox_name.Text;
            string email = textBox_email.Text;
            string Phone = textBox_phone.Text;
            string request = textBox_request.Text;
            string state = comboBox_state.Text;
            MemoryStream ms = new MemoryStream();

            if(verify())
            {
                try
                {
                    if(guest.insertOrder(oid, oDate, name, email, Phone, request, state))
                    {
                        showTable();
                        MessageBox.Show("New request Added", "Add request", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                }catch(Exception ex)

                    { 
                        MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    
                    
                    
                    }
                else { 
                    
                    MessageBox.Show("Empty","Add request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                
                
                
                }


        

        bool verify()
        {
            if((textBox_orderid.Text=="")|| (textBox_name.Text == "") || (textBox_email.Text == "") || (textBox_phone.Text == ""))
            { 
                return false;
                }
            else
                return true;
            }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_email.Clear();
            textBox_name.Clear();
            textBox_phone.Clear();
            textBox_orderid.Clear();
            textBox_request.Clear();
            comboBox_state.ResetText();
        }

        private void textBox_orderid_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Hide();
                _parentMenu.Show();
        }

        private void textBox_state_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_state_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
