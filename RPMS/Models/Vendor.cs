using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpms.Models
{
    public class Vendor
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public DateTime EntryDate { get; set; }

        public string Status { get; set; }
    }
}
