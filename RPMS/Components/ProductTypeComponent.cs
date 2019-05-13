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
        public readonly Guid ProductTypeID;

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
        private void PopulateProduct(Guid ID)
        {
            var productType = productTypeController.FindById(ID);
           
           

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Add")
            {
                var productType = new ProductType
                {

                    ID = Guid.NewGuid(),
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

            }
        }

        private void ProductTypeComponent_Load(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            grdProducts.DataSource = productTypeController.GetSearchDataTable(txtSearch.Text);

        }
    }
}
