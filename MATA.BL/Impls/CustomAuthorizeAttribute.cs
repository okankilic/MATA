using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Impls
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomAuthorizeAttribute: Attribute
    {
        public string Roles { get; set; }
    }
}
