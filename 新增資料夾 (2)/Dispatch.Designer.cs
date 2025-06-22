
namespace afterservice
{
    partial class Dispatch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_shoppingcart = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel_product = new System.Windows.Forms.FlowLayoutPanel();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_shoppingcart)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1105, 42);
            this.label6.TabIndex = 14;
            this.label6.Text = "Make Order";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(879, 588);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 39;
            this.label1.Text = "Total";
            // 
            // dataGridView_shoppingcart
            // 
            this.dataGridView_shoppingcart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_shoppingcart.Location = new System.Drawing.Point(523, 45);
            this.dataGridView_shoppingcart.Name = "dataGridView_shoppingcart";
            this.dataGridView_shoppingcart.RowTemplate.Height = 24;
            this.dataGridView_shoppingcart.Size = new System.Drawing.Size(576, 528);
            this.dataGridView_shoppingcart.TabIndex = 38;
            // 
            // flowLayoutPanel_product
            // 
            this.flowLayoutPanel_product.Location = new System.Drawing.Point(4, 45);
            this.flowLayoutPanel_product.Name = "flowLayoutPanel_product";
            this.flowLayoutPanel_product.Size = new System.Drawing.Size(513, 528);
            this.flowLayoutPanel_product.TabIndex = 37;
            // 
            // button_clear
            // 
            this.button_clear.BackColor = System.Drawing.Color.Fuchsia;
            this.button_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_clear.ForeColor = System.Drawing.Color.White;
            this.button_clear.Location = new System.Drawing.Point(943, 579);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 21);
            this.button_clear.TabIndex = 36;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = false;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click_1);
            // 
            // button_back
            // 
            this.button_back.BackColor = System.Drawing.Color.Red;
            this.button_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_back.ForeColor = System.Drawing.Color.White;
            this.button_back.Location = new System.Drawing.Point(12, 579);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(75, 21);
            this.button_back.TabIndex = 35;
            this.button_back.Text = "Back";
            this.button_back.UseVisualStyleBackColor = false;
            this.button_back.Click += new System.EventHandler(this.button_back_Click_1);
            // 
            // button_add
            // 
            this.button_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.button_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_add.ForeColor = System.Drawing.Color.White;
            this.button_add.Location = new System.Drawing.Point(1024, 579);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 21);
            this.button_add.TabIndex = 34;
            this.button_add.Text = "Confirm";
            this.button_add.UseVisualStyleBackColor = false;
            this.button_add.Click += new System.EventHandler(this.button_add_Click_1);
            // 
            // Dispatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 612);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_shoppingcart);
            this.Controls.Add(this.flowLayoutPanel_product);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.label6);
            this.Name = "Dispatch";
            this.Text = "Dispatch";
            this.Load += new System.EventHandler(this.Dispatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_shoppingcart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_shoppingcart;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_product;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Button button_add;
    }
}