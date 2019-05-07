using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpms.Models
{
    public class DiscountCode
    {
        public Guid ID { get; set; }

        public string Code { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime TillDate { get; set; }

        public string Status { get; set; }

    }
}
