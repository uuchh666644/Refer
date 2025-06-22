using afterservice.ProductPorcess;
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
    public partial class menu : Form
    {
        private Timer timer;
        public menu()
        {
            InitializeComponent();
            label5.Text = "00:00:00";
            this.StartPosition = FormStartPosition.CenterScreen;
            button_inventory.Image = ResizeImage(Properties.Resources.productRequirement, new Size(32, 32));
            button_inventory.ImageAlign = ContentAlignment.MiddleLeft;
            button_inventory.TextImageRelation = TextImageRelation.ImageBeforeText;

            button3.Image = ResizeImage(Properties.Resources.dispatchProcessing, new Size(32, 32));
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;

            button6.Image = ResizeImage(Properties.Resources.inventoryControl, new Size(32, 32));
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.TextImageRelation = TextImageRelation.ImageBeforeText;

            button7.Image = ResizeImage(Properties.Resources.afterService, new Size(32, 32));
            button7.ImageAlign = ContentAlignment.MiddleLeft;
            button7.TextImageRelation = TextImageRelation.ImageBeforeText;

            button_exit.Image = ResizeImage(Properties.Resources.exit, new Size(32, 32));
            button_exit.ImageAlign = ContentAlignment.MiddleLeft;
            button_exit.TextImageRelation = TextImageRelation.ImageBeforeText;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            updateTimeLabel();
        }

     

        private Image ResizeImage(Image imgToResize, Size size)
        {
            return new Bitmap(imgToResize, size);
        }
        private void button_dispatch_Click(object sender, EventArgs e)
        {

        }

        private void menu_Load(object sender, EventArgs e)
        {
            //panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;


        }

        private void button_product_Click(object sender, EventArgs e)
        {
            
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            loginForm log = new loginForm();
            this.Hide();
            log.Show();
        }

        private void button_inventory_Click(object sender, EventArgs e)
        {
            
        }

        private void button_afterservice_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void customizeDesign()
        {
            //panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;

        }
        private void hideSubmenu()
        {
            //if (panel3.Visible == true)
            //    panel3.Visible = false;
            if (panel4.Visible == true)
                panel4.Visible = false; 
            if (panel5.Visible == true)
                panel5.Visible = false;
        }

        private void sohwSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;

        }

        private void button_inventory_Click_1(object sender, EventArgs e)
        {
            CreaterequirementMenu req = new CreaterequirementMenu(this);
            this.Hide();
            req.Show();
            //sohwSubmenu(panel3);
        }

        private void button_record_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dispatch dis = new Dispatch();
            this.Hide();
            dis.Show();
            sohwSubmenu(panel4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sohwSubmenu(panel5);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Supplie sup = new Supplie(this);
            this.Hide();
            sup.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            record1 re = new record1(this);
            this.Hide();
            re.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1(this);
            this.Hide();
            form.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            registerForm reg = new registerForm();
            reg.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            productProcessIndex pro = new productProcessIndex();
            this.Hide();
            pro.Show();
        }

        private void Timer_Tick(Object sender, EventArgs e)
        {
            updateTimeLabel();
        }
        private void updateTimeLabel()
        {
            label5.Text = DateTime.Now.ToString("HH:mm:ss");
            label6.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

    }
}
