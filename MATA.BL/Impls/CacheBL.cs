using MATA.BL.Filters;
using MATA.BL.Interfaces;
using System.Collections.Generic;

namespace MATA.BL.Impls
{
    public class CacheBL: ICacheBL
    {
        public IEnumerable<string> GetAll()
        {
            return CacheHelper.GetKeys();
        }

        public void Reset(string cacheKey)
        {
            CacheHelper.Reset(cacheKey);
        }
    }
}
