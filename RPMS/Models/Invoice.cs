using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpms.Models
{
    
    public class Invoice
    {
        public Guid ID { get; set; }
        public string Number { get; set; }
        public Guid CustomerID { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public Guid DiscountCode { get; set; }
        public Decimal DiscountCodeAmount { get; set; }
        public Decimal TotalDiscount { get; set; }

    }
}
