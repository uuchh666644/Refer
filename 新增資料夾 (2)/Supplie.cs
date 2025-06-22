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
using System.Drawing.Printing;
namespace afterservice
{
    public partial class Supplie : Form
    {
        GuestClass record = new GuestClass();
        private Form _parentMenu;

        public Supplie(Form parentMenu)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            _parentMenu = parentMenu;
        }

        private void button_ADD_Click(object sender, EventArgs e)
        {
            string supplier = textBox_supplier.Text;
            string iteamname = textBox_iteamname.Text;
            string quantity = textBox_quantity.Text;
            string price = textBox_price.Text;
            DateTime indate = dateTimePicker1.Value;






            if (!verify())
            {
                MessageBox.Show("Empty Field", "Add record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (!ItemExistsInInventory(iteamname))
            {
                MessageBox.Show("The inventory does not have this type of item. Please go to add new type of product/Material.",
                                "Item Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_iteamname.Focus();
                return;
            }


            try
            {
                if (record.insertinrecord(supplier, iteamname, quantity, price, indate, loginUser.Username))
                {
                    MessageBox.Show("Now the Purchase order added", "Add Purchase order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            bool verify()
            {
                if ((textBox_supplier.Text == "") || (textBox_iteamname.Text == "") || (textBox_quantity.Text == "") || (textBox_price.Text == ""))
                {
                    return false;
                }
                else
                    return true;
            }
            showTable();

        }
        private bool ItemExistsInInventory(string itemName)
        {
            // If type is empty, treat as not found
            if (string.IsNullOrEmpty(itemName))
                return false;

            DataTable dt = record.getMaprInventoryByColumnAndType("name", itemName);
            return dt != null && dt.Rows.Count > 0;
        }
        private void Supplie_Load(object sender, EventArgs e)
        {
            {
                showTable();
            }
        }
        public void showTable()
        {
            dataGridView1.DataSource = record.getRecordlist();
            AddEditDeleteButtons();
            stylechange();

        }
        private void PrintSelectedRow(int rowIndex)
        {
            var row = dataGridView1.Rows[rowIndex];
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += (s, e) =>
            {
                int y = 60;
                Font titleFont = new Font("Arial", 18, FontStyle.Bold);
                Font contentFont = new Font("Arial", 12);

                // Draw logo from resources
                try
                {
                    Image logo = Properties.Resources.download;
                    e.Graphics.DrawImage(logo, 100, y, 60, 60); // (x, y, width, height)
                }
                catch (Exception ex)
                {
                    e.Graphics.DrawString("Logo not found", contentFont, Brushes.Red, 100, y);
                }
                y += 70; // Move below the logo

                // Title and separator
                e.Graphics.DrawString("Inbound Order", titleFont, Brushes.Black, 100, y); y += 40;
                e.Graphics.DrawLine(Pens.Black, 100, y, 400, y); y += 20;

                // Data fields
                e.Graphics.DrawString($"Supplier: {row.Cells["Supplier"].Value}", contentFont, Brushes.Black, 100, y); y += 25;
                e.Graphics.DrawString($"Item Name: {row.Cells["ItemName"].Value}", contentFont, Brushes.Black, 100, y); y += 25;
                e.Graphics.DrawString($"Quantity: {row.Cells["Quantity"].Value}", contentFont, Brushes.Black, 100, y); y += 25;
                e.Graphics.DrawString($"Price: {row.Cells["price"].Value}", contentFont, Brushes.Black, 100, y); y += 25;
                e.Graphics.DrawString($"Date: {row.Cells["Dateti"].Value}", contentFont, Brushes.Black, 100, y); y += 25;
                e.Graphics.DrawString($"Person in Charge: {row.Cells["Personcharge"].Value}", contentFont, Brushes.Black, 100, y);
            };
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDoc;
            previewDialog.ShowDialog();
        }
        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_supplier.Clear();
            textBox_iteamname.Clear();
            textBox_quantity.Clear();
            textBox_price.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedtyprText = comboBox1.SelectedItem.ToString();
                if (selectedtyprText == "Material")
                {
                    tyelabe.Text = "Material name :";
                }
                else
                {
                    tyelabe.Text = "Product name :";
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    int inID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["inID"].Value);
                    editrecord editForm = new editrecord(inID);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        showTable();
                    }
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Print")
                {

                    PrintSelectedRow(e.RowIndex);
                }

            }
        }
        private void AddEditDeleteButtons()
        {
            // Prevent adding multiple times
            if (dataGridView1.Columns["Edit"] == null)
            {
                DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
                editButton.HeaderText = "Edit";
                editButton.Name = "Edit";
                editButton.Text = "Edit";
                editButton.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Insert(0, editButton);
            }

            if (dataGridView1.Columns["Delete"] == null)
            {
                DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
                deleteButton.HeaderText = "Delete";
                deleteButton.Name = "Delete";
                deleteButton.Text = "Delete";
                deleteButton.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Insert(1, deleteButton);
            }
            if (dataGridView1.Columns["Print"] == null)
            {
                DataGridViewButtonColumn printButton = new DataGridViewButtonColumn();
                printButton.HeaderText = "print";
                printButton.Name = "Print";
                printButton.Text = "print";
                printButton.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Insert(2, printButton);
            }
        }
        private void stylechange()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            _parentMenu.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            addnewmptype form = new addnewmptype();
            form.Show();
        }
    }
}
