using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpms.Models
{
    public class Note
    {
        public Guid ID { get; set; }
        public string TypeID { get; set; }
        public string TypeValue { get; set; }
    }
}
