using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rpms.Components.Menu
{
    public partial class AdminMenu : UserControl
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void BtnProduct_Click(object sender, EventArgs e)
        {
            PopulateModule("Product");
        }

        private void PopulateModule(string moduleName) {
            //remove all control
            var pnlModule = this.Parent.Controls.Find("pnlModule", true).FirstOrDefault();
            foreach (Control item in pnlModule.Controls.OfType<Control>())
            {
                pnlModule.Controls.Remove(item);
            }

            string title= string.Empty;
            switch (moduleName)
            {
                case "Product":
                    var productComponent = new ProductComponent();
                    pnlModule.Controls.Add(productComponent);
                    break;
                case "Tax":
                    var taxComponent = new TaxComponent();
                    pnlModule.Controls.Add(taxComponent);
                    break;
                default:
                    break;
            }


            var lblTitle = (Label)Parent.Controls.Find("lblModuleTitle", true).FirstOrDefault();
            lblTitle.Text = string.IsNullOrEmpty(title) ? moduleName : title ;
        }

        private void btnTax_Click(object sender, EventArgs e)
        {
            PopulateModule("Tax");
        }
    }
}
