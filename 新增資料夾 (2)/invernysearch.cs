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
    public partial class invernysearch : Form
    {
        GuestClass pminvetory = new GuestClass();
        public invernysearch()
        {
            InitializeComponent();
            radioButtonProduct.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
            radioButtonMaterial.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void invernysearch_Load(object sender, EventArgs e)
        {
            showTable();
        }
        public void showTable()
        {
            dataGridView1.DataSource = pminvetory.getMaprInventoryList();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchw = textBox1.Text;
            string selectedColumn = comboBox1.Text;
            string typeFilter = "";

            if (radioButtonProduct.Checked) typeFilter = "Product";
            if (radioButtonMaterial.Checked) typeFilter = "Material";

            DataTable results;
            if (!string.IsNullOrEmpty(typeFilter))
            {
                results = pminvetory.getMaprInventoryByColumnAndType(selectedColumn, searchw);
            }
            else
            {
                results = pminvetory.getMaprInventoryByColumn(selectedColumn, searchw);
            }
            dataGridView1.DataSource = results;
        }
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonProduct.Checked)
            {
                // type=Product
                dataGridView1.DataSource = pminvetory.getMaprInventoryByColumn("type", "Product");
            }
            else if (radioButtonMaterial.Checked)
            {
                // type=Material
                dataGridView1.DataSource = pminvetory.getMaprInventoryByColumn("type", "Material");
            }
            else
            {
                // 显示全部
                dataGridView1.DataSource = pminvetory.getMaprInventoryList();
            }
        }
    }
}
