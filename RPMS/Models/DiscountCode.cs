using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rpms.DataAccess;

namespace Rpms.Models
{
    [Sheet("DiscountCode")]
    public class DiscountCode
    {
        public Guid ID { get; set; }

        public string Code { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime TillDate { get; set; }

        public string Status { get; set; }

        public DateTime EntryDate { get; set; }

    }
}
