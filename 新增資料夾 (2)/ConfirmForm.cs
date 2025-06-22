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
    public partial class ConfirmForm : Form
    {
        private DeliveryOrderData OrderData;

        public ConfirmForm(DeliveryOrderData data)
        {
            InitializeComponent();
            OrderData = data;
            ShowOrderData();
        }

        private void ShowOrderData()
        {
            panelProducts.Controls.Clear();
            int y = 0;

            Font headerFont = new Font("Arial", 11, FontStyle.Bold);
            Font cellFont = new Font("Arial", 11);

            Label lblProductH = new Label { Text = "Product", Location = new Point(10, y), Width = 200, Font = headerFont };
            Label lblQtyH = new Label { Text = "Quantity", Location = new Point(220, y), Width = 80, Font = headerFont };
            Label lblPriceH = new Label { Text = "Price", Location = new Point(310, y), Width = 100, Font = headerFont };
            panelProducts.Controls.Add(lblProductH);
            panelProducts.Controls.Add(lblQtyH);
            panelProducts.Controls.Add(lblPriceH);
            y += 28;

            decimal total = 0;
            foreach (var item in OrderData.Items)
            {
                Label lblProduct = new Label { Text = item.ProductName, Location = new Point(10, y), Width = 200, Font = cellFont };
                Label lblQty = new Label { Text = item.Quantity.ToString(), Location = new Point(220, y), Width = 80, Font = cellFont };
                Label lblPrice = new Label { Text = $"${item.Price:0.00}", Location = new Point(310, y), Width = 100, Font = cellFont };
                panelProducts.Controls.Add(lblProduct);
                panelProducts.Controls.Add(lblQty);
                panelProducts.Controls.Add(lblPrice);
                total += item.Price * item.Quantity;
                y += 24;
            }

            labelTotal.Text = $"Total: ${total:0.00}";

            labelName.Text = $"Customer Name: {OrderData.CustomerName}";
            labelAddress.Text = $"Address: {OrderData.Address}";
            labelPhone.Text = $"Phone: {OrderData.Phone}";
            labelEmail.Text = $"Email: {OrderData.Email}";
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Order Confirmed!\nThank you!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;

            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDoc;
            ((Form)previewDialog).WindowState = FormWindowState.Maximized;
            previewDialog.ShowDialog();
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            float y = 80;
            float left = 100;
            float right = e.PageBounds.Width - 100;
            float lineHeight = 24;
            Font printFont = new Font("Arial", 12);

            string companyName = "Smile Sunshine";
            SizeF companySize = e.Graphics.MeasureString(companyName, new Font("Arial", 16, FontStyle.Bold));
            e.Graphics.DrawString(companyName, new Font("Arial", 16, FontStyle.Bold), Brushes.Black, (e.PageBounds.Width - companySize.Width) / 2, y);
            y += companySize.Height + 10;

            e.Graphics.DrawLine(Pens.Black, left, y, right, y);
            y += 10;

            e.Graphics.DrawString("Product", printFont, Brushes.Black, left, y);
            e.Graphics.DrawString("Quantity", printFont, Brushes.Black, left + 200, y);
            e.Graphics.DrawString("Price", printFont, Brushes.Black, left + 320, y);
            y += lineHeight;

            decimal total = 0;
            foreach (var item in OrderData.Items)
            {
                e.Graphics.DrawString(item.ProductName, printFont, Brushes.Black, left, y);
                e.Graphics.DrawString(item.Quantity.ToString(), printFont, Brushes.Black, left + 200, y);
                e.Graphics.DrawString($"${item.Price:0.00}", printFont, Brushes.Black, left + 320, y);
                total += item.Price * item.Quantity;
                y += lineHeight;
            }

            e.Graphics.DrawLine(Pens.Black, left, y, right, y);
            y += 10;

            e.Graphics.DrawString($"Total: ${total:0.00}", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, left, y);
            y += lineHeight * 2;

            e.Graphics.DrawString($"Name: {OrderData.CustomerName}", printFont, Brushes.Black, left, y); y += lineHeight;
            e.Graphics.DrawString($"Phone: {OrderData.Phone}", printFont, Brushes.Black, left, y); y += lineHeight;
            e.Graphics.DrawString($"Email: {OrderData.Email}", printFont, Brushes.Black, left, y); y += lineHeight;
            if (!string.IsNullOrEmpty(OrderData.Address))
            {
                e.Graphics.DrawString($"Address: {OrderData.Address}", printFont, Brushes.Black, left, y); y += lineHeight;
            }

            float signY = e.PageBounds.Height - 100;
            e.Graphics.DrawString("Signature: ______________", printFont, Brushes.Black, right - 220, signY);

            e.Graphics.DrawString(DateTime.Now.ToString("yyyy-MM-dd"), printFont, Brushes.Black, left, signY);
        }
    }
}