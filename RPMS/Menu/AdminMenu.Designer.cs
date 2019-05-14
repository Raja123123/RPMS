namespace Rpms.Components.Menu
{
    partial class AdminMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnTax = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.btnVendor = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_StockIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProduct
            // 
            this.btnProduct.Location = new System.Drawing.Point(14, 42);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(131, 23);
            this.btnProduct.TabIndex = 0;
            this.btnProduct.Text = "Product";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.BtnProduct_Click);
            // 
            // btnTax
            // 
            this.btnTax.Location = new System.Drawing.Point(14, 13);
            this.btnTax.Name = "btnTax";
            this.btnTax.Size = new System.Drawing.Size(131, 23);
            this.btnTax.TabIndex = 1;
            this.btnTax.Text = "Tax";
            this.btnTax.UseVisualStyleBackColor = true;
            this.btnTax.Click += new System.EventHandler(this.btnTax_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(14, 158);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Product Type";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnDiscount
            // 
            this.btnDiscount.Location = new System.Drawing.Point(14, 71);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(131, 23);
            this.btnDiscount.TabIndex = 3;
            this.btnDiscount.Text = "Discount";
            this.btnDiscount.UseVisualStyleBackColor = true;
            this.btnDiscount.Click += new System.EventHandler(this.btnDiscount_Click);
            // 
            // btnVendor
            // 
            this.btnVendor.Location = new System.Drawing.Point(14, 100);
            this.btnVendor.Name = "btnVendor";
            this.btnVendor.Size = new System.Drawing.Size(131, 23);
            this.btnVendor.TabIndex = 4;
            this.btnVendor.Text = "Vendor";
            this.btnVendor.UseVisualStyleBackColor = true;
            this.btnVendor.Click += new System.EventHandler(this.btnVendor_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 129);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Orgnization";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btn_StockIn
            // 
            this.btn_StockIn.Location = new System.Drawing.Point(14, 187);
            this.btn_StockIn.Name = "btn_StockIn";
            this.btn_StockIn.Size = new System.Drawing.Size(131, 23);
            this.btn_StockIn.TabIndex = 6;
            this.btn_StockIn.Text = "StockIn";
            this.btn_StockIn.UseVisualStyleBackColor = true;
            this.btn_StockIn.Click += new System.EventHandler(this.btn_StockIn_Click);
            // 
            // AdminMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_StockIn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnVendor);
            this.Controls.Add(this.btnDiscount);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnTax);
            this.Controls.Add(this.btnProduct);
            this.Name = "AdminMenu";
            this.Size = new System.Drawing.Size(160, 323);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnTax;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.Button btnVendor;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_StockIn;
    }
}
