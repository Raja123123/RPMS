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
        public readonly Guid TaxID;

        public readonly TaxController taxController;

        public TaxComponent()
        {
            InitializeComponent();
            taxController = new TaxController();
            Bind();
        }

        private void Bind()
        {
            if (TaxID == Guid.Empty)
            {
                btnSave.Text = "Add";
            }
            grdProducts.DataSource = taxController.GetAllDataTable();
        }
        private void PopulateProduct(Guid ID)
        {
            var tax = taxController.FindById(ID);
           
            txtType.Text = tax.Type;
            txtValue.Text = tax.Value.ToString();
            chkStatus.Checked = tax.Status == "Active";

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

            }
        }

        private void TaxComponent_Load(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            grdProducts.DataSource = taxController.GetSearchDataTable(txtSearch.Text);

        }
    }
}
