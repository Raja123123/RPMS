using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rpms.Demo
{
    public partial class ProductTax : UserControl
    {
        public ProductTax()
        {
            InitializeComponent();
        }

        private void ProductTax_Load(object sender, EventArgs e)
        {
            List<TextBox> textBoxList = new List<TextBox>();

            for (int index = 0; index < 10; index++)
            {
                var textBox = new TextBox();
                textBoxList.Add(textBox);

                this.Controls.Add(textBox);

                // do the rest of work.
            }
        }
    }
}
