using MATA.BL.Impls;
using MATA.BL.Interfaces;
using System;
using System.Reflection;
using System.Runtime.Remoting.Messaging;

namespace MATA.BL.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomCacheResetAttributeAttribute: Attribute, ICacheAttribute
    {
        public string CacheKey { get; set; }

        public IMessage Handle<T>(T decorated, IMethodCallMessage methodCall, MethodInfo methodInfo)
        {
            string cacheKey = CacheHelper.GenerateCacheKey(CacheKey);

            CacheHelper.Reset(cacheKey);

            var cacheObject = methodInfo.Invoke(decorated, methodCall.InArgs);

            return new ReturnMessage(cacheObject, null, 0, methodCall.LogicalCallContext, methodCall);
        }
    }
}
