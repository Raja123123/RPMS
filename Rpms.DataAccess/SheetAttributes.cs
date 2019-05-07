using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpms.DataAccess
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class SheetAttribute: Attribute
    {
        public SheetAttribute(string name)
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
