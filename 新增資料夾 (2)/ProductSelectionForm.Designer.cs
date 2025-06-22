
namespace afterservice
{
    partial class ProductSelectionForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelProductSelection = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.buttonBack = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.labelProductSelection);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 106);
            this.panel1.TabIndex = 43;
            // 
            // labelProductSelection
            // 
            this.labelProductSelection.AutoSize = true;
            this.labelProductSelection.Font = new System.Drawing.Font("PMingLiU", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelProductSelection.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelProductSelection.Location = new System.Drawing.Point(308, 44);
            this.labelProductSelection.Name = "labelProductSelection";
            this.labelProductSelection.Size = new System.Drawing.Size(161, 21);
            this.labelProductSelection.TabIndex = 0;
            this.labelProductSelection.Text = "ProductSelection";
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(300, 412);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 25);
            this.buttonNext.TabIndex = 42;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Location = new System.Drawing.Point(60, 114);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.Size = new System.Drawing.Size(541, 193);
            this.dataGridViewProducts.TabIndex = 40;
            this.dataGridViewProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProducts_CellContentClick);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(60, 412);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 25);
            this.buttonBack.TabIndex = 49;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // ProductSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 478);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.dataGridViewProducts);
            this.Name = "ProductSelectionForm";
            this.Text = "ProductSelectionForm";
            this.Load += new System.EventHandler(this.ProductSelectionForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelProductSelection;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.Button buttonBack;
    }
}