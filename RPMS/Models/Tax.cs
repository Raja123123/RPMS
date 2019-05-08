using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rpms.DataAccess;

namespace Rpms.Models
{
    [Sheet("Tax")]
    public class Tax
    {
        [Column("Id")]
        public Guid ID { get; set; }

        public string Type { get; set; }

        public decimal Value { get; set; }

        public string Status { get; set; }

        public DateTime EntryDate { get; set; }
    }
}
