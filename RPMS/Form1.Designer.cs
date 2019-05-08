namespace Rpms
{
    partial class Form1
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlModule = new System.Windows.Forms.Panel();
            this.adminMenu1 = new Rpms.Components.Menu.AdminMenu();
            this.lblModuleTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(192, 74);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.82482F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.17519F));
            this.tableLayoutPanel1.Controls.Add(this.pnlModule, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.adminMenu1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblModuleTitle, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.393586F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.60641F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1370, 686);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pnlModule
            // 
            this.pnlModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlModule.Location = new System.Drawing.Point(165, 40);
            this.pnlModule.Name = "pnlModule";
            this.pnlModule.Size = new System.Drawing.Size(1202, 643);
            this.pnlModule.TabIndex = 1;
            // 
            // adminMenu1
            // 
            this.adminMenu1.Location = new System.Drawing.Point(3, 40);
            this.adminMenu1.Name = "adminMenu1";
            this.adminMenu1.Size = new System.Drawing.Size(156, 191);
            this.adminMenu1.TabIndex = 2;
            // 
            // lblModuleTitle
            // 
            this.lblModuleTitle.AutoSize = true;
            this.lblModuleTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModuleTitle.Location = new System.Drawing.Point(165, 0);
            this.lblModuleTitle.Name = "lblModuleTitle";
            this.lblModuleTitle.Size = new System.Drawing.Size(64, 25);
            this.lblModuleTitle.TabIndex = 0;
            this.lblModuleTitle.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 686);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

         private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblModuleTitle;
        private System.Windows.Forms.Panel pnlModule;
        private Components.Menu.AdminMenu adminMenu1;
    }
}

