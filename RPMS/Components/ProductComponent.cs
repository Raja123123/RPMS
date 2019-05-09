using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rpms.Models;
using Rpms.Controllers;

namespace Rpms.Components
{
    public partial class ProductComponent : UserControl
    {
        public readonly Guid ProductID;

        public readonly ProductController productController;

        public ProductComponent()
        {
            InitializeComponent();
            productController = new ProductController();
            Bind();
        }

        private void Bind() {
            if (ProductID == Guid.Empty)
            {
                btnSave.Text = "Add";
            }
            grdProducts.DataSource = productController.GetAllDataTable();
        }
        private void PopulateProduct(Guid ID)
        {
            var product = productController.FindById(ID);
            txtName.Text = product.Name;
            txtSku.Text = product.SKU;
            txtDesc.Text = product.Description;
            chkStatus.Checked = product.Status == "Active" ;

        }

       


        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Add")
            {
                var product = new Product
                {
                    ID = Guid.NewGuid(),
                    Code = txtCode.Text,
                    Description = txtDesc.Text,
                    Name = txtName.Text,
                    SKU = txtSku.Text,
                    EntryDate = DateTime.Now,
                    Status = "Active"
                };
                productController.Add(product);
                MessageBox.Show("Product Added Sucessfully");
                grdProducts.DataSource = productController.GetAllDataTable();

            }
            else {

            }
        }

      

        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //grdProducts.DataSource =((DataTable)grdProducts.DataSource).Find(txtSearch.Text);
                grdProducts.DataSource = productController.GetAllDataTable().Find(txtSearch.Text);
                
            }
        }
    }
}
