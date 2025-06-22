using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace afterservice
{
    
    public partial class editrecord : Form
    {
        string originalState;
        int originalQuantity;
        string itemName;
        
        public editrecord()
        {
            InitializeComponent();
        }

        private void editrecord_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        int _inID;
        GuestClass record = new GuestClass();

        public editrecord(int inID)
        {
            InitializeComponent();
            _inID = inID;
            LoadRecordData();
        }

        private void LoadRecordData()
        {
            DataTable dt = record.getRecordkeylist("inID", _inID.ToString());
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                label2.Text = _inID.ToString();
                textBox1.Text = row["ItemName"].ToString();
                textBox2.Text = row["Quantity"].ToString();
                textBox3.Text = row["price"].ToString();
                textBox4.Text = row["Supplier"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row["Dateti"]);
                comboBox1.Text = row["state"].ToString();

                originalState = row["state"].ToString();
                originalQuantity = int.Parse(row["Quantity"].ToString());
                itemName = row["ItemName"].ToString();
                
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string supplier = textBox4.Text;
            string itemname = textBox1.Text;
            string quantity = textBox2.Text;
            string price = textBox3.Text;
            DateTime indate = dateTimePicker1.Value;
            string state = comboBox1.Text;
            int qty = int.Parse(quantity);

            // If state changed to "Finish" and wasn't "Finish" before, update maprinventry
            if (originalState != "Finish" && state == "Finish")
            {
                // Update the Quantity in maprinventry
                if (record.UpdateMaprInventoryQuantity(itemname, qty))
                {
                    // Optionally inform user
                }
                else
                {
                    MessageBox.Show("Failed to update inventory quantity!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // If the record is already finished, prevent changes
            if (originalState == "Finish")
            {
                MessageBox.Show("This record is already finished and cannot be modified.", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool updated = record.updateInwardRecord(_inID, supplier, itemname, quantity, price, indate, state);

            if (updated)
            {
                MessageBox.Show("update successful!", "hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("update unsuccessful!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string supplier = textBox4.Text;
            string itemname = textBox1.Text;
            string quantity = textBox2.Text;
            string price = textBox3.Text;
            DateTime indate = dateTimePicker1.Value;
            string state = comboBox1.Text;
            int newQty = int.Parse(quantity);

            
            int diff = newQty - originalQuantity;

           
            if (diff != 0)
            {
                if (!record.UpdateMaprInventoryQuantity(itemname, diff))
                {
                    MessageBox.Show("Inventory update error!", "wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            
            bool updated = record.updateInwardRecord(_inID, supplier, itemname, quantity, price, indate, state);

            if (updated)
            {
                MessageBox.Show("update successful!", "hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("update unsuccessful!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
