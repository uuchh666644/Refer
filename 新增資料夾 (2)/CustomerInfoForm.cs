using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace afterservice
{
    public partial class CustomerInfoForm : Form
    {
        private DeliveryOrderData OrderData;

        public CustomerInfoForm(DeliveryOrderData data)
        {
            InitializeComponent();
            OrderData = data;
        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text) ||
                string.IsNullOrWhiteSpace(textBoxPhone.Text) ||
                string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("Name, Phone, and Email are required.");
                return;
            }

            if (!Regex.IsMatch(textBoxPhone.Text, @"^\+?\d+$"))
            {
                MessageBox.Show("Phone number can only contain + and digits.");
                textBoxPhone.Focus();
                return;
            }

            if (!textBoxEmail.Text.Contains("@"))
            {
                MessageBox.Show("Please enter the correct Email format");
                textBoxEmail.Focus();
                return;
            }

            OrderData.CustomerName = textBoxName.Text.Trim();
            OrderData.Address = textBoxAddress.Text.Trim();
            OrderData.Phone = textBoxPhone.Text.Trim();
            OrderData.Email = textBoxEmail.Text.Trim();

            ConfirmForm confirmForm = new ConfirmForm(OrderData);
            this.Hide();
            var result = confirmForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.Show();
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxName.Clear();
            textBoxAddress.Clear();
            textBoxPhone.Clear();
            textBoxEmail.Clear();
            textBoxName.Focus();
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBoxPhone_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBoxAddress_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBoxName.Text, @"^[a-zA-Z\s]*$"))
            {
                MessageBox.Show("Only English letters and spaces are allowed in the name.");
                textBoxName.Text = Regex.Replace(textBoxName.Text, @"[^a-zA-Z\s]", "");
                textBoxName.SelectionStart = textBoxName.Text.Length;
            }
        }
    }
}
