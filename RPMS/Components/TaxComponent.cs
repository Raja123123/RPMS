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
    public partial class TaxComponent : UserControl
    {
        public  Guid TaxID;
        DataTable dtProducts;
        public readonly TaxController taxController;

        public TaxComponent()
        {
            InitializeComponent();
            taxController = new TaxController();
            Bind();
        }

        private void Bind()
        {
            btnSave.Text = "Add";
            lblTitle.Text = "Add Tax";
            grdProducts.DataSource = dtProducts = taxController.GetAllDataTable();
        }
        private void PopulateTax(Guid ID)
        {
            var tax = taxController.FindById(ID);

            txtType.Text = tax.Type;
            txtValue.Text = tax.Value.ToString();
            chkStatus.Checked = tax.Status == "Active";
            TaxID = tax.ID;

            lblTitle.Text = "Update Tax";
            btnSave.Text = "Update";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Add")
            {
                var tax = new Tax
                {

                    ID = Guid.NewGuid(),
                    Type = txtType.Text,
                    Value = Decimal.Parse(txtValue.Text),
                    EntryDate = DateTime.Now,
                    Status = "Active"
                };
                taxController.Add(tax);
                MessageBox.Show("Tax Added Sucessfully");
                grdProducts.DataSource = taxController.GetAllDataTable();

            }
            else
            {
                var tax = new Tax
                {

                    ID = Guid.NewGuid(),
                    Type = txtType.Text,
                    Value = Decimal.Parse(txtValue.Text),
                    EntryDate = DateTime.Now,
                    Status = "Active"
                };
                taxController.Update(TaxID, tax);
                grdProducts.DataSource = dtProducts = taxController.GetAllDataTable();
                MessageBox.Show("Tax Updated Sucessfully");
            }
        }

        private void TaxComponent_Load(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //grdProducts.DataSource =((DataTable)grdProducts.DataSource).Find(txtSearch.Text);
                grdProducts.DataSource = dtProducts.Find(txtSearch.Text);

            }
        }

        private void grdProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulateTax(Guid.Parse(grdProducts.SelectedRows[0].Cells[0].Value.ToString()));

        }
    }
}
