﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpms.Models
{
    public class Tax
    {
        public Guid ID { get; set; }

        public string Type { get; set; }

        public decimal Value { get; set; }

        public string Status { get; set; }
    }
}
