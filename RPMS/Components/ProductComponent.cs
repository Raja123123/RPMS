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
        public Guid ProductID;

        public readonly ProductController productController;
        public readonly ProductTaxController productTaxController;
        public readonly TaxController taxController;


        DataTable dtProducts;
        public ProductComponent()
        {
            InitializeComponent();
            productController = new ProductController();
            productTaxController = new ProductTaxController();
            taxController =  new TaxController();
            Bind();
        }

        private void Bind() {
            btnSave.Text = "Add";
            lblTitle.Text = "Add Product";
            grdProducts.DataSource = dtProducts =  productController.GetAllDataTable();
            pnlTax.Visible = false;

        }
        public void PopulateProduct(Guid ID)
        {
            var product = productController.FindById(ID);
            txtName.Text = product.Name;
            txtSku.Text = product.SKU;
            txtCode.Text = product.Code;
            txtDesc.Text = product.Description;
            chkStatus.Checked = product.Status == "Active" ;
            ProductID = product.ID;

            lblTitle.Text = "Update Product";
            btnSave.Text = "Update";

            pnlTax.Visible = true;


            var allProductTax = productTaxController.All().Where(t => t.ProductID == ID && t.Status == "Active").ToList();
            var allTax = taxController.All();

            DataTable dt = new DataTable();
            dt.Columns.Add("ProductTaxID", typeof(Guid));
            dt.Columns.Add("Tax");

            foreach (var productTax in allProductTax)
            {
                DataRow tax = dt.NewRow();
                tax["ProductTaxID"] = productTax.ID;
                tax["Tax"] = allTax.Where(t => t.ID == productTax.TaxId).Select(t => $"{t.Type} - {t.Value}%").FirstOrDefault();
                dt.Rows.Add(tax);
            }

            grdTax.DataSource = dt;
            grdTax.Columns[0].Visible = false;
            btnDeleteTax.Visible = false;
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
                grdProducts.DataSource = dtProducts = productController.GetAllDataTable();
                MessageBox.Show("Product Added Sucessfully");


            }
            else {
                var product = new Product
                {
                    ID = ProductID,
                    Code = txtCode.Text,
                    Description = txtDesc.Text,
                    Name = txtName.Text,
                    SKU = txtSku.Text,
                    EntryDate = DateTime.Now,
                    Status = "Active"
                };
                productController.Update(ProductID, product);
                grdProducts.DataSource = dtProducts = productController.GetAllDataTable();
                MessageBox.Show("Product Updated Sucessfully");
            }
        }

      

        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //grdProducts.DataSource =((DataTable)grdProducts.DataSource).Find(txtSearch.Text);
                grdProducts.DataSource = dtProducts.Find(txtSearch.Text);
                
            }
        }

        private void GrdProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           PopulateProduct(Guid.Parse(grdProducts.SelectedRows[0].Cells[0].Value.ToString()));
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnAddtax_Click(object sender, EventArgs e)
        {
            ProductTaxForm productTaxForm = new ProductTaxForm(productController.FindById(ProductID), this);
            productTaxForm.Show();
        }

        private void BtnDeleteTax_Click(object sender, EventArgs e)
        {
            var productTaxID = Guid.Parse(grdTax.SelectedRows[0].Cells[0].Value.ToString());
            productTaxController.Delete(productTaxID);
            MessageBox.Show("Product Tax Deleted Sucessfully");
            PopulateProduct(ProductID);
        }

        private void GrdTax_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            btnDeleteTax.Visible = true;
        }
    }
}
