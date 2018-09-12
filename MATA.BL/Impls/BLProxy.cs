using MATA.BL.Filters;
using MATA.BL.Interfaces;
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

                if (authorizeAttribute != null)
                {
                    CustomAuthorizeAttribute.Handle(methodCall, authorizeAttribute.Roles);
                }

                var cacheInvalidateAttribute = method.GetCustomAttribute<CustomCacheResetAttributeAttribute>(true);

                if (cacheInvalidateAttribute != null)
                {
                    return cacheInvalidateAttribute.Handle(decorated, methodCall, methodInfo);
                }

                var cacheAttribute = method.GetCustomAttribute<CustomCacheAttribute>(true);

                if (cacheAttribute != null)
                {
                    return cacheAttribute.Handle(decorated, methodCall, methodInfo);
                }

                var result = methodInfo.Invoke(decorated, methodCall.InArgs);

                return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);

            }
            catch (Exception e)
            {
                return new ReturnMessage(e, methodCall);
            }
        }
    }
}
