namespace Rpms.Components
{
    partial class ProductTaxForm
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
            this.comboTax = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddProductTax = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboTax
            // 
            this.comboTax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTax.FormattingEnabled = true;
            this.comboTax.Location = new System.Drawing.Point(43, 25);
            this.comboTax.Name = "comboTax";
            this.comboTax.Size = new System.Drawing.Size(257, 21);
            this.comboTax.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tax";
            // 
            // btnAddProductTax
            // 
            this.btnAddProductTax.Location = new System.Drawing.Point(43, 60);
            this.btnAddProductTax.Name = "btnAddProductTax";
            this.btnAddProductTax.Size = new System.Drawing.Size(75, 23);
            this.btnAddProductTax.TabIndex = 2;
            this.btnAddProductTax.Text = "Save";
            this.btnAddProductTax.UseVisualStyleBackColor = true;
            this.btnAddProductTax.Click += new System.EventHandler(this.BtnAddProductTax_Click);
            // 
            // ProductTaxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 95);
            this.Controls.Add(this.btnAddProductTax);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboTax);
            this.Name = "ProductTaxForm";
            this.Text = "ProductTaxForm";
            this.Load += new System.EventHandler(this.ProductTaxForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboTax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddProductTax;
    }
}