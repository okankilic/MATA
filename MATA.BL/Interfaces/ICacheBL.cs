using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Interfaces
{
    public interface ICacheBL
    {
        IEnumerable<string> GetAll();

        void Reset(string cacheKey);
    }
}
