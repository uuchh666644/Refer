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
    public partial class reqProductSelection : Form
    {
        private TextBox textBoxToUpdate;
        public reqProductSelection(TextBox textBox)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            textBoxToUpdate = textBox;
            this.Text = "Product Selection";
            Panel panel = new Panel
            {
                AutoScroll = true,
                Size = new Size(640, 480),
                Location = new Point(0, 0),
                BackColor = Color.White
            };
            int x = 20, y = 20;
            for (int i = 1; i <= 30; i++)
            {
               
                string resourceName = $"product{i}";
                var resourceImage = Properties.Resources.ResourceManager.GetObject(resourceName) as Image;
                if (resourceImage != null)
                {
                    PictureBox pd = new PictureBox()
                    {
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Size = new Size(120, 120),
                        Location = new Point(x, y),
                        Tag = i,
                        BorderStyle = BorderStyle.FixedSingle,
                        Image = resourceImage,
                        
                    };

                    Label label = new Label()
                    {
                        Text = "XA" + i,
                        Location = new Point(x + 45, y + 130),
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    pd.Click += ProductImage_Click;
                    panel.Controls.Add(pd);
                    panel.Controls.Add(label);
                   

                    x += 140;
                    if (i % 4 == 0)
                    {
                        x = 20;
                        y += 150;
                    }
                }
            }
            this.Controls.Add(panel);
            this.ClientSize = new Size(640, 480);
        }
        private void ProductImage_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb != null && pb.Tag is int id)
            {
                string productId = "XA" + id;
                textBoxToUpdate.Text = productId;
                this.Close();
            }
        }
        
    }
}
