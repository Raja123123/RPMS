using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpms.Models
{
    public class InvoiceSetting
    {
        public bool DisplayContactNo { get; set; } = true;
        public bool DisplaySalesPersonName { get; set; } = true;
        public bool DisplayGST { get; set; } = true;
        public bool DisplayOrgnizationAddress { get; set; } = true;
        public bool DisplayOrgnizationName { get; set; } = true;
        public bool DisplayPrintDate { get; set; } = true;

        public bool DisplayInvoiceDate { get; set; } = true;


    }
}
