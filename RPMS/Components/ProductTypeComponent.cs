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
    public partial class ProductTypeComponent : UserControl
    {
        public Guid ProductTypeID;
        DataTable dtProductType;

        public readonly ProductController productController;

        public readonly ProductTypeController productTypeController;

        public ProductTypeComponent()
        {
            InitializeComponent();
            productTypeController = new ProductTypeController();
            productController = new ProductController();
            Bind();
        }

        private void Bind()
        {
            if (ProductTypeID == Guid.Empty)
            {
                btnSave.Text = "Add";
            }

            var allProducts = productController.All().Where(p => p.Status == "Active").ToList();
            foreach (var product in allProducts)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = $"{product.Name} - {product.SKU}" ;
                item.Value = product.ID;
                comProductType.Items.Add(item);
                comProductType.SelectedIndex = 0;
            }
            grdProducts.DataSource = productTypeController.GetAllDataTable();
        }
        private void PopulateProductType(Guid ID)
        {

            var productType = productTypeController.FindById(ID);
            foreach (ComboboxItem item in comProductType.Items)
            {
                if ((Guid)item.Value == productType.ProductID)
                {
                    comProductType.SelectedItem = item;
                    break;
                }
            }

            txtType.Text = productType.Key;
            txtValue.Text = productType.Value;
            chkStatus.Checked = productType.Status == "Active";

            ProductTypeID = productType.ID;
            btnSave.Text = "Update";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Add")
            {
                var productId = ((ComboboxItem)comProductType.SelectedItem).Value.ToString();
                var productType = new ProductType
                {

                    ID = Guid.NewGuid(),
                    ProductID = Guid.Parse(productId),
                    Key = txtType.Text,
                    Value = txtValue.Text,
                    EntryDate = DateTime.Now,
                    Status = "Active"
                };
                productTypeController.Add(productType);
                MessageBox.Show("ProductType Added Sucessfully");
                grdProducts.DataSource = productTypeController.GetAllDataTable();

            }
            else
            {
                var productId = ((ComboboxItem)comProductType.SelectedItem).Value.ToString();

                var productType = new ProductType
                {

                    ID = ProductTypeID,
                    ProductID = Guid.Parse(productId),
                    Key = txtType.Text,
                    Value = txtValue.Text,
                    EntryDate = DateTime.Now,
                    Status = "Active"
                };
                productTypeController.Update(ProductTypeID, productType);
                grdProducts.DataSource = dtProductType = productTypeController.GetAllDataTable();
                MessageBox.Show("Product Type Updated Sucessfully");
            }
        }

        private void ProductTypeComponent_Load(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            grdProducts.DataSource = productTypeController.GetSearchDataTable(txtSearch.Text);

        }

        private void grdProductsType_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulateProductType(Guid.Parse(grdProducts.SelectedRows[0].Cells[0].Value.ToString()));
        }

        private void ProductTypeSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //grdProducts.DataSource =((DataTable)grdProducts.DataSource).Find(txtSearch.Text);
                grdProducts.DataSource = dtProductType.Find(txtSearch.Text);

            }
        }
    }
}
