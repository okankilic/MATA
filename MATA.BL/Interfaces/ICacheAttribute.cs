using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Interfaces
{
    public interface ICacheAttribute
    {
        string CacheKey { get; set; }
    }
}
