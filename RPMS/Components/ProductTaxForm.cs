using Rpms.Controllers;
using Rpms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rpms.Components
{
    public partial class ProductTaxForm : Form
    {
        Product _product;
        ProductTaxController productTaxController;
        TaxController taxController;
        ProductComponent _productComponent;

        public ProductTaxForm(Product product, ProductComponent productComponent)
        {
            InitializeComponent();
            _product = product;
            productTaxController = new ProductTaxController();
            taxController = new TaxController();
            _productComponent = productComponent;
        }

        private void ProductTaxForm_Load(object sender, EventArgs e)
        {
            this.Text = _product.Name + " - " + _product.Code;
            var allTaxes = taxController.All().Where(t => t.Status == "Active");
            foreach (var tax in allTaxes)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = $"{tax.Type} - {tax.Value}";
                item.Value = tax.ID;
                comboTax.Items.Add(item);
                comboTax.SelectedIndex = 0;
            }


        }

        private void BtnAddProductTax_Click(object sender, EventArgs e)
        {
            var productType = new ProductTax
            {

                ID = Guid.NewGuid(),
                ProductID = _product.ID,
                TaxId = (Guid)((ComboboxItem)comboTax.SelectedItem).Value,
                EntryDate = DateTime.Now,
                Status = "Active"
            };
            productTaxController.Add(productType);
            MessageBox.Show("Product Tax Added Sucessfully");
            this.Close();
            _productComponent.PopulateProduct(_product.ID);
        }
    }
}
