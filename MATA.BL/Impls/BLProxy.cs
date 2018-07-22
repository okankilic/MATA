using MATA.Data.Repositories.Interfaces;
using MATA.Infrastructure.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Caching;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Impls
{
    public class BLProxy<T> : RealProxy
    {
        private readonly T decorated;

        public BLProxy(T decorated) : base(typeof(T))
        {
            this.decorated = decorated;
        }

        public static T Create(T decorated)
        {
            var blProxy = (T)new BLProxy<T>(decorated).GetTransparentProxy();

            return blProxy;
        }

        public override IMessage Invoke(IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;
            var methodInfo = methodCall.MethodBase as MethodInfo;

            try
            {
                var method = decorated.GetType().GetMethod(methodInfo.Name);

                var authorizeAttribute = method.GetCustomAttribute<CustomAuthorizeAttribute>(true);

                if(authorizeAttribute != null)
                {
                    if(methodCall.InArgCount < 2)
                    {
                        throw new Exception("Invalid parameter count for CustomAuthorizeAttribute");
                    }

                    var tokenString = methodCall.InArgs[methodCall.InArgCount - 2].ToString();
                    var tokenGuid = Guid.Parse(tokenString);
                    var uow = methodCall.InArgs[methodCall.InArgCount - 1] as IUnitOfWork;

                    var accountID = uow.TokenRepository.Find(q => q.TokenString == tokenGuid).Single().AccountID;
                    var account = uow.AccountRepository.GetByID(accountID);

                    if (authorizeAttribute.Roles.Contains(account.RoleName) == false)
                    {
                        throw new AuthorizationException();
                    }
                }

                var cacheAttribute = method.GetCustomAttribute<CustomCacheAttribute>(true);

                if (cacheAttribute != null)
                {
                    string cacheKey = GenerateCacheKey(methodCall, cacheAttribute);

                    var memoryCache = MemoryCache.Default;

                    var cached = memoryCache.Get(cacheKey);

                    if (cached == null)
                    {
                        cached = methodInfo.Invoke(decorated, methodCall.InArgs);

                        memoryCache.Set(cacheKey, cached, new CacheItemPolicy());
                    }

                    return new ReturnMessage(cached, null, 0, methodCall.LogicalCallContext, methodCall);
                }

                var result = methodInfo.Invoke(decorated, methodCall.InArgs);

                return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);

            }
            catch (Exception e)
            {
                return new ReturnMessage(e, methodCall);
            }
        }

        private static string GenerateCacheKey(IMethodCallMessage methodCall, CustomCacheAttribute cacheAttribute)
        {
            string cacheKey = cacheAttribute.CacheName;

            if (methodCall.InArgCount > 0)
            {
                var stringBuilder = new StringBuilder(cacheKey);

                foreach (var inArg in methodCall.InArgs)
                {
                    if(inArg is IUnitOfWork)
                    {
                        continue;
                    }

                    stringBuilder.Append("_");
                    stringBuilder.Append(inArg);
                }

                cacheKey = stringBuilder.ToString();
            }

            return cacheKey;
        }
    }
}
