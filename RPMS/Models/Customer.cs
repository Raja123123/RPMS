using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpms.Models
{
    public class Customer
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Adderss { get; set; }
        public string Status { get; set; }

    }
}
