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
    public partial class inventoryStaffMenu : Form
    {
        public inventoryStaffMenu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            button_inventory.Image = ResizeImage(Properties.Resources.productRequirement, new Size(32, 32));
            button_inventory.ImageAlign = ContentAlignment.MiddleLeft;
            button_inventory.TextImageRelation = TextImageRelation.ImageBeforeText;
        }
        private Image ResizeImage(Image imgToResize, Size size)
        {
            return new Bitmap(imgToResize, size);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1(this);
            this.Hide();
            form.Show();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            loginForm log = new loginForm();
            this.Hide();
            log.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Supplie sup = new Supplie(this);
            this.Hide();
            sup.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            record1 re = new record1(this);
            this.Hide();
            re.Show();
        }
    }
}
