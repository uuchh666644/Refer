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
    public partial class addnewmptype : Form
    {
        GuestClass addnew = new GuestClass();
        public addnewmptype()
        {
            InitializeComponent();
        }

        private void addnewmptype_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(opf.FileName);
        }

        private void button_ADD_Click(object sender, EventArgs e)
        {
            
            string pmname = textBox1.Text;

            string decrpition = textBox2.Text;
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img = ms.ToArray();


            if (verify())
            {
                try
                {
                    if (addnew.insertpminvrtity(pmname, decrpition,  img))
                    {
                        MessageBox.Show("Now the Purchase order added", "Add Purchase order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Emty  Field", "Add record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bool verify()
            {
                if ((textBox1.Text == "") || (textBox2.Text == "") || (pictureBox1.Image == null))
                {
                    return false;
                }
                else
                    return true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
    
}
