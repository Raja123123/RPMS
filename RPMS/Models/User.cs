using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpms.Models
{
    public class User
    {
        public Guid ID { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        
    }
}
