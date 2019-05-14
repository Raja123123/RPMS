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
    public partial class VendorComponent : UserControl
    {
        public  Guid VendorID;
        DataTable dtProducts;
        public readonly VendorController vendorController;

        public VendorComponent()
        {
            InitializeComponent();
            vendorController = new VendorController();
            Bind();
        }

        private void Bind()
        {
            btnSave.Text = "Add";
            lblTitle.Text = "Add Vendor";
            grdVendor.DataSource = dtProducts = vendorController.GetAllDataTable();
        }
        private void PopulateVendor(Guid ID)
        {
            var vendor = vendorController.FindById(ID);

            txtName.Text = vendor.Name;
            txtAddress.Text = vendor.Address;
            txtMobileNumber.Text = vendor.MobileNumber;
            txtEmail.Text = vendor.Email;
            txtGst.Text = vendor.GST;
            chkStatus.Checked = vendor.Status == "Active";
            VendorID = vendor.ID;

            lblTitle.Text = "Update Vendor";
            btnSave.Text = "Update";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Add")
            {
                var vendor = new Vendor
                {

                    ID = Guid.NewGuid(),
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    MobileNumber = txtMobileNumber.Text,
                    Email = txtEmail.Text,
                    GST = txtGst.Text,
                    EntryDate = DateTime.Now,
                    Status = "Active"
                };
                vendorController.Add(vendor);
                MessageBox.Show("Vendor Added Sucessfully");
                grdVendor.DataSource = vendorController.GetAllDataTable();

            }
            else
            {
                var vendor = new Vendor
                {

                    ID = Guid.NewGuid(),
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    MobileNumber = txtMobileNumber.Text,
                    Email = txtEmail.Text,
                    GST = txtGst.Text,
                    EntryDate = DateTime.Now,
                    Status = "Active"
                };
                vendorController.Update(VendorID, vendor);
                grdVendor.DataSource = dtProducts = vendorController.GetAllDataTable();
                MessageBox.Show("Vendor Updated Sucessfully");
            }
        }

        private void VendorComponent_Load(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //grdProducts.DataSource =((DataTable)grdProducts.DataSource).Find(txtSearch.Text);
                grdVendor.DataSource = dtProducts.Find(txtSearch.Text);

            }
        }

        private void grdProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulateVendor(Guid.Parse(grdVendor.SelectedRows[0].Cells[0].Value.ToString()));

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
