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
    public partial class StockInComponent : UserControl
    {
        public  Guid StockInID;
        DataTable dtProducts;
        public readonly StockInController stockInController;

        public StockInComponent()
        {
            InitializeComponent();
            stockInController = new StockInController();
            Bind();
        }

        private void Bind()
        {
            btnSave.Text = "Add";
            lblTitle.Text = "Add StockIn";
            grdStockIn.DataSource = dtProducts = stockInController.GetAllDataTable();
        }
        private void PopulateStockIn(Guid ID)
        {
            var stockIn = stockInController.FindById(ID);

            txtQuantity.Text = stockIn.Quantity.ToString();
            //txtVendorid.Text = stockIn.VendorID;
            txtMRP.Text = stockIn.MRP.ToString();
            txtCostPrice.Text = stockIn.CostPrice.ToString();
            dateTimePickerStockin.Text = stockIn.Date.ToString();
            chkStatus.Checked = stockIn.Status == "Active";
            StockInID = stockIn.ID;

            lblTitle.Text = "Update StockIn";
            btnSave.Text = "Update";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Add")
            {
                var stockIn = new StockIn
                {

                    ID = Guid.NewGuid(),
                    Quantity =Convert.ToInt32(txtQuantity.Text),
                    MRP =Decimal.Parse(txtVendorid.Text),
                    CostPrice = Decimal.Parse(txtMRP.Text),
                    Date =Convert.ToDateTime(dateTimePickerStockin.Text),
                    EntryDate = DateTime.Now,
                    Status = "Active"
                };
                stockInController.Add(stockIn);
                MessageBox.Show("StockIn Added Sucessfully");
                grdStockIn.DataSource = stockInController.GetAllDataTable();

            }
            else
            {
                var stockIn = new StockIn
                {

                    ID = Guid.NewGuid(),
                    Quantity = Convert.ToInt32(txtQuantity.Text),
                    MRP = Decimal.Parse(txtVendorid.Text),
                    CostPrice = Decimal.Parse(txtMRP.Text),
                    Date = Convert.ToDateTime(dateTimePickerStockin.Text),
                    EntryDate = DateTime.Now,
                    Status = "Active"
                };
                stockInController.Update(StockInID, stockIn);
                grdStockIn.DataSource = dtProducts = stockInController.GetAllDataTable();
                MessageBox.Show("StockIn Updated Sucessfully");
            }
        }

        private void StockInComponent_Load(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //grdProducts.DataSource =((DataTable)grdProducts.DataSource).Find(txtSearch.Text);
                grdStockIn.DataSource = dtProducts.Find(txtSearch.Text);

            }
        }

        private void grdProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulateStockIn(Guid.Parse(grdStockIn.SelectedRows[0].Cells[0].Value.ToString()));

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
