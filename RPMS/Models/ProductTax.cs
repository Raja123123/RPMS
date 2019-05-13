using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpms.Models
{
    public class ProductTax
    {

        public Guid ID { get; set; }

        public Guid ProductID { get; set; }
        public Guid TaxId { get; set; }

        public string Status { get; set; }

        public DateTime EntryDate { get; set; }
    }
}
