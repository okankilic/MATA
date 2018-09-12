using System;
using MATA.BL.Impls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CacheAttributeTests
{
    [TestClass]
    public class CacheHelperTests
    {
        [TestMethod]
        public void GenerateCacheKeyTest1()
        {
            string cacheKey = "TestCache";

            var generatedCacheKey = CacheHelper.GenerateCacheKey(cacheKey);

            Assert.AreEqual("MATA::" + cacheKey, generatedCacheKey);
        }

        [TestMethod]
        public void GenerateCacheKeyTest2()
        {
            string cacheKey = "TestCache";

            var arg1 = 1;
            var arg2 = 2;

            var generatedCacheKey = CacheHelper.GenerateCacheKey(cacheKey, arg1, arg2);

            var expected = string.Join("_", "MATA::" + cacheKey, arg1, arg2);

            Assert.AreEqual(expected, generatedCacheKey);
        }

        [TestMethod]
        public void GenerateCacheKeyTest3()
        {
            string cacheKey = "TestCache";

            var arg1 = 1;
            var arg2 = 2;
            var arg3 = new int[] { 3, 4 };

            var generatedCacheKey = CacheHelper.GenerateCacheKey(cacheKey, arg1, arg2, arg3);

            var expected = string.Join("_", "MATA::" + cacheKey, arg1, arg2, string.Join("_", arg3));

            Assert.AreEqual(expected, generatedCacheKey);
        }
    }
}
