using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpms.DataAccess
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class ColumnAttribute: Attribute
    {
        public ColumnAttribute(string name)
        {
            Name = name;
        }
        public string Name
        {
            get;
            set;
        }
    }
    
}
