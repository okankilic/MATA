using MATA.Data.DTO.Models;
using MATA.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;

namespace MATA.BL.Impls
{
    public static class CacheHelper
    {
        const string RegionName = "MATA";

        public static string GenerateCacheKey(string cacheKey, params object[] args)
        {
            var stringBuilder = new StringBuilder(RegionName);

            stringBuilder.Append("::");
            stringBuilder.Append(cacheKey);

            foreach (var arg in args)
            {
                if (arg is IUnitOfWork
                    || arg is AccountDTO
                    || arg is CountryDTO
                    || arg is CityDTO
                    || arg is ProjectDTO
                    || arg is StoreDTO
                    || arg is IssueDTO)
                {
                    continue;
                }

                if (arg is Array)
                {
                    var subArgs = arg as Array;

                    foreach (var subArg in subArgs)
                    {
                        if (subArg is IUnitOfWork
                    || subArg is AccountDTO
                    || subArg is CountryDTO
                    || subArg is CityDTO
                    || subArg is ProjectDTO
                    || subArg is StoreDTO
                    || subArg is IssueDTO)
                        {
                            continue;
                        }

                        stringBuilder.Append("_");
                        stringBuilder.Append(subArg);
                    }
                }
                else
                {
                    stringBuilder.Append("_");
                    stringBuilder.Append(arg);
                }
            }

            return stringBuilder.ToString();
        }

        internal static void Reset(string cacheKey)
        {
            var memoryCache = MemoryCache.Default;

            var keys = memoryCache.Where(q => q.Key.StartsWith(cacheKey)).Select(q => q.Key);

            foreach (var key in keys)
            {
                memoryCache.Remove(key);
            }
        }

        public static IEnumerable<string> GetKeys()
        {
            return MemoryCache.Default.Where(q => q.Key.StartsWith(RegionName)).OrderBy(q => q.Key).Select(q => q.Key);
        }

        public static object Get(string cacheKey)
        {
            return MemoryCache.Default.Get(cacheKey);
        }

        public static void Set(string cacheKey, object cacheObject)
        {
            var policy = new CacheItemPolicy();

            MemoryCache.Default.Set(cacheKey, cacheObject, policy);
        }

        //public static void Invalidate(string cacheKey, object cacheObject)
        //{
        //    var cached = Get(cacheKey);

        //    if(cached != null)
        //    {
        //        MemoryCache.Default.Remove(cacheKey);
        //    }

        //    Set(cacheKey, cacheObject);
        //}
    }
}