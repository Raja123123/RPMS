using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpms.Models
{
    public class InvoiceProduct
    {
        public Guid ID { get; set; }

        public Guid ProductID { get; set; }
        public decimal Quantity { get; set; }
        public decimal Mrp { get; set; }
        public decimal Discount { get; set; }
        public Guid DiscountCode { get; set; }

    }
}
