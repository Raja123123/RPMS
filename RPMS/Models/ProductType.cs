using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpms.Models
{
    public class ProductType
    {
        public Guid ID { get; set; }
        public Guid ProductID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Status { get; set; }


    }
}
