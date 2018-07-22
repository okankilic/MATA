using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Impls
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomCacheAttribute : Attribute
    {
        public string CacheName { get; set; }
    }
}
