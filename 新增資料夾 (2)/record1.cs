using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
namespace afterservice
{
    public partial class record1 : Form
    {
        GuestClass record = new GuestClass();
        private Form _parentMenu;

        public record1(Form parentMenu)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _parentMenu = parentMenu;
        }

        private void record_Load(object sender, EventArgs e)
        {
            showTable();
        }

        public void showTable()
        {
            dataGridView1.DataSource = record.getRecordlist();
            AddEditDeleteButtons();
            stylechange();
        }

        // Add Edit, Delete, Print button columns (same as Supplie)
        private void AddEditDeleteButtons()
        {
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
                printButton.HeaderText = "Print";
                printButton.Name = "Print";
                printButton.Text = "Print";
                printButton.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Insert(2, printButton);
            }
        }

        // Make columns auto-size
        private void stylechange()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
                // You can add Delete logic here if needed
            }
        }

        // Print row (reuse from Supplie)
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
                    e.Graphics.DrawImage(logo, 100, y, 60, 60);
                }
                catch (Exception ex)
                {
                    e.Graphics.DrawString("Logo not found", contentFont, Brushes.Red, 100, y);
                }
                y += 70;

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

        private void button1_Click(object sender, EventArgs e)
        {
            string searchw = textBox_search.Text;
            string selectedColumn = comboBox1.Text;

            DataTable results = record.getRecordkeylist(selectedColumn, searchw);
            dataGridView1.DataSource = results;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            _parentMenu.Show();
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Transparent;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Red;
        }
    }
}