using MATA.BL.Impls;
using MATA.BL.Interfaces;
using System;
using System.Reflection;
using System.Runtime.Remoting.Messaging;

namespace MATA.BL.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomCacheAttribute : Attribute, ICacheAttribute
    {
        public string CacheKey { get; set; }

        public IMessage Handle<T>(T decorated, IMethodCallMessage methodCall, MethodInfo methodInfo)
        {
            string cacheKey = CacheHelper.GenerateCacheKey(CacheKey, methodCall.MethodName, methodCall.InArgs);

            var cacheObject = CacheHelper.Get(cacheKey);

            if (cacheObject == null)
            {
                cacheObject = methodInfo.Invoke(decorated, methodCall.InArgs);

                CacheHelper.Set(cacheKey, cacheObject);
            }

            return new ReturnMessage(cacheObject, null, 0, methodCall.LogicalCallContext, methodCall);
        }
    }
}
