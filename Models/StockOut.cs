using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpms.Models
{
    
    public class StockOut
    {
        public Guid ID { get; set; }
        public Guid ProductID { get; set; }
        public Guid InvoiceID { get; set; }
    }
}
