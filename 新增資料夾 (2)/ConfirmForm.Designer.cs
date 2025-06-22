namespace afterservice
{
    partial class ConfirmForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelProducts;
        private System.Windows.Forms.Label labelTotal;

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonPrint;

        private void InitializeComponent()
        {
            this.panelProducts = new System.Windows.Forms.Panel();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelProducts
            // 
            this.panelProducts.AutoScroll = true;
            this.panelProducts.Location = new System.Drawing.Point(50, 120);
            this.panelProducts.Name = "panelProducts";
            this.panelProducts.Size = new System.Drawing.Size(450, 180);
            this.panelProducts.TabIndex = 0;
            // 
            // labelTotal
            // 
            this.labelTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.labelTotal.Location = new System.Drawing.Point(50, 310);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(200, 23);
            this.labelTotal.TabIndex = 1;
            this.labelTotal.Text = "Total";
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(550, 120);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(200, 24);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Name";
            // 
            // labelAddress
            // 
            this.labelAddress.Location = new System.Drawing.Point(550, 160);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(200, 24);
            this.labelAddress.TabIndex = 3;
            this.labelAddress.Text = "Address";
            // 
            // labelPhone
            // 
            this.labelPhone.Location = new System.Drawing.Point(550, 200);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(200, 24);
            this.labelPhone.TabIndex = 4;
            this.labelPhone.Text = "Phone";
            // 
            // labelEmail
            // 
            this.labelEmail.Location = new System.Drawing.Point(550, 240);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(200, 24);
            this.labelEmail.TabIndex = 5;
            this.labelEmail.Text = "Email";
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(50, 400);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 6;
            this.buttonBack.Text = "Back";
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(350, 400);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 7;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(650, 400);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 23);
            this.buttonPrint.TabIndex = 8;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // ConfirmForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelProducts);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.buttonPrint);
            this.Name = "ConfirmForm";
            this.Text = "ConfirmForm";
            this.ResumeLayout(false);

        }
    }
}