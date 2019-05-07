using Rpms.DataAccess;
using System;

namespace Rpms.Models
{
    [Sheet("Products")]
    public class Product
    {
        
        [Column("Id")]
        public Guid ID { get; set; }
        [Column("Product Name")]
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Code { get; set; }
        public string  Description { get; set; }
        public string Status { get; set; }

    }
}
