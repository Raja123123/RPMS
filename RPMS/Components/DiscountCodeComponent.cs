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
    public partial class DiscountCodeComponent : UserControl
    {
        public readonly Guid DiscountCodeID;
        DataTable dtDiscountCode;

        public readonly DiscountCodeController discountcodeController;

        public DiscountCodeComponent()
        {
            InitializeComponent();
            discountcodeController = new DiscountCodeController();
            Bind();
        }

        private void Bind()
        {
            if (DiscountCodeID == Guid.Empty)
            {
                btnSave.Text = "Add";
            }
            grdDiscountCode.DataSource = discountcodeController.GetAllDataTable();
        }
        private void PopulateDiscountCode(Guid ID)
        {
            var discountcode = discountcodeController.FindById(ID);

            txtCode.Text = discountcode.Code;
            dateTimeFromDate.Text = discountcode.FromDate.ToString();
            dateTimeTillDate.Text = discountcode.TillDate.ToString();
            chkStatus.Checked = discountcode.Status == "Active";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Add")
            {
                var discountcode = new DiscountCode
                {

                    ID = Guid.NewGuid(),
                    Code = txtCode.Text,
                    FromDate = Convert.ToDateTime(dateTimeFromDate.Text),
                    TillDate = Convert.ToDateTime(dateTimeTillDate.Text),
                    EntryDate = DateTime.Now,
                    Status = "Active"
                };
                discountcodeController.Add(discountcode);
                MessageBox.Show("DiscountCode Added Sucessfully");
                grdDiscountCode.DataSource = discountcodeController.GetAllDataTable();

            }
            else
            {

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            grdDiscountCode.DataSource = discountcodeController.GetSearchDataTable(txtSearch.Text);

        }

        private void DiscountCodeComponent_Load(object sender, EventArgs e)
        {

        }

        private void DiscountCodeSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                grdDiscountCode.DataSource = dtDiscountCode.Find(txtSearch.Text);

            }
        }

        private void grdDiscountCode_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulateDiscountCode(Guid.Parse(grdDiscountCode.SelectedRows[0].Cells[0].Value.ToString()));
        }
    }
}
