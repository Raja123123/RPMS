using System.Collections.Generic;

namespace Rpms.Models
{
    public class InvoicePrint
    {
        public Orgnization Orgnization { get; set; }
        public Invoice Invoice { get; set; }
        public Customer Customer { get; set; }
        public User User { get; set; }
        public List<InvoiceProduct> InvoiceProducts { get; set; }

        public InvoiceSetting InvoiceSetting { get; set; }

    }
}
